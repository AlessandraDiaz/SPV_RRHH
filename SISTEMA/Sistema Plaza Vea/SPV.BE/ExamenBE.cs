using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ExamenBE
    {
        //Patron Composite.
        #region "Atributos"
        private Int16 codigo;
        private String perfil;
        private String tipoExamen;
        private String nombre;
        private String descripcion;
        private String estado;
        private List<ExamenPreguntaBE> listaPregunta;
        #endregion

        #region "Propiedades"

        public Int16 Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public String Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }
        public String TipoExamen
        {
            get { return tipoExamen; }
            set { tipoExamen = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public List<ExamenPreguntaBE> ListaPregunta
        {
            get { return listaPregunta; }
            set { listaPregunta = value; }
        }

        #endregion

        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string NombreEx { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionEx { get; set; }
        [Display(Name = "Estado")]
        public int EstadoEx { get; set; }
        public List<ExamenPreguntaBE> ListaPreguntas { get; set; }
        #endregion  

        #region "Constructor"
        public ExamenBE() { }

        public ExamenBE(Int16 p_Codigo, String p_Perfil, String p_TipoExamen, String p_Nombre, String p_Descripcion, String p_Estado) {
            this.codigo = p_Codigo;
            this.perfil = p_Perfil;
            this.tipoExamen = p_TipoExamen;
            this.nombre = p_Nombre;
            this.descripcion = p_Descripcion;
            this.estado = p_Estado;
            this.listaPregunta = new List<ExamenPreguntaBE>();
        }
        #endregion
    }
}
