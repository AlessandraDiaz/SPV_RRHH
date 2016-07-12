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
        public List<PerfilBE> ListaPerfil(PerfilBE perfil)
        {
            return new PerfilDA().ListarPerfil(perfil);
        }
    }
}
