using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class UsuarioGRH_BL
    {
        public UsuarioBE Login(String p_Usuario, String p_Password)
        {
            return new UsuarioGRH_DA().Login(p_Usuario, p_Password);
        }
    }
}
