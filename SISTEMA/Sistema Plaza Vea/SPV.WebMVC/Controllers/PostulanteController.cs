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
    public class PostulanteController : Controller
    {

        private SolicitudPersonalBL solicitudBL = new SolicitudPersonalBL();
        private ParametroBL parametroBL = new ParametroBL();
        private CargoBL cargoBL = new CargoBL();
        private Convocatoria2BL convocatoriaBL = new Convocatoria2BL();
        private ColaboradorBL colaboradorBL = new ColaboradorBL();

        // GET: Postulante/Index
        public ActionResult Index(int cboTipoFiltro = 0, string desc = null, int cboFiltro = 0, string fechaIni = null, string fechaFin = null, int cboEstado = 0,
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
            //administrador o Gerente RRHH
            if (FachadaSesion.Usuario.Perfil.CodPerfil == 1 || FachadaSesion.Usuario.Perfil.CodPerfil == 4)
            {
                usuarioID = 0;
            }
            var local = FachadaSesion.Usuario.Local.CodTienda;
            var area = FachadaSesion.Usuario.Area.CodArea;

            List<SolicitudPersonalBE> listadoSolicitud = solicitudBL.ListarSolicitudesConvocatoria(cboTipoFiltro, desc, cboFiltro, fechaIni, fechaFin, cboEstado, usuarioID, local, area);

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

        // GET: Postulante/Seleccion
        public ActionResult Seleccion(int Id)
        {
            Convocatoria2BE convocatoria = convocatoriaBL.Get(Id);
            var listaColaborador = colaboradorBL.ListaPostulanteByConvocatoria(Id).ToList();

            string sort = "ID";
            int pageSize = 10;
            int page = 1;
            string sortdir = "DESC";

            ListaPaginada<ColaboradorBE> lista = new ListaPaginada<ColaboradorBE>();
            lista.Content = listaColaborador.OrderBy(sort + " " + sortdir)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            lista.TotalRecords = listaColaborador.Count();
            lista.CurrentPage = page;
            lista.PageSize = pageSize;
            convocatoria.ListaColaborador = lista;

            return View("Seleccion", convocatoria);

        }

        // POST: Postulante/Seleccion/1
        [HttpPost]
        public ActionResult Seleccion(string id, string seleccionados)
        {
            try
            {
                var colaboradoresList = seleccionados.Split(',');
                int codigoConvocatoria = Convert.ToInt32(id);
                var listaColaborador = colaboradorBL.ListaPostulanteByConvocatoria(codigoConvocatoria).ToList();
                var estadoAprobado = ConfigurationManager.AppSettings["PostulanteAceptado"];
                var estadoRechazado = ConfigurationManager.AppSettings["PostulanteRechazado"];

                foreach (var colabora in listaColaborador)
                {
                    var results = Array.Find(colaboradoresList, s => s.Equals(colabora.ID.ToString()));

                    if (results == null) // no fue seleccionado
                    {
                        ParametroBE paramEstado = new ParametroBE() { Codigo = Convert.ToInt32(estadoRechazado) };
                        colabora.EstadoAceptacion = paramEstado;
                        colaboradorBL.UpdatePostulantes(colabora);
                    }
                    else //Si fue Seleccionado
                    {
                        ParametroBE paramEstado = new ParametroBE() { Codigo = Convert.ToInt32(estadoAprobado) };
                        colabora.EstadoAceptacion = paramEstado;
                        colaboradorBL.UpdatePostulantes(colabora);
                    }
                }

                Convocatoria2BE convoca = convocatoriaBL.Get(codigoConvocatoria);
                ParametroBE param = new ParametroBE() { Codigo = 3 }; // ESTADO DE CONVOCATORIA FINALIZADA
                convoca.Estado = param;

                convocatoriaBL.UpdateEstadoConvocatoria(convoca);

                return Json(new { status = "Success" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Detalle(int id)
        {
            Convocatoria2BE convocatoria = convocatoriaBL.Get(id);
            var listaColaborador = colaboradorBL.ListaPostulanteByConvocatoria(id).ToList();

            string sort = "ID";
            int pageSize = 10;
            int page = 1;
            string sortdir = "DESC";

            ListaPaginada<ColaboradorBE> lista = new ListaPaginada<ColaboradorBE>();
            lista.Content = listaColaborador.OrderBy(sort + " " + sortdir)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            lista.TotalRecords = listaColaborador.Count();
            lista.CurrentPage = page;
            lista.PageSize = pageSize;
            convocatoria.ListaColaborador = lista;

            return View("Detalle", convocatoria);
        }

        // GET: /Postulante/VerCV/1
        public ActionResult VerCV(int id = 0)
        {
            ColaboradorBE cv = colaboradorBL.GetColaboradorByID(id);
            if (cv == null)
            {
                return HttpNotFound();
            }

            return PartialView("VerCV", cv);
        }

        public JsonResult ListaTipoSolicitud()
        {
            ParametroBE param = new ParametroBE();
            string codigoTipoSolicitud = ConfigurationManager.AppSettings["CodigoTipoSolicitud"].ToString();
            param.CodigoAgrupador = Convert.ToInt32(codigoTipoSolicitud);
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
    }
}