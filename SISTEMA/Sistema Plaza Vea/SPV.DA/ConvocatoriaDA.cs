using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class ConvocatoriaDA
    {
        private String querySQL;
        private ConvocatoriaBE oConvocatoriaBE;
        private List<ConvocatoriaBE> lConvocatoria;
        private DataBaseDA cn = new DataBaseDA();

        public List<ConvocatoriaBE> ListarConvocatoriaVigente(){
            querySQL = "SELECT CCONVOCATORIACOD FROM GRH_CONVOCATORIA WHERE CESTADO = 'REVISION'";
            lConvocatoria = new List<ConvocatoriaBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                DateTime oset =new DateTime();
                while (rd.Read())
                {
                    oConvocatoriaBE = new ConvocatoriaBE(rd.GetString(0),
                                                       null,
                                                       oset,
                                                       oset,
                                                       null,
                                                       null,
                                                       oset
                                                        );
                    lConvocatoria.Add(oConvocatoriaBE);
                }
                rd.Close();
            }
            catch (Exception)
            {
                lConvocatoria = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }

            return lConvocatoria;
        }

        public Int32 ObtenerCantidadConvocatoria(String p_CodigoConvocatoria) {
            Int32 cantidad = 0;
            querySQL = "SELECT SOL.NCANTIDADSOLICITADA FROM GRH_CONVOCATORIA CON " +
                        "INNER JOIN GRH_SOLICITUDPERFIL SOL ON SOL.NSOLICITUDPERSONALCOD = CON.NSOLICITUDPERSONALCOD "	+
                        "WHERE CON.CCONVOCATORIACOD = @CCONVOCATORIACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CCONVOCATORIACOD", p_CodigoConvocatoria);
            try {
                cmd.Connection.Open();
                cantidad = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception) {
                cantidad = 0;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return cantidad;
        }
   
        public Boolean RegistrarGanadorConvocatoria(String p_CodigoPostulante){
            Boolean registrar = false;
            querySQL = "UPDATE GRH_POSTULANTE SET NESTADO = 1 WHERE CPOSTULANTECOD = @CPOSTULANTECOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CPOSTULANTECOD", p_CodigoPostulante);
            try {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                registrar = true;
            }
            catch (Exception) {
                registrar = false;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return registrar;
        }

        public Boolean CerrarConvocatoria(String p_CodigoConvocatoria)
        {
            Boolean cerrar = false;
            querySQL = "UPDATE GRH_CONVOCATORIA SET CESTADO = 'CERRADA' WHERE CCONVOCATORIACOD=@CCONVOCATORIACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CCONVOCATORIACOD", p_CodigoConvocatoria);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cerrar = true;
            }
            catch (Exception)
            {
                cerrar = false;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return cerrar;
        }

    }
}
