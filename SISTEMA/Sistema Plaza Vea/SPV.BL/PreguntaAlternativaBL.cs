using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class PreguntaAlternativaBL
    {
        PreguntaAlternativaDA oPreguntaAlternativaDA = new PreguntaAlternativaDA();

        public Boolean AgregarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, PreguntaAlternativaBE p_PreguntaAlternativa) { 
            return oPreguntaAlternativaDA.AgregarAlternativa(p_CodigoExamen, p_CodigoPregunta, p_PreguntaAlternativa);
        }

        public List<PreguntaAlternativaBE> BuscarListaAlternativa(String p_CodigoExamen, String p_CodigoPregunta){
            return oPreguntaAlternativaDA.BuscarListaAlternativa(p_CodigoExamen, p_CodigoPregunta);
        }

        public Boolean ActualizarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, PreguntaAlternativaBE p_PreguntaAlternativa){
            return oPreguntaAlternativaDA.ActualizarAlternativa(p_CodigoExamen, p_CodigoPregunta, p_PreguntaAlternativa);
        }

        public Boolean EliminarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, String p_CodigoAlternativa) {
            return oPreguntaAlternativaDA.EliminarAlternativa(p_CodigoExamen, p_CodigoPregunta, p_CodigoAlternativa);
        }

        public String GenerarCodigoAlternativa(String p_CodigoExamen, String p_CodigoPregunta) {
            return oPreguntaAlternativaDA.GenerarCodigoAlternativa(p_CodigoExamen, p_CodigoPregunta);
        }

        public PreguntaAlternativaBE BuscarAlternativa(String p_CodigoExamen, String p_CodigoPregunta, String p_CodigoAlternativa) {
            return oPreguntaAlternativaDA.BuscarAlternativa(p_CodigoExamen, p_CodigoPregunta, p_CodigoAlternativa);
        }

    }
}
