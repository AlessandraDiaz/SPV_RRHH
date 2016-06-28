using System;

namespace SPV.BE
{
    public class ListaDocumentoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 dni;
        private Int32 partidaMatrimonio;
        private Int32 antecedentesPenales;
        private Int32 antecedentesPoliciales;
        #endregion

        #region "Propiedades"
        public Int32 Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public Int32 PartidaMatrimonio
        {
            get { return partidaMatrimonio; }
            set { partidaMatrimonio = value; }
        }
        public Int32 AntecedentesPenales
        {
            get { return antecedentesPenales; }
            set { antecedentesPenales = value; }
        }
        public Int32 AntecedentesPoliciales
        {
            get { return antecedentesPoliciales; }
            set { antecedentesPoliciales = value; }
        }
        #endregion

        #region "Constructor"
        public ListaDocumentoBE(Int32 p_Dni, Int32 p_PartidaMatrimonio, Int32 p_AntecedentesPenales, Int32 p_AntecedentesPoliciales) {
            this.dni = p_Dni;
            this.partidaMatrimonio = p_PartidaMatrimonio;
            this.antecedentesPenales = p_AntecedentesPenales;
            this.antecedentesPoliciales = p_AntecedentesPoliciales;
        }
        #endregion
    }
}
