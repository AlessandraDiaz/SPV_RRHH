using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class ColaboradorBL
    {
        private ColaboradorDA oColaboradorDA = new ColaboradorDA();
        
        public Int32 ObtenerCodigoCargoColaborador(String p_CodigoUsuario) {
            return oColaboradorDA.ObtenerCodigoCargoColaborador(p_CodigoUsuario);
        }

        public Int32 ObtenerCodigoColaborador(String p_CodigoUsuario) {
            return oColaboradorDA.ObtenerCodigoColaborador(p_CodigoUsuario);
        }

        public Int32 ObtenerContratoColaborador(String p_CodigoUsuario)
        {
            return oColaboradorDA.ObtenerContratoColaborador(p_CodigoUsuario);
        }

        public List<ColaboradorBE> ListarColaboradores(ColaboradorBE colaborador)
        {
            return new ColaboradorDA().ListarColaboradores(colaborador);
        }
    }
}
