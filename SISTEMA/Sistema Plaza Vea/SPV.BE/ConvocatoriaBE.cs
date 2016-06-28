using System;

namespace SPV.BE
{
    public class ConvocatoriaBE
    {
        //Patron Composite
        #region "Atributos"
        private String codigoConvocatoria;
        private String nombreConvocatoria;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private String estado;
        private String fechaMaxRecepcionCV;
        private DateTime fechaPublicacionConvocatoria;
        //private String listaDocumentosContrato;
        #endregion

        #region "Propiedades"
        public String CodigoConvocatoria
        {
            get { return codigoConvocatoria; }
            set { codigoConvocatoria = value; }
        }
        public String NombreConvocatoria
        {
            get { return nombreConvocatoria; }
            set { nombreConvocatoria = value; }
        }
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public String FechaMaxRecepcionCV
        {
            get { return fechaMaxRecepcionCV; }
            set { fechaMaxRecepcionCV = value; }
        }
        public DateTime FechaPublicacionConvocatoria
        {
            get { return fechaPublicacionConvocatoria; }
            set { fechaPublicacionConvocatoria = value; }
        }
        /*public String ListaDocumentosContrato
        {
            get { return listaDocumentosContrato; }
            set { listaDocumentosContrato = value; }
        }*/
        #endregion

        #region "Constructor"
        public ConvocatoriaBE(String p_CodigoConvocatoria, String p_NombreConvocatoria, DateTime p_FechaInicio, DateTime p_FechaFin, String p_Estado, String p_FechaMaxRecepcionCV, DateTime p_FechaPublicacionConvocatoria/*, String p_ListaDocumentosContrato*/)
        {
            this.codigoConvocatoria = p_CodigoConvocatoria;
            this.nombreConvocatoria = p_NombreConvocatoria;
            this.fechaInicio = p_FechaInicio;
            this.fechaFin = p_FechaFin;
            this.estado = p_Estado;
            this.fechaMaxRecepcionCV = p_FechaMaxRecepcionCV;
            this.fechaPublicacionConvocatoria = p_FechaPublicacionConvocatoria;
            //this.listaDocumentosContrato = p_ListaDocumentosContrato;
        }
        #endregion
    }
}
