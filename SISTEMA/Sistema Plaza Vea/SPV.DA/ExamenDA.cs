using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class ExamenDA
    {
        private ExamenBE oExamen;
        private List<ExamenBE> lExamen;
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();


        //Listar Examenes
        public List<ExamenBE> ListarExamen()
        {
            querySQL = "SELECT NEXAMENCOD, CPERFILNOM, NEXAMENTIPO, CEXAMENNOM, CEXAMENDESC, CEXAMENEST FROM GRH_EXAMEN WHERE CEXAMENEST='ACT'";
            lExamen = new List<ExamenBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamen = new ExamenBE(
                        rd.GetInt16(0),
                        rd.GetString(1),
                        rd.GetInt16(2).ToString(),
                        rd.GetString(3),
                        rd.GetString(4),
                        rd.GetString(5)
                        );
                    /*oExamen.Codigo = rd.GetInt16(0);
                    oExamen.Nombre = rd.GetString(1);
                    oExamen.Descripcion = rd.GetString(2);
                    oExamen.Estado = rd.GetString(3);
                    oExamen.TipoExamen = rd.GetInt16(4).ToString();*/
                    lExamen.Add(oExamen);
                }
                rd.Close();
            }
            catch (Exception)
            {
                lExamen = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lExamen;
        }

        //Buscar Examen
        public ExamenBE BuscarExamen(String p_CodigoExamen) {
            querySQL = "SELECT NEXAMENCOD, CPERFILNOM, NEXAMENTIPO, CEXAMENNOM, CEXAMENDESC, CEXAMENEST  FROM GRH_EXAMEN " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD";
            oExamen = new ExamenBE(0, null, null, null ,null ,null);
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamen = new ExamenBE(
                        rd.GetInt16(0),
                        rd.GetString(1),
                        rd.GetInt16(2).ToString(),
                        rd.GetString(3),
                        rd.GetString(4),
                        rd.GetString(5)
                        );
                  /*  oExamen.Codigo = rd.GetInt16(0);
                    oExamen.Nombre = rd.GetString(1);
                    oExamen.Descripcion = rd.GetString(2);
                    oExamen.Estado = rd.GetString(3);
                    oExamen.TipoExamen = rd.GetInt16(4).ToString();*/
                }
                rd.Close();
            }
            catch (Exception)
            {
                oExamen = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return oExamen;
        }

        //Agregar Examen
        public String AgregarExamen(ExamenBE p_Examen)
        {
            String codigo;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = cn.getConecction();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GRH_SP_AGREGAREXAMEN";
                cmd.Parameters.AddWithValue("@ExamenNom", p_Examen.Nombre);
                cmd.Parameters.AddWithValue("@CNOMBREPERFIL", p_Examen.Perfil);
                cmd.Parameters.AddWithValue("@ExamenDesc", p_Examen.Descripcion);
                cmd.Parameters.AddWithValue("@ExamenTipo", p_Examen.TipoExamen);
                cmd.Connection.Open();
                codigo = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                codigo = "0";
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return codigo;
        }

        //Actualizar Examen
        public Boolean ActualizarExamen(ExamenBE p_Examen)
        {
            Boolean actualizar = false;
            querySQL = "UPDATE GRH_EXAMEN SET CEXAMENNOM = @CEXAMENNOM, CEXAMENDESC = @CEXAMENDESC, NEXAMENTIPO = @NEXAMENTIPO " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_Examen.Codigo);
            cmd.Parameters.AddWithValue("@CEXAMENNOM", p_Examen.Nombre);
            cmd.Parameters.AddWithValue("@CEXAMENDESC", p_Examen.Descripcion);
            cmd.Parameters.AddWithValue("@NEXAMENTIPO", p_Examen.TipoExamen);
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

        //Eliminar Examen
        public Boolean EliminarExamen(String p_CodigoExamen)
        {
            Boolean eliminar = false;
            querySQL = "UPDATE GRH_EXAMEN SET CEXAMENEST = 'INA' " +
                        "WHERE NEXAMENCOD = @NEXAMENCOD";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@NEXAMENCOD", p_CodigoExamen);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                eliminar = true;
            }
            catch (Exception)
            {
                eliminar = false;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return eliminar;
        }

        /*
        
        //Listar Examenes con Preguntas
        public List<ExamenBE> ListarExamen_Pregunta()
        {
            querySQL = "SELECT [ExamenCod], [ExamenNom], [ExamenDesc], REPLACE([ExamenEst], 'ACT' ,'ACTIVO') 'ExamenEst', [ExamenTipo] " +
                       "FROM [SGS_PlazaVea].[dbo].[GRH_Examen]" +
                       "WHERE [ExamenEst] = 'ACT'";
            lExamen = new List<ExamenBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamen = new ExamenBE();
                    oExamen.Codigo = rd.GetInt16(0);
                    oExamen.Nombre = rd.GetString(1);
                    oExamen.Descripcion = rd.GetString(2);
                    oExamen.Estado = rd.GetString(3);
                    oExamen.TipoExamen = rd.GetInt16(4).ToString();
                    oExamen.ListaPregunta = new ExamenPreguntaDA().ListarPregunta(rd.GetInt16(0).ToString());
                    lExamen.Add(oExamen);
                }
                rd.Close();
            }
            catch (Exception)
            {
                lExamen = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lExamen;
        }

        //Listar Examenes con Preguntas con Alternativas
        public List<ExamenBE> ListarExamen_Pregunta_Alternativa()
        {
            querySQL = "SELECT [ExamenCod], [ExamenNom], [ExamenDesc], REPLACE([ExamenEst], 'ACT' ,'ACTIVO') 'ExamenEst', [ExamenTipo] " +
                       "FROM [SGS_PlazaVea].[dbo].[GRH_Examen]" +
                       "WHERE [ExamenEst] = 'ACT'";
            lExamen = new List<ExamenBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamen = new ExamenBE();
                    oExamen.Codigo = rd.GetInt16(0);
                    oExamen.Nombre = rd.GetString(1);
                    oExamen.Descripcion = rd.GetString(2);
                    oExamen.Estado = rd.GetString(3);
                    oExamen.TipoExamen = rd.GetInt16(4).ToString();
                    oExamen.ListaPregunta = new ExamenPreguntaDA().ListarPregunta_Alternativa(rd.GetInt16(0).ToString());
                    lExamen.Add(oExamen);
                }
                rd.Close();
            }
            catch (Exception)
            {
                lExamen = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return lExamen;
        }

        //Buscar Examen con Preguntas  
        public ExamenBE BuscarExamen_Pregunta(String p_CodigoExamen)
        {
            oExamen = new ExamenBE();
            querySQL = "SELECT [ExamenCod], [ExamenNom], [ExamenDesc], REPLACE([ExamenEst], 'ACT' ,'ACTIVO') 'ExamenEst', [ExamenTipo] " +
                       "FROM [SGS_PlazaVea].[dbo].[GRH_Examen]" +
                       "WHERE [ExamenEst] = 'ACT' AND [ExamenCod]= @ExamenCod";
           
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@ExamenCod", p_CodigoExamen);
            try
            {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    oExamen.Codigo = rd.GetInt16(0);
                    oExamen.Nombre = rd.GetString(1);
                    oExamen.Descripcion = rd.GetString(2);
                    oExamen.Estado = rd.GetString(3);
                    oExamen.TipoExamen = rd.GetInt16(4).ToString();
                    oExamen.ListaPregunta = new ExamenPreguntaDA().ListarPregunta(rd.GetInt16(0).ToString());
                }
                rd.Close();
            }
            catch (Exception)
            {
                oExamen = null;
            }
            finally
            {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return oExamen;
        }

        //Agregar Examen y que me retorne el Codigo que ingreso
        public String AgregarExamen(ExamenBE p_Examen) {
            String codigo;
            querySQL = "exec sp_IngresarExamen @ExamenNom, @ExamenDesc, @ExamenTipo";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@ExamenNom", p_Examen.Nombre);
            cmd.Parameters.AddWithValue("@ExamenDesc", p_Examen.Descripcion);
            cmd.Parameters.AddWithValue("@ExamenTipo", p_Examen.TipoExamen);
            //SqlTransaction tx = null;
            try
            {
                cmd.Connection.Open();
              //  tx = cmd.Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
              //  tx.Commit();

                cmd.Parameters.Clear();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT MAX(ExamenCod) FROM GRH_Examen";
                codigo = cmd.ExecuteScalar().ToString();
            }
            catch (Exception) {
                //tx.Rollback();
                codigo = "0";
            }
            finally {
                cmd.Connection.Close();
                cmd.Parameters.Clear();
            }
            return codigo;
        }

   */
    
    }
}
