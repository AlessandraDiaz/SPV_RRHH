using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class SPV_RRHH_SolicitudPersonal : System.Web.UI.Page
{
    private TurnoBL oTurnoBL = new TurnoBL();
    private PerfilBL oPerfilBL = new PerfilBL();
    private AreaTiendaBL oAreaTiendaBL = new AreaTiendaBL();
    private ColaboradorBL oColaboradorBL = new ColaboradorBL();
    private SolicitudPersonalBL oSolicitudPersonalBL = new SolicitudPersonalBL();
    private SolicitudPerfilBL oSolicitudPerfilBL = new SolicitudPerfilBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            return;
        }
        //btnContinuarPnlOrden.Attributes.Add("onclick", "javascript: return ValidarPnlPerfil();");
       // btnAgregarPerfilRequisito.Attributes.Add("onclick", "javascript: return ValidarAgregarRequisito();");
        btnAgregarSolicitudPersonal.Attributes.Add("onclick", "javascript: return ValidarPnlOrden();");
        lblMensaje.Visible = false;
        this.ObterneDatos();
    }


    private void ObterneDatos()
    {
        /* String nombre = Request.QueryString["txtNombre"];
         txtNombrePerfil.Text = nombre.Trim();*/
    }

    private void CargarDDL()
    {
        ddlHorario.Items.Clear();
        ddlHorario.Items.Add("Seleccione un Horario");
        foreach (TurnoBE pTurno in oTurnoBL.ListarTurno())
        {
            ddlHorario.Items.Add(new ListItem(pTurno.Descripcion + " - " + pTurno.DiaInicio + " a " + pTurno.DiaFin, pTurno.HoraInicio + " a " + pTurno.HoraFin));
        }
        ddlHorario.AutoPostBack = true;
        ddlHorario.DataBind();


        ddlPerfil.Items.Clear();
        ddlPerfil.Items.Add("Seleccione un Perfil");
        foreach (PerfilBE pPerfil in oPerfilBL.ListaPerfil())
        {
            ddlPerfil.Items.Add(new ListItem(pPerfil.NombrePerfil, pPerfil.CodigoPerfil.ToString()));
        }
        ddlPerfil.AutoPostBack = true;
        ddlPerfil.DataBind();

        String usuario = Profile.Usuario.no_login;

        ddlCantidadRequerida.Items.Clear();
        ddlCantidadRequerida.Items.Add("Seleccione una cantidad");
        for (int i = 1; i <= oAreaTiendaBL.ObtenerCapacidadLibre(usuario); i++)
        {
            ddlCantidadRequerida.Items.Add(i.ToString());
        }
        ddlHorario.DataBind();
    }





    protected void btnAgregarSolicitudPersonal_Click(object sender, EventArgs e)
    {
        //-------------------------------
        if (ddlTipoSolicitudPersonal.SelectedIndex == 0)
        {
            ddlTipoSolicitudPersonal.Focus();
            return;
        }

        try
        {
            String usuario = Profile.Usuario.no_login;

            if (oColaboradorBL.ObtenerCodigoCargoColaborador(usuario) != 12)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Usted no tiene permisos para acceder a esta Solicitud... ";
                return;
            }
            if (oAreaTiendaBL.ObtenerCapacidadLibre(usuario) <= 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Lo sentimos no hay Puestos Libres en su Área";
            }

        }
        catch (Exception)
        {
            Session.Abandon();
            Response.Redirect("./../Logueo.aspx");
        }



        //--------------------------------



        if (ddlPerfil.SelectedIndex == 0)
        {
            ddlPerfil.Focus();
            return;
        }




        //----------------------------------------





        if (ddlHorario.SelectedIndex == 0)
        {
            ddlHorario.Focus();
            return;
        }
        if (ddlCantidadRequerida.SelectedIndex == 0)
        {
            ddlCantidadRequerida.Focus();
            return;
        }

        Int32 CodigoColaborador = oColaboradorBL.ObtenerCodigoColaborador(Profile.Usuario.no_login);
        Int32 ContratoColaborador = oColaboradorBL.ObtenerContratoColaborador(Profile.Usuario.no_login);
        DateTime oSet = new DateTime().Date;
        SolicitudPersonalBE oSolicitud = new SolicitudPersonalBE(0,
                                                                oSet, 
                                                                oSet, 
                                                                ddlTipoSolicitudPersonal.SelectedItem.Text, 
                                                                txtMotivo.Text, 
                                                                ddlHorario.SelectedItem.Text + " :: " + ddlHorario.SelectedValue.ToString(), 
                                                                txtTiempoContrato.Text + " " + ddlTiempoOrden.SelectedItem.Text, 
                                                                txtTiempoApoyo.Text + " " + ddlTiempoOrden.SelectedItem.Text, 
                                                                txtMotivo.Text, 
                                                                Convert.ToDouble(txtSueldoPerfil.Text), 
                                                                oSet, 
                                                                0);

        Int32 CodigoSolicitud = oSolicitudPersonalBL.IngresarSolicitudPersonal(CodigoColaborador, ContratoColaborador, oSolicitud);

        lblMensaje.Visible = true;
        if (CodigoSolicitud == 0)
        {
            lblMensaje.Text = "Error En Agregar Solicitud Personal";
            return;
        }


        if (oSolicitudPerfilBL.IngresarSolicitudPerfil(CodigoSolicitud, Convert.ToInt32(ddlPerfil.SelectedValue.ToString()), Convert.ToInt32(ddlCantidadRequerida.SelectedIndex.ToString())))
        {
            this.Limpiar();
            lblMensaje.Text = "La Solicitud Fue Realizada un Exito! Su Codigo de Solicitud es " + CodigoSolicitud.ToString("000000000");
            
        }
        else
        {
            lblMensaje.Text = "Error Ingresar Solitud Perfil";
        }

    }
    protected void ddlHorario_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtHorario.Text = ddlHorario.SelectedValue;
    }

    protected void ddlTipoSolicitudPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoSolicitudPersonal.SelectedIndex == 1)
        {
            txtTiempoContrato.Text = "0";
            txtTiempoApoyo.Text = "1";
            txtTiempoContrato.Visible = false;
            lblTiempoContrato.Visible = false;
            txtTiempoApoyo.Visible = true;
            lblTiempoApoyo.Visible = true;
        }
        if (ddlTipoSolicitudPersonal.SelectedIndex == 2)
        {
            txtTiempoContrato.Text = "1";
            txtTiempoApoyo.Text = "0";
            txtTiempoApoyo.Visible = false;
            lblTiempoApoyo.Visible = false;
            txtTiempoContrato.Visible = true;
            lblTiempoContrato.Visible = true;
        }

        this.CargarDDL();

    }

    protected void btnContinuarPnlPerfil_Click(object sender, EventArgs e)
    {
        if (ddlTipoSolicitudPersonal.SelectedIndex == 0)
        {
            ddlTipoSolicitudPersonal.Focus();
            return;
        }
        
        try {
            String usuario = Profile.Usuario.no_login;

            if(oColaboradorBL.ObtenerCodigoCargoColaborador(usuario) != 12){
                lblMensaje.Visible = true;
                lblMensaje.Text = "Usted no tiene permisos para acceder a esta Solicitud... ";
                return;
            }
            if (oAreaTiendaBL.ObtenerCapacidadLibre(usuario) <= 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Lo sentimos no hay Puestos Libres en su Área";
            }

        }catch(Exception){
            Session.Abandon();
            Response.Redirect("./../Logueo.aspx");
        }



       // this.CargarDDL();

        pnlSolicitudPersonal.Visible = false;
        pnlPerfil.Visible = true;
        pnlOrden.Visible = false;
    }
    protected void btnContinuarPnlOrden_Click(object sender, EventArgs e)
    {
        if (ddlPerfil.SelectedIndex == 0)
        {
            ddlPerfil.Focus();
            return;
        }


        pnlSolicitudPersonal.Visible = false;
        pnlPerfil.Visible = false;
        pnlOrden.Visible = true;
        btnAgregarSolicitudPersonal.Visible = true;

    }

    private void Limpiar() {
        #region "pnlSolicitud"
        ddlTipoSolicitudPersonal.SelectedIndex = 0;
        #endregion
        #region "pnlPerfil"
        ddlPerfil.SelectedIndex = 0;
        txtAreasPerfil.Text = "";
        txtDescripcionPerfil.Text = "";
        txtSueldoPerfil.Text = "";
        lbxRequisito.Items.Clear();
        #endregion
        #region "pnlOrden"
        ddlTiempoOrden.SelectedIndex = 0;
        ddlHorario.SelectedIndex = 0;
        ddlCantidadRequerida.SelectedIndex = 0;
        txtTiempoApoyo.Text = "0";
        txtTiempoContrato.Text = "0";
        txtMotivo.Text = "";
      //  btnAgregarSolicitudPersonal.Visible = false;
        #endregion
      /*  pnlSolicitudPersonal.Visible = true;
        pnlPerfil.Visible = false;
        pnlOrden.Visible = false;*/
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        this.Limpiar();
        lblMensaje.Text = "";
        ddlPerfil.Items.Clear();
    }
    protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlPerfil.SelectedIndex == 0){
            txtAreasPerfil.Text = "";
            txtSueldoPerfil.Text = "";
            txtDescripcionPerfil.Text = "";
            lbxRequisito.Items.Clear();
            return;
        }

        PerfilBE pPerfil = oPerfilBL.BuscarPerfil(Convert.ToInt32(ddlPerfil.SelectedValue.ToString()));

        if (pPerfil == null)
        {
            return;
        }
        else {
            txtAreasPerfil.Text = pPerfil.AreasPerfil;
            txtSueldoPerfil.Text = pPerfil.Sueldo.ToString();
            txtDescripcionPerfil.Text = pPerfil.Descripcion;

            foreach (PerfilRequisitoBE pRequistio in pPerfil.ListaRequisito)
            {
                lbxRequisito.Items.Add(pRequistio.Requisito);
            }
        
        }
     
    }
}