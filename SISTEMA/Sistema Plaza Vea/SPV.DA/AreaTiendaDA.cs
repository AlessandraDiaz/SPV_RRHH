using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SPV.DA
{
    public class AreaTiendaDA
    {
        private String querySQL;
        private DataBaseDA cn = new DataBaseDA();

        public Int32 obtenerCapacidadLibre( String p_CodigoUsuario)
        {

            Int32 CodigoArea = new ColaboradorDA().ObtenerCodigoAreaColaborador(p_CodigoUsuario);
            Int32 capacidadLibre;
            querySQL = "SELECT ((SELECT NCAPACIDADCOLABORADORES FROM GRH_AREATIENDA WHERE NAREATIENDACOD = @CodigoArea) - COUNT(*) ) " +
                        "FROM GRH_COLABORADOR COL " +
                        "INNER JOIN GRH_AREATIENDA ATI ON COL.NAREATIENDACOD = ATI.NAREATIENDACOD "+
                        "WHERE ATI.NAREATIENDACOD = @CodigoArea";
            SqlCommand cmd = new SqlCommand(querySQL, cn.getConecction());
            cmd.Parameters.AddWithValue("@CodigoArea", CodigoArea);
            try {
                cmd.Connection.Open();
                capacidadLibre = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception) {
                capacidadLibre = 0;
            }
            finally {
                cmd.Connection.Close();
                querySQL = String.Empty;
            }
            return capacidadLibre;
        }
    }
}
