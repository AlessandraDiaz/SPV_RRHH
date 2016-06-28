using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;


namespace SPV.BL
{
    public class AreaTiendaBL
    {
        private AreaTiendaDA oAreaTiendaDA = new AreaTiendaDA();

        public Int32 ObtenerCapacidadLibre(String p_Usuario)
        {
            return oAreaTiendaDA.obtenerCapacidadLibre(p_Usuario);
        }


    }
}
