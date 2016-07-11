using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPV.DA
{
    public class ExamenPreguntaDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public List<ExamenPreguntaBE> Listar(int codigoExamen)
        {
            dbRRHH = new DataBaseDA();
            List<ExamenPreguntaBE> lista = new List<ExamenPreguntaBE>();
            List<PreguntaAlternativaBE> listaAlternativas;
            try
            {
                qSQL = "SPS_PREGUNTAEXAMEN";

                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigoExamen);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ExamenBE exam = new ExamenBE();
                        exam.ID = (Int32)rd[0];
                        exam.NombreEx = rd[1].ToString();
                        exam.DescripcionEx = rd[2].ToString();

                        ExamenPreguntaBE item = new ExamenPreguntaBE();
                        int codigo = (Int32)rd[3];
                        item.ID = codigo;
                        item.PreguntaEx = rd[4].ToString();

                        ParametroBE tipoPregunta = new ParametroBE();
                        tipoPregunta.Codigo = (Int32)rd[5];
                        tipoPregunta.Descripcion = rd[9].ToString();
                        item.TipoPreguntaEx = tipoPregunta;

                        item.ImagenEx = rd[6].ToString();
                        item.PuntajeEx = (Int32)rd[7];
                        int tipoControl = (Int32)rd[8];
                        item.TipoControlEx = tipoControl;

                        //Opciones de las preguntas
                        if (tipoControl == 1)
                            listaAlternativas = new PreguntaAlternativaDA().Listar(codigo);
                        else
                            listaAlternativas = new List<PreguntaAlternativaBE>();
                        
                        item.listaOpciones = listaAlternativas;

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

    }
}
