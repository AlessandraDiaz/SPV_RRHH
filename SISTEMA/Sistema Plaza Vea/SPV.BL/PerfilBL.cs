using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class PerfilBL
    {
        private PerfilDA oPerfilDA = new PerfilDA();

        public List<PerfilBE> ListaPerfil(PerfilBE perfil)
        {
            return oPerfilDA.ListarPerfil(perfil);
        }

        public PerfilBE BuscarPerfil(Int32 p_CodigoPerfil) {
            return oPerfilDA.BuscarPefil(p_CodigoPerfil);
        }
    }
}
