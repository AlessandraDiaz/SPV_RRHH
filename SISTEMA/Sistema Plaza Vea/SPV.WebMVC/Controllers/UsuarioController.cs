using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPV.BE;
using SPV.BL;
using formsAuth = System.Web.Security.FormsAuthentication;

namespace SPV.WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioGRH_BL usuarioBL = new UsuarioGRH_BL();

        // GET: Usuario
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UsuarioBE usuario)
        {
            string mensaje = "";
            if (ModelState.IsValid)
            {
                UsuarioBE usuarioLogeado;
                usuarioLogeado = usuarioBL.Login(usuario.NombreUsuario, usuario.Pass);

                if (usuarioLogeado != null)
                {
                    formsAuth.SetAuthCookie(usuario.NombreUsuario, true);
                    mensaje = "Exito";
                    FachadaSesion.Usuario = usuarioLogeado;
                }
                else
                {
                    mensaje = "Usuario o password incorrecto";
                }
            }
            else
            {
                mensaje = "Ingrese los campos requeridos";
            }

            if (Request.IsAjaxRequest())
            {
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var entrada = FachadaSesion.Usuario;

            if (entrada != null) { FachadaSesion.Usuario = null; }

            formsAuth.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}