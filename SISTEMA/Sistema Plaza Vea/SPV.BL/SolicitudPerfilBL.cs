using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class SolicitudPerfilBL
    {
        public List<SolicitudPerfilBE> Listar(SolicitudPerfilBE solicitudPerfil)
        {
            return new SolicitudPerfilDA().Listar(solicitudPerfil);
        }

        public SolicitudPerfilBE GetSolicitudPerfilByID(int Id)
        {
            return new SolicitudPerfilDA().GetSolicitudPerfilByID(Id);
        }

        public Int32 IngresarSolicitudPerfil(SolicitudPerfilBE solicitudPerfil)
        {
            return new SolicitudPerfilDA().IngresarSolicitudPerfil(solicitudPerfil);
        }

        public SolicitudPerfilBE UpdateSolicitudPerfil(SolicitudPerfilBE solicitudPerfil)
        {
            return new SolicitudPerfilDA().UpdateSolicitudPerfil(solicitudPerfil);
        }

        public Int32 EliminarSolicitudPerfil(int id)
        {
            return new SolicitudPerfilDA().EliminarSolicitudPerfil(id);
        }

    }
}
