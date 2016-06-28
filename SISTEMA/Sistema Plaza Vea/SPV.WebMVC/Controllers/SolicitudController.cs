using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using SPV.BE;
using SPV.BL;

namespace SPV.WebMVC.Controllers
{
    public class SolicitudController : Controller
    {
        private SolicitudPersonalBL solicitudBL = new SolicitudPersonalBL();
        private SolicitudPerfilBL solicitudPerfilBL = new SolicitudPerfilBL();
        private ParametroBL parametroBL = new ParametroBL();
        private PerfilBL perfilBL = new PerfilBL();
        private ListaPaginada<SolicitudPerfilBE> listaPerfilDetalle = null;
        private List<SolicitudPerfilBE> listaPerfilDetalleContent = null;
        // GET: Solicitud
        public ActionResult Index(string descSol = null, int cboTipo = 0, int page = 1, int pageSize = 10, string sort = "CodigoSol", string sortdir = "DESC")
        {
            var records = new ListaPaginada<SolicitudPersonalBE>();
            ViewBag.descSol = descSol;
            ViewBag.tipSol = cboTipo;

            SolicitudPersonalBE solicitud = new SolicitudPersonalBE();
            solicitud.DescripcionSol = (descSol == null ? "" : descSol);

            ParametroBE tipoSolBE = new ParametroBE();
            tipoSolBE.Codigo = cboTipo;

            solicitud.TipoSolicitudSol = tipoSolBE;

            List<SolicitudPersonalBE> listadoSolicitud = solicitudBL.Listar(solicitud);

            records.Content = listadoSolicitud
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = listadoSolicitud.Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            FachadaSesion.EsEdicionSolicitud = false;
            FachadaSesion.listaPerfilesFS = null;
            FachadaSesion.SolicitudFS = null;

            return View(records);
        }

        // GET: /Solicitud/Registrar
        [HttpGet]
        public ActionResult Registrar()
        {
            SolicitudPersonalBE solicitud;
            ListaPaginada<SolicitudPerfilBE> listaPerfil;
            if (FachadaSesion.listaPerfilesFS != null)
            {
                if (FachadaSesion.SolicitudFS == null)
                {
                    solicitud = new SolicitudPersonalBE();
                }
                else
                {
                    solicitud = FachadaSesion.SolicitudFS;
                }

                solicitud.Detalle = FachadaSesion.listaPerfilesFS;
            }
            else
            {
                solicitud = new SolicitudPersonalBE();

                FachadaSesion.SolicitudFS = solicitud;

                listaPerfil = new ListaPaginada<SolicitudPerfilBE>();
                listaPerfil.PageSize = 10;
                listaPerfil.CurrentPage = 1;
                listaPerfil.TotalRecords = 0;
                listaPerfil.Content = new List<SolicitudPerfilBE>();
                solicitud.Detalle = listaPerfil;
                
            }

            return View("Registrar", solicitud);
        }

        [HttpPost]
        public ActionResult Registrar(SolicitudPersonalBE solicitud, string cboTipo)
        {
            try
            {
                if (solicitud.Detalle == null)
                {
                    ListaPaginada<SolicitudPerfilBE> listaPerfil = new ListaPaginada<SolicitudPerfilBE>();
                    listaPerfil.PageSize = 10;
                    listaPerfil.CurrentPage = 1;
                    listaPerfil.TotalRecords = 0;
                    listaPerfil.Content = new List<SolicitudPerfilBE>();
                    solicitud.Detalle = listaPerfil;
                    solicitud.TipoSolicitudSol = new ParametroBE();
                }
                //validaciones
                if (ModelState.IsValid)
                {

                    if (cboTipo == null || cboTipo == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Tipo de solicitud");
                        return View(solicitud);
                    }

                    if (FachadaSesion.listaPerfilesFS == null)
                    {
                        ModelState.AddModelError("MensajeError", "Agrege Perfiles");
                        return View(solicitud);
                    }

                    var listaPerfiles = FachadaSesion.listaPerfilesFS.Content;
                    if (listaPerfiles.Count() == 0)
                    {
                        ModelState.AddModelError("MensajeError", "Agrege Perfiles");
                        return View(solicitud);
                    }
                    else
                    {
                        var idSolicitud = 0;

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = Convert.ToInt32(cboTipo);

                        ParametroBE estado = new ParametroBE();
                        estado.Codigo = Convert.ToInt32(1);

                        solicitud.TipoSolicitudSol = tipoSolicitud;
                        solicitud.EstadoSol = estado;
                        idSolicitud = solicitudBL.IngresarSolicitudPersonal(solicitud);

                        if (idSolicitud != 0)
                        {
                            SolicitudPersonalBE sol = new SolicitudPersonalBE();
                            sol.CodigoSol = idSolicitud;

                            foreach (var item in listaPerfiles)
                            {
                                item.SolicitudPersonal = sol;
                                solicitudPerfilBL.IngresarSolicitudPerfil(item);
                            }
                        }

                        FachadaSesion.listaPerfilesFS = null;
                        FachadaSesion.SolicitudFS = null;
                        TempData["msg"] = "Grabado Correctamente";
                        return RedirectToAction("Index", "Solicitud");
                    }
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
                    if (FachadaSesion.EsEdicionSolicitud)
                    {
                        solicitud = FachadaSesion.SolicitudFS;
                    }
                    else
                    {
                        solicitud = solicitudBL.GetSolicitudByID(id);
                        FachadaSesion.SolicitudFS = solicitud;
                        FachadaSesion.listaPerfilesFS = solicitud.Detalle;
                        FachadaSesion.EsEdicionSolicitud = false;
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("MensajeError", "Ocurrió un error.");
                    return View(solicitud);
                }
            }
            return View(solicitud);
        }

        [HttpPost]
        public ActionResult Editar(SolicitudPersonalBE solicitud, string cboTipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (cboTipo == null || cboTipo == "0")
                    {
                        ModelState.AddModelError("MensajeError", "Seleccione Tipo de solicitud");
                        return View(solicitud);
                    }

                    var listaPerfiles = FachadaSesion.listaPerfilesFS.Content;
                    if (listaPerfiles.Count() == 0)
                    {
                        ModelState.AddModelError("MensajeError", "Agrege Perfiles");
                        return View(solicitud);
                    }
                    else
                    {
                        SolicitudPersonalBE solictudActualizada = null;

                        ParametroBE tipoSolicitud = new ParametroBE();
                        tipoSolicitud.Codigo = Convert.ToInt32(cboTipo);

                        ParametroBE estado = new ParametroBE();
                        estado.Codigo = Convert.ToInt32(1);

                        solicitud.TipoSolicitudSol = tipoSolicitud;
                        solicitud.EstadoSol = estado;
                        solictudActualizada = solicitudBL.UpdateSolicitud(solicitud);

                        if (solictudActualizada != null)
                        {
                            foreach (var item in listaPerfiles)
                            {
                                item.SolicitudPersonal = solictudActualizada;
                                if (item.EstadoItem == 1) //NUEVO
                                {
                                    solicitudPerfilBL.IngresarSolicitudPerfil(item);
                                }
                                else if (item.EstadoItem == 2) // MODIFICADO
                                {
                                    solicitudPerfilBL.UpdateSolicitudPerfil(item);
                                }
                            }

                            if (FachadaSesion.listaPerfilesEliminadosFS != null)
                            {
                                foreach (var item in FachadaSesion.listaPerfilesEliminadosFS)
                                {
                                    solicitudPerfilBL.EliminarSolicitudPerfil(item.CodigoSolicitudPer);
                                }
                            }
                        }

                        FachadaSesion.listaPerfilesFS = null;
                        FachadaSesion.SolicitudFS = null;
                        FachadaSesion.listaPerfilesEliminadosFS = null;
                        FachadaSesion.EsEdicionSolicitud = false;

                        TempData["msg"] = "Grabado Correctamente";
                        return RedirectToAction("Index");
                    }
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

        // GET: /Solicitud/RegistrarPerfil
        [HttpGet]
        public ActionResult RegistrarPerfil()
        {
            var solicitudPerfil = new SolicitudPerfilBE();
            return PartialView("RegistrarPerfil", solicitudPerfil);
        }

        // POST: /Solicitud/RegistrarPerfil
        [HttpPost]
        public ActionResult RegistrarPerfil(SolicitudPerfilBE solicitudPerfil, string cboPerfil)
        {
            if (ModelState.IsValid)
            {
                if (cboPerfil == null || cboPerfil == "0")
                {
                    ModelState.AddModelError("MensajeError", "Seleccione Perfil");
                }

                PerfilBE pe = new PerfilBE { CodPerfil = Convert.ToInt32(cboPerfil), Perfil = string.Empty };
                PerfilBE perfilEN = perfilBL.ListaPerfil(pe).FirstOrDefault();

                if (FachadaSesion.listaPerfilesFS != null)
                {
                    listaPerfilDetalle = FachadaSesion.listaPerfilesFS;
                   

                    listaPerfilDetalleContent = listaPerfilDetalle.Content;

                    var maxID = listaPerfilDetalleContent.Max(x => x.CodigoSolicitudPer);
                    solicitudPerfil.Perfil = perfilEN;
                    solicitudPerfil.EstadoItem = 1;
                    solicitudPerfil.CodigoSolicitudPer = maxID + 1;
                    listaPerfilDetalleContent.Add(solicitudPerfil);

                    listaPerfilDetalle.TotalRecords = listaPerfilDetalleContent.Count();
                    listaPerfilDetalle.CurrentPage = 1;
                    listaPerfilDetalle.PageSize = 10;
                    listaPerfilDetalle.Content = listaPerfilDetalleContent;

                    FachadaSesion.listaPerfilesFS = listaPerfilDetalle;
                    FachadaSesion.EsEdicionSolicitud = true;
                }
                else
                {
                    listaPerfilDetalle = new ListaPaginada<SolicitudPerfilBE>();
                    listaPerfilDetalleContent = new List<SolicitudPerfilBE>();

                    solicitudPerfil.Perfil = perfilEN;
                    listaPerfilDetalleContent.Add(solicitudPerfil);

                    listaPerfilDetalle.TotalRecords = listaPerfilDetalleContent.Count();

                    listaPerfilDetalle.CurrentPage = 1;
                    listaPerfilDetalle.PageSize = 10;

                    listaPerfilDetalle.Content = listaPerfilDetalleContent;

                    FachadaSesion.listaPerfilesFS = listaPerfilDetalle;
                }

                return Json(new { success = true });
            }
            return PartialView("RegistrarPerfil", solicitudPerfil);
        }

        // GET: /Solicitud/EditarPerfil/5
        [HttpGet]
        public ActionResult EditarPerfil(int id = 0)
        {
            var listaPerfilesSolicitud = FachadaSesion.listaPerfilesFS;
            listaPerfilDetalleContent = listaPerfilesSolicitud.Content;

            var query = (from item in listaPerfilDetalleContent
                         where item.CodigoSolicitudPer == id
                         select item).ToList<SolicitudPerfilBE>();

            SolicitudPerfilBE perfilSolicitud = query.FirstOrDefault();
            if (perfilSolicitud == null)
            {
                return HttpNotFound();
            }

            return PartialView("EditarPerfil", perfilSolicitud);
        }

        // POST: /Solicitud/EditarPerfil/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPerfil(SolicitudPerfilBE solicitudPerfil, string cboPerfil)
        {
            if (ModelState.IsValid)
            {
                var listaPerfilesSolicitud = FachadaSesion.listaPerfilesFS;
                listaPerfilDetalleContent = listaPerfilesSolicitud.Content;

                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).CantidadSolicitudPer = solicitudPerfil.CantidadSolicitudPer;
                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).Perfil.CodigoPerfil = Convert.ToInt32(cboPerfil);
                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).Funciones = solicitudPerfil.Funciones;
                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).Requisitos = solicitudPerfil.Requisitos;
                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).Sueldo = solicitudPerfil.Sueldo;
                listaPerfilDetalleContent.Find(p => p.CodigoSolicitudPer == solicitudPerfil.CodigoSolicitudPer).EstadoItem = 2;
                listaPerfilesSolicitud.Content = listaPerfilDetalleContent;
                FachadaSesion.listaPerfilesFS = listaPerfilesSolicitud;
                FachadaSesion.EsEdicionSolicitud = true;

                return Json(new { success = true });
            }
            return PartialView("Edit", solicitudPerfil);
        }

        // GET: /Solicitud/EliminarPerfil/5
        public ActionResult EliminarPerfils(int id = 0)
        {
            var listaPerfilesSolicitud = FachadaSesion.listaPerfilesFS;
            listaPerfilDetalleContent = listaPerfilesSolicitud.Content;

            var query = (from item in listaPerfilDetalleContent
                         where item.CodigoSolicitudPer == id
                         select item).ToList<SolicitudPerfilBE>();

            SolicitudPerfilBE solicitudPerfil = query.FirstOrDefault();
            FachadaSesion.EsEdicionSolicitud = true;
            if (solicitudPerfil == null)
            {
                return HttpNotFound();
            }
            return PartialView("EliminarPerfils", solicitudPerfil);
        }

        // POST: /Solicitud/EliminarPerfils/5
        [HttpPost, ActionName("EliminarPerfils")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarPerfilsConfirm(int id)
        {
            var listaPerfilesSolicitud = FachadaSesion.listaPerfilesFS;
            listaPerfilDetalleContent = listaPerfilesSolicitud.Content;
            List<SolicitudPerfilBE> listaNegra;

            var query = (from item in listaPerfilDetalleContent
                         where item.CodigoSolicitudPer == id
                         select item).ToList<SolicitudPerfilBE>();

            SolicitudPerfilBE solicitudPerfil = query.FirstOrDefault();

            if (FachadaSesion.listaPerfilesEliminadosFS == null)
            {
                listaNegra = new List<SolicitudPerfilBE>();
                listaNegra.Add(solicitudPerfil);
            }
            else
            {
                listaNegra = FachadaSesion.listaPerfilesEliminadosFS;
                listaNegra.Add(solicitudPerfil);
            }
            FachadaSesion.listaPerfilesEliminadosFS = listaNegra;
            listaPerfilDetalleContent.Remove(solicitudPerfil);

            listaPerfilesSolicitud.Content = listaPerfilDetalleContent;
            FachadaSesion.listaPerfilesFS = listaPerfilesSolicitud;

            return Json(new { success = true });
        }

        public JsonResult ListaTipoSolicitud()
        {
            ParametroBE param = new ParametroBE();
            param.CodigoAgrupador = 1;
            return Json(parametroBL.Listar(param).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaPerfiles()
        {
            PerfilBE perfil = new PerfilBE();
            perfil.CodPerfil = 0;
            perfil.Perfil = string.Empty;
            return Json(perfilBL.ListaPerfil(perfil).ToList(), JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}