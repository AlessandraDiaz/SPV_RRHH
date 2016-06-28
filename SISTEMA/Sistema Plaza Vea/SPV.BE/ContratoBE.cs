using System;

namespace SPV.BE
{
    public class ContratoBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoContrato;
        private DateTime inicioContrato;
        private DateTime finContrato;
        private String tiempoContrato;
        private String tipoContrato;
        private DateTime fechaFirmaContrato;
        private Double sueldoBase;
        private String estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoContrato
        {
            get { return codigoContrato; }
            set { codigoContrato = value; }
        }
        public DateTime InicioContrato
        {
            get { return inicioContrato; }
            set { inicioContrato = value; }
        }
        public DateTime FinContrato
        {
            get { return finContrato; }
            set { finContrato = value; }
        }
        public String TiempoContrato
        {
            get { return tiempoContrato; }
            set { tiempoContrato = value; }
        }
        public String TipoContrato
        {
            get { return tipoContrato; }
            set { tipoContrato = value; }
        }
        public DateTime FechaFirmaContrato
        {
            get { return fechaFirmaContrato; }
            set { fechaFirmaContrato = value; }
        }
        public Double SueldoBase
        {
            get { return sueldoBase; }
            set { sueldoBase = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "Constructor"
        public ContratoBE(Int32 p_CodigoContrato, DateTime p_InicioContrato, DateTime p_FinContrato, String p_TiempoContrato, String p_TipoContrato, DateTime p_FechaFirmaContrato, Double p_SueldoBase, String p_Estado) {
            this.codigoContrato = p_CodigoContrato;
            this.inicioContrato = p_InicioContrato;
            this.finContrato = p_FinContrato;
            this.tiempoContrato = p_TiempoContrato;
            this.tipoContrato = p_TipoContrato;
            this.fechaFirmaContrato = p_FechaFirmaContrato;
            this.sueldoBase = p_SueldoBase;
            this.estado = p_Estado;
        }
        #endregion
    }
}
