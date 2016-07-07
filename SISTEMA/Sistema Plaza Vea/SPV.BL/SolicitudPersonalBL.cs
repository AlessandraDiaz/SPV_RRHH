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
        public List<SolicitudPersonalBE> Listar(int tipoFiltro, string desc, int codigo, string fechaini,
                                                    string fechafin, int estado, int usuario, int local, int area)
        {
            return new SolicitudPersonalDA().Listar(tipoFiltro,desc, codigo,fechaini,fechafin,estado, usuario, local,area);
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
