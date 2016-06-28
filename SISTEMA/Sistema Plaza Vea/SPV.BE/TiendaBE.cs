using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class TiendaBE
    {
        //Patron Composite
        #region "Atributos"
        private Int32 codigoTienda;
        private String nombre;
        private String direccion;
        private String departamento;
        private Int16 estado;
        #endregion

        #region "Propiedades"
        public Int32 CodigoTienda
        {
            get { return codigoTienda; }
            set { codigoTienda = value; }
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
        public String Departamento
        {
            get { return departamento; }
            set { departamento = value; }
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
        public int CodTienda { get; set; }
        [Display(Name = "Tienda")]
        public string NombreTienda { get; set; }
        [Display(Name = "Dirección")]
        public string DireccionTienda { get; set; }
        [Display(Name = "Estado")]
        public int EstadoTienda { get; set; }

        #endregion

        #region "Constructor"
        public TiendaBE() { }
        public TiendaBE(Int32 p_CodigoTienda, String p_Nombre, String p_Direccion, String p_Departamento, Int16 p_Estado) {
            this.codigoTienda = p_CodigoTienda;
            this.nombre = p_Nombre;
            this.direccion = p_Direccion;
            this.departamento = p_Departamento;
            this.estado = p_Estado;
        }
        #endregion
    }
}
