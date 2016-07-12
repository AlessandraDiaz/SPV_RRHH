using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class SolicitudPerfilBE
    {
        #region "PropiedadesMySQL"
        [Display(Name = "ID")]
        [Key]
        public int CodigoSolicitudPer { get; set; }
        [Display(Name = "Solicitud")]
        public SolicitudPersonalBE SolicitudPersonal { get; set; }
        [Display(Name = "Perfil")]
        public PerfilBE Perfil { get; set; }
        [Display(Name = "Cantidad Solicitada")]
        [Required(ErrorMessage = "Ingrese cantidad de vacantes")]
        public int CantidadSolicitudPer { get; set; }
        [Display(Name = "Requisitos")]
        [Required(ErrorMessage = "Ingrese Requisitos")]
        public string Requisitos { get; set; }
        [Display(Name = "Funciones")]
        [Required(ErrorMessage = "Ingrese Funciones")]
        public string Funciones { get; set; }
        [Display(Name = "Sueldo")]
        [Required(ErrorMessage = "Ingrese Sueldo")]
        public decimal Sueldo { get; set; }
        [Display(Name = "Estado")]
        public int EstadoItem { get; set; }
        #endregion
    }
}
