using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ExamenBE
    {
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

    }
}
