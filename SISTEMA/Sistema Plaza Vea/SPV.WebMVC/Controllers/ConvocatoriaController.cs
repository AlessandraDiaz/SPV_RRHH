using SPV.BE;
using SPV.BL;
using SPV.WebMVC.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Web.Mvc;

namespace SPV.WebMVC.Controllers
{
    public class ConvocatoriaController : Controller
    {
        // GET: Convocatoria
        public ActionResult Index(string txtCodigoBusqueda, string txtNombreBusqueda, string dpFechaInicio, string dpFechaFin, int? cboTipoConvocatoria, int? cboCargo, int pageSize = 10, int page = 1, string sort = "Nombre", string sortdir = "ASC")
        {
            ParametroBE param1 = new ParametroBE();
            string codigoTipoConvo = ConfigurationManager.AppSettings["CodigoTipoConvocatoria"].ToString();
            param1.CodigoAgrupador = Convert.ToInt32(codigoTipoConvo);

            var tiposConvocatoria = new ParametroBL().Listar(param1);
            ViewBag.TiposConvocatoria = new SelectList(tiposConvocatoria, "Codigo", "Descripcion");

            CargoBE oCargo = new CargoBE();
            oCargo.ID = 0;
            oCargo.Descripcion = string.Empty;

            var cargo = new CargoBL().ListaCargo(oCargo);
            ViewBag.Cargos = new SelectList(cargo, "ID", "Descripcion");

            var records = new ListaPaginada<Convocatoria2BE>();
            ViewBag.id = txtCodigoBusqueda;
            ViewBag.nombre = txtNombreBusqueda;
            ViewBag.sFechaInicio = dpFechaInicio;
            ViewBag.sFechafin = dpFechaFin;
            ViewBag.codTipoConvocatoria = cboTipoConvocatoria;
            ViewBag.codCargo = cboCargo;


            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;

            if (!string.IsNullOrEmpty(dpFechaInicio))
                fechaInicio = DateTime.ParseExact(dpFechaInicio, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(dpFechaFin))
                fechaFin = DateTime.ParseExact(dpFechaFin, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);

            List<Convocatoria2BE> lista = new Convocatoria2BL().Search(txtCodigoBusqueda, txtNombreBusqueda, cboTipoConvocatoria, fechaInicio, fechaFin, cboCargo);

            records.Content = lista
             .OrderBy(sort + " " + sortdir)
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToList();

            // Count
            records.TotalRecords = lista.Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: Convocatoria/Details/5
        public ActionResult Detalle(int id)
        {
            var solicitud = new SolicitudPersonalBL().GetSolicitudByID(id);
            return PartialView(solicitud);
        }

        // GET: Convocatoria/Registrar
        public ActionResult Registrar()
        {
            Convocatoria2BE convocatoria = new Convocatoria2BE();
            CargoBE param = new CargoBE();
            param.ID = 0;
            param.Descripcion = "";

            ParametroBE param1 = new ParametroBE();
            string codigoTipoSolicitud = ConfigurationManager.AppSettings["CodigoTipoSolicitud"].ToString();
            param1.CodigoAgrupador = Convert.ToInt32(codigoTipoSolicitud);

            ParametroBE param2 = new ParametroBE();
            string codigoMotivoFiltro = ConfigurationManager.AppSettings["CodigoMotivoFiltro"].ToString();
            param2.CodigoAgrupador = Convert.ToInt32(codigoMotivoFiltro);

            var listaCargos = new CargoBL().ListaCargo(param).ToList();
            ViewBag.Cargos = new SelectList(listaCargos, "ID", "Descripcion");

            var listaTipoSol = new ParametroBL().Listar(param1).ToList();
            ViewBag.TipoSolicitud = new SelectList(listaTipoSol, "Codigo", "Descripcion");

            var listaMotivos = new ParametroBL().Listar(param2).ToList();
            ViewBag.Motivos = new SelectList(listaMotivos, "Codigo", "Descripcion");

            var listaSolicitudes = new SolicitudPersonalBL().Listar(8,String.Empty, 0 , String.Empty, String.Empty,2,0,0,0).ToList();


            string sort = "CodigoSol";
            int pageSize = 10;
            int page = 1;
            string sortdir = "DESC";

            ListaPaginada<SolicitudPersonalBE> lista = new ListaPaginada<SolicitudPersonalBE>();
            lista.Content = listaSolicitudes.OrderBy(sort + " " + sortdir)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            lista.TotalRecords = listaSolicitudes.Count();
            lista.CurrentPage = page;
            lista.PageSize = pageSize;
            convocatoria.ListaSolicitud = lista;

            return View("Registrar", convocatoria);
        }

        // POST: Convocatoria/Create
        [HttpPost]
        public ActionResult Registrar(Convocatoria2BE convoca)
        {
            try
            {
                DateTime fechaInicio = DateTime.ParseExact(convoca.GetStringFechaInicio, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(convoca.GetStringFechaFin, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);

                var entidad = new Convocatoria2BE();
                entidad.Nombre = convoca.Nombre;
                entidad.FechaInicio = fechaInicio;
                entidad.FechaFin = fechaFin;
                SolicitudPersonalBE SOL = new SolicitudPersonalBE();
                SOL.CodigoSol = convoca.SolicitudID;
                entidad.Solicitud = SOL;

                new Convocatoria2BL().Insert(entidad);

                List<string> destinatarios = new List<string>();

                // Enviar correos
                var colaboradores = new ColaboradorBL().List();

                // Configurar envio de correo
                string subject = string.Format("{0}: {1} - {2}", ConfigurationManager.AppSettings.Get("AsuntoMail"), entidad.Nombre, DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss"));
                string mailFrom = ConfigurationManager.AppSettings.Get("MailEmisor");
                string passwordMailEmisor = ConfigurationManager.AppSettings.Get("PasswordMailEmisor");
                StringBuilder buffer = new StringBuilder();
                buffer.Append("Estimado <b>{0} {1}, {2} </b> ");
                buffer.Append(" Es grato saludarlo e informarle que ha iniciado una nueva convocatoria <br />");
                buffer.Append(" Saludos cordiales. <br/><br/>");
                buffer.Append("<i> Nota: Por favor no responda este correo. <i>");

                var solicitudAsignada = new SolicitudPersonalBL().GetSolicitudByID(convoca.SolicitudID);

                if (solicitudAsignada.TipoConvocatoria.Codigo == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdTipoConvocatoriaInterno")))
                {
                    foreach (var colaborador in colaboradores)
                    {
                        // No enviar al colaborador marcado como externo
                        if (colaborador.ID != Convert.ToUInt32(ConfigurationManager.AppSettings.Get("IdColaboradorExterno")))
                            MailHelper.SendMail(mailFrom, passwordMailEmisor, colaborador.Correo, subject, string.Format(buffer.ToString(), colaborador.ApellidoPaterno, colaborador.ApellidoMaterno, colaborador.Nombres), true, System.Net.Mail.MailPriority.Normal);
                    }
                }
                else if (solicitudAsignada.TipoConvocatoria.Codigo == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdTipoConvocatoriaExterno")))
                {
                    var contactoExterno = colaboradores.FirstOrDefault(t => t.ID == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdColaboradorExterno")));
                    MailHelper.SendMail(mailFrom, passwordMailEmisor, contactoExterno.Correo, subject, string.Format(buffer.ToString(), contactoExterno.ApellidoPaterno, contactoExterno.ApellidoMaterno, contactoExterno.Nombres), true, System.Net.Mail.MailPriority.Normal);
                }

                return Json(new { status = "Success" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Convocatoria/Buscar
        [HttpPost]
        public ActionResult _Registrar(FormCollection collection,int pageSize = 10, int page = 1, string sort = "CodigoSol", string sortdir = "ASC")
        {
            Convocatoria2BE convocatoria = new Convocatoria2BE();

            int cboCargo;
            int cboTipoSolicitud;
            int cboMotivo;

            if (String.IsNullOrEmpty(Request.Form.Get("cboCargo")))
            {
                cboCargo = 0;
            }
            else
            {
                cboCargo = Convert.ToInt32(Request.Form.Get("cboCargo"));
            }


            if (String.IsNullOrEmpty(Request.Form.Get("cboTipoSolicitud")))
            {
                cboTipoSolicitud = 0;
            }
            else
            {
                cboTipoSolicitud = Convert.ToInt32(Request.Form.Get("cboTipoSolicitud"));
            }

            if (String.IsNullOrEmpty(Request.Form.Get("cboMotivo")))
            {
                cboMotivo = 0;
            }
            else
            {
                cboMotivo = Convert.ToInt32(Request.Form.Get("cboMotivo"));
            }

            CargoBE param = new CargoBE();
            param.ID = 0;
            param.Descripcion = "";

            ParametroBE param1 = new ParametroBE();
            string codigoTipoSolicitud = ConfigurationManager.AppSettings["CodigoTipoSolicitud"].ToString();
            param1.CodigoAgrupador = Convert.ToInt32(codigoTipoSolicitud);

            ParametroBE param2 = new ParametroBE();
            string codigoMotivoFiltro = ConfigurationManager.AppSettings["CodigoMotivoFiltro"].ToString();
            param2.CodigoAgrupador = Convert.ToInt32(codigoMotivoFiltro);

            var listaCargos = new CargoBL().ListaCargo(param).ToList();
            ViewBag.Cargos = new SelectList(listaCargos, "ID", "Descripcion", cboCargo);

            var listaTipoSol = new ParametroBL().Listar(param1).ToList();
            ViewBag.TipoSolicitud = new SelectList(listaTipoSol, "Codigo", "Descripcion", cboTipoSolicitud);

            var listaMotivos = new ParametroBL().Listar(param2).ToList();
            ViewBag.Motivos = new SelectList(listaMotivos, "Codigo", "Descripcion", cboMotivo);

            var listaSolicitudes = new SolicitudPersonalBL().Listar(8, String.Empty, cboCargo, String.Empty, String.Empty, 2, 0, cboTipoSolicitud, cboMotivo).ToList();

            //ViewBag.nombre = "testaaaa";
            //ViewBag.FIni = "01/01/2016";
            //ViewBag.FFin = "01/01/2016";

            ListaPaginada<SolicitudPersonalBE> lista = new ListaPaginada<SolicitudPersonalBE>();
            lista.Content = listaSolicitudes.OrderBy(sort + " " + sortdir)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

            lista.TotalRecords = listaSolicitudes.Count();
            lista.CurrentPage = page;
            lista.PageSize = pageSize;
            convocatoria.ListaSolicitud = lista;

            return PartialView("Registrar", convocatoria);
        }

    }
}
