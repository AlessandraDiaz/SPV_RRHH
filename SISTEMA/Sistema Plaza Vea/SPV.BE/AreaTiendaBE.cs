using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class AreaTiendaBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoArea;
        private String nombre;
        private Int32 capacidadColaboradores;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Int32 CapacidadColaboradores
        {
            get { return capacidadColaboradores; }
            set { capacidadColaboradores = value; }
        }
        public Int32 CodigoArea
        {
            get { return codigoArea; }
            set { codigoArea = value; }
        }
        public Int16 Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion

        #region "PropiedadeMySql"
        [Display(Name = "ID")]
        [Key]
        public int CodArea { get; set; }
        [Display(Name = "Área")]
        public string Descripcion { get; set; }
        [Display(Name = "Estado")]
        public int EstadoArea { get; set; }

        #endregion

        #region "Constructor"
        public AreaTiendaBE() { }
        public AreaTiendaBE(Int32 p_CodigoArea, String p_Nombre, Int32 p_CapacidadColaboradores, Int16 p_Estado) {
            this.codigoArea = p_CodigoArea;
            this.nombre = p_Nombre;
            this.capacidadColaboradores = p_CapacidadColaboradores;
            this.estado = p_Estado;
        }
        #endregion
    }
}
