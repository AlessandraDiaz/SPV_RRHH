using System;
using System.Net;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SPV.BE;
using SPV.BL.SPV_Seguridad;
using SPV.WebEvents;

public partial class Logueo : PaginaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.pnlLogueo.Focus();
        }
    }

    protected void Logueo_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            String indLogeo, msgLogeo;
            UsuarioBL oSeguridadBL = new UsuarioBL();
            UsuarioBE oUsuario = new UsuarioBE();
            MembershipUser user;

            oUsuario = oSeguridadBL.ValidaLogeoUsuario(this.pnlLogueo.UserName, this.pnlLogueo.Password, out indLogeo, out msgLogeo);
            
            if (indLogeo.Equals("0"))
            {
                e.Authenticated = true;                
            }
            else e.Authenticated = false;

            if (oUsuario == null)
            {
                indLogeo = "-5";
                msgLogeo = "Usuario no existe.";
                e.Authenticated = false;
            }

            if (e.Authenticated)
            {
                //OOpcionSeguridadBEList = OOpcionSeguridadBL.GetAll(oUsuario.NID_PERFIL);

                user = Membership.GetUser(this.pnlLogueo.UserName.ToUpper().Trim());
                if (user == null)
                {
                    user = Membership.CreateUser(this.pnlLogueo.UserName.ToUpper().Trim(), this.pnlLogueo.Password);
                }

                oUsuario.CUSR_ID = this.pnlLogueo.UserName.ToUpper().Trim();
                System.Net.IPHostEntry host;
                host = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]);
                String clientComputerName = host.HostName;

                String usuarioRed = Request.ServerVariables["LOGON_USER"];
                String[] arrusuarioRed;
                if (usuarioRed != null)
                {
                    arrusuarioRed = usuarioRed.Split('\\');
                    if (arrusuarioRed.Length > 0) usuarioRed = arrusuarioRed[arrusuarioRed.Length - 1];
                }
                else usuarioRed = String.Empty;

                ProfileCommon profile = Profile.GetProfile(oUsuario.CUSR_ID);
                profile.Usuario = oUsuario;
                profile.UserName = oUsuario.no_apellido_paterno + " " + oUsuario.no_apellido_materno + " " + oUsuario.no_usuario;
                profile.id_usuario = oUsuario.id_usuario;
                profile.PageSize = 15;
                profile.PageSizeMant = 13;
                profile.PageSizePopUp = 5;
                profile.PageSizeFiles = 3;
                profile.PageSizeDoubleGrid = 7;
                profile.Estacion = clientComputerName;
                profile.UsuarioRed = usuarioRed;
                profile.ipMaquina = host.AddressList[2].ToString();
                profile.id_rol = oUsuario.id_rol;
                profile.id_area = oUsuario.id_area;
                profile.fl_usuario = oUsuario.fl_usuario;
                profile.Save();

                this.pnlLogueo.DestinationPageUrl = "Inicio/Default.aspx";
            }
            else
            {
                this.pnlLogueo.FailureText = msgLogeo;
            }
        }
        catch (Exception ex)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl, false);
            this.Web_ErrorEvent(this, ex);
        }
    }
   
    #region "Excepciones"
    public void Transaction_ErrorEvent(object sender, Exception ex)
    {
        TransactionFailureEvent input = new TransactionFailureEvent(sender, Profile.Usuario.CUSR_ID, ex.Message);
        input.Raise();
    }

    public void Web_ErrorEvent(object sender, Exception ex)
    {
        WebFailureEvent input = new WebFailureEvent(sender, Profile.Usuario.CUSR_ID, ex.Message);
        input.Raise();
    }
    #endregion
    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {

    }
}