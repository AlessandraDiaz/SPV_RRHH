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
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingrese descripción")]
        public string DescripcionSol { get; set; }

        [Display(Name = "Fecha Solicitud")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaSol { get; set; }
        [Display(Name = "Tipo Solicitud")]
        public ParametroBE TipoSolicitudSol { get; set; }
        [Display(Name = "Estado")]
        public ParametroBE EstadoSol { get; set; }
        public ListaPaginada<SolicitudPerfilBE> Detalle { get; set; }
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
