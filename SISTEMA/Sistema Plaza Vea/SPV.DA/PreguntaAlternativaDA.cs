using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class PreguntaAlternativaDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<PreguntaAlternativaBE> Listar(int codigoPregunta)
        {
            dbRRHH = new DataBaseDA();
            List<PreguntaAlternativaBE> lista = new List<PreguntaAlternativaBE>();
            try
            {
                qSQL = "SPS_EXAMENOPCIONES";

                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigoPregunta);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        PreguntaAlternativaBE alternativa = new PreguntaAlternativaBE();
                        alternativa.ID = (Int32)rd[0];

                        ExamenPreguntaBE pregunta = new ExamenPreguntaBE();
                        pregunta.ID = (Int32)rd[1];
                        alternativa.Pregunta = pregunta;

                        alternativa.NombreOpcionEx = rd[2].ToString();
                        alternativa.CorrectoEx = (Int32)rd[3];

                        lista.Add(alternativa);
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
