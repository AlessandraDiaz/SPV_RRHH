using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class CargoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoCargo;
        private String nombre;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoCargo
        {
            get { return codigoCargo; }
            set { codigoCargo = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

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

        #region "Constructor"

        public CargoBE()
        {
        }
        public CargoBE(Int32 p_CodigoCargo, String p_Nombre, Int16 p_Estado) {
            this.codigoCargo = p_CodigoCargo;
            this.nombre = p_Nombre;
            this.estado = p_Estado;
        }
        #endregion
    }
}
