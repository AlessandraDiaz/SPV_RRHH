using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    public class ParametroBE
    {
        public int CodigoParametro { get; set; }
        public int CodigoAgrupador { get; set; }
        public string DescripcionAgrupador { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public int Estado { get; set; }
    }
}
