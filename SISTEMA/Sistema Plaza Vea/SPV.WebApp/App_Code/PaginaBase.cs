using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;

public class PaginaBase : System.Web.UI.Page
{
    public void MostarMensajeModal(String pMensaje)
    {
        pMensaje = pMensaje.Replace("\n", "\\n");
        pMensaje = pMensaje.Replace("\r", "");
        pMensaje = pMensaje.Replace("\'", "");
        if (pMensaje != string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MensajeModal",
                                                "<script>alert('" + @pMensaje + "');</script>", false);
        }
    }

    public void RegistrarJS(String pJsScript)
    {
        pJsScript = pJsScript.Replace("\n", "\\n");
        pJsScript = pJsScript.Replace("\r", "");
        pJsScript = pJsScript.Replace("\'", "");
        if (pJsScript != string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RegScriptJs",
                                                "<script>" + pJsScript + "</script>", false);
        }
    }

    public PaginaBase()
    {
        this.PreInit += new EventHandler(Page_PreInit);
    }

    protected void Page_PreInit(object sender, System.EventArgs e)
    {
        GlobalizationSection oGlobalization = (GlobalizationSection)ConfigurationManager.GetSection("system.web/globalization");
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(oGlobalization.Culture);
    }

    protected void CargarCombo(DropDownList Combo, object OrigenDatos, string CampoValor, string CampoTexto)
    {
        Combo.DataSource = OrigenDatos;
        Combo.DataValueField = CampoValor;
        Combo.DataTextField = CampoTexto;
        Combo.DataBind();
    }

    # region "Metodos Internos"
    //protected override object LoadPageStateFromPersistenceMedium()
    //{
    //    string viewState = Request.Form["__VSTATE"];
    //    byte[] bytes = Convert.FromBase64String(viewState);
    //    bytes = Compresor.Descomprimir(bytes);
    //    LosFormatter formatter = new LosFormatter();
    //    return formatter.Deserialize(Convert.ToBase64String(bytes));
    //}

    //protected override void SavePageStateToPersistenceMedium(object viewState)
    //{
    //    LosFormatter formatter = new LosFormatter();
    //    StringWriter writer = new StringWriter();
    //    formatter.Serialize(writer, viewState);
    //    string viewStateString = writer.ToString();
    //    byte[] bytes = Convert.FromBase64String(viewStateString);
    //    bytes = Compresor.Comprimir(bytes);
    //    //ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes));
    //    ScriptManager.RegisterHiddenField(this, "__VSTATE", Convert.ToBase64String(bytes));
    //}
    #endregion

    #region "Manejo de Excepciones"
    protected void General_ErrorEvent(object sender, Exception ex)
    {
        //WebFailureEvent input = new WebFailureEvent(this, oUsuario.CUSR_ID, ex.Message));
        //input.Raise();
        //onError = true;
    }

    /*protected void Transaction_ErrorEvent(object sender, Exception ex)
    {
        //TransactionFailureEvent input = new TransactionFailureEvent(sender, oUsuario.CUSR_ID, ex.Message);
        //input.Raise();
        onError = true;
    }

    protected void Web_ErrorEvent(object sender, Exception ex)
    {
        //WebFailureEvent input = new WebFailureEvent(sender, oUsuario.CUSR_ID, ex.Message);
        //input.Raise();
        onError = true;
    }*/
    #endregion
}