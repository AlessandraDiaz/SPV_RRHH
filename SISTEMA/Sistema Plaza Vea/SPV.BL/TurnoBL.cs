using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;

namespace SPV.BL
{
    public class TurnoBL
    {
        private TurnoDA oTurnoDA = new TurnoDA();
        public List<TurnoBE> ListarTurno() {
            return oTurnoDA.ListarTurno();
        }
    }
}
