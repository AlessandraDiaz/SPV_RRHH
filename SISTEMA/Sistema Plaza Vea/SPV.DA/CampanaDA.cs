using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class CampanaDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<CampanaBE> ListarCampana(CampanaBE campana)
        {
            dbRRHH = new DataBaseDA();
            List<CampanaBE> lista = new List<CampanaBE>();
            try
            {
                qSQL = "SPS_CAMPANA";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", campana.Descripcion);
                    cmd.Parameters.AddWithValue("@CODIGO", campana.ID);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        CampanaBE item = new CampanaBE();
                        item.ID = (Int32)rd[0];
                        item.Descripcion = rd[1].ToString() != "" ? (String)rd[1] : "";

                        if (rd[2].ToString() != "")
                        {
                            item.FechaInicio = Convert.ToDateTime(rd[2]);
                        }

                        if (rd[3].ToString() != "")
                        {
                            item.FechaFin = Convert.ToDateTime(rd[3]);
                        }
                        item.Estado = (Int32)rd[4];

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
