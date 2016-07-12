using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ExamenPreguntaBE
    {
        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Pregunta")]
        public string PreguntaEx { get; set; }
        [Display(Name = "Tipo de pregunta")]
        public ParametroBE TipoPreguntaEx { get; set; }
        [Display(Name ="Imagen")]
        public string ImagenEx { get; set; }
        [Display(Name = "Puntaje")]
        public int PuntajeEx { get; set; }
        public int TipoControlEx { get; set; }
        public int EstadoEx { get; set; }
        public ExamenBE Examen { get; set; }
        public List<PreguntaAlternativaBE> listaOpciones { get; set; }
        #endregion  
    }
}
