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
        private String qSQL;
        DataBaseDA dbRRHH;

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
                    cmd.Parameters.AddWithValue("@PERFIL", colaborador.Usuario.Perfil.CodPerfil);
                    cmd.Parameters.AddWithValue("@TIENDA", colaborador.Usuario.Local.CodTienda);
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
                        item.Usuario = usuario;

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
            qSQL = "SPS_COLABORADORES";
            
            try
            {
                var lista = new List<ColaboradorBE>();

                using (var conexion = new MySqlConnection())
                {
                    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;

                    using (var comando = conexion.CreateCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = qSQL;
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

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

        public List<ColaboradorBE> ListaPostulanteByConvocatoria(int codigo)
        {
            dbRRHH = new DataBaseDA();
            List<ColaboradorBE> lista = new List<ColaboradorBE>();
            try
            {
                qSQL = "SPS_POSTULANTES_BY_CONVOCATORIA";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ColaboradorBE item = new ColaboradorBE();
                        item.ID = (Int32)rd[0];
                        item.ApellidoPaterno = rd[1].ToString() != "" ? (String)rd[1] : "";
                        item.ApellidoMaterno = rd[2].ToString() != "" ? (String)rd[2] : "";
                        item.Nombres = rd[3].ToString() != "" ? (String)rd[3] : "";
                        item.DNI = rd[4].ToString() != "" ? (String)rd[4] : "";
                        item.FechaNacimiento = Convert.ToDateTime(rd[5]);
                        item.Sexo = rd[6].ToString() != "" ? (String)rd[6] : "";
                        item.Direccion = rd[7].ToString() != "" ? (String)rd[7] : "";
                        item.Telefono = rd[8].ToString() != "" ? (String)rd[8] : "";
                        item.Correo = rd[9].ToString() != "" ? (String)rd[9] : "";
                        item.EstadoCivil = rd[10].ToString() != "" ? (String)rd[10] : "";
                        item.CantidadHijos = (Int32)rd[11];
                        item.Seguro = rd[12].ToString() != "" ? (String)rd[12] : "";
                        item.CodigoEssalud = rd[13].ToString() != "" ? (String)rd[13] : "";
                        item.FechaCese = Convert.ToDateTime(rd[14]);
                        item.Antecedente = rd[15].ToString() != "" ? (String)rd[15] : "";

                        CurriculumVitaeBE cv = new CurriculumVitaeBE();
                        cv.ID = Convert.ToInt32(rd[16]);

                        item.CurriculumVitaeDetalle = cv;
                        item.RindioExamen = Convert.ToInt32(rd[17]);
                        item.PuntajeExamen = rd[18].ToString() != "" ? (Int32)rd[18] : 0;

                        ParametroBE estadoAceptacion = new ParametroBE();
                        estadoAceptacion.Codigo = rd[19].ToString() != "" ? (Int32)rd[19] : 0;
                        estadoAceptacion.Descripcion = rd[20].ToString() != "" ? (String)rd[20] : "";
                        item.EstadoAceptacion = estadoAceptacion;

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

        public void UpdatePostulantes(ColaboradorBE postulante)
        {
            dbRRHH = new DataBaseDA();
            try
            {
                qSQL = "SPU_POSTULANTES_APTOS";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", postulante.ID);
                    cmd.Parameters.AddWithValue("@ESTADO_ACEPTACION", postulante.EstadoAceptacion.Codigo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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
        }

        public ColaboradorBE GetColaboradorByID(int codigo)
        {
            dbRRHH = new DataBaseDA();
            ColaboradorBE item = null;
            try
            {
                qSQL = "SPS_COLABORADORBYID";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    int pCodCV = 0;
                    while (rd.Read())
                    {
                        item = new ColaboradorBE();
                        item.ID = (Int32)rd[0];
                        item.ApellidoPaterno = rd[1].ToString() != "" ? (String)rd[1] : "";
                        item.ApellidoMaterno = rd[2].ToString() != "" ? (String)rd[2] : "";
                        item.Nombres = rd[3].ToString() != "" ? (String)rd[3] : "";
                        item.DNI = rd[4].ToString() != "" ? (String)rd[4] : "";
                        item.FechaNacimiento = Convert.ToDateTime(rd[5]);
                        item.Sexo = rd[6].ToString() != "" ? (String)rd[6] : "";
                        item.Direccion = rd[7].ToString() != "" ? (String)rd[7] : "";
                        item.Telefono = rd[8].ToString() != "" ? (String)rd[8] : "";
                        item.Correo = rd[9].ToString() != "" ? (String)rd[9] : "";
                        item.EstadoCivil = rd[10].ToString() != "" ? (String)rd[10] : "";
                        item.CantidadHijos = (Int32)rd[11];
                        item.Seguro = rd[12].ToString() != "" ? (String)rd[12] : "";
                        item.CodigoEssalud = rd[13].ToString() != "" ? (String)rd[13] : "";
                        item.FechaCese = Convert.ToDateTime(rd[14]);
                        item.Antecedente = rd[15].ToString() != "" ? (String)rd[15] : "";
                        pCodCV = Convert.ToInt32(rd[16]);
                        CurriculumVitaeBE cv = new CurriculumVitaeDA().ObtenerCVByPostulante(pCodCV);
                        if (cv == null)
                        {
                            cv = new CurriculumVitaeBE() { ID = pCodCV };
                        }
                        item.CurriculumVitaeDetalle = cv;
                        item.RindioExamen = Convert.ToInt32(rd[17]);
                        item.PuntajeExamen = rd[18].ToString() != "" ? (Int32)rd[18] : 0;
                        item.Foto = rd[19].ToString() != "" ? rd[19].ToString() : "";
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

            return item;
        }


    }
}
