using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class PostulanteRespuestaDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<PostulanteRespuestaBE> Listar(int id)
        {
            dbRRHH = new DataBaseDA();
            List<PostulanteRespuestaBE> lista = new List<PostulanteRespuestaBE>();
            try
            {
                qSQL = "SPS_RESPUESTAS";

                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO_POSTULANTE", id);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PostulanteRespuestaBE item = new PostulanteRespuestaBE();
                        item.ID = (Int32)rd[0];
                        item.CodigoUsuario = rd[1].ToString() != "" ? (Int32)rd[1] : 0;
                        item.CodigoExamen = rd[2].ToString() != "" ? (Int32)rd[2] : 0;
                        item.CodigoPregunta = rd[3].ToString() != "" ? (Int32)rd[3] : 0;
                        item.CodigoOpcion = rd[4].ToString() != "" ? (Int32)rd[4] : 0;
                        item.Respuesta = rd[5].ToString() != "" ? rd[5].ToString() : "";
                        item.Correcto = rd[6].ToString() != "" ? (Int32)rd[6] : 0;
                        item.PuntajePregunta = rd[7].ToString() != "" ? (Int32)rd[7] : 0;
                        item.Tiempo = rd[8].ToString() != "" ? rd[8].ToString() : "";

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
        public PostulanteRespuestaBE GetResumenRespuestaByPostulante(int Id)
        {
            dbRRHH = new DataBaseDA();
            PostulanteRespuestaBE respuesta = null;
            try
            {
                qSQL = "SPS_RESULTRESUMENBYPOSTULANTE";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO_POSTULANTE", Id);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        respuesta = new PostulanteRespuestaBE();
                        respuesta.Tiempo = rd[0].ToString() != "" ? (String)rd[0] : "";
                        respuesta.TotalPreguntas = rd[1].ToString() != "" ? (Int32)rd[1] : 0;
                        respuesta.CantidadCorrecto = rd[2].ToString() != "" ? (Int32)rd[2] : 0;
                        respuesta.CantidadIncorrecto = rd[3].ToString() != "" ? (Int32)rd[3] : 0;
                        respuesta.CantidadNoRespondidas = rd[4].ToString() != "" ? (Int32)rd[4] : 0;
                        respuesta.PuntajeTotal = rd[5].ToString() != "" ? (Int32)rd[5] : 0;
                        respuesta.PuntajeObtenido = rd[6].ToString() != "" ? (Int32)rd[6] : 0;
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

            return respuesta;
        }
        public Int32 RegistrarRespuesta(PostulanteRespuestaBE respuesta)
        {
            dbRRHH = new DataBaseDA();
            Int32 salida = 0;
            try
            {
                qSQL = "SPI_RESPUESTAS";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_USUARIO", respuesta.CodigoUsuario);
                    cmd.Parameters.AddWithValue("@COD_EXAMEN", respuesta.CodigoExamen);
                    cmd.Parameters.AddWithValue("@COD_PREGUNTA", respuesta.CodigoPregunta);
                    cmd.Parameters.AddWithValue("@COD_OPCION", respuesta.CodigoOpcion);
                    cmd.Parameters.AddWithValue("@RESPUESTA", respuesta.Respuesta);
                    cmd.Parameters.AddWithValue("@CORRECTO", respuesta.Correcto);
                    cmd.Parameters.AddWithValue("@PUNTAJE", respuesta.PuntajePregunta);
                    cmd.Parameters.AddWithValue("@TIEMPO", respuesta.Tiempo);

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

    }
}
