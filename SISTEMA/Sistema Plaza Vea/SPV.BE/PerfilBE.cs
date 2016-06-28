using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class PerfilBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoPerfil;
        private String areasPerfil;
        private String nombrePerfil;
        private String descripcion;
        private Double sueldo;
        private Int16 estado;
        private List<PerfilRequisitoBE> listaRequisito;
        #endregion

        #region "Propiedades"
        public Int32 CodigoPerfil
        {
            get { return codigoPerfil; }
            set { codigoPerfil = value; }
        }
        public String AreasPerfil
        {
            get { return areasPerfil; }
            set { areasPerfil = value; }
        }
        public String NombrePerfil
        {
            get { return nombrePerfil; }
            set { nombrePerfil = value; }
        }
        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public Double Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public List<PerfilRequisitoBE> ListaRequisito
        {
            get { return listaRequisito; }
            set { listaRequisito = value; }
        }
        #endregion


        #region "PropiedadeMySql"
        [Display(Name = "ID")]
        [Key]
        public int CodPerfil { get; set; }
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionPerfil { get; set; }
        [Display(Name = "Estado")]
        public int EstadoPerfil { get; set; }

        #endregion

        #region "Constructor"
        public PerfilBE() { }
        public PerfilBE(Int32 p_CodigoPerfil, String p_AreasPerfil, String p_NombrePerfil, String p_Descripcion, Double p_Sueldo, Int16 p_Estado) {
            this.codigoPerfil = p_CodigoPerfil;
            this.areasPerfil = p_AreasPerfil;
            this.nombrePerfil = p_NombrePerfil;
            this.descripcion = p_Descripcion;
            this.sueldo = p_Sueldo;
            this.estado = p_Estado;
            this.listaRequisito = new List<PerfilRequisitoBE>();
        }
        #endregion
    }
}
