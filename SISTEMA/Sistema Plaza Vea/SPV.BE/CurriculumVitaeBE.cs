using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class CurriculumVitaeBE
    {
        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profesion")]
        public string Profesion { get; set; }
        [Display(Name = "Nivel Académico")]
        public string NivelAcademico { get; set; }
        [Display(Name = "Centro de Estudios")]
        public string CentroDeEstudios { get; set; }
        [Display(Name = "Año de Egreso")]
        public int Anio { get; set; }
        [Display(Name = "Trabajo 1")]
        public string Trabajo1 { get; set; }
        [Display(Name = "Periodo Laboral 1")]
        public string Periodo1 { get; set; }
        [Display(Name = "Funciones 1")]
        public string Funciones1 { get; set; }
        [Display(Name = "Trabajo 2")]
        public string Trabajo2 { get; set; }
        [Display(Name = "Periodo Laboral 2")]
        public string Periodo2 { get; set; }
        [Display(Name = "Funciones 2")]
        public string Funciones2 { get; set; }
        [Display(Name = "Trabajo 3")]
        public string Trabajo3 { get; set; }
        [Display(Name = "Periodo Laboral 3")]
        public string Periodo3 { get; set; }
        [Display(Name = "Funciones 3")]
        public string Funciones3 { get; set; }

        #endregion
    }
}
