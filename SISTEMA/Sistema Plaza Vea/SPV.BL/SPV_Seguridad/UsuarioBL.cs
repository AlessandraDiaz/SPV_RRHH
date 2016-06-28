using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA.SPV_Seguridad;

namespace SPV.BL.SPV_Seguridad
{
    public class UsuarioBL
    {
        public delegate void ErrorDelegate(object sender, Exception ex);
        public event ErrorDelegate ErrorEvent;

        public UsuarioBE ValidaLogeoUsuario(String usuario, String pass, out String indLogeo, out String msgLogeo)
        {
            UsuarioDA oUsuarioDA = new UsuarioDA();
            UsuarioBE oUsuarioBE = null;
            indLogeo = "0";
            msgLogeo = String.Empty;
            try
            {
                oUsuarioBE = oUsuarioDA.ValidaLogeoUsuario(usuario, pass);
                if (oUsuarioBE == null)
                {
                    indLogeo = "1";
                    msgLogeo = "Usuario no existe.";
                }
            }
            catch (Exception ex)
            {
                ErrorEvent(this, ex);
            }
            return oUsuarioBE;
        }
    }
}