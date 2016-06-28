using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class UsuarioGRH_BE
    {  //Patron Composite
        #region "Atributos"
        private String usuario;
        private String password;
        #endregion

        #region "Propiedades"
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region "Constructor"
        public UsuarioGRH_BE(String p_Usuario, String p_Password)
        {
            this.usuario = p_Usuario;
            this.password = p_Password;
        }
        #endregion
    }
}
