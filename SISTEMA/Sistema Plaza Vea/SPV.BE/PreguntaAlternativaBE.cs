using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class PreguntaAlternativaBE
    {
        //Patron Composite.
        #region "Atributos"
        private Int16 codigoAlternativa;
        private String alternativa;
        private Int16 esCorrecta;
        private Int16 puntaje;
        private String estado;
        #endregion

        #region "Propiedades"
        public Int16 CodigoAlternativa
        {
            get { return codigoAlternativa; }
            set { codigoAlternativa = value; }
        }
        public String Alternativa
        {
            get { return alternativa; }
            set { alternativa = value; }
        }
        public Int16 EsCorrecta
        {
            get { return esCorrecta; }
            set { esCorrecta = value; }
        }
        public Int16 Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        public string NombreOpcionEx { get; set; }
        public int CorrectoEx { get; set; }
        public int EstadoEx { get; set; }
        public ExamenPreguntaBE Pregunta { get; set; }
        #endregion  

        #region "Constructor"

        public PreguntaAlternativaBE() { }

        public PreguntaAlternativaBE(Int16 p_CodigoAlternativa, String p_Alternativa, Int16 p_EsCorrecta, Int16 p_Puntaje, String p_Estado) {
            this.codigoAlternativa = p_CodigoAlternativa;
            this.alternativa = p_Alternativa;
            this.esCorrecta = p_EsCorrecta;
            this.puntaje = p_Puntaje;
            this.estado = p_Estado;
        }
        #endregion
    }
}
