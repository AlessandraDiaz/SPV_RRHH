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

    }

}
