using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class CargoBE
    {
        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Funciones")]
        public string Funciones { get; set; }
        [Display(Name = "Requisitos")]
        public string Requisitos { get; set; }
        [Display(Name = "Sueldo Máximo")]
        public decimal SueldoMax { get; set; }
        [Display(Name = "Sueldo Mínimo")]
        public decimal SueldoMin { get; set; }
        [Display(Name = "Rango Sueldo")]
        public string RangoSueldo { get { return string.Concat(SueldoMin.ToString(), " - ", SueldoMax.ToString()); } }
        [Display(Name = "Estado")]
        public int EstadoCargo { get; set; }

        #endregion  
    }
}
