using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;
namespace SPV.BL
{
    public class ExamenPreguntaBL
    {
        private ExamenPreguntaDA oExamenPregunta = new ExamenPreguntaDA();

        public List<ExamenPreguntaBE> BuscarListaPregunta(String p_CodigoExamen){
            return oExamenPregunta.BuscarListarPregunta(p_CodigoExamen);
        }

        public String GenerarCodigoPregunta(String p_CodigoExamen){
            return oExamenPregunta.GenerarCodigoPregunta(p_CodigoExamen);
        }

        public Boolean AgregarPregunta(String p_CodigoExamen, ExamenPreguntaBE p_ExamenPregunta){
            return oExamenPregunta.AgregarPregunta(p_CodigoExamen, p_ExamenPregunta);
        }

        public Boolean ActualizarPregunta(String p_CodigoExamen, ExamenPreguntaBE p_ExamenPregunta){
            return oExamenPregunta.ActualizarPregunta(p_CodigoExamen, p_ExamenPregunta);
        }

        public Boolean EliminarPregunta(String p_CodigoExamen, String p_CodigoPregunta){
            return oExamenPregunta.EliminarPregunta(p_CodigoExamen, p_CodigoPregunta);
        }

        public ExamenPreguntaBE BuscarPregunta(String p_CodigoExamen, String p_CodigoPregunta){
            return oExamenPregunta.BuscarPregunta(p_CodigoExamen, p_CodigoPregunta);
        }
    }
}
