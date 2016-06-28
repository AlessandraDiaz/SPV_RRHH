using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace SPV.DA
{
    public class ColaboradorDA
    {
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        //Obtener Codigo Colaborador por codigo usuario
        public Int32 ObtenerCodigoCargoColaborador(String p_CodigoUsuario)
        {
            Int32 codigo;
            querySQL = "SELECT COL.NCARGOCOD FROM GRH_COLABORADOR COL " +
                        "INNER JOIN general.mae_usuario USU ON COL.NCOLABORADORCOD = USU.NCOLABORADORCOD " +
                        "WHERE USU.no_login = @CUSUARIOCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CUSUARIOCOD", p_CodigoUsuario);
            try
            {
                cmd.Connection.Open();
                codigo = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                codigo = 0;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }

        public Int32 ObtenerCodigoColaborador(String p_CodigoUsuario)
        {
            Int32 codigo;
            querySQL = "SELECT NCOLABORADORCOD FROM general.mae_usuario " +
                        "WHERE no_login = @CUSUARIOCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CUSUARIOCOD", p_CodigoUsuario);
            try
            {
                cmd.Connection.Open();
                codigo = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                codigo = 0;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }

        public Int32 ObtenerContratoColaborador(String p_CodigoUsuario)
        {
            Int32 codigo;
            querySQL = "SELECT NCONTRATOCOD FROM general.mae_usuario " +
                        "WHERE no_login = @CUSUARIOCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CUSUARIOCOD", p_CodigoUsuario);
            try
            {
                cmd.Connection.Open();
                codigo = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                codigo = 0;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }

        public Int32 ObtenerCodigoAreaColaborador(String p_CodigoUsuario)
        {
            Int32 codigo;
            querySQL = "SELECT COL.NAREATIENDACOD FROM GRH_COLABORADOR COL " +
                        "INNER JOIN general.mae_usuario USU ON COL.NCOLABORADORCOD = USU.NCOLABORADORCOD " +
                        "WHERE USU.no_login = @CUSUARIOCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CUSUARIOCOD", p_CodigoUsuario);
            try
            {
                cmd.Connection.Open();
                codigo = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                codigo = 0;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }
    }
}
