using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class PostulanteDocumentoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int16 estado;        
        #endregion

        #region "Propiedades"
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }    
        #endregion

        #region "Constructor"
        public  PostulanteDocumentoBE (Int16 p_Estado) {
            this.estado = p_Estado;
        }
        #endregion
    }
}
