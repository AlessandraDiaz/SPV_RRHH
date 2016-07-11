using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ExamenPreguntaBE
    {
        //Patron Composite.
        #region "Atributos"
        private Int16 codigoPregunta;
        private String pregunta;
        private String tipoPregunta;
        private String estadoPregunta;
        private List<PreguntaAlternativaBE> listaAlternativa;
        #endregion
        
        #region "Propiedades"
        public Int16 CodigoPregunta
        {
            get { return codigoPregunta; }
            set { codigoPregunta = value; }
        }
        public String Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }
        public String TipoPregunta
        {
            get { return tipoPregunta; }
            set { tipoPregunta = value; }
        }
        public String EstadoPregunta
        {
            get { return estadoPregunta; }
            set { estadoPregunta = value; }
        }
        public List<PreguntaAlternativaBE> ListaAlternativa
        {
            get { return listaAlternativa; }
            set { listaAlternativa = value; }
        }
        #endregion

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

        #region "Constructor"

        public ExamenPreguntaBE() { }
        public ExamenPreguntaBE(Int16 p_CodigoPregunta, String p_Pregunta, String p_TipoPregunta, String p_EstadoPregunta) {
            this.codigoPregunta = p_CodigoPregunta;
            this.pregunta = p_Pregunta;
            this.tipoPregunta = p_TipoPregunta;
            this.estadoPregunta = p_EstadoPregunta;
            this.listaAlternativa = new List<PreguntaAlternativaBE>();
        }
        #endregion
       
    }
}
