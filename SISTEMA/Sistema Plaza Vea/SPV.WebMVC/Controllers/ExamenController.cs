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

        // GET: Examen
        public ActionResult Examen()
        {
            List<ExamenPreguntaBE> listaPreguntas = new List<ExamenPreguntaBE>();
            listaPreguntas = preguntasBL.Listar(FachadaSesion.Usuario.Perfil.Examen.ID);
            ColaboradorBE colaborador = new ColaboradorBL().GetColaboradorByID(0, FachadaSesion.Usuario.CodigoUsuario);
            FachadaSesion.Colaborador = colaborador;
            return View("Examen", listaPreguntas);
        }

        // POST: Examen/Examen
        [HttpPost]
        public ActionResult Examen(string IdUsuario, string IdExamen, string rpta, string time)
        {
            

            return Json(new { status = "Success" });
        }

    }
}