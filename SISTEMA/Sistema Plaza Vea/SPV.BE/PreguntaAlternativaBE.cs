using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class PreguntaAlternativaBE
    {
        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        public string NombreOpcionEx { get; set; }
        public int CorrectoEx { get; set; }
        public int EstadoEx { get; set; }
        public ExamenPreguntaBE Pregunta { get; set; }
        #endregion
    }
}
