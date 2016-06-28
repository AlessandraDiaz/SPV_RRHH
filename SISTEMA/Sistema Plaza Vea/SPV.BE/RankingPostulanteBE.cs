using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public class RankingPostulanteBE
    {
        //Patron Composite

        #region "Atributos"
        private String codigoPostulante;
        private String nombreApellido;
        private String notaEvaPerfil;
        private String notaExaPsicologico;
        private String notaExaPsicotecnico;
        private String notaEntrevista;
        #endregion

        #region "Propiedades"
        public String CodigoPostulante
        {
            get { return codigoPostulante; }
            set { codigoPostulante = value; }
        }
        public String NombreApellido
        {
            get { return nombreApellido; }
            set { nombreApellido = value; }
        }
        public String NotaEvaPerfil
        {
            get { return notaEvaPerfil; }
            set { notaEvaPerfil = value; }
        }
        public String NotaExaPsicologico
        {
            get { return notaExaPsicologico; }
            set { notaExaPsicologico = value; }
        }
        public String NotaExaPsicotecnico
        {
            get { return notaExaPsicotecnico; }
            set { notaExaPsicotecnico = value; }
        }
        public String NotaEntrevista
        {
            get { return notaEntrevista; }
            set { notaEntrevista = value; }
        }
        #endregion

        #region "Constructor"
        public RankingPostulanteBE(String p_CodigoPostulante, String p_NombreApellido, String p_NotaEvaPerfil, String p_NotaExaPsicologico, String p_NotaExaPsicotecnico, String p_NotaEntrevista) {
            this.codigoPostulante = p_CodigoPostulante;
            this.nombreApellido = p_NombreApellido;
            this.notaEvaPerfil = p_NotaEvaPerfil;
            this.notaExaPsicologico = p_NotaExaPsicologico;
            this.notaExaPsicotecnico = p_NotaExaPsicotecnico;
            this.notaEntrevista = p_NotaEntrevista;        
        }
        #endregion

    }
}
