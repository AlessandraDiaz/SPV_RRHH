using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;
namespace SPV.BL
{
    public class ExamenPreguntaBL
    {
        public List<ExamenPreguntaBE> Listar(int codigoExamen)
        {
            return new ExamenPreguntaDA().Listar(codigoExamen);
        }

    }
}
