using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using SPV.BE;

namespace SPV.DA
{
    public class SolicitudPerfilDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;
        public List<SolicitudPerfilBE> Listar(SolicitudPerfilBE solicitudPerfil)
        {
            dbRRHH = new DataBaseDA();
            List<SolicitudPerfilBE> lista = new List<SolicitudPerfilBE>();
            try
            {
                qSQL = "SPS_PERFIL_X_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO_SOL", solicitudPerfil.SolicitudPersonal.CodigoSol);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SolicitudPerfilBE item = new SolicitudPerfilBE();
                        item.CodigoSolicitudPer = (Int32)rd[0];
                        //item.SolicitudPersonal.CodigoSol = (Int32)rd[1];

                        PerfilBE perfil = new PerfilBE();
                        perfil.CodPerfil = (Int32)rd[2];
                        perfil.Perfil = rd[3].ToString();
                        item.Perfil = perfil;

                        item.CantidadSolicitudPer = (Int32)rd[4];
                        item.Requisitos = rd[5].ToString() != "" ? (String)rd[5] : "";
                        item.Funciones = rd[6].ToString() != "" ? (String)rd[6] : "";
                        item.Sueldo = Convert.ToDecimal(rd[7]);

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

        public SolicitudPerfilBE GetSolicitudPerfilByID(int Id)
        {
            dbRRHH = new DataBaseDA();
            SolicitudPerfilBE item = null;
            try
            {
                qSQL = "SPS_PERFIL_X_SOLICITUD_BY_ID";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", Id);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        item = new SolicitudPerfilBE();
                        item.CodigoSolicitudPer = (Int32)rd[0];
                        //item.SolicitudPersonal.CodigoSol = (Int32)rd[1];

                        PerfilBE perfil = new PerfilBE();
                        perfil.CodPerfil = (Int32)rd[2];
                        perfil.Perfil = rd[3].ToString();
                        item.Perfil = perfil;

                        item.CantidadSolicitudPer = (Int32)rd[4];
                        item.Requisitos = rd[5].ToString() != "" ? (String)rd[5] : "";
                        item.Funciones = rd[6].ToString() != "" ? (String)rd[6] : "";
                        item.Sueldo = Convert.ToDecimal(rd[7]);
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

        public Int32 IngresarSolicitudPerfil(SolicitudPerfilBE solicitudPerfil)
        {
            dbRRHH = new DataBaseDA();
            Int32 salida = 0;
            try
            {
                qSQL = "SPI_PERFIL_X_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO_SOL", solicitudPerfil.SolicitudPersonal.CodigoSol);
                    cmd.Parameters.AddWithValue("@CODIGO_PERFIL", solicitudPerfil.Perfil.CodPerfil);
                    cmd.Parameters.AddWithValue("@CANTIDAD", solicitudPerfil.CantidadSolicitudPer);
                    cmd.Parameters.AddWithValue("@REQUISITOS", solicitudPerfil.Requisitos);
                    cmd.Parameters.AddWithValue("@FUNCIONES", solicitudPerfil.Funciones);
                    cmd.Parameters.AddWithValue("@SUELDO", solicitudPerfil.Sueldo);

                    cmd.Parameters.Add(new MySqlParameter("@RESULT", MySqlDbType.Int64));
                    cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    salida = (Int32)cmd.ExecuteScalar();
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

        public SolicitudPerfilBE  UpdateSolicitudPerfil(SolicitudPerfilBE solicitudPerfil)
        {
            dbRRHH = new DataBaseDA();
            SolicitudPerfilBE solicitudPerfilActualizada = null;
            try
            {
                qSQL = "SPU_PERFIL_X_SOLICITUD";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_SOLPERFIL", solicitudPerfil.CodigoSolicitudPer);
                    cmd.Parameters.AddWithValue("@CODIGO_SOL", solicitudPerfil.SolicitudPersonal.CodigoSol);
                    cmd.Parameters.AddWithValue("@CODIGO_PERFIL", solicitudPerfil.Perfil.CodPerfil);
                    cmd.Parameters.AddWithValue("@CANTIDAD", solicitudPerfil.CantidadSolicitudPer);
                    cmd.Parameters.AddWithValue("@REQUISITOS", solicitudPerfil.Requisitos);
                    cmd.Parameters.AddWithValue("@FUNCIONES", solicitudPerfil.Funciones);
                    cmd.Parameters.AddWithValue("@SUELDO", solicitudPerfil.Sueldo);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    solicitudPerfilActualizada = GetSolicitudPerfilByID(solicitudPerfil.CodigoSolicitudPer);
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

            return solicitudPerfilActualizada;
        }

        public Int32 EliminarSolicitudPerfil(int id)
        {
            dbRRHH = new DataBaseDA();
            Int32 salida = -1;
            try
            {
                qSQL = "SPD_PERFIL_X_SOLICITUD";
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
