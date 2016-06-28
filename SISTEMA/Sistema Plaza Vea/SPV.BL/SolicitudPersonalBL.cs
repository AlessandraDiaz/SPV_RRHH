using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class SolicitudPersonalBL
    {
        public List<SolicitudPersonalBE> Listar(SolicitudPersonalBE solicitud)
        {
            return new SolicitudPersonalDA().Listar(solicitud);
        }

        public SolicitudPersonalBE GetSolicitudByID(int Id)
        {
            return new SolicitudPersonalDA().GetSolicitudByID(Id);
        }

        public Int32 IngresarSolicitudPersonal(SolicitudPersonalBE solicitud)
        {
            return new SolicitudPersonalDA().IngresarSolicitudPersonal(solicitud);
        }

        public SolicitudPersonalBE UpdateSolicitud(SolicitudPersonalBE solicitud)
        {
            return new SolicitudPersonalDA().UpdateSolicitud(solicitud);
        }
        public Int32 EliminarSolicitudPersonal(int id)
        {
            return new SolicitudPersonalDA().EliminarSolicitudPersonal(id);
        }
    }
}
