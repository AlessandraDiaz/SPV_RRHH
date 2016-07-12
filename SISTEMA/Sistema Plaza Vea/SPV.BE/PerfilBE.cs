using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class PerfilBE
    {
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
        [Display(Name = "Exámen")]
        public ExamenBE Examen { get; set; }

        #endregion
    }
}
