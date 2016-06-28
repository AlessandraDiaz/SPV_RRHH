using System;

namespace SPV.BE
{
    public class OrdenApoyoBE
    {
        //Patron Composite
        #region "Atributos"
        private DateTime fechaRegistro;
        private String estado;
        #endregion

        #region "Propiedades"
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public OrdenApoyoBE(DateTime p_FechaRegistro, String p_Estado) {
            this.fechaRegistro = p_FechaRegistro;
            this.estado = p_Estado;
        }
        #endregion
    }
}
