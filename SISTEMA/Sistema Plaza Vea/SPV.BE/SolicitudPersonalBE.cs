using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SPV.BE
{
    public class SolicitudPersonalBE
    {
        #region "PropiedadesMySQL"
        [Display(Name = "ID")]
        [Key]
        public int CodigoSol { get; set; }

        [Display(Name = "Código")]
        public string CodigoInterno { get; set; }

        [Display(Name = "Tipo Solicitud")]
        public ParametroBE TipoSolicitudSol { get; set; }

        [Display(Name = "Tipo Convocatoria")]
        public ParametroBE TipoConvocatoria { get; set; }

        [Display(Name = "Motivo")]
        public ParametroBE Motivo { get; set; }

        [Display(Name = "Fecha Solicitud")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FechaSol { get; set; }
        public string GetStringFechaSol
        {
            get { return FechaSol != null ? FechaSol.Value.ToShortDateString() : string.Empty; }
        }

        [Display(Name = "Fecha Presentación")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FechaPresentacion { get; set; }
        public string GetStringFechaPresentacion
        {
            get { return FechaPresentacion != null ? FechaPresentacion.Value.ToShortDateString() : string.Empty; }
        }

        [Display(Name = "Fecha Envío")]
        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FechaEnvio { get; set; }
        public string GetStringFechaEnvio
        {
            get { return FechaEnvio != null ? FechaEnvio.Value.ToShortDateString() : string.Empty; }
        }

        [Display(Name = "Campaña")]
        public CampanaBE Campana { get; set; }

        [Display(Name = "Cargo")]
        public CargoBE Cargo { get; set; }

        [Display(Name = "Sueldo")]
        public decimal SueldoSolicitud { get; set; }

        [Display(Name = "Moneda")]
        public ParametroBE MonedaSolicitud { get; set; }

        [Display(Name = "Vacantes")]
        public int Cantidad { get; set; }

        [Display(Name = "Observación")]
        public string Comentarios { get; set; }

        [Display(Name = "Estado")]
        public ParametroBE EstadoSol { get; set; }

        public int LocalUsuario { get; set; }

        public int CodigoUsuario { get; set; }

        public Convocatoria2BE Convocatoria { get; set; }

        #endregion

        #region "Constructor"

        public SolicitudPersonalBE() {
            FechaSol = DateTime.Now;
        }
        #endregion

    }
}
