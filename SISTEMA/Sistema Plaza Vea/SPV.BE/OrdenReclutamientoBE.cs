using System;

namespace SPV.BE
{
    public class OrdenReclutamientoBE
    {
        //Patron Composite
        #region "Atributos"
        private DateTime fecha;
        private String estado;
        private Int32 cantidadReclutar;
        #endregion

        #region "Propiedades"
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public Int32 CantidadReclutar
        {
            get { return cantidadReclutar; }
            set { cantidadReclutar = value; }
        }
        #endregion

        #region "Constructor"
        public OrdenReclutamientoBE(DateTime p_Fecha, String p_Estado, Int32 p_CantidadReclutar) {
            this.fecha = p_Fecha;
            this.estado = p_Estado;
            this.cantidadReclutar = p_CantidadReclutar;
        }
        #endregion
     }
}
