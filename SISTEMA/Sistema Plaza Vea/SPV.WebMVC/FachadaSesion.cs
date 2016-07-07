using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPV.BE;

namespace SPV.WebMVC
{
    public class FachadaSesion
    {
        /// <summary>
        /// Usuario actual.
        /// </summary>
        public static UsuarioBE Usuario
        {
            get
            {
                return Obtener<UsuarioBE>("entrada");
            }
            set { Asignar("entrada", value); }
        }

        public static SolicitudPersonalBE SolicitudFS
        {
            get
            {
                return Obtener<SolicitudPersonalBE>("SolicitudPer");
            }
            set { Asignar("SolicitudPer", value); }
        }

        public static List<CampanaBE> Campanas
        {
            get
            {
                return Obtener<List<CampanaBE>>("ListCampanas");
            }
            set { Asignar("ListCampanas", value); }
        }

        public static List<CargoBE> Cargos
        {
            get
            {
                return Obtener<List<CargoBE>>("ListCargos");
            }
            set { Asignar("ListCargos", value); }
        }

        private static void Asignar(string key, object value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T Obtener<T>(string key)
        {
            var x = new HttpContextWrapper(HttpContext.Current);
            var y = x.Session[key];

            return (T)HttpContext.Current.Session[key];
        }

        private static bool Existe(string key)
        {
            bool retval = HttpContext.Current.Session[key] != null;

            return retval;
        }

    }
}