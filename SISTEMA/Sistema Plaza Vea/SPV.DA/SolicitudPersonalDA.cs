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

        public List<SolicitudPersonalBE> Listar(SolicitudPersonalBE solicitud)
        {
            dbRRHH = new DataBaseDA();
            List<SolicitudPersonalBE> lista = new List<SolicitudPersonalBE>();
            try
            {
                qSQL = "SPS_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", solicitud.DescripcionSol);
                    cmd.Parameters.AddWithValue("@TIPOSOLICITUD", solicitud.TipoSolicitudSol.Codigo);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SolicitudPersonalBE item = new SolicitudPersonalBE();
                        item.CodigoSol = (Int32)rd[0];
                        item.DescripcionSol = rd[1].ToString();
                        item.FechaSol = Convert.ToDateTime(rd[2]);

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = (Int32)rd[3];
                        tipoSolicitud.Descripcion = rd[4].ToString();
                        item.TipoSolicitudSol = tipoSolicitud;

                        ParametroBE estadoSolicitud = new ParametroBE();
                        estadoSolicitud.Codigo = (Int32)rd[5];
                        estadoSolicitud.Descripcion = rd[6].ToString();
                        item.EstadoSol = estadoSolicitud;

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
                        solicitud.DescripcionSol = rd[1].ToString();
                        solicitud.FechaSol = Convert.ToDateTime(rd[2]);

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = (Int32)rd[3];
                        tipoSolicitud.Descripcion = rd[4].ToString();
                        solicitud.TipoSolicitudSol = tipoSolicitud;

                        ParametroBE estadoSolicitud = new ParametroBE();
                        estadoSolicitud.Codigo = (Int32)rd[5];
                        estadoSolicitud.Descripcion = rd[6].ToString();

                        SolicitudPerfilBE perfilFND = new SolicitudPerfilBE();
                        perfilFND.SolicitudPersonal = solicitud;

                        SolicitudPerfilDA sPerfilDA = new SolicitudPerfilDA();
                        List<SolicitudPerfilBE> listaSolicitudPerfiles = sPerfilDA.Listar(perfilFND);
                        sPerfilDA = null;

                        ListaPaginada<SolicitudPerfilBE> listaPagSolPer = new ListaPaginada<SolicitudPerfilBE>();
                        listaPagSolPer.Content = listaSolicitudPerfiles;
                        listaPagSolPer.CurrentPage = 1;
                        listaPagSolPer.PageSize = 10;
                        listaPagSolPer.TotalRecords = listaSolicitudPerfiles.Count();

                        solicitud.Detalle = listaPagSolPer;

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
                    cmd.Parameters.AddWithValue("@DESCRIPCION", solicitud.DescripcionSol);
                    cmd.Parameters.AddWithValue("@FECHA", solicitud.FechaSol);
                    cmd.Parameters.AddWithValue("@TIPO_SOL", solicitud.TipoSolicitudSol.Codigo);
                    cmd.Parameters.AddWithValue("@ESTADO", solicitud.EstadoSol.Codigo);

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
                    cmd.Parameters.AddWithValue("@DESCRIPCION", solicitud.DescripcionSol);
                    cmd.Parameters.AddWithValue("@FECHA", solicitud.FechaSol);
                    cmd.Parameters.AddWithValue("@TIPO_SOL", solicitud.TipoSolicitudSol.Codigo);
                    cmd.Parameters.AddWithValue("@ESTADO", solicitud.EstadoSol.Codigo);

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
