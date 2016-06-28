using System;

namespace SPV.BE
{
    public class PerfilRequisitoBE
    {
        //Patron Composite
        #region "Atributos"
        private String requisito;
        private Int16 estado;

        #endregion

        #region "Propiedades"
        public String Requisito
        {
            get { return requisito; }
            set { requisito = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public PerfilRequisitoBE(String p_Requisito, Int16 p_Estado) {
            this.requisito = p_Requisito;
            this.estado = p_Estado;
        }
        #endregion
    }
}
