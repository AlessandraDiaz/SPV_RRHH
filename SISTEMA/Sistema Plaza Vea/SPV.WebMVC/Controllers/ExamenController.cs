using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using SPV.BE;
using SPV.BL;
using System.Configuration;
using System.Text;
using SPV.WebMVC.Helper;

namespace SPV.WebMVC.Controllers
{
    public class ExamenController : Controller
    {
        ExamenPreguntaBL preguntasBL = new ExamenPreguntaBL();
        PostulanteRespuestaBL respuestasBL = new PostulanteRespuestaBL();
        ColaboradorBL colaboradorBL = new ColaboradorBL();

        // GET: Examen
        public ActionResult Examen()
        {
            List<ExamenPreguntaBE> listaPreguntas = new List<ExamenPreguntaBE>();
            listaPreguntas = preguntasBL.Listar(FachadaSesion.Usuario.Perfil.Examen.ID);
            return View("Examen", listaPreguntas);
        }

        // POST: Examen/Examen
        [HttpPost]
        public ActionResult Examen(string IdUsuario, string IdExamen, string rpta, string time)
        {
            var codigoRespuestasList = rpta.Split(',');
            var listaPreguntas = preguntasBL.Listar(FachadaSesion.Usuario.Perfil.Examen.ID);
            
            var codigoUsuario = Convert.ToInt32(IdUsuario);
            var puntajeSum = 0;

            foreach (var pregunta in listaPreguntas)
            {
                var codigoRpta = codigoRespuestasList[(pregunta.ID -1)];
                int codRpta = 0; string cadenaRpta = string.Empty;
                var respuesta = new PostulanteRespuestaBE();
                respuesta.CodigoUsuario = codigoUsuario;
                respuesta.CodigoExamen = Convert.ToInt32(IdExamen);
                respuesta.CodigoPregunta = pregunta.ID;
                if (codigoRpta == "NR")
                {
                    codRpta = -1;
                }
                else
                {
                    if (pregunta.ID == 13)
                    {
                        cadenaRpta = codigoRpta;
                        codRpta = 0;
                    }
                    else
                    {
                        codRpta = Convert.ToInt32(codigoRpta);
                    }
                }
                respuesta.CodigoOpcion = codRpta;
                respuesta.Respuesta = cadenaRpta;

                var codigoRespuestaCorrecta = (from r in pregunta.listaOpciones
                                       where r.CorrectoEx == 1
                                       select r).FirstOrDefault();

                if (pregunta.ID == 13)
                {
                    respuesta.Correcto = 1;
                    respuesta.PuntajePregunta = pregunta.PuntajeEx;
                    puntajeSum += pregunta.PuntajeEx;
                }
                else
                {
                    if (codigoRespuestaCorrecta.ID == codRpta)
                    {
                        respuesta.Correcto = 1;
                        respuesta.PuntajePregunta = pregunta.PuntajeEx;
                        puntajeSum += pregunta.PuntajeEx;
                    }
                    else
                    {
                        respuesta.Correcto = 0;
                        respuesta.PuntajePregunta = 0;
                    }
                }

                respuesta.Tiempo = time;
                respuestasBL.RegistrarRespuesta(respuesta);
            }

            ColaboradorBE postulante = new ColaboradorBE();
            UsuarioBE usuario = new UsuarioBE();
            usuario.CodigoUsuario = Convert.ToInt32(IdUsuario);
            postulante.Usuario = usuario;
            postulante.RindioExamen = 1; /// 1: Si rindio examen 0: No rindio examen
            postulante.PuntajeExamen = puntajeSum;

            colaboradorBL.UpdatePostulanteExamen(postulante);

            return Json(new { status = "Success" });
        }

        // GET: Resultados
        public ActionResult Resultados()
        {
            PostulanteRespuestaBE respuestasResumen = respuestasBL.GetResumenRespuestaByPostulante(FachadaSesion.Usuario.CodigoUsuario);
            return View("Resultados", respuestasResumen);
        }

    }
}