using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SPV.DA
{
    public class CurriculumVitaeDA
    {
        private String qSQL;
        DataBaseDA dbRRHH;

        public CurriculumVitaeBE ObtenerCVByPostulante(int codigoPostulante)
        {
            dbRRHH = new DataBaseDA();
            CurriculumVitaeBE curriculum = null;
            try
            {
                qSQL = "SPS_CV_BY_POSTULANTE";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigoPostulante);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        curriculum = new CurriculumVitaeBE();
                        curriculum.ID = (Int32)rd[0];
                        curriculum.Profesion = rd[1].ToString() != "" ? (String)rd[1] : "";
                        curriculum.NivelAcademico = rd[2].ToString() != "" ? (String)rd[2] : "";
                        curriculum.CentroDeEstudios = rd[3].ToString() != "" ? (String)rd[3] : "";
                        curriculum.Anio = rd[4].ToString() != "" ? (Int32)rd[4] : 0;

                        curriculum.Trabajo1 = rd[5].ToString() != "" ? (String)rd[5] : "";
                        curriculum.Periodo1 = rd[6].ToString() != "" ? (String)rd[6] : "";
                        curriculum.Funciones1 = rd[7].ToString() != "" ? (String)rd[7] : "";
                        curriculum.Trabajo2 = rd[8].ToString() != "" ? (String)rd[8] : "";
                        curriculum.Periodo2 = rd[9].ToString() != "" ? (String)rd[9] : "";
                        curriculum.Funciones2 = rd[10].ToString() != "" ? (String)rd[10] : "";
                        curriculum.Trabajo3 = rd[11].ToString() != "" ? (String)rd[11] : "";
                        curriculum.Periodo3 = rd[12].ToString() != "" ? (String)rd[12] : "";
                        curriculum.Funciones3 = rd[13].ToString() != "" ? (String)rd[13] : "";
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

            return curriculum;
        }

    }
}
