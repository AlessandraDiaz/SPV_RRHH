using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;


namespace SPV.BL
{
    public class ParametroBL
    {
        public List<ParametroBE> Listar(ParametroBE parametro)
        {
            return new ParametroDA().Listar(parametro);
        }
    }
}
