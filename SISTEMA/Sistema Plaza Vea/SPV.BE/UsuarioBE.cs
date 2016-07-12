using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    [Serializable]
    public class UsuarioBE
    {
        #region "PropiedadeMySql"

        [Display(Name = "ID")]
        [Key]
        public int CodigoUsuario { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Area")]
        public AreaTiendaBE Area { get; set; }
        [Display(Name = "Perfil")]
        public PerfilBE Perfil { get; set; }
        [Display(Name = "Local")]
        public TiendaBE Local { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
        [Display(Name = "Estado")]
        public int EstadoUsuario { get; set; }

        public int RindioExamen { get; set; }

        #endregion
    }
}