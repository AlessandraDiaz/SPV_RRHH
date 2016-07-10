using MySql.Data.MySqlClient;
using SPV.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace SPV.DA
{
    public class Convocatoria2DA
    {
        public void Insert(Convocatoria2BE entidad)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection())
                {
                    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;

                    using (MySqlCommand comando = conexion.CreateCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = "RRHH.SPI_CONVOCATORIA";
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        var pNombre = new MySqlParameter();
                        pNombre.ParameterName = "P_NOMBRE";
                        pNombre.MySqlDbType = MySqlDbType.VarChar;
                        pNombre.Value = entidad.Nombre;
                        pNombre.Direction = System.Data.ParameterDirection.Input;
                        comando.Parameters.Add(pNombre);

                        var pFechaInicio = new MySqlParameter();
                        pFechaInicio.ParameterName = "P_FECHA_INICIO";
                        pFechaInicio.MySqlDbType = MySqlDbType.DateTime;
                        pFechaInicio.Value = entidad.FechaInicio;
                        pFechaInicio.Direction = System.Data.ParameterDirection.Input;
                        comando.Parameters.Add(pFechaInicio);

                        var pFechaFin = new MySqlParameter();
                        pFechaFin.ParameterName = "P_FECHA_FIN";
                        pFechaFin.MySqlDbType = MySqlDbType.DateTime;
                        pFechaFin.Value = entidad.FechaFin;
                        pFechaFin.Direction = System.Data.ParameterDirection.Input;
                        comando.Parameters.Add(pFechaFin);

                        var pCodigoSolicitud = new MySqlParameter();
                        pCodigoSolicitud.ParameterName = "P_CODIGO_SOLICITUD";
                        pCodigoSolicitud.MySqlDbType = MySqlDbType.Int32;
                        pCodigoSolicitud.Value = entidad.Solicitud.CodigoSol;
                        pCodigoSolicitud.Direction = System.Data.ParameterDirection.Input;
                        comando.Parameters.Add(pCodigoSolicitud);

                        var pId = new MySqlParameter();
                        pId.ParameterName = "P_ID";
                        pId.MySqlDbType = MySqlDbType.Int32;
                        pId.Direction = System.Data.ParameterDirection.Output;
                        comando.Parameters.Add(pId);

                        conexion.Open();

                        entidad.Id = (int)comando.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Convocatoria2BE Get(int id)
        {
            try
            {
                Convocatoria2BE entidad = null;

                using (MySqlConnection conexion = new MySqlConnection())
                {
                    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;

                    using (MySqlCommand comando = conexion.CreateCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = "RRHH.SPS_GET_CONVOCATORIA";
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        var pId = new MySqlParameter();
                        pId.ParameterName = "P_ID";
                        pId.MySqlDbType = MySqlDbType.Int32;
                        pId.Value = id;
                        pId.Direction = System.Data.ParameterDirection.Input;
                        comando.Parameters.Add(pId);

                        conexion.Open();

                        using (IDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                entidad = new Convocatoria2BE();

                                entidad.Id = Convert.ToInt32(lector["ID"]);
                                entidad.CodigoInterno = lector["CodigoInterno"].ToString();
                                entidad.Nombre = Convert.ToString(lector["NOMBRE"]);
                                entidad.FechaInicio = Convert.ToDateTime(lector["FECHAINICIO"]);
                                entidad.FechaFin = Convert.ToDateTime(lector["FECHAFIN"]);

                                SolicitudPersonalBE oSol = new SolicitudPersonalBE();
                                ParametroBE paramConvoc = new ParametroBE();
                                paramConvoc.Codigo = Convert.ToInt32(lector["CODTIPOCONVOCATORIA"]);
                                paramConvoc.Descripcion = Convert.ToString(lector["TIPOCONVOCATORIA"]);
                                oSol.TipoConvocatoria = paramConvoc;
                                oSol.Cantidad = Convert.ToInt32(lector["Cantidad"]);
                                oSol.CodigoSol = Convert.ToInt32(lector["CODIGOSOLICITUD"]);
                                CargoBE oCargo = new CargoBE();
                                oCargo.ID = Convert.ToInt32(lector["FK_CodigoCargo"]);
                                oCargo.Descripcion = Convert.ToString(lector["CARGO"]);

                                oSol.Cargo = oCargo;

                                entidad.FechaCreacion = Convert.ToDateTime(lector["FECHACREACION"]);

                                ParametroBE pEstado = new ParametroBE();
                                pEstado.Codigo = Convert.ToInt32(lector["CODIGOESTADO"]);
                                pEstado.Descripcion = Convert.ToString(lector["ESTADO"]);
                                entidad.Estado = pEstado;

                                entidad.Solicitud = oSol;


                            }
                        }
                    }
                }

                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Convocatoria2BE> Search(string id, string nombre, int? codTipoConvocatoria, DateTime? fechaInicio, DateTime? fechaFin, int? codTipoSolicitud)
        {
            try
            {
                List<Convocatoria2BE> lista = new List<Convocatoria2BE>();

                using (MySqlConnection conexion = new MySqlConnection())
                {
                    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["cnMySql"].ConnectionString;

                    using (MySqlCommand comando = conexion.CreateCommand())
                    {
                        comando.Connection = conexion;
                        comando.CommandText = "RRHH.SPS_SEARCH_CONVOCATORIA";
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        var pId = new MySqlParameter();
                        pId.ParameterName = "P_ID";
                        pId.Direction = System.Data.ParameterDirection.Input;
                        if (id != null && id != "")
                        {   
                            pId.MySqlDbType = MySqlDbType.VarChar;
                            pId.Value = id;
                        }
                        else
                            pId.Value = DBNull.Value;

                        comando.Parameters.Add(pId);

                        var pNombre = new MySqlParameter();
                        pNombre.ParameterName = "P_NOMBRE";
                        pNombre.Direction = System.Data.ParameterDirection.Input;
                        if (!string.IsNullOrEmpty(nombre))
                        {   
                            pNombre.MySqlDbType = MySqlDbType.VarChar;
                            pNombre.Value = nombre;
                            
                        }
                        else
                            pNombre.Value = DBNull.Value;

                        comando.Parameters.Add(pNombre);

                        var pCodigoTipo = new MySqlParameter();
                        pCodigoTipo.ParameterName = "P_CODIGO_TIPO_CONVOCATORIA";
                        pCodigoTipo.Direction = System.Data.ParameterDirection.Input;
                        if (codTipoConvocatoria != null)
                        {   
                            pCodigoTipo.MySqlDbType = MySqlDbType.Int32;
                            pCodigoTipo.Value = codTipoConvocatoria;
                        }
                        else
                            pCodigoTipo.Value = DBNull.Value;

                        comando.Parameters.Add(pCodigoTipo);

                        var pFechaInicio = new MySqlParameter();
                        pFechaInicio.ParameterName = "P_FECHA_INICIO";
                        pFechaInicio.Direction = System.Data.ParameterDirection.Input;
                        if (fechaInicio != null)
                        {
                            pFechaInicio.Value = fechaInicio;
                            pFechaInicio.MySqlDbType = MySqlDbType.DateTime;
                        }
                        else
                            pFechaInicio.Value = DBNull.Value;

                        comando.Parameters.Add(pFechaInicio);

                        var pFechaFin = new MySqlParameter();
                        pFechaFin.ParameterName = "P_FECHA_FIN";
                        pFechaFin.Direction = System.Data.ParameterDirection.Input;
                        if (fechaInicio != null)
                        {   
                            pFechaFin.Value = fechaFin;
                            pFechaFin.MySqlDbType = MySqlDbType.DateTime;
                        }
                        else
                            pFechaFin.Value = DBNull.Value;

                        comando.Parameters.Add(pFechaFin);

                        var pCodigoSolicitud = new MySqlParameter();
                        pCodigoSolicitud.ParameterName = "P_CODIGO_CARGO";
                        pCodigoSolicitud.Direction = System.Data.ParameterDirection.Input;
                        if (codTipoSolicitud != null)
                        {   
                            pCodigoSolicitud.MySqlDbType = MySqlDbType.Int32;
                            pCodigoSolicitud.Value = codTipoSolicitud;
                        }
                        else
                            pCodigoSolicitud.Value = DBNull.Value;

                        comando.Parameters.Add(pCodigoSolicitud);

                        conexion.Open();
                        using (IDataReader lector = comando.ExecuteReader())
                        {
                            Convocatoria2BE entidad = null;

                            while (lector.Read())
                            {
                                entidad = new Convocatoria2BE();

                                entidad.Id = Convert.ToInt32(lector["ID"]);
                                entidad.CodigoInterno = lector["CodigoInterno"].ToString();
                                entidad.Nombre = Convert.ToString(lector["NOMBRE"]);
                                entidad.FechaInicio = Convert.ToDateTime(lector["FECHAINICIO"]);
                                entidad.FechaFin = Convert.ToDateTime(lector["FECHAFIN"]);

                                SolicitudPersonalBE oSol = new SolicitudPersonalBE();
                                ParametroBE paramConvoc = new ParametroBE();
                                paramConvoc.Codigo = Convert.ToInt32(lector["CODTIPOCONVOCATORIA"]);
                                paramConvoc.Descripcion = Convert.ToString(lector["TIPOCONVOCATORIA"]);
                                oSol.TipoConvocatoria = paramConvoc;
                                oSol.Cantidad = Convert.ToInt32(lector["Cantidad"]);
                                oSol.CodigoSol = Convert.ToInt32(lector["CODIGOSOLICITUD"]);
                                CargoBE oCargo = new CargoBE();
                                oCargo.ID = Convert.ToInt32(lector["FK_CodigoCargo"]);
                                oCargo.Descripcion = Convert.ToString(lector["CARGO"]);

                                oSol.Cargo = oCargo;

                                entidad.FechaCreacion = Convert.ToDateTime(lector["FECHACREACION"]);

                                ParametroBE pEstado = new ParametroBE();
                                pEstado.Codigo = Convert.ToInt32(lector["CODIGOESTADO"]);
                                pEstado.Descripcion = Convert.ToString(lector["ESTADO"]);
                                entidad.Estado = pEstado;

                                entidad.Solicitud = oSol;

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
