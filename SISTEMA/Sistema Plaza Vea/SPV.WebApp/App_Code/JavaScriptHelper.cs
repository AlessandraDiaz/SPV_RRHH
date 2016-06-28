using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class JavaScriptHelper
{
    public JavaScriptHelper()
    {
    }

    public static void Alert(Page page, string message, string key)
    {
        string alert = String.Format("<script type='text/javascript' language='javascript'>alert({0});</script>", message);
        page.ClientScript.RegisterStartupScript(page.GetType(), key, alert);
    }

    public static void Redirect(Page page, string ruta, string key)
    {
        string redirect = String.Format("<script type='text/javascript' language='javascript'>location.href='{0}';</script>", ruta);
        page.ClientScript.RegisterStartupScript(page.GetType(), key, redirect);
    }

    public static void Funcion(Page page, string funcion, string parametros, string key)
    {
        string executeFuncion = String.Format("<script type='text/javascript' language='javascript'>{0}({1});</script>", funcion, parametros);
        page.ClientScript.RegisterStartupScript(page.GetType(), key, executeFuncion);
    }
}