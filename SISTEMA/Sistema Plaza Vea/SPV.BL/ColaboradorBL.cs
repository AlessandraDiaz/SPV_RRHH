using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class ColaboradorBL
    {
        public List<ColaboradorBE> ListarColaboradores(ColaboradorBE colaborador)
        {
            return new ColaboradorDA().ListarColaboradores(colaborador);
        }

        public List<ColaboradorBE> List()
        {
            try
            {
                return new ColaboradorDA().List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColaboradorBE> ListaPostulanteByConvocatoria(int codigo)
        {
            return new ColaboradorDA().ListaPostulanteByConvocatoria(codigo);
        }
        public void UpdatePostulantes(ColaboradorBE postulante)
        {
            new ColaboradorDA().UpdatePostulantes(postulante);
        }

        public ColaboradorBE GetColaboradorByID(int codigo)
        {
            return new ColaboradorDA().GetColaboradorByID(codigo);
        }
    }
}
