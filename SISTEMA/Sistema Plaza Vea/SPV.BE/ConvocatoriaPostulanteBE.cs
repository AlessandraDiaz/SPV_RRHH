using System;

namespace SPV.BE
{
    public class ConvocatoriaPostulanteBE
    {
        //Patron Composite
        #region "Atributos"
        private DateTime fechaPostulacion;
        private Int16 estadoPostulante;
        #endregion

        #region "Propiedades"
        public DateTime FechaPostulacion
        {
            get { return fechaPostulacion; }
            set { fechaPostulacion = value; }
        }
        public Int16 EstadoPostulante
        {
            get { return estadoPostulante; }
            set { estadoPostulante = value; }
        }
        #endregion

        #region "Constructor"
        public ConvocatoriaPostulanteBE(DateTime p_FechaPostulacion, Int16 p_EstadoPostulante) {
            this.fechaPostulacion = p_FechaPostulacion;
            this.estadoPostulante = p_EstadoPostulante;
        }
        #endregion
    }
}
