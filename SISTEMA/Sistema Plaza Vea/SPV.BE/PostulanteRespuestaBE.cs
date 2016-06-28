using System;

namespace SPV.BE
{
    public class PostulanteRespuestaBE
    {
        //Patron Composite
        #region "Atributos"
        private String alternativaRespuesta;
        #endregion

        #region "Propiedades"
        public String AlternativaRespuesta
        {
            get { return alternativaRespuesta; }
            set { alternativaRespuesta = value; }
        }
        #endregion

        #region "Constructor"
        public PostulanteRespuestaBE(String p_AlternativaRespuesta) {
            this.alternativaRespuesta = p_AlternativaRespuesta;
        }
        #endregion
    }
}
