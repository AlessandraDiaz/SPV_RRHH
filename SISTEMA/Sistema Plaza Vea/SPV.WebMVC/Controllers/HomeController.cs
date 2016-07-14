using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPV.BE;
using SPV.BL;

namespace SPV.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (FachadaSesion.Usuario != null)
            {
                UsuarioBE usuarioLogeado;
                usuarioLogeado = new UsuarioGRH_BL().Login(FachadaSesion.Usuario.NombreUsuario, "123");
                FachadaSesion.Usuario = usuarioLogeado;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}