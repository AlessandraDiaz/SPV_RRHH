using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class PreguntaAlternativaDA
    {
        private List<PreguntaAlternativaBE> lAlternativa;
        private PreguntaAlternativaBE oAlternativa;
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        //Buscar Por CodigoPregunta
        public List<PreguntaAlternativaBE> BuscarListaAlternativa(String p_CodigoExamen, String p_CodigoPregunta)
        {
            querySQL = "SELECT NALTERNATIVACOD, CALTERNATIVADESC, NALTERNATIVACORRECTA, NALTERNATIVAPUNTAJE, CALTERNATIVAEST FROM GRH_PREGUNTAALTERNATIVA " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD AND CALTERNATIVAEST = 'ACT' ";
            lAlternativa = new List<PreguntaAlternativaBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            try {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read()){
                    oAlternativa = new PreguntaAlternativaBE(
                        rd.GetInt16(0),
                        rd.GetString(1),
                        Convert.ToInt16(rd.GetBoolean(2)),
                        rd.GetInt16(3),
                        rd.GetString(4)
                        );
                   /* oAlternativa.CodigoAlternativa = rd.GetInt16(0);
                    oAlternativa.Alternativa = rd.GetString(1);
                    oAlternativa.EsCorrecta = Convert.ToInt16(rd.GetBoolean(2));
                    oAlternativa.Puntaje = rd.GetInt16(3);
                    oAlternativa.Estado = rd.GetString(4);*/
                    lAlternativa.Add(oAlternativa);
                }
                rd.Close();
            }
            catch (Exception) {
                lAlternativa = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }


            return lAlternativa;
        }

        public Boolean AgregarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, PreguntaAlternativaBE p_PreguntaAlternativa)
        {
            Boolean guardar = false;
            querySQL = "INSERT INTO GRH_PREGUNTAALTERNATIVA (NEXAMENCOD, NPREGUNTACOD, NALTERNATIVACOD, CALTERNATIVADESC, NALTERNATIVACORRECTA, NALTERNATIVAPUNTAJE, CALTERNATIVAEST) " +
                        "VALUES (@NEXAMENCOD, @NPREGUNTACOD, @NALTERNATIVACOD, @CALTERNATIVADESC, @NALTERNATIVACORRECTA, @NALTERNATIVAPUNTAJE, 'ACT')";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            cmd.Parameters.AddWithValue("@NALTERNATIVACOD", p_PreguntaAlternativa.CodigoAlternativa);
            cmd.Parameters.AddWithValue("@CALTERNATIVADESC", p_PreguntaAlternativa.Alternativa);
            cmd.Parameters.AddWithValue("@NALTERNATIVACORRECTA", p_PreguntaAlternativa.EsCorrecta);
            cmd.Parameters.AddWithValue("@NALTERNATIVAPUNTAJE", p_PreguntaAlternativa.Puntaje);
            try {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                guardar = true;
            }
            catch (Exception) {
                guardar = false;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return guardar;
        }

        public Boolean ActualizarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, PreguntaAlternativaBE p_PreguntaAlternativa)
        {
            Boolean actualizar = false;
            querySQL = "UPDATE GRH_PREGUNTAALTERNATIVA  SET CALTERNATIVADESC = @CALTERNATIVADESC, NALTERNATIVACORRECTA = @NALTERNATIVACORRECTA, NALTERNATIVAPUNTAJE = @NALTERNATIVAPUNTAJE " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD AND NALTERNATIVACOD = @NALTERNATIVACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            cmd.Parameters.AddWithValue("@NALTERNATIVACOD", p_PreguntaAlternativa.CodigoAlternativa);
            cmd.Parameters.AddWithValue("@CALTERNATIVADESC", p_PreguntaAlternativa.Alternativa);
            cmd.Parameters.AddWithValue("@NALTERNATIVACORRECTA", p_PreguntaAlternativa.EsCorrecta);
            cmd.Parameters.AddWithValue("@NALTERNATIVAPUNTAJE", p_PreguntaAlternativa.Puntaje);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                actualizar = true;
            }
            catch (Exception)
            {
                actualizar = false;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return actualizar;
        }

        public Boolean EliminarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, String p_CodigoAlternativa) {
            Boolean Eliminar = false;
            querySQL = "UPDATE GRH_PREGUNTAALTERNATIVA  SET CALTERNATIVAEST = 'INA', NALTERNATIVACORRECTA = 0, NALTERNATIVAPUNTAJE = 0 " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD AND NALTERNATIVACOD = @NALTERNATIVACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            cmd.Parameters.AddWithValue("@NALTERNATIVACOD", p_CodigoAlternativa);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                Eliminar = true;
            }
            catch (Exception)
            {
                Eliminar = false;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return Eliminar;
        }

        public String GenerarCodigoAlternativa(String p_codigoExamen, String p_codigoPregunta)
        {
            String codigo;
            querySQL = "SELECT ISNULL(MAX(NALTERNATIVACOD),0) + 1 FROM GRH_PREGUNTAALTERNATIVA " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_codigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_codigoPregunta);
            try
            {
                cmd.Connection.Open();
                codigo = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                codigo = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }

        public PreguntaAlternativaBE BuscarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, String p_CodigoAlternativa)
        {
            querySQL = "SELECT NALTERNATIVACOD, CALTERNATIVADESC, NALTERNATIVACORRECTA, NALTERNATIVAPUNTAJE, CALTERNATIVAEST FROM GRH_PREGUNTAALTERNATIVA " +
                           "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD AND NALTERNATIVACOD = @NALTERNATIVACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            cmd.Parameters.AddWithValue("@NALTERNATIVACOD", p_CodigoAlternativa);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oAlternativa = new PreguntaAlternativaBE(
                            rd.GetInt16(0),
                            rd.GetString(1),
                            Convert.ToInt16(rd.GetBoolean(2)),
                            rd.GetInt16(3),
                            rd.GetString(4)
                        );
                 /*   oAlternativa.CodigoAlternativa = rd.GetInt16(0);
                    oAlternativa.Alternativa = rd.GetString(1);
                    oAlternativa.EsCorrecta = rd.GetInt16(2);
                    oAlternativa.Puntaje = rd.GetInt16(3);
                    oAlternativa.Estado = rd.GetString(4);*/
                }
                rd.Close();
            }
            catch (Exception)
            {
                oAlternativa = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }

            return oAlternativa;
        }

    }
}
