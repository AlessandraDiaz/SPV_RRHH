using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class CampanaBE
    {
        #region "PropiedadesMySQL"
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaFin { get; set; }
        public int Estado { get; set; }
        #endregion
    }
}
