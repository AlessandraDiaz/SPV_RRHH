using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class PerfilDA
    {
        private PerfilBE oPerfil;
        private DataBaseDA cn = new DataBaseDA();
        private String querySQL;

        private String qSQL;
        DataBaseDA dbRRHH;

        public List<PerfilBE> ListarPerfil(PerfilBE perfil)
        {
            dbRRHH = new DataBaseDA();
            List<PerfilBE> lista = new List<PerfilBE>();
            try
            {
                qSQL = "SPS_PERFIL";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", perfil.Perfil);
                    cmd.Parameters.AddWithValue("@CODIGO", perfil.CodPerfil);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PerfilBE item = new PerfilBE();
                        item.CodPerfil = (Int32)rd[0];
                        item.Perfil = rd[1].ToString() != "" ? (String)rd[1] : "";
                        item.DescripcionPerfil = rd[2].ToString() != "" ? (String)rd[2] : "";
                        item.EstadoPerfil = (Int32)rd[3];

                        lista.Add(item);
                    }

                    if (rd != null && rd.IsClosed == false) rd.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbRRHH = null;
            }

            return lista;
        }

        public Int32 IngresarPerfil(PerfilBE p_Perfil) {
            Int32 codigoPerfil;
            SqlCommand cmd = new SqlCommand();
            try {
                cmd.Connection = cn.getConecction();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GRH_SP_AGREGARPERFIL";
                cmd.Parameters.AddWithValue("@CAREASPERFIL", p_Perfil.AreasPerfil);
                cmd.Parameters.AddWithValue("@CNOMBREPERFIL", p_Perfil.NombrePerfil);
                cmd.Parameters.AddWithValue("@CDESCRIPCION", p_Perfil.Descripcion);
                cmd.Parameters.AddWithValue("@NSUELDO", p_Perfil.Sueldo);
                codigoPerfil = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                foreach (PerfilRequisitoBE oRequisito in p_Perfil.ListaRequisito) {
                    new PerfilRequisitoDA().IngresarPerfilRequisto(codigoPerfil, oRequisito);
                }

            }
            catch (Exception)
            {
                codigoPerfil = 0;
            }
            finally {
                cmd.Connection.Close();
            }
            
            return codigoPerfil;
        }

        public PerfilBE BuscarPefil(Int32 p_CodigoPerfil) {
            querySQL = "SELECT CAREASPERFIL, CDESCRIPCION, NSUELDO FROM GRH_PERFIL WHERE NPERFILCOD = @NPERFILCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NPERFILCOD", p_CodigoPerfil);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oPerfil = new PerfilBE(0,
                                            rd.GetString(0),
                                            null,
                                            rd.GetString(1),
                                            Convert.ToDouble(rd.GetDecimal(2)),
                                            0);
                    oPerfil.ListaRequisito = new PerfilRequisitoDA().BuscaListaRequisito(p_CodigoPerfil);
                }
            }
            catch (Exception)
            {
                oPerfil = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }

            return oPerfil;
        }
    }

}
