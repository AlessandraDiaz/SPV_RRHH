using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.BE;
using SPV.DA;

namespace SPV.BL
{
    public class PostulanteRespuestaBL
    {
        public List<PostulanteRespuestaBE> Listar(int id)
        {
            return new PostulanteRespuestaDA().Listar(id);
        }

        public PostulanteRespuestaBE GetResumenRespuestaByPostulante(int Id)
        {
            return new PostulanteRespuestaDA().GetResumenRespuestaByPostulante(id);
        }

        public Int32 RegistrarRespuesta(PostulanteRespuestaBE respuesta)
        {
            return new PostulanteRespuestaDA().RegistrarRespuesta(respuesta);
        }
    }
}
