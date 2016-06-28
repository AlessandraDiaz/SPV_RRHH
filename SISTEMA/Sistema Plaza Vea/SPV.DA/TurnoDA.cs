using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class TurnoDA
    {
        private List<TurnoBE> lTurno;
        private TurnoBE oTurno;
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        public List<TurnoBE> ListarTurno() {
            lTurno = new List<TurnoBE>();
            querySQL = "SELECT FORMAT(CONVERT(smalldatetime, DHORAINICIO),'HH:mm') , FORMAT(CONVERT(smalldatetime, DHORAFIN),'HH:mm'), CDIAINCIO, CDIAFIN, CDESCRIPCION FROM GRH_TURNO";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            try {
                cmd.Connection.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read()){
                    oTurno = new TurnoBE(0,
                                        rd.GetString(0),
                                        rd.GetString(1),
                                        rd.GetString(2),
                                        rd.GetString(3),
                                        rd.GetString(4), 
                                        0);
                    lTurno.Add(oTurno);
                }
                rd.Close();
            }
            catch (Exception) {
                lTurno = null;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }

            return lTurno;
        }

    }
}
