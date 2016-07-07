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
        public ActionResult Index(string txtCodigoBusqueda, string txtNombreBusqueda, string dpFechaInicio, string dpFechaFin, int? cboTipoConvocatoria, int? cboTipoSolicitud, int pageSize = 10, int page = 1, string sort = "Nombre", string sortdir = "ASC")
        {
            var tiposConvocatoria = new ParametroBL().ListarXCodAgrupador(Convert.ToInt32(ConfigurationManager.AppSettings.Get("CodigoTipoConvocatoria")));
            ViewBag.TiposConvocatoria = new SelectList(tiposConvocatoria, "CodigoParametro", "Descripcion");

            var tiposSolicitud = new ParametroBL().ListarXCodAgrupador(Convert.ToInt32(ConfigurationManager.AppSettings.Get("CodigoTipoSolicitud")));
            ViewBag.TiposSolicitud = new SelectList(tiposSolicitud, "CodigoParametro", "Descripcion");

            var records = new ListaPaginada<Convocatoria2BE>();
            ViewBag.id = txtCodigoBusqueda;
            ViewBag.nombre = txtNombreBusqueda;
            ViewBag.sFechaInicio = dpFechaInicio;
            ViewBag.sFechafin = dpFechaFin;
            ViewBag.codTipoConvocatoria = cboTipoConvocatoria;
            ViewBag.codTipoSolicitud = cboTipoSolicitud;


            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;

            if (!string.IsNullOrEmpty(dpFechaInicio))
                fechaInicio = DateTime.ParseExact(dpFechaInicio, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(dpFechaFin))
                fechaFin = DateTime.ParseExact(dpFechaFin, ConfigurationManager.AppSettings.Get("FormatoFecha2"), CultureInfo.InvariantCulture);

            List<Convocatoria2BE> lista = new Convocatoria2BL().Search(txtCodigoBusqueda, txtNombreBusqueda, cboTipoConvocatoria, fechaInicio, fechaFin, cboTipoSolicitud);

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
        public ActionResult Details(int id)
        {
            var convocatoria = new Convocatoria2BL().Get(id);
            var solicitud = new SolicitudPersonalBL().GetSolicitudByID(convocatoria.CodSolicitud);

            return PartialView(solicitud);
        }

        // GET: Convocatoria/Create
        public ActionResult Create()
        {
            var tiposConvocatoria = new ParametroBL().ListarXCodAgrupador(Convert.ToInt32(ConfigurationManager.AppSettings.Get("CodigoTipoConvocatoria")));
            ViewBag.TiposConvocatoria = new SelectList(tiposConvocatoria, "CodigoParametro", "Descripcion");

            var solicitudes = new SolicitudPersonalBL().Listar(0, string.Empty, 0, string.Empty, string.Empty, 1,0,0,0);
            ViewBag.TiposSolicitud = new SelectList(solicitudes, "CodigoSol", "CodigoInterno");

            return View();
        }

        // POST: Convocatoria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string nombre = Request.Form.Get("Nombre");
                DateTime fechaInicio = DateTime.ParseExact(Request.Form.Get("FechaInicio"), ConfigurationManager.AppSettings.Get("FormatoFecha"), CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(Request.Form.Get("FechaFin"), ConfigurationManager.AppSettings.Get("FormatoFecha"), CultureInfo.InvariantCulture);

                int codTipoConvocatoria = Convert.ToInt32(Request.Form.Get("cboTipoConvocatoria"));
                int codSolicitud = Convert.ToInt32(Request.Form.Get("cboSolicitud"));

                var entidad = new Convocatoria2BE();
                entidad.Nombre = nombre;
                entidad.FechaInicio = fechaInicio;
                entidad.FechaFin = fechaFin;
                entidad.CodTipoConvocatoria = codTipoConvocatoria;
                entidad.CodSolicitud = codSolicitud;

                new Convocatoria2BL().Insert(entidad);

                List<string> destinatarios = new List<string>();

                // Enviar correos
                var colaboradores = new ColaboradorBL().List();

                // Configurar envio de correo
                string subject = string.Format("{0}: {1} - {2}", ConfigurationManager.AppSettings.Get("AsuntoMail"), entidad.Nombre, DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss"));
                string mailFrom = ConfigurationManager.AppSettings.Get("MailEmisor");
                string passwordMailEmisor = ConfigurationManager.AppSettings.Get("PasswordMailEmisor");
                StringBuilder buffer = new StringBuilder();
                buffer.Append("Estimado <b>{0} {1}, {2}</b>");
                buffer.Append("Es grato saludarlo e informarle que ha iniciado una nueva convocatoria <br />");
                buffer.Append("Saludos cordiales. <br/><br/>");
                buffer.Append("<i>Nota: Por favor no responda este correo.<i>");
                
                if (entidad.CodTipoConvocatoria == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdTipoConvocatoriaInterno")))
                {
                    foreach (var colaborador in colaboradores)
                    {
                        // No enviar al colaborador marcado como externo
                        if (colaborador.ID != Convert.ToUInt32(ConfigurationManager.AppSettings.Get("IdColaboradorExterno")))
                            MailHelper.SendMail(mailFrom, passwordMailEmisor, colaborador.Correo, subject, string.Format(buffer.ToString(), colaborador.ApellidoPaterno, colaborador.ApellidoMaterno, colaborador.Nombres), true, System.Net.Mail.MailPriority.Normal);
                    }
                }
                else if (entidad.CodTipoConvocatoria == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdTipoConvocatoriaExterno")))
                {
                    var contactoExterno = colaboradores.FirstOrDefault(t => t.ID == Convert.ToInt32(ConfigurationManager.AppSettings.Get("IdColaboradorExterno")));
                    MailHelper.SendMail(mailFrom, passwordMailEmisor, contactoExterno.Correo, subject, string.Format(buffer.ToString(), contactoExterno.ApellidoPaterno, contactoExterno.ApellidoMaterno, contactoExterno.Nombres), true, System.Net.Mail.MailPriority.Normal);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }


    }
}
