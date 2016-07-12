using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SPV.BE
{
    public class SolicitudPersonalBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoSolicitudPersonal;
        private DateTime fechaSolicitud;
        private DateTime fechaRevisada;
        private String tipoSolicitud;
        private String motivoSolicitud;
        private String horario;
        private String tiempoContrato;
        private String tiempoApoyo;
        private String descripcion;
        private Double sueldoBase;
        private DateTime fechaMaxAtenderse;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoSolicitudPersonal
        {
            get { return codigoSolicitudPersonal; }
            set { codigoSolicitudPersonal = value; }
        }
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }
        public DateTime FechaRevisada
        {
            get { return fechaRevisada; }
            set { fechaRevisada = value; }
        }
        public String TipoSolicitud
        {
            get { return tipoSolicitud; }
            set { tipoSolicitud = value; }
        }
        public String MotivoSolicitud
        {
            get { return motivoSolicitud; }
            set { motivoSolicitud = value; }
        }
        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }
        public String TiempoContrato
        {
            get { return tiempoContrato; }
            set { tiempoContrato = value; }
        }
        public String TiempoApoyo
        {
            get { return tiempoApoyo; }
            set { tiempoApoyo = value; }
        }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Double SueldoBase
        {
            get { return sueldoBase; }
            set { sueldoBase = value; }
        }
        public DateTime FechaMaxAtenderse
        {
            get { return fechaMaxAtenderse; }
            set { fechaMaxAtenderse = value; }
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
        public SolicitudPersonalBE(Int32 p_CodigoSolicitudPersonal, DateTime p_FechaSolicitud, DateTime p_FechaRevisada,String p_TipoSolicitud, String p_MotivoSolicitud, String p_Horario, String p_TiempoContrato, String p_TiempoApoyo, String p_Descripcion, Double p_SueldoBase, DateTime p_FechaMaxAtenderse, Int16 p_Estado)
        {
            this.codigoSolicitudPersonal = p_CodigoSolicitudPersonal;
            this.fechaSolicitud = p_FechaSolicitud;
            this.fechaRevisada = p_FechaRevisada;
            this.tipoSolicitud = p_TipoSolicitud;
            this.motivoSolicitud = p_MotivoSolicitud;
            this.horario = p_Horario;
            this.tiempoContrato = p_TiempoContrato;
            this.tiempoApoyo = p_TiempoApoyo;
            this.descripcion = p_Descripcion;
            this.sueldoBase = p_SueldoBase;
            this.fechaMaxAtenderse = p_FechaMaxAtenderse;
            this.estado = p_Estado;
        }
        #endregion
    }
}
