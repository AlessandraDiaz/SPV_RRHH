using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class CargoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoCargo;
        private String nombre;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoCargo
        {
            get { return codigoCargo; }
            set { codigoCargo = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public CargoBE(Int32 p_CodigoCargo, String p_Nombre, Int16 p_Estado) {
            this.codigoCargo = p_CodigoCargo;
            this.nombre = p_Nombre;
            this.estado = p_Estado;
        }
        #endregion
    }
}
