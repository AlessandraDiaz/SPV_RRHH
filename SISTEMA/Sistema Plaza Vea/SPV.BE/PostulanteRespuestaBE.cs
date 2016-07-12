using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class PostulanteRespuestaBE
    {
        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoExamen { get; set; }
        public int CodigoPregunta { get; set; }
        public int CodigoOpcion { get; set; }
        public string Respuesta{ get; set; }
        public int Correcto { get; set; }
        public int PuntajePregunta { get; set; }

        [Display(Name = "Tiempo")]
        public string Tiempo { get; set; }
        [Display(Name = "Total de Preguntas")]
        public int TotalPreguntas { get; set; }
        [Display(Name = "Correctos")]
        public int CantidadCorrecto { get; set; }
        [Display(Name = "Incorrectos")]
        public int CantidadIncorrecto { get; set; }
        [Display(Name = "No Respondidas")]
        public int CantidadNoRespondidas { get; set; }
        [Display(Name = "Puntaje Total")]
        public int PuntajeTotal { get; set; }
        [Display(Name = "Puntaje Obtenido")]
        public int PuntajeObtenido { get; set; }

        #endregion
    }
}
