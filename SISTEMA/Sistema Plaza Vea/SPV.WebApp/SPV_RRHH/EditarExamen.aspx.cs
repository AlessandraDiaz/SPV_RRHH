using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BL;
using SPV.BE;

public partial class SPV_RRHH_EditarExamen : System.Web.UI.Page
{
    private Int16 codigo;
    private PerfilBL oPerfilBL = new PerfilBL();
    private ExamenPreguntaBL oExamenPreguntaBL = new ExamenPreguntaBL();
    private ExamenBL oExamenBL = new ExamenBL();
    private PreguntaAlternativaBL oPreguntaAlternativaBL = new PreguntaAlternativaBL();

    private ExamenBE oExamen;
    private PreguntaAlternativaBE oPreguntaAlternativa;
    private ExamenPreguntaBE oExamenPregunta;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            return;
        }
        this.CargarDatosDLL();
        //this.btnAgregarAlternativa.Attributes.Add("onclick", "javascript: return ValidarAlternativa();");
        this.btnPnlAlternativa.Attributes.Add("onclick", "javascript: return ValidarPregunta();");
        this.CargarDatos();
    }



    private void Obtener()
    {
        try
        {
            // codigo = Convert.ToInt16(Request.QueryString[0]);
            codigo = Convert.ToInt16(Request.QueryString["id"]);
            if (codigo == 0)
            {
                Response.Redirect("./ListarExamen.aspx?msg=null");
            }
        }
        catch (Exception)
        {
            Response.Redirect("./ListarExamen.aspx?msg=null");
        }
    }

    private void CargarDatosDLL()
    {
        foreach (PerfilBE v_Perfil in oPerfilBL.ListaPerfil())
        {
            ddlPerfil.Items.Add(new ListItem(v_Perfil.NombrePerfil, v_Perfil.NombrePerfil));
        }
        ddlPerfil.DataBind();

        ddlTipoExamen.Items.Add(new ListItem("Evaluacion Perfil", "1"));
        ddlTipoExamen.Items.Add(new ListItem("Examen Psicologico", "2"));
        ddlTipoExamen.Items.Add(new ListItem("Examen Psicotecnico", "3"));
        ddlTipoExamen.Items.Add(new ListItem("Entrevista Personal", "4"));
        ddlTipoExamen.DataBind();
    }

    private void CargarDatos()
    {
        this.Obtener();
       // oExamen = new ExamenBE();----------------
        //txtCodigo.Text = this.codigo.ToString();
        oExamen = oExamenBL.BuscarExamen(this.codigo.ToString());
        txtCodigo.Text = oExamen.Codigo.ToString();
        txtNombreExamen.Text = oExamen.Nombre;
        txtDescripcionExamen.Text = oExamen.Descripcion;
        ddlPerfil.SelectedValue = oExamen.Perfil;
        ddlTipoExamen.SelectedValue = oExamen.TipoExamen;

        dgvPregunta.DataSource = oExamenPreguntaBL.BuscarListaPregunta(oExamen.Codigo.ToString());
        dgvPregunta.DataBind();

    }

    protected void btnGuardarExamen_Click(object sender, EventArgs e)
    {
        ExamenBE vExamen = new ExamenBE(Convert.ToInt16(txtCodigo.Text),
                                        ddlPerfil.SelectedItem.Text,
                                        ddlTipoExamen.SelectedValue.ToString(),
                                        txtNombreExamen.Text,
                                        txtDescripcionExamen.Text,
                                        ddlPerfil.SelectedValue.ToString());
        if (oExamenBL.ActualizarExamen(vExamen))
        {
            Response.Redirect("./ListarExamen.aspx?msg=1");

        }
        else {
            lblMensaje.Text = "Error";
        }


    }

    protected void btnAgregarPregunta_Click(object sender, EventArgs e)
    {
        txtCodigoPregunta.Text = oExamenPreguntaBL.GenerarCodigoPregunta(txtCodigo.Text);
        txtPregunta.Text = "";
        ddlEstadoPregunta.SelectedIndex = 0;
        ddlTipoPregunta.SelectedIndex = 0;

        txtAlternativa.Text = "";
        txtPuntaje.Text = "";
        cbkCorrecta.Checked = false;
        dgvAlternativa.DataSource = null;
        dgvAlternativa.DataBind();

        //txtCodigoAlternativa.Text = (lAlternativa.Count + 1).ToString();

        btnAgregarAlternativa.Visible = true;
        btnTerminarPregunta.Visible = true;
        btnPnlAlternativa.Visible = true;
        btnActualizarAlternativa.Visible = false;
        pnlExamen.Visible = false;
        pnlAlternativa.Visible = false;
        pnlPregunta.Visible = true;
    }

    protected void dgvPregunta_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (oExamenPreguntaBL.EliminarPregunta(txtCodigo.Text, dgvPregunta.Rows[e.RowIndex].Cells[0].Text))
        {
            lblMensaje.Text = "Pregunta Eliminada";
            dgvPregunta.DataSource = oExamenPreguntaBL.BuscarListaPregunta(txtCodigo.Text);
            dgvPregunta.DataBind();
        }
        else
        {
            lblMensaje.Text = "Error al eliminar Pregunta";
        }
    }

    protected void btnPnlAlternativa_Click(object sender, EventArgs e)
    {
        
        oExamenPregunta = new ExamenPreguntaBE(Convert.ToInt16(txtCodigoPregunta.Text),
                                               txtPregunta.Text,
                                               ddlTipoPregunta.SelectedValue,
                                               "ACT");
       /* oExamenPregunta.CodigoPregunta = Convert.ToInt16(txtCodigoPregunta.Text);
        oExamenPregunta.Pregunta = txtPregunta.Text;
        oExamenPregunta.TipoPregunta = ddlTipoPregunta.SelectedValue;*/
        //oExamenPregunta.TipoPregunta = ddlTipoPregunta.SelectedValue;
        if (oExamenPreguntaBL.AgregarPregunta(txtCodigo.Text, oExamenPregunta) == false)
        {
            return;
        }

        txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);

        if (ddlTipoPregunta.SelectedValue == "UNI") {
            //UNICA
            lblUnica.Visible = true;
            rblUnica.Visible = true;

            cbkCorrecta.Visible = false;

            lblAlternativaText.Visible = false;
            txtAlternativa.Visible = false;

        } else if (ddlTipoPregunta.SelectedValue == "MUL") {

            lblUnica.Visible = false;
            rblUnica.Visible = false;

            cbkCorrecta.Visible = false;

            lblAlternativaText.Visible = true;
            txtAlternativa.Visible = true;
            // MULTIPLE
        }

        btnAgregarAlternativa.Enabled = true;

        pnlExamen.Visible = false;
        pnlPregunta.Visible = false;
        pnlAlternativa.Visible = true;
    }

    protected void btnCancelarPregunta_Click(object sender, EventArgs e)
    {
        txtCodigoPregunta.Text = "";
        txtPregunta.Text = "";
        ddlTipoPregunta.SelectedIndex = 0;
        ddlEstadoPregunta.SelectedIndex = 0;
        pnlPregunta.Visible = false;
        pnlAlternativa.Visible = false;
        pnlExamen.Visible = true;
    }

    protected void btnAgregarAlternativa_Click(object sender, EventArgs e)
    {

       // oPreguntaAlternativa = new PreguntaAlternativaBE();--------------

       
        if (txtPuntaje.Text == "" || txtPuntaje.Text == null)
        {
            lblMensaje.Text = "Ingrese un Puntaje";
            return;
        }

        if (rblUnica.Visible != true)
        {

            //MULTIPLE

            if (txtAlternativa.Text == "" || txtAlternativa.Text == null)
            {
                lblMensaje.Text = "Ingrese una alternativa";
                return;
            }

            Int16 ok;
            if (Convert.ToInt16(txtPuntaje.Text) == 0)
            {
                ok = 0;
            }
            else
            {
                ok = 1;
            }

            oPreguntaAlternativa = new PreguntaAlternativaBE(Convert.ToInt16(txtCodigoAlternativa.Text),
                                                            txtAlternativa.Text,
                                                            ok,
                                                            Convert.ToInt16(txtPuntaje.Text),
                                                            "ACT");

            oPreguntaAlternativaBL.AgregarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, oPreguntaAlternativa);

            txtAlternativa.Text = "";
            cbkCorrecta.Checked = false;
            txtPuntaje.Text = "0";
            txtAlternativa.Focus();
            txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
           
        }
        else {

            //UNICA
           
            if(dgvAlternativa.Rows.Count == 2){
                lblMensaje.Text = "Usted ya tiene 2 alternativa no puede agregar mas.";
                return;
            }


            lblMensaje.Text = "";

            if (rblUnica.SelectedItem.Text == "SI")
            {
                oPreguntaAlternativa = new PreguntaAlternativaBE(Convert.ToInt16(txtCodigoAlternativa.Text), "SI", 1, Convert.ToInt16(txtPuntaje.Text), "ACT");
                oPreguntaAlternativaBL.AgregarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, oPreguntaAlternativa);
                txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);

                oPreguntaAlternativa = new PreguntaAlternativaBE(Convert.ToInt16(txtCodigoAlternativa.Text), "NO", 0, 0, "ACT");
                oPreguntaAlternativaBL.AgregarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, oPreguntaAlternativa);

            }
            else if (rblUnica.SelectedItem.Text == "NO")
            {
                oPreguntaAlternativa = new PreguntaAlternativaBE(Convert.ToInt16(txtCodigoAlternativa.Text), "NO", 1, Convert.ToInt16(txtPuntaje.Text), "ACT");
                oPreguntaAlternativaBL.AgregarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, oPreguntaAlternativa);
                txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);

                oPreguntaAlternativa = new PreguntaAlternativaBE(Convert.ToInt16(txtCodigoAlternativa.Text), "SI", 0, 0, "ACT");
            }
            btnAgregarAlternativa.Enabled = false;
            txtPuntaje.Text = "0";

        }



        lblMensaje.Text = "";

        

        dgvAlternativa.DataSource = oPreguntaAlternativaBL.BuscarListaAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
        dgvAlternativa.DataBind();
    }

    protected void btnTerminarPregunta_Click(object sender, EventArgs e)
    {
        if(dgvAlternativa.Rows.Count < 2){
            lblMensaje.Text = "Recuerde debe Ingresar como minimo 2 alternativas";
            return;
        }

        lblMensaje.Text = "";

        dgvPregunta.DataSource = oExamenPreguntaBL.BuscarListaPregunta(txtCodigo.Text);
        dgvPregunta.DataBind();
        pnlExamen.Visible = true;
        pnlAlternativa.Visible = false;
        pnlPregunta.Visible = false;
    }

    protected void btnTerminarActualizarPregunta_Click(object sender, EventArgs e)
    {
    }

    protected void dgvPregunta_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtCodigoPregunta.Text = oExamenPreguntaBL.ObtenerCodigoPregunta(txtCodigo.Text);
        //txtCodigoAlternativa.Text = (lAlternativa.Count + 1).ToString();
       // oExamenPregunta = new ExamenPreguntaBE();-------------------
        oExamenPregunta = oExamenPreguntaBL.BuscarPregunta(txtCodigo.Text, dgvPregunta.Rows[dgvPregunta.SelectedIndex].Cells[0].Text);
        txtCodigoPregunta.Text = oExamenPregunta.CodigoPregunta.ToString();
        txtPregunta.Text = oExamenPregunta.Pregunta;
        ddlTipoPregunta.SelectedValue = oExamenPregunta.TipoPregunta;
        ddlEstadoPregunta.SelectedValue = oExamenPregunta.EstadoPregunta;
        //oPreguntaAlternativa = oPreguntaAlternativaBL.

        btnTerminarPregunta.Visible = true;
        btnActualizarAlternativa.Visible = true;
        btnPnlAlternativa.Visible = false;
        pnlExamen.Visible = false;
        pnlAlternativa.Visible = false;
        pnlPregunta.Visible = true;
    }

    protected void btnActualizarAlternativa_Click(object sender, EventArgs e)
    {
        txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
        dgvAlternativa.DataSource = oPreguntaAlternativaBL.BuscarListaAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
        dgvAlternativa.DataBind();


        if (ddlTipoPregunta.SelectedValue == "UNI")
        {
            //UNICA
            lblUnica.Visible = true;
            rblUnica.Visible = true;

            cbkCorrecta.Visible = false;

            lblAlternativaText.Visible = false;
            txtAlternativa.Visible = false;

        }
        else if (ddlTipoPregunta.SelectedValue == "MUL")
        {
            // MULTIPLE
            lblUnica.Visible = false;
            rblUnica.Visible = false;

            cbkCorrecta.Visible = false;

            lblAlternativaText.Visible = true;
            txtAlternativa.Visible = true;
        }



        pnlExamen.Visible = false;
        pnlPregunta.Visible = false;
        pnlAlternativa.Visible = true;
    }

    protected void dgvAlternativa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (rblUnica.Visible == true)
        {
            //UNICA
            for (int i = 0; i < dgvAlternativa.Rows.Count; i++ )
            {
                    if (oPreguntaAlternativaBL.EliminarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, dgvAlternativa.Rows[i].Cells[0].Text) == false)
                    {
                        lblMensaje.Text = "Las Alternativa 1";
                        return;
                    }
            }
            dgvAlternativa.DataSource = oPreguntaAlternativaBL.BuscarListaAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
            dgvAlternativa.DataBind();
            lblMensaje.Text = "Las Alternativas fueron Eliminadas";

            txtCodigoAlternativa.Text = oPreguntaAlternativaBL.GenerarCodigoAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
            btnAgregarAlternativa.Enabled = true;
        }
        else {
            //MULTIPLE
            if (oPreguntaAlternativaBL.EliminarAlternativa(txtCodigo.Text, txtCodigoPregunta.Text, dgvAlternativa.Rows[e.RowIndex].Cells[0].Text))
            {
                lblMensaje.Text = "Alternativa Eliminada";
                dgvAlternativa.DataSource = oPreguntaAlternativaBL.BuscarListaAlternativa(txtCodigo.Text, txtCodigoPregunta.Text);
                dgvAlternativa.DataBind();
            }
            else
            {
                lblMensaje.Text = "Error Al Eliminar Alternativa";
            }
        }
        
        
        
       
    }



}