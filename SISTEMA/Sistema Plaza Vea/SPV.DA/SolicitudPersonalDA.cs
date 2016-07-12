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
    public class SolicitudPersonalDA
    {

        private String qSQL;
        DataBaseDA dbRRHH;

        public List<SolicitudPersonalBE> Listar(int tipoFiltro, string desc, int codigo, string fechaini,
                                                    string fechafin, int estado, int usuario, int local, int area)
        {
            dbRRHH = new DataBaseDA();
            List<SolicitudPersonalBE> lista = new List<SolicitudPersonalBE>();
            try
            {
                qSQL = "SPS_SOLICITUD";

                if (fechaini != null && fechaini != "")
                    fechaini = Convert.ToDateTime(fechaini).ToString("yyyy-MM-dd");

                if (fechafin != null && fechafin != "")
                    fechafin = Convert.ToDateTime(fechafin).ToString("yyyy-MM-dd");

                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPOFILTRO", tipoFiltro);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", desc);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fechaini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN",fechafin );
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
                    cmd.Parameters.AddWithValue("@CODLOCAL", local);
                    cmd.Parameters.AddWithValue("@CODAREA", area);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SolicitudPersonalBE item = new SolicitudPersonalBE();
                        item.CodigoSol = (Int32)rd[0];
                        item.CodigoInterno = rd[1].ToString();

                        ParametroBE tipoConvocatoria = new ParametroBE();
                        tipoConvocatoria.Codigo = (Int32)rd[2];
                        tipoConvocatoria.Descripcion = rd[3].ToString();
                        item.TipoConvocatoria = tipoConvocatoria;

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = (Int32)rd[4];
                        tipoSolicitud.Descripcion = rd[5].ToString();
                        item.TipoSolicitudSol = tipoSolicitud;

                        ParametroBE motivo = new ParametroBE();
                        motivo.Codigo = (Int32)rd[6];
                        motivo.Descripcion = rd[7].ToString();
                        item.Motivo = motivo;

                        item.FechaSol = Convert.ToDateTime(rd[8]);
                        item.FechaPresentacion = Convert.ToDateTime(rd[9]);

                        if (rd[10].ToString() != "")
                        {
                            item.FechaEnvio = Convert.ToDateTime(rd[10]);
                        }

                        CampanaBE campana = new CampanaBE();
                        campana.ID = rd[11].ToString() != "" ? (Int32)rd[11] : 0;
                        campana.Descripcion = rd[12].ToString() != "" ? (string)rd[12] : "";
                        
                        if (rd[13].ToString() != "")
                        {
                            campana.FechaInicio = Convert.ToDateTime(rd[13]);
                            campana.FechaInicio = Convert.ToDateTime(rd[14]);
                        }
                        item.Campana = campana;

                        CargoBE cargo = new CargoBE();
                        cargo.ID = (Int32)rd[15];
                        cargo.Descripcion = rd[16].ToString();
                        cargo.Funciones = rd[17].ToString();
                        cargo.Requisitos = rd[18].ToString();
                        cargo.SueldoMin = (decimal)rd[19];
                        cargo.SueldoMax = (decimal)rd[20];

                        item.Cargo = cargo;

                        item.SueldoSolicitud = (decimal)rd[21];

                        ParametroBE moneda = new ParametroBE();
                        moneda.Codigo = (Int32)rd[22];
                        moneda.Descripcion = rd[23].ToString();
                        item.MonedaSolicitud = moneda;

                        item.Cantidad = (Int32)rd[24];
                        item.Comentarios = rd[25].ToString() != "" ? (string)rd[25] : "";

                        ParametroBE estadoSolicitud = new ParametroBE();
                        estadoSolicitud.Codigo = (Int32)rd[26];
                        estadoSolicitud.Descripcion = rd[27].ToString();
                        item.EstadoSol = estadoSolicitud;
                        item.CodigoUsuario = (Int32)rd[28];

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

        public List<SolicitudPersonalBE> ListarSolicitudesConvocatoria(int tipoFiltro, string desc, int codigo, string fechaini,
                                            string fechafin, int estado, int usuario, int local, int area)
        {
            dbRRHH = new DataBaseDA();
            List<SolicitudPersonalBE> lista = new List<SolicitudPersonalBE>();
            try
            {
                qSQL = "SPS_SOLICITUD_CONVOCATORIA";

                if (fechaini != null && fechaini != "")
                    fechaini = Convert.ToDateTime(fechaini).ToString("yyyy-MM-dd");

                if (fechafin != null && fechafin != "")
                    fechafin = Convert.ToDateTime(fechafin).ToString("yyyy-MM-dd");

                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPOFILTRO", tipoFiltro);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", desc);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fechaini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fechafin);
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
                    cmd.Parameters.AddWithValue("@CODLOCAL", local);
                    cmd.Parameters.AddWithValue("@CODAREA", area);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SolicitudPersonalBE item = new SolicitudPersonalBE();
                        item.CodigoSol = (Int32)rd[0];
                        item.CodigoInterno = rd[1].ToString();

                        ParametroBE tipoConvocatoria = new ParametroBE();
                        tipoConvocatoria.Codigo = (Int32)rd[2];
                        tipoConvocatoria.Descripcion = rd[3].ToString();
                        item.TipoConvocatoria = tipoConvocatoria;

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = (Int32)rd[4];
                        tipoSolicitud.Descripcion = rd[5].ToString();
                        item.TipoSolicitudSol = tipoSolicitud;

                        ParametroBE motivo = new ParametroBE();
                        motivo.Codigo = (Int32)rd[6];
                        motivo.Descripcion = rd[7].ToString();
                        item.Motivo = motivo;

                        item.FechaSol = Convert.ToDateTime(rd[8]);
                        item.FechaPresentacion = Convert.ToDateTime(rd[9]);

                        if (rd[10].ToString() != "")
                        {
                            item.FechaEnvio = Convert.ToDateTime(rd[10]);
                        }

                        CampanaBE campana = new CampanaBE();
                        campana.ID = rd[11].ToString() != "" ? (Int32)rd[11] : 0;
                        campana.Descripcion = rd[12].ToString() != "" ? (string)rd[12] : "";

                        if (rd[13].ToString() != "")
                        {
                            campana.FechaInicio = Convert.ToDateTime(rd[13]);
                            campana.FechaInicio = Convert.ToDateTime(rd[14]);
                        }
                        item.Campana = campana;

                        CargoBE cargo = new CargoBE();
                        cargo.ID = (Int32)rd[15];
                        cargo.Descripcion = rd[16].ToString();
                        cargo.Funciones = rd[17].ToString();
                        cargo.Requisitos = rd[18].ToString();
                        cargo.SueldoMin = (decimal)rd[19];
                        cargo.SueldoMax = (decimal)rd[20];

                        item.Cargo = cargo;

                        item.SueldoSolicitud = (decimal)rd[21];

                        ParametroBE moneda = new ParametroBE();
                        moneda.Codigo = (Int32)rd[22];
                        moneda.Descripcion = rd[23].ToString();
                        item.MonedaSolicitud = moneda;

                        item.Cantidad = (Int32)rd[24];
                        item.Comentarios = rd[25].ToString() != "" ? (string)rd[25] : "";

                        ParametroBE estadoSolicitud = new ParametroBE();
                        estadoSolicitud.Codigo = (Int32)rd[26];
                        estadoSolicitud.Descripcion = rd[27].ToString();
                        item.EstadoSol = estadoSolicitud;
                        item.CodigoUsuario = (Int32)rd[28];

                        Convocatoria2BE convocatoria = new Convocatoria2BE();
                        convocatoria.ID = rd[29].ToString() != "" ? (Int32)rd[29] : 0;

                        ParametroBE estadoConvocatoria = new ParametroBE();
                        estadoConvocatoria.Codigo = rd[30].ToString() != "" ? (Int32)rd[30] : 0;
                        estadoConvocatoria.Descripcion = rd[31].ToString() != "" ? (string)rd[31] : "";

                        convocatoria.Estado = estadoConvocatoria;

                        item.Convocatoria = convocatoria;
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

        public SolicitudPersonalBE GetSolicitudByID(int Id)
        {
            dbRRHH = new DataBaseDA();
            SolicitudPersonalBE solicitud = null;
            try
            {
                qSQL = "SPS_SOLICITUDBYID";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", Id);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        solicitud = new SolicitudPersonalBE();
                        solicitud.CodigoSol = (Int32)rd[0];
                        solicitud.CodigoInterno = rd[1].ToString();

                        ParametroBE tipoConvocatoria = new ParametroBE();
                        tipoConvocatoria.Codigo = (Int32)rd[2];
                        tipoConvocatoria.Descripcion = rd[3].ToString();
                        solicitud.TipoConvocatoria = tipoConvocatoria;

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = (Int32)rd[4];
                        tipoSolicitud.Descripcion = rd[5].ToString();
                        solicitud.TipoSolicitudSol = tipoSolicitud;

                        ParametroBE motivo = new ParametroBE();
                        motivo.Codigo = (Int32)rd[6];
                        motivo.Descripcion = rd[7].ToString();
                        solicitud.Motivo = motivo;

                        solicitud.FechaSol = Convert.ToDateTime(rd[8]);
                        solicitud.FechaPresentacion = Convert.ToDateTime(rd[9]);

                        if (rd[10].ToString() != "")
                        {
                            solicitud.FechaEnvio = Convert.ToDateTime(rd[10]);
                        }

                        CampanaBE campana = new CampanaBE();
                        campana.ID = rd[11].ToString() != "" ? (Int32)rd[11] : 0;
                        campana.Descripcion = rd[12].ToString() != "" ? (string)rd[12] : "";

                        if (rd[13].ToString() != "")
                        {
                            campana.FechaInicio = Convert.ToDateTime(rd[13]);
                            campana.FechaInicio = Convert.ToDateTime(rd[14]);
                        }
                        solicitud.Campana = campana;

                        CargoBE cargo = new CargoBE();
                        cargo.ID = (Int32)rd[15];
                        cargo.Descripcion = rd[16].ToString();
                        cargo.Funciones = rd[17].ToString();
                        cargo.Requisitos = rd[18].ToString();
                        cargo.SueldoMin = (decimal)rd[19];
                        cargo.SueldoMax = (decimal)rd[20];

                        solicitud.Cargo = cargo;

                        solicitud.SueldoSolicitud = (decimal)rd[21];

                        ParametroBE moneda = new ParametroBE();
                        moneda.Codigo = (Int32)rd[22];
                        moneda.Descripcion = rd[23].ToString();
                        solicitud.MonedaSolicitud = moneda;

                        solicitud.Cantidad = (Int32)rd[24];
                        solicitud.Comentarios = rd[25].ToString() != "" ? (string)rd[25] : "";

                        ParametroBE estadoSolicitud = new ParametroBE();
                        estadoSolicitud.Codigo = (Int32)rd[26];
                        estadoSolicitud.Descripcion = rd[27].ToString();
                        solicitud.EstadoSol = estadoSolicitud;
                        solicitud.CodigoUsuario = (Int32)rd[28];

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

            return solicitud;
        }

        public Int32 IngresarSolicitudPersonal(SolicitudPersonalBE solicitud)
        {
            dbRRHH = new DataBaseDA();
            Int32 salida = 0;
            try
            {
                qSQL = "SPI_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPO_CONV", solicitud.TipoConvocatoria.Codigo);
                    cmd.Parameters.AddWithValue("@TIPO_SOL", solicitud.TipoSolicitudSol.Codigo);
                    cmd.Parameters.AddWithValue("@MOTIVO", solicitud.Motivo.Codigo);
                    cmd.Parameters.AddWithValue("@FECHA_SOL", solicitud.FechaSol);
                    cmd.Parameters.AddWithValue("@FECHA_PRE", solicitud.FechaPresentacion);
                    cmd.Parameters.AddWithValue("@COD_CAMPANA", solicitud.Campana.ID);
                    cmd.Parameters.AddWithValue("@COD_CARGO", solicitud.Cargo.ID);
                    cmd.Parameters.AddWithValue("@COD_MONEDA", solicitud.MonedaSolicitud.Codigo);
                    cmd.Parameters.AddWithValue("@SUELDO", solicitud.SueldoSolicitud);
                    cmd.Parameters.AddWithValue("@CANTIDAD", solicitud.Cantidad);
                    cmd.Parameters.AddWithValue("@ESTADO", solicitud.EstadoSol.Codigo);
                    cmd.Parameters.AddWithValue("@COD_LOCAL", solicitud.LocalUsuario);
                    cmd.Parameters.AddWithValue("@USUARIO", solicitud.CodigoUsuario);
                    cmd.Parameters.Add(new MySqlParameter("@RESULT", MySqlDbType.Int64));
                    cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    salida= (Int32)cmd.ExecuteScalar();
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

            return salida;
        }

        public SolicitudPersonalBE UpdateSolicitud(SolicitudPersonalBE solicitud)
        {
            dbRRHH = new DataBaseDA();
            SolicitudPersonalBE solicitudActualizada = null;
            try
            {
                qSQL = "SPU_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", solicitud.CodigoSol);
                    cmd.Parameters.AddWithValue("@TIPO_CONV", solicitud.TipoConvocatoria.Codigo);
                    cmd.Parameters.AddWithValue("@TIPO_SOL", solicitud.TipoSolicitudSol.Codigo);
                    cmd.Parameters.AddWithValue("@MOTIVO", solicitud.Motivo.Codigo);
                    cmd.Parameters.AddWithValue("@FECHA_PRE", solicitud.FechaPresentacion);
                    cmd.Parameters.AddWithValue("@COD_CAMPANA", solicitud.Campana.ID);
                    cmd.Parameters.AddWithValue("@COD_CARGO", solicitud.Cargo.ID);
                    cmd.Parameters.AddWithValue("@COD_MONEDA", solicitud.MonedaSolicitud.Codigo);
                    cmd.Parameters.AddWithValue("@SUELDO", solicitud.SueldoSolicitud);
                    cmd.Parameters.AddWithValue("@CANTIDAD", solicitud.Cantidad);
                    cmd.Parameters.AddWithValue("@ESTADO", solicitud.EstadoSol.Codigo);
                    cmd.Parameters.AddWithValue("@OBSERVACION", solicitud.Comentarios);
                    cmd.Parameters.AddWithValue("@FECHA_ENV", solicitud.FechaEnvio);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    solicitudActualizada = GetSolicitudByID(solicitud.CodigoSol);
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

            return solicitudActualizada;
        }

        public Int32 EliminarSolicitudPersonal(int id)
        {
            dbRRHH = new DataBaseDA();
            Int32 salida = -1;
            try
            {
                qSQL = "SPD_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", id);

                    cmd.Connection.Open();
                    salida = (Int32)cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                salida = -1;
                throw ex;
            }
            finally
            {
                dbRRHH = null;
            }

            return salida;
        }
    }
}
