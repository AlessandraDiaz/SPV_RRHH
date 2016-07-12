using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ColaboradorBE
    {

        #region "PropiedadesMySQL"

        [Display(Name = "ID")]
        [Key]
        public int ID { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public Nullable<DateTime> FechaNacimiento { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Display(Name = "Curriculum VITAE")]
        public string CurriculumVitae { get; set; }
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }
        [Display(Name = "Cantidad de Hijos")]
        public int CantidadHijos { get; set; }
        [Display(Name = "Seguro Social")]
        public string Seguro { get; set; }
        [Display(Name = "Cod. ESSALUD")]
        public string CodigoEssalud { get; set; }
        [Display(Name = "Fecha de Cese")]
        public Nullable<DateTime> FechaCese { get; set; }
        [Display(Name = "Antecedentes")]
        public string Antecedente { get; set; }
        [Display(Name = "Usuario")]
        public UsuarioBE Usuario { get; set; }
        [Display(Name = "Tipo de colaborador")]
        public ParametroBE TipoColaborador { get; set; }
        [Display(Name = "Foto")]
        public string Foto { get; set; }
        public int EstadoPostulanteConvocatoria { get; set; }
        public ParametroBE EstadoAceptacion { get; set; }
        public Convocatoria2BE Convocatoria { get; set; }
        public int RindioExamen { get; set; }
        [Display(Name = "Puntaje")]
        public int PuntajeExamen { get; set; }
        public CurriculumVitaeBE CurriculumVitaeDetalle { get; set; }
        #endregion
    }
}
