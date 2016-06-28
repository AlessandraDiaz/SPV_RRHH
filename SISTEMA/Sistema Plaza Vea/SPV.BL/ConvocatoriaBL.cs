using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class ConvocatoriaBL
    {
        private ConvocatoriaDA oConvocatoriaDA = new ConvocatoriaDA();

        public List<ConvocatoriaBE> ListarConvocatoriaVigente() {
            return oConvocatoriaDA.ListarConvocatoriaVigente();
        }

        public Int32 ObtenerCantidadConvocatoria(String p_CodigoConvocatoria) {
            return oConvocatoriaDA.ObtenerCantidadConvocatoria(p_CodigoConvocatoria);
        }

        public Boolean RegistrarGanadorConvocatoria(String p_CodigoPostulante) {
            return oConvocatoriaDA.RegistrarGanadorConvocatoria(p_CodigoPostulante);
        }

        public Boolean CerrarConvocatoria(String p_CodigoConvocatoria) {
            return oConvocatoriaDA.CerrarConvocatoria(p_CodigoConvocatoria);
        }
    }
}
