using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class Convocatoria2BE
    {
        [Key]
        [Display (Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        public int CodTipoConvocatoria { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaFin { get; set; }

        public int CodSolicitud { get; set; }

        public int CodEstado { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        // Aditionals
        
        [Display(Name = "Tipo Convocatoria")]
        [Required]
        public string TipoConvocatoria { get; set; }

        [Display(Name = "Solicitud")]
        [Required]
        public string Solicitud { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public string Estado { get; set; }
    }
}
