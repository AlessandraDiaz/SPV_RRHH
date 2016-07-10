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
    public class SolicitudController : Controller
    {
        private SolicitudPersonalBL solicitudBL = new SolicitudPersonalBL();
        private ParametroBL parametroBL = new ParametroBL();
        private CargoBL cargoBL = new CargoBL();
        private CampanaBL oCampanaBL = new CampanaBL();
        private ColaboradorBL oColaboradorBL = new ColaboradorBL();

        // GET: Solicitud
        public ActionResult Index(int cboTipoFiltro = 0, string desc = null, int cboFiltro = 0, string fechaIni = null, string fechaFin =null, int cboEstado=0,
                                    int page = 1, int pageSize = 10, string sort = "CodigoSol", string sortdir = "DESC")
        {
            var records = new ListaPaginada<SolicitudPersonalBE>();
            ViewBag.TipoFiltro = cboTipoFiltro;
            ViewBag.desc = desc;
            ViewBag.cboTipo = cboFiltro;
            ViewBag.cboEstado = cboEstado;
            ViewBag.FIni = fechaIni;
            ViewBag.FFin = fechaFin;

            FachadaSesion.TipoFiltro = cboTipoFiltro;

            desc = (desc == null ? "" : desc);
            fechaIni = (fechaIni == null ? "" : fechaIni);
            fechaFin = (fechaFin == null ? "" : fechaFin);

            int usuarioID = FachadaSesion.Usuario.CodigoUsuario;
            //administrador
            if (FachadaSesion.Usuario.Perfil.CodPerfil == 1)
            {
                usuarioID = 0;
            }
            var local = FachadaSesion.Usuario.Local.CodTienda;
            var area = FachadaSesion.Usuario.Area.CodArea;

            List<SolicitudPersonalBE> listadoSolicitud = solicitudBL.Listar(cboTipoFiltro,desc,cboFiltro,fechaIni, fechaFin, cboEstado, usuarioID, local , area);

            records.Content = listadoSolicitud
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = listadoSolicitud.Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: /Solicitud/Registrar
        [HttpGet]
        public ActionResult Registrar()
        {
            SolicitudPersonalBE solicitud;
            solicitud = new SolicitudPersonalBE();
            return View("Registrar", solicitud);
        }

        [HttpPost]
        public ActionResult Registrar(SolicitudPersonalBE solicitud, string cboTipoConvoca, string cboTipoSolicitud,
                    string cboMotivo, string cboCampana, string cboCargo, string cboMoneda)
        {
            try
            {
                //validaciones
                if (ModelState.IsValid)
                {

                    if (cboTipoConvoca == null || cboTipoConvoca == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Tipo de solicitud");
                        return View(solicitud);
                    }

                    var idSolicitud = 0;

                    ParametroBE tipoConvoca = new ParametroBE() { Codigo = Convert.ToInt32(cboTipoConvoca) };
                    ParametroBE tipoSolicitud = new ParametroBE() { Codigo = Convert.ToInt32(cboTipoSolicitud) };
                    ParametroBE motivo = new ParametroBE() { Codigo = Convert.ToInt32(cboMotivo) };
                    CampanaBE campana ;
                    if (cboCampana != "0")
                        campana = new CampanaBE() { ID = Convert.ToInt32(cboCampana) };
                    else
                        campana = new CampanaBE();
                    
                    CargoBE cargo = new CargoBE() { ID = Convert.ToInt32(cboCargo) };
                    ParametroBE estado = new ParametroBE() { Codigo = Convert.ToInt32(1) };
                    ParametroBE moneda = new ParametroBE() { Codigo = Convert.ToInt32(cboMoneda) };

                    solicitud.TipoConvocatoria = tipoConvoca;
                    solicitud.TipoSolicitudSol = tipoSolicitud;
                    solicitud.Motivo = motivo;
                    solicitud.Campana = campana;
                    solicitud.Cargo = cargo;
                    solicitud.MonedaSolicitud = moneda;
                    solicitud.EstadoSol = estado;
                    solicitud.LocalUsuario = FachadaSesion.Usuario.Local.CodTienda;
                    solicitud.CodigoUsuario = FachadaSesion.Usuario.CodigoUsuario;

                    idSolicitud = solicitudBL.IngresarSolicitudPersonal(solicitud);

                    TempData["msg"] = "Grabado Correctamente";
                    return RedirectToAction("Index", "Solicitud");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("MensajeError", "Ocurrió un error al grabar el registro.");
            }
            return View(solicitud);
        }

        // GET: /Solicitud/Editar/5
        public ActionResult Editar(int id)
        {
            SolicitudPersonalBE solicitud = new SolicitudPersonalBE();
            if (ModelState.IsValid)
            {
                try
                {
                    solicitud = solicitudBL.GetSolicitudByID(id);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("MensajeError", "Ocurrió un error.");
                    return View(solicitud);
                }
            }
            return View(solicitud);
        }

        [HttpPost]
        public ActionResult Editar(SolicitudPersonalBE solicitud, string cboTipoConvoca, string cboTipoSolicitud,
                    string cboMotivo, string cboCampana, string cboCargo, string cboMoneda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cboTipoSolicitud == null || cboTipoSolicitud == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Tipo de solicitud");
                        return View(solicitud);
                    }

                    SolicitudPersonalBE solictudActualizada = null;

                    ParametroBE tipoConvoca = new ParametroBE() { Codigo = Convert.ToInt32(cboTipoConvoca) };
                    ParametroBE tipoSolicitud = new ParametroBE() { Codigo = Convert.ToInt32(cboTipoSolicitud) };
                    ParametroBE motivo = new ParametroBE() { Codigo = Convert.ToInt32(cboMotivo) };
                    CampanaBE campana;
                    if (cboCampana != "0")
                        campana = new CampanaBE() { ID = Convert.ToInt32(cboCampana) };
                    else
                        campana = new CampanaBE();

                    CargoBE cargo = new CargoBE() { ID = Convert.ToInt32(cboCargo) };
                    ParametroBE estado = new ParametroBE() { Codigo = Convert.ToInt32(1) };
                    ParametroBE moneda = new ParametroBE() { Codigo = Convert.ToInt32(cboMoneda) };

                    solicitud.TipoConvocatoria = tipoConvoca;
                    solicitud.TipoSolicitudSol = tipoSolicitud;
                    solicitud.Motivo = motivo;
                    solicitud.Campana = campana;
                    solicitud.Cargo = cargo;
                    solicitud.MonedaSolicitud = moneda;
                    solicitud.EstadoSol = estado;                    

                    solictudActualizada = solicitudBL.UpdateSolicitud(solicitud);

                    TempData["msg"] = "Grabado Correctamente";
                    return RedirectToAction("Index");
                    
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("MensajeError", "Ocurrió un error al actualizar el registro.");
            }
            return View(solicitud);
        }

        // GET: /Solicitud/Eliminar/5
        public ActionResult Eliminar(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return PartialView("Eliminar", solicitud);
        }

        // POST: /Solicitud/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            solicitudBL.EliminarSolicitudPersonal(id);
            return Json(new { success = true });
        }

        // GET: /Solicitud/Detalle/5
        public ActionResult Detalle(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View("Detalle", solicitud);
        }

        // GET: /Solicitud/Enviar/5
        public ActionResult Enviar(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return PartialView("Enviar", solicitud);
        }

        // POST: /Solicitud/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviarMail(SolicitudPersonalBE solicitud)
        {
            try
            {
                SolicitudPersonalBE solicitudData = solicitudBL.GetSolicitudByID(solicitud.CodigoSol);

                ParametroBE estadoSol = new ParametroBE();
                estadoSol.Codigo = 4; //Enviado
                solicitudData.EstadoSol = estadoSol;
                solicitudData.FechaEnvio = DateTime.Now;
                solicitudBL.UpdateSolicitud(solicitudData);

                ColaboradorBE oParam = new ColaboradorBE();
                UsuarioBE oParamUser = new UsuarioBE();
                PerfilBE oPerfil = new PerfilBE() { CodPerfil = 3 };
                TiendaBE olocal = new TiendaBE() { CodTienda = FachadaSesion.Usuario.Local.CodTienda };
                oParamUser.Perfil = oPerfil;
                oParamUser.Local = olocal;
                oParam.usuario = oParamUser;

                var listColaboradores = oColaboradorBL.ListarColaboradores(oParam);

                if (listColaboradores != null)
                {
                    if (listColaboradores.Count > 0)
                    {
                        ColaboradorBE colaborador = listColaboradores.FirstOrDefault();
                        // Configurar envio de correo
                        string subject = string.Format("{0}: {1} - {2}", ConfigurationManager.AppSettings.Get("AsuntoMailEnvioSolicitud"), solicitudData.CodigoInterno ,DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss"));
                        string mailFrom = ConfigurationManager.AppSettings.Get("MailEmisor");
                        string passwordMailEmisor = ConfigurationManager.AppSettings.Get("PasswordMailEmisor");
                        StringBuilder buffer = new StringBuilder();
                        buffer.Append("Estimado <b>{0} {1}, {2}</b>");
                        buffer.Append("Es grato saludarlo e informarle que se ha enviado la solicitud para la aprobación <br />");
                        buffer.Append("Saludos cordiales. <br/><br/>");
                        buffer.Append("<i>Nota: Por favor no responda este correo.<i>");

                        MailHelper.SendMail(mailFrom, passwordMailEmisor, colaborador.Correo, subject, string.Format(buffer.ToString(), colaborador.ApellidoPaterno, colaborador.ApellidoMaterno, colaborador.Nombres), true, System.Net.Mail.MailPriority.Normal);
                    }
                }
            }
            catch (Exception)
            {
            }
            return Json(new { success = true });
        }

        // GET: /Solicitud/Enviar/5
        public ActionResult Observacion(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return PartialView("Observacion", solicitud);
        }

        // GET: /Solicitud/VerDetalleCargo
        [HttpGet]
        public ActionResult VerDetalleCargo(int id = 0)
        {
            List<CargoBE> listCargos = FachadaSesion.Cargos;
            CargoBE cargo;
            var query = (from c in listCargos
                         where c.CodigoCargo == id
                         select c).FirstOrDefault();

            if (query == null)
            {
                cargo = new CargoBE();
            }
            else
            {
                cargo = query;
            }

            return PartialView("VerDetalleCargo", cargo);
        }
        public JsonResult ListaTipoSolicitud()
        {
            ParametroBE param = new ParametroBE();
            string codigoTipoSolicitud = ConfigurationManager.AppSettings["CodigoTipoSolicitud"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoTipoSolicitud);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaMotivos(string tipo)
        {
            ParametroBE param = new ParametroBE();
            string codigoTipoMotivo = ConfigurationManager.AppSettings["CodigoMotivoFiltro"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoTipoMotivo);

            List<ParametroBE> lista = parametroBL.Listar(param).ToList();

            var query = (from p in lista
                         where p.Valor == tipo
                         select p).ToList<ParametroBE>();

            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaTipoConvocatoria()
        {
            ParametroBE param = new ParametroBE();
            string codigoTipoConvocatoria = ConfigurationManager.AppSettings["CodigoTipoConvocatoria"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoTipoConvocatoria);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaTipoFiltro()
        {
            ParametroBE param = new ParametroBE();
            string codigoTipoFiltro = ConfigurationManager.AppSettings["CodigoTipoFiltro"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoTipoFiltro);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaMotivoFiltro()
        {
            ParametroBE param = new ParametroBE();
            string codigoMotivoFiltro = ConfigurationManager.AppSettings["CodigoMotivoFiltro"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoMotivoFiltro);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaEstadoFiltro()
        {
            ParametroBE param = new ParametroBE();
            string codigoEstadoFiltro = ConfigurationManager.AppSettings["CodigoEstadoSolFiltro"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoEstadoFiltro);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaCargoFiltro()
        {
            CargoBE param = new CargoBE();
            param.ID = 0;
            param.Descripcion = "";
            return Json(cargoBL.ListaCargo(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaCampanas()
        {
            CampanaBE param = new CampanaBE();
            param.Descripcion = "";
            param.ID = 0;

            List<CampanaBE> lista = oCampanaBL.ListarCampana(param).ToList();
            FachadaSesion.Campanas = lista;

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDataCampana(string ID)
        {
            List<CampanaBE> lista = FachadaSesion.Campanas;
            var campana = (from c in lista
                           where c.ID == Convert.ToInt32(ID)
                           select c).FirstOrDefault();
            return Json(campana, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaCargo()
        {
            CargoBE param = new CargoBE();
            param.CodigoCargo = 0;
            param.Descripcion = "";

            List<CargoBE> lista = cargoBL.ListaCargo(param).ToList();
            FachadaSesion.Cargos = lista;

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDataCargos(string ID)
        {
            List<CargoBE> lista = FachadaSesion.Cargos;

            var cargo = (from c in lista
                           where c.CodigoCargo == Convert.ToInt32(ID)
                           select c).FirstOrDefault();

            return Json(cargo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaMonedas()
        {
            ParametroBE param = new ParametroBE();
            string codigoMoneda = ConfigurationManager.AppSettings["CodigoMoneda"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoMoneda);
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }


        #region "CUS 02 -- Aprobacion de solicitudes"

        // GET: IndexAprobar
        public ActionResult IndexAprobar(int cboTipoFiltro = 0, string desc = null, int cboFiltro = 0, string fechaIni = null, string fechaFin = null, int cboEstado = 0,
                                    int page = 1, int pageSize = 10, string sort = "CodigoSol", string sortdir = "DESC")
        {
            var records = new ListaPaginada<SolicitudPersonalBE>();
            ViewBag.TipoFiltro = cboTipoFiltro;
            ViewBag.desc = desc;
            ViewBag.cboTipo = cboFiltro;
            ViewBag.cboEstado = cboEstado;
            ViewBag.FIni = fechaIni;
            ViewBag.FFin = fechaFin;


            desc = (desc == null ? "" : desc);
            fechaIni = (fechaIni == null ? "" : fechaIni);
            fechaFin = (fechaFin == null ? "" : fechaFin);

            int usuarioID = 0; //FachadaSesion.Usuario.CodigoUsuario;
            //administrador
            if (FachadaSesion.Usuario.Perfil.CodPerfil == 1)
            {
                usuarioID = 0;
            }

            var local = FachadaSesion.Usuario.Local.CodTienda;
            var area = FachadaSesion.Usuario.Area.CodArea;

            List<SolicitudPersonalBE> listadoSolicitud = solicitudBL.Listar(cboTipoFiltro, desc, cboFiltro, fechaIni, fechaFin, cboEstado, usuarioID, local, area);

            records.Content = listadoSolicitud
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = listadoSolicitud.Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: /Solicitud/DetalleAprobar/5
        public ActionResult DetalleAprobar(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View("DetalleAprobar", solicitud);
        }

        // GET: /Solicitud/Aprobar/5
        public ActionResult Aprobar(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return PartialView("Aprobar", solicitud);
        }

        // POST: /Solicitud/Aprobar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aprobar(SolicitudPersonalBE solicitud)
        {
            if (ModelState.IsValid)
            {
                SolicitudPersonalBE solicitudPorActualizar = solicitudBL.GetSolicitudByID(solicitud.CodigoSol);

                ParametroBE estado = new ParametroBE();
                estado.Codigo = 2;
                solicitudPorActualizar.EstadoSol = estado;
                solicitudPorActualizar.Comentarios = solicitud.Comentarios;

                solicitudBL.UpdateSolicitud(solicitudPorActualizar);

                ColaboradorBE oParam = new ColaboradorBE();
                UsuarioBE oParamUser = new UsuarioBE();
                PerfilBE oPerfil = new PerfilBE() { CodPerfil = 0 };
                TiendaBE olocal = new TiendaBE() { CodTienda = 0 };
                oParamUser.Perfil = oPerfil;
                oParamUser.Local = olocal;
                oParam.usuario = oParamUser;

                List<ColaboradorBE> colaboradores = oColaboradorBL.ListarColaboradores(oParam);
                var usuarioCrea = colaboradores.FirstOrDefault(t => t.usuario.CodigoUsuario == solicitudPorActualizar.CodigoUsuario);

                // Configurar envio de correo
                string subject = string.Format("{0}: {1} - {2}", ConfigurationManager.AppSettings.Get("AsuntoMailEnvioSolicitud"), solicitudPorActualizar.CodigoInterno, DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss"));
                string mailFrom = ConfigurationManager.AppSettings.Get("MailEmisor");
                string passwordMailEmisor = ConfigurationManager.AppSettings.Get("PasswordMailEmisor");
                StringBuilder buffer = new StringBuilder();
                buffer.Append("Estimado <b>{0} {1}, {2}</b>");
                buffer.Append("Es grato saludarlo e informarle que se su solicitud ha sido aprobada. <br />");
                buffer.Append("Saludos cordiales. <br/><br/>");
                buffer.Append("<i>Nota: Por favor no responda este correo.<i>");

                MailHelper.SendMail(mailFrom, passwordMailEmisor, usuarioCrea.Correo, subject, string.Format(buffer.ToString(), usuarioCrea.ApellidoPaterno, usuarioCrea.ApellidoMaterno, usuarioCrea.Nombres), true, System.Net.Mail.MailPriority.Normal);


                return Json(new { success = true });
            }
            return PartialView("Aprobar", solicitud);
        }

        // GET: /Solicitud/Rechazar/5
        public ActionResult Rechazar(int id = 0)
        {
            SolicitudPersonalBE solicitud = solicitudBL.GetSolicitudByID(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return PartialView("Rechazar", solicitud);
        }

        // POST: /Solicitud/Rechazar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rechazar(SolicitudPersonalBE solicitud)
        {
            if (ModelState.IsValid)
            {

                if (solicitud.Comentarios == "" || solicitud.Comentarios == null)
                {
                    return Json(new { success = false, msg= "Ingrese observación" });
                }

                SolicitudPersonalBE solicitudPorActualizar = solicitudBL.GetSolicitudByID(solicitud.CodigoSol);

                ParametroBE estado = new ParametroBE();
                estado.Codigo = 3;
                solicitudPorActualizar.EstadoSol = estado;
                solicitudPorActualizar.Comentarios = solicitud.Comentarios;

                solicitudBL.UpdateSolicitud(solicitudPorActualizar);


                ColaboradorBE oParam = new ColaboradorBE();
                UsuarioBE oParamUser = new UsuarioBE();
                PerfilBE oPerfil = new PerfilBE() { CodPerfil = 0 };
                TiendaBE olocal = new TiendaBE() { CodTienda = 0 };
                oParamUser.Perfil = oPerfil;
                oParamUser.Local = olocal;
                oParam.usuario = oParamUser;

                List<ColaboradorBE> colaboradores = oColaboradorBL.ListarColaboradores(oParam);
                var usuarioCrea = colaboradores.FirstOrDefault(t => t.usuario.CodigoUsuario == solicitudPorActualizar.CodigoUsuario);

                // Configurar envio de correo
                string subject = string.Format("{0}: {1} - {2}", ConfigurationManager.AppSettings.Get("AsuntoMailEnvioSolicitud"), solicitudPorActualizar.CodigoInterno, DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss"));
                string mailFrom = ConfigurationManager.AppSettings.Get("MailEmisor");
                string passwordMailEmisor = ConfigurationManager.AppSettings.Get("PasswordMailEmisor");
                StringBuilder buffer = new StringBuilder();
                buffer.Append("Estimado <b>{0} {1}, {2}</b>");
                buffer.Append("Su solicitud ha sido rechazada. Ver los detalles en el panel de solicitudes. <br />");
                buffer.Append("Saludos cordiales. <br/><br/>");
                buffer.Append("<i>Nota: Por favor no responda este correo.<i>");

                MailHelper.SendMail(mailFrom, passwordMailEmisor, usuarioCrea.Correo, subject, string.Format(buffer.ToString(), usuarioCrea.ApellidoPaterno, usuarioCrea.ApellidoMaterno, usuarioCrea.Nombres), true, System.Net.Mail.MailPriority.Normal);

                return Json(new { success = true });
            }
            return PartialView("Rechazar", solicitud);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}