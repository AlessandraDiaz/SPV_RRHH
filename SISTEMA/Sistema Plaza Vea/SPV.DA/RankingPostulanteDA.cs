using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SPV.BE;

namespace SPV.DA
{
    public class RankingPostulanteDA
    {
        private String querySQL;
        private RankingPostulanteBE oRankingPostulante;
        private List<RankingPostulanteBE> lRankingPostulante;
        private DataBaseDA cn = new DataBaseDA();

        public List<RankingPostulanteBE> ListaRankingPostulanteConvocatoriaVigente(String p_CodigoConvocatoria) {
            querySQL = "SELECT POS.CPOSTULANTECOD, POS.CNOMBRES + ' ' + POS.CAPELLIDOPATERNO + ' ' + POS.CAPELLIDOMATERNO, RAN.NNOTAEVALPERFIL, RAN.NNOTAEXAPSICOLOGICO, RAN.NNOTAEXAPSICOTECNICO, RAN.NNOTAENTREVISTA  FROM GRH_RANKINGPOSTULANTE RAN " +
                        "INNER JOIN GRH_POSTULANTE POS ON POS.CPOSTULANTECOD = RAN.CPOSTULANTECOD " +
                        "INNER JOIN GRH_CONVOCATORIA CON ON CON.CCONVOCATORIACOD = RAN.CCONVOCATORIACOD " +
                        "WHERE RAN.CCONVOCATORIACOD = 'CV000001' AND ((RAN.NNOTAENTREVISTA + RAN.NNOTAEVALPERFIL + RAN.NNOTAEXAPSICOLOGICO + RAN.NNOTAEXAPSICOTECNICO) / 4) >= CON.NNOTAAPROVADORIA AND POS.NESTADO = 0 " +
                        "ORDER BY RAN.NNOTAEVALPERFIL DESC, RAN.NNOTAEXAPSICOLOGICO DESC, RAN.NNOTAEXAPSICOTECNICO DESC, RAN.NNOTAENTREVISTA DESC";
            lRankingPostulante = new List<RankingPostulanteBE>();
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("", p_CodigoConvocatoria);
            try {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) {
                    oRankingPostulante = new RankingPostulanteBE(rd.GetString(0),
                                                                rd.GetString(1),
                                                                rd.GetInt32(2).ToString(),
                                                                rd.GetInt32(3).ToString(),
                                                                rd.GetInt32(4).ToString(),
                                                                rd.GetInt32(5).ToString());
                    lRankingPostulante.Add(oRankingPostulante);
                }
                rd.Close();
            }
            catch (Exception) {
                lRankingPostulante = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }

            return lRankingPostulante;
        }

    }
}
