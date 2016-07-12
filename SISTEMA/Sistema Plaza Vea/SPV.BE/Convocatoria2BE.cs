using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class Convocatoria2BE
    {
        [Key]
        [Display (Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Código")]
        public string CodigoInterno { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInicio { get; set; }

        public string GetStringFechaInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaFin { get; set; }

        public string GetStringFechaFin { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Solicitud")]
        [Required]
        public SolicitudPersonalBE Solicitud { get; set; }

        public ListaPaginada<SolicitudPersonalBE> ListaSolicitud { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public ParametroBE Estado { get; set; }

        [Display(Name = "Fase")]
        [Required]
        public ParametroBE Fase { get; set; }
        public int SolicitudID { get; set; }

        public ListaPaginada<ColaboradorBE> ListaColaborador { get; set; }
    }
}
