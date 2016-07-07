using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class CargoDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<CargoBE> ListarCargo(CargoBE cargo)
        {
            dbRRHH = new DataBaseDA();
            List<CargoBE> lista = new List<CargoBE>();
            try
            {
                qSQL = "SPS_CARGO";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", cargo.Descripcion);
                    cmd.Parameters.AddWithValue("@CODIGO", cargo.CodigoCargo);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        CargoBE item = new CargoBE();
                        item.CodigoCargo = (Int32)rd[0];
                        item.Descripcion = rd[1].ToString() != "" ? (String)rd[1] : "";
                        item.Funciones = rd[2].ToString() != "" ? (String)rd[2] : "";
                        item.Requisitos = rd[3].ToString() != "" ? (String)rd[3] : "";
                        item.SueldoMin = (decimal)rd[4];
                        item.SueldoMax = (decimal)rd[5];
                        item.EstadoCargo = (Int32)rd[6];

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
