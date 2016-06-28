using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SPV.BE;

namespace SPV.DA
{
    public class PerfilRequisitoDA
    {
        private List<PerfilRequisitoBE> lRequisito;
        private PerfilRequisitoBE oRequisito;
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        public Boolean IngresarPerfilRequisto(Int32 p_CodigoPerfil, PerfilRequisitoBE p_PerfilRequisito) {
            Boolean Ingresar = false;
            querySQL = "INSERT INTO GRH_PERFILREQUISITO (NPERFILCOD, CREQUISITO, NESTADO) VALUES (@NPERFILCOD, @CREQUISITO, 1)";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NPERFILCOD", p_CodigoPerfil);
            cmd.Parameters.AddWithValue("@CREQUISITO", p_PerfilRequisito.Requisito);
            try {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                Ingresar = true;
            }
            catch (Exception)
            {
                Ingresar = false;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return Ingresar;
        }

        public List<PerfilRequisitoBE> BuscaListaRequisito(Int32 p_CodigoPerfil) {
            lRequisito = new List<PerfilRequisitoBE>();
            querySQL = "SELECT CREQUISITO FROM GRH_PERFILREQUISITO WHERE NPERFILCOD = @NPERFILCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NPERFILCOD", p_CodigoPerfil);
            try {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) {
                    oRequisito = new PerfilRequisitoBE(rd.GetString(0), 0);
                    lRequisito.Add(oRequisito);
                }
            }
            catch (Exception) {
                lRequisito = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lRequisito;
        }
    }
}
