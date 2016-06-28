using System;

namespace SPV.BE
{
    public class SedeBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoSede;
        private String nombre;
        private String direccion;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoSede
        {
            get { return codigoSede; }
            set { codigoSede = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public SedeBE(Int32 p_CodigoSede, String p_Nombre, String p_Direccion, Int16 p_Estado) {
            this.codigoSede = p_CodigoSede;
            this.nombre = p_Nombre;
            this.direccion = p_Direccion;
            this.estado = p_Estado;
        }
        #endregion
      }
}
