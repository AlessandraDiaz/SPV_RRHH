using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class ExamenPreguntaDA
    {
        private ExamenPreguntaBE oExamenPregunta;
        private List<ExamenPreguntaBE> lExamenPregunta;
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        //Listar Pregunta sin lista Altenativa
        public List<ExamenPreguntaBE> BuscarListarPregunta(String p_CodigoExamen)
        {
            lExamenPregunta = new List<ExamenPreguntaBE>();
            querySQL = "SELECT NPREGUNTACOD, CPREGUNTADES, CPREGUNTATIPO, CPREGUNTAEST FROM GRH_EXAMENPREGUNTA "+
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND CPREGUNTAEST = 'ACT'";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamenPregunta = new ExamenPreguntaBE(
                        rd.GetInt16(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetString(3)
                        );
                  /*  oExamenPregunta.CodigoPregunta = rd.GetInt16(0);
                    oExamenPregunta.Pregunta = rd.GetString(1);
                    oExamenPregunta.TipoPregunta = rd.GetString(2);
                    oExamenPregunta.EstadoPregunta = rd.GetString(3);*/
                    lExamenPregunta.Add(oExamenPregunta);
                }
                rd.Close();
            }
            catch (Exception)
            {
                lExamenPregunta = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lExamenPregunta;
        }

        //Agregar Pregunta sin Alternativa
        public Boolean AgregarPregunta(String p_CodigoExamen, ExamenPreguntaBE p_ExamenPregunta) {
            Boolean guardar = false;
            querySQL = "INSERT INTO GRH_EXAMENPREGUNTA (NEXAMENCOD, NPREGUNTACOD, CPREGUNTADES, CPREGUNTATIPO, CPREGUNTAEST) "+
                        "VALUES (@NEXAMENCOD, @NPREGUNTACOD, @CPREGUNTADES, @CPREGUNTATIPO, 'ACT')";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_ExamenPregunta.CodigoPregunta);
            cmd.Parameters.AddWithValue("@CPREGUNTADES", p_ExamenPregunta.Pregunta);
            cmd.Parameters.AddWithValue("@CPREGUNTATIPO", p_ExamenPregunta.TipoPregunta);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                guardar = true;
            }
            catch (Exception)
            {
                guardar = false;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return guardar;
        }

        //Actualizar Pregunta sin Alternativa
        public Boolean ActualizarPregunta(String p_CodigoExamen, ExamenPreguntaBE p_ExamenPregunta)
        {
            Boolean actualizar = false;
            querySQL = "UPDATE GRH_EXAMENPREGUNTA  SET CPREGUNTADES = @CPREGUNTADES, CPREGUNTATIPO = CPREGUNTATIPO " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_ExamenPregunta.CodigoPregunta);
            cmd.Parameters.AddWithValue("@CPREGUNTADES", p_ExamenPregunta.Pregunta);
            cmd.Parameters.AddWithValue("@CPREGUNTATIPO", p_ExamenPregunta.TipoPregunta);
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

        //Eliminar Pregunta sin Alternativa
        public Boolean EliminarPregunta(String p_CodigoExamen, String p_CodigoPregunta)
        {
            Boolean actualizar = false;
            querySQL = "UPDATE GRH_EXAMENPREGUNTA  SET CPREGUNTAEST = 'INA' " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
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
        
        //Generar Codigo 
        public String GenerarCodigoPregunta(String p_CodigoExamen)
        {
            String codigo;
            querySQL = "SELECT ISNULL(MAX(NPREGUNTACOD), 0) + 1 FROM GRH_EXAMENPREGUNTA " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
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

        //Buscar Pregunta
        public ExamenPreguntaBE BuscarPregunta(String p_CodigoExamen, String p_CodigoPregunta)
        {
            //oExamenPregunta = new ExamenPreguntaBE();
            querySQL = "SELECT NPREGUNTACOD, CPREGUNTADES, CPREGUNTATIPO, CPREGUNTAEST FROM GRH_EXAMENPREGUNTA " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD AND NPREGUNTACOD = @NPREGUNTACOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@NPREGUNTACOD", p_CodigoPregunta);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamenPregunta = new ExamenPreguntaBE(
                        rd.GetInt16(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetString(3)
                        );
                  /*  oExamenPregunta.CodigoPregunta = rd.GetInt16(0);
                    oExamenPregunta.Pregunta = rd.GetString(1);
                    oExamenPregunta.TipoPregunta = rd.GetString(2);
                    oExamenPregunta.EstadoPregunta = rd.GetString(3);*/
                }
                rd.Close();
            }
            catch (Exception)
            {
                oExamenPregunta = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return oExamenPregunta;
        }


        //Listar Pregunta con Alternativas
        /*
        public List<ExamenPreguntaBE> ListarPregunta_Alternativa(String p_codigoExamen)
        {
            lExamenPregunta = new List<ExamenPreguntaBE>();
            querySQL = "SELECT PreguntaCod, PreguntaDesc, PreguntaTipo, PreguntaEst FROM GRH_ExamenSMExamenPregunta " +
                        "WHERE ExamenCod = @codigoExamen";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@codigoExamen",p_codigoExamen);
            try {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read()){
                    oExamenPregunta = new ExamenPreguntaBE();
                    oExamenPregunta.CodigoPregunta = rd.GetInt16(0);
                    oExamenPregunta.Pregunta = rd.GetString(1);
                    oExamenPregunta.TipoPregunta = rd.GetString(2);
                    oExamenPregunta.EstadoPregunta = rd.GetString(3);
                    oExamenPregunta.ListaAlternativa = new PreguntaAlternativaDA().BuscarAlternativa(p_codigoExamen, rd.GetInt16(0).ToString());
                    lExamenPregunta.Add(oExamenPregunta);
                }
            }
            catch (Exception) {
                lExamenPregunta = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lExamenPregunta;
        }
        */

        //Guardar Pregunta con Alternativas
        /*
        public Boolean GuardarPregunta_Alternativa(String p_CodigoExamen, ExamenPreguntaBE p_ExamenPregunta) {
            Boolean guardar = false;
            querySQL = "INSERT INTO GRH_ExamenSMExamenPregunta (ExamenCod, PreguntaCod, PreguntaDesc, PreguntaTipo, PreguntaEst) " +
                        "VALUES (@ExamenCod, @PreguntaCod, @PreguntaDesc, @PreguntaTipo, @PreguntaEst)";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@ExamenCod", p_CodigoExamen);
            cmd.Parameters.AddWithValue("@PreguntaCod", p_ExamenPregunta.CodigoPregunta);
            cmd.Parameters.AddWithValue("@PreguntaDesc", p_ExamenPregunta.Pregunta);
            cmd.Parameters.AddWithValue("@PreguntaTipo", p_ExamenPregunta.TipoPregunta);
            cmd.Parameters.AddWithValue("@PreguntaEst", p_ExamenPregunta.EstadoPregunta);
            try{
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                foreach(PreguntaAlternativaBE oPreAlt in p_ExamenPregunta.ListaAlternativa){
                    new PreguntaAlternativaDA().GuardarAlternativa(p_CodigoExamen, p_ExamenPregunta.CodigoPregunta.ToString(), oPreAlt);
                }
                guardar = true;
            }
            catch (Exception){
                guardar = false;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return guardar;
        }
        */


  
    }
}
