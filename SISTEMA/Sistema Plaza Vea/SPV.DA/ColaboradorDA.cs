using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SPV.DA
{
    public class ColaboradorDA
    {
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        private String qSQL;
        DataBaseDA dbRRHH;

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

        public List<ColaboradorBE> ListarColaboradores(ColaboradorBE colaborador)
        {
            dbRRHH = new DataBaseDA();
            List<ColaboradorBE> lista = new List<ColaboradorBE>();
            try
            {
                qSQL = "SPS_COLABORADOR_PERFIL";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PERFIL", colaborador.usuario.Perfil.CodPerfil);
                    cmd.Parameters.AddWithValue("@TIENDA", colaborador.usuario.Local.CodTienda);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ColaboradorBE item = new ColaboradorBE();
                        item.ID = (Int32)rd[0];
                        item.ApellidoPaterno = rd[1].ToString() != "" ? (String)rd[1] : "";
                        item.ApellidoMaterno = rd[2].ToString() != "" ? (String)rd[2] : "";
                        item.Nombres = rd[3].ToString() != "" ? (String)rd[3] : "";
                        item.Correo = rd[4].ToString() != "" ? (String)rd[4] : "";

                        UsuarioBE usuario = new UsuarioBE();
                        usuario.CodigoUsuario = rd[5] != null ? (Int32)rd[5] : 0;

                        PerfilBE perfil = new PerfilBE() { CodPerfil = rd[6] != null ? (Int32)rd[6] : 0 };
                        AreaTiendaBE area = new AreaTiendaBE() { CodArea = rd[7] != null ? (Int32)rd[7] : 0 };
                        TiendaBE local = new TiendaBE() { CodTienda = rd[8] != null ? (Int32)rd[8] : 0 };

                        usuario.Perfil = perfil;
                        usuario.Area = area;
                        usuario.Local = local;
                        item.usuario = usuario;

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

		
public List<ColaboradorBE> List()
        {
            querySQL = "SELECT PK_CODIGOCOLABORADOR AS CODIGO, APELLIDOPATERNO, APELLIDOMATERNO, NOMBRE, DNI, FECHANACIMIENTO, SEXO, DIRECCION, TELEFONO, CORREO, CURRICULUMVITAE, ESTADOCIVIL, CANTIDADHIJOS, SEGURO, CODIGOESSALUD, FECHACESE, ANTECEDENTEPOLICIAL FROM RRHH.TB_COLABORADOR A";
            
            try
            {
                var lista = new List<ColaboradorBE>();

                using (var conexion = new MySqlConnection())
                {
                    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;

                    using (var comando = conexion.CreateCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = querySQL;
                        comando.CommandType = System.Data.CommandType.Text;

                        conexion.Open();

                        using (var lector = comando.ExecuteReader())
                        {
                            ColaboradorBE entidad = null;

                            while (lector.Read())
                            {
                                entidad = new ColaboradorBE();
                                entidad.ID = Convert.ToInt32(lector["CODIGO"]);
                                entidad.ApellidoPaterno = Convert.ToString(lector["APELLIDOPATERNO"]);
                                entidad.ApellidoMaterno = Convert.ToString(lector["APELLIDOMATERNO"]);
                                entidad.Nombres = Convert.ToString(lector["NOMBRE"]);
                                entidad.DNI = Convert.ToString(lector["DNI"]);
                                entidad.FechaNacimiento = Convert.ToDateTime(lector["FECHANACIMIENTO"]);
                                entidad.Sexo = Convert.ToString(lector["SEXO"]);
                                entidad.Direccion = Convert.ToString(lector["DIRECCION"]);
                                entidad.Telefono = Convert.ToString(lector["TELEFONO"]);
                                entidad.Correo = Convert.ToString(lector["CORREO"]);

                                lista.Add(entidad);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
