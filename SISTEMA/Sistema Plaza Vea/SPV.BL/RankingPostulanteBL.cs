using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;

namespace SPV.BL
{
    public class RankingPostulanteBL {


        private RankingPostulanteDA oRankingPostulanteDA = new RankingPostulanteDA();

        public List<RankingPostulanteBE> ListaRankingPostulanteConvocatoriaVigente(String p_CodigoConvocatoria)
        {
            return oRankingPostulanteDA.ListaRankingPostulanteConvocatoriaVigente(p_CodigoConvocatoria);
        }

    }
}
