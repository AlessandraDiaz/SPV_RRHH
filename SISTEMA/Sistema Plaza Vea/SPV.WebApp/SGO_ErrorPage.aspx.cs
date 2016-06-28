using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SGO_ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MensajeError.Text = Global.getMensajeError();
    }

    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        Response.Redirect(FormsAuthentication.DefaultUrl, false);
    }

    protected void btnCerrarSesion_OnClick(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect(FormsAuthentication.LoginUrl, false);
        Response.End();
    }
}