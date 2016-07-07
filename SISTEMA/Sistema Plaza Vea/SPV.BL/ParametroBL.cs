using SPV.BE;
using SPV.DA;
using System;
using System.Collections.Generic;


namespace SPV.BL
{
    public class ParametroBL
    {
        public List<ParametroBE> Listar(ParametroBE parametro)
        {
            return new ParametroDA().Listar(parametro);
        }

        public List<ParametroBE> ListarXCodAgrupador(int codigoAgrupador)
        {
            try
            {
                return new ParametroDA().ListarXCodAgrupador(codigoAgrupador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
