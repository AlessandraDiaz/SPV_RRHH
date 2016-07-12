using System;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class AreaTiendaBE
    {
        #region "PropiedadeMySql"
        [Display(Name = "ID")]
        [Key]
        public int CodArea { get; set; }
        [Display(Name = "Área")]
        public string Descripcion { get; set; }
        [Display(Name = "Estado")]
        public int EstadoArea { get; set; }

        #endregion
    }
}
