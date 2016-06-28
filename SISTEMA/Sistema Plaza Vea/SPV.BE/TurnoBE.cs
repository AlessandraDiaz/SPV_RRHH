using System;

namespace SPV.BE
{
    public class TurnoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoTurno;
        private String horaInicio;
        private String horaFin;
        private String diaInicio;
        private String diaFin;
        private String descripcion;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoTurno
        {
            get { return codigoTurno; }
            set { codigoTurno = value; }
        }
        public String HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }
        public String HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }
        public String DiaInicio
        {
            get { return diaInicio; }
            set { diaInicio = value; }
        }
        public String DiaFin
        {
            get { return diaFin; }
            set { diaFin = value; }
        }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public TurnoBE(Int32 p_CodigoTurno, String p_HoraInicio, String p_HoraFin, String p_DiaInicio, String p_DiaFin, String p_Descripcion, Int16 p_Estado)
        {
            this.codigoTurno = p_CodigoTurno;
            this.horaInicio = p_HoraInicio;
            this.horaFin = p_HoraFin;
            this.diaInicio = p_DiaInicio;
            this.diaFin = p_DiaFin;
            this.descripcion = p_Descripcion;
            this.estado = p_Estado;
        }
        #endregion
     }
}
