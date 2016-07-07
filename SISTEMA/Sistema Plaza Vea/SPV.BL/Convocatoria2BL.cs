using SPV.BE;
using SPV.DA;
using System;
using System.Collections.Generic;

namespace SPV.BL
{
    public class Convocatoria2BL
    {
        public void Insert(Convocatoria2BE entidad)
        {
            try
            {
                new Convocatoria2DA().Insert(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Convocatoria2BE Get(int id)
        {
            try
            {
                return new Convocatoria2DA().Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Convocatoria2BE> Search(string id, string nombre, int? codTipoConvocatoria, DateTime? fechaInicio, DateTime? fechaFin, int? codTipoSolicitud)
        {
            try
            {
                return new Convocatoria2DA().Search(id, nombre, codTipoConvocatoria, fechaInicio, fechaFin, codTipoSolicitud);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
