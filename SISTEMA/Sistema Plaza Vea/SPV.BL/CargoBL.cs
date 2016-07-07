using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class CargoBL
    {
        public List<CargoBE>ListaCargo(CargoBE cargo)
        {
            return new CargoDA().ListarCargo(cargo);
        }

    }
}
