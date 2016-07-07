using MySql.Data.MySqlClient;
using SPV.BE;
using System;
using System.Collections.Generic;
using System.Data;


namespace SPV.DA
{
    public class ParametroDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<ParametroBE> Listar(ParametroBE parametro)
        {
            dbRRHH = new DataBaseDA();
            List<ParametroBE> lista = new List<ParametroBE>();
            try
            {
                qSQL = "SPS_PARAMETRO";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_AGRUPADOR", parametro.CodigoAgrupador);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ParametroBE param = new ParametroBE();
                        param.Codigo = (Int32)rd[0];
                        param.Descripcion = rd[1].ToString();
                        param.Valor = rd[2].ToString() != "" ? (String)rd[2] : "";
                        param.Estado = (Int32)rd[3];
                        lista.Add(param);
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

        public List<ParametroBE> ListarXCodAgrupador(int codigoAgrupador)
        {
            dbRRHH = new DataBaseDA();
            List<ParametroBE> lista = new List<ParametroBE>();
            try
            {
                qSQL = "SPS_PARAMETROXCODAGRUPADOR";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_AGRUPADOR", codigoAgrupador);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ParametroBE param = new ParametroBE();
                        param.CodigoParametro = (Int32)rd[0];
                        param.Descripcion = (string)rd[1];
                        param.Valor = rd[2].ToString() != "" ? (String)rd[2] : "";
                        param.Estado = (Int32)rd[3];
                        lista.Add(param);
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
