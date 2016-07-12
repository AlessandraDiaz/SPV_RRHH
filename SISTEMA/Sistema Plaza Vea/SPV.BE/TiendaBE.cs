using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class TiendaBE
    {

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
    }
}
