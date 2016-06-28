using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;
using System.Data.SqlClient;

namespace SPV.BL
{
    public class ExamenBL
    {
        private ExamenDA oExamenDA = new ExamenDA();
      
        public List<ExamenBE> ListarExamen() {
            return oExamenDA.ListarExamen();
        }

        public ExamenBE BuscarExamen(String p_CodigoExamen) {
            return oExamenDA.BuscarExamen(p_CodigoExamen);
        }

        public String AgregarExamen(ExamenBE p_Examen) {
            return oExamenDA.AgregarExamen(p_Examen);
        }

        public Boolean ActualizarExamen(ExamenBE p_Examen){
            return oExamenDA.ActualizarExamen(p_Examen);
        }

        public Boolean EliminarExamen(String p_CodigoExamen) {
            return oExamenDA.EliminarExamen(p_CodigoExamen);
        }
    }
}
