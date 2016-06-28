using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BE;
using SPV.BL;

public partial class SPV_RRHH_AgregarExamen : System.Web.UI.Page
{
    private PerfilBL oPerfilBL = new PerfilBL();
    private ExamenBL oExamenBL = new ExamenBL();
    private ExamenPreguntaBL oExamenPreguntaBL = new ExamenPreguntaBL();
    private PreguntaAlternativaBL oPreguntaAlternativaBL = new PreguntaAlternativaBL();

    private static ExamenBE oExamen = null;
    private static ExamenPreguntaBE oExamenPreguntaBE;
    private static PreguntaAlternativaBE oPreguntaAlternativaBE;

    private static List<PreguntaAlternativaBE> lAlternativa = new List<PreguntaAlternativaBE>();
    private static List<ExamenPreguntaBE> lPregunta = new List<ExamenPreguntaBE>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            return;
        }
        oExamen = null;
        btnAgregar.Attributes.Add("onclick", "javascript: return validar();");
        this.ListarDDL();
    }


    private void ListarDDL() {

        foreach ( PerfilBE vPerfil in oPerfilBL.ListaPerfil())
        {
            ddlPerfil.Items.Add(vPerfil.NombrePerfil);
        }
        ddlPerfil.DataBind();
    }

    private void ListarDGVPregunta()
        {
            dgvPregunta.DataSource = oExamen.ListaPregunta;
            dgvPregunta.DataBind();
        }

        private void LimpiarPanelPregunta() {
            txtPregunta.Text = "";
            ddlEstadoPregunta.SelectedIndex = 0;
            ddlTipoPregunta.SelectedIndex = 0;
        }

        private void LimpiarPanelAlternativa() {
            cbkCorrecta.Checked = false;
            txtPuntaje.Text = "";
            txtAlternativa.Text = "";

            dgvAlternativa.DataSource = null;
            dgvAlternativa.DataBind();
        }
       
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtNombreExamen.Text == "" || txtNombreExamen.Text == null){
                lblMensajeError.Text = "Ingrese un nombre del Examen";
                return;
            }
            if (txtDescripcion.Text == "" || txtDescripcion.Text == null)
            {
                lblMensajeError.Text = "Ingrese una descripcion";

                return;
            }

            lblMensajeError.Text = "";
            if (oExamen == null)
            {
                oExamen = new ExamenBE(0, ddlPerfil.SelectedItem.Text, ddlTipoExamen.SelectedValue.ToString(), txtNombreExamen.Text, txtDescripcion.Text, "ACT");
            }

            pnlExamen.Visible = false;
            pnlAlternativa.Visible = false;
            pnlPregunta.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ListarExamen.aspx?msg=null");
        }

        protected void btnPnlAlternativa_Click(object sender, EventArgs e)
        {
            if(txtPregunta.Text == "" || txtPregunta.Text == null){
                lblMensajeError.Text = "Ingrese una pregunta";
                return;
            }
            lblMensajeError.Text = "";

            oExamenPreguntaBE = new ExamenPreguntaBE(0, txtPregunta.Text, ddlTipoPregunta.SelectedValue.ToString(), ddlEstadoPregunta.SelectedValue.ToString());

            if(ddlTipoPregunta.SelectedValue == "UNI"){
                lblUnica.Visible = true;
                rblOpcionUnica.Visible = true;

                //cbkCorrecta.Visible = false;

                Label7.Visible = false;
                txtAlternativa.Visible = false;
            }
            else if (ddlTipoPregunta.SelectedValue == "MUL")
            {
                Label7.Visible = true;
                txtAlternativa.Visible = true;

                //cbkCorrecta.Visible = true;

                lblUnica.Visible = false;
                rblOpcionUnica.Visible = false;
            }

            btnAgregarAlternativa.Enabled = true;

            pnlExamen.Visible = false;
            pnlPregunta.Visible = false;
            pnlAlternativa.Visible = true;
        }

        protected void btnTerminarPregunta_Click(object sender, EventArgs e)
        {
            if(dgvAlternativa.Rows.Count < 2){
                lblMensajeError.Text = "Ingrese Alternativas";
                return;
            }


            lblMensajeError.Text = "";
            oExamen.ListaPregunta.Add(oExamenPreguntaBE);

            /*
            oExamenPreguntaBE.CodigoPregunta = Convert.ToInt16(txtCodigoPregunta.Text);
            oExamenPreguntaBE.Pregunta = txtPregunta.Text;
            oExamenPreguntaBE.TipoPregunta = ddlTipoPregunta.SelectedValue;
            oExamenPreguntaBE.EstadoPregunta = ddlEstadoPregunta.SelectedValue;

            for (int i = 0; i < dgvAlternativa.Rows.Count; i++ ){*/
          /*      oPreguntaAlternativaBE = new PreguntaAlternativaBE();
                oPreguntaAlternativaBE.CodigoAlternativa = Convert.ToInt16(dgvAlternativa.Rows[i].Cells[0].Text);
                oPreguntaAlternativaBE.Alternativa = dgvAlternativa.Rows[i].Cells[1].Text;
                oPreguntaAlternativaBE.EsCorrecta = Convert.ToInt16(dgvAlternativa.Rows[i].Cells[2].Text);
                //Response.Write(dgvAlternativa.Rows[i].Cells[2].Controls.GetType());
                oPreguntaAlternativaBE.Puntaje = Convert.ToInt16(dgvAlternativa.Rows[i].Cells[3].Text);
                lAlternativa.Add(oPreguntaAlternativaBE);*/
           /* }

            lPregunta.Add(oExamenPreguntaBE);*/
         //   oExamenPreguntaBE = new ExamenPreguntaBE();
            this.ListarDGVPregunta();
            //Response.Write(i);
            this.LimpiarPanelAlternativa();
            this.LimpiarPanelPregunta();
            
            pnlExamen.Visible = true;
            pnlPregunta.Visible = false;
            pnlAlternativa.Visible = false;
        }

        protected void btnCancelarPregunta_Click(object sender, EventArgs e)
        {
            pnlExamen.Visible = true;
            pnlPregunta.Visible = false;
            pnlAlternativa.Visible = false;
        }

        protected void btnAgregarAlternativa_Click(object sender, EventArgs e)
        {

            btnAgregarAlternativa.Enabled = true;

            if (rblOpcionUnica.Visible == false)
            {
                if (txtAlternativa.Text == "" || txtAlternativa.Text == null)
                {
                    lblMensajeError.Text = "Ingrese Alternativa";
                    return;
                }
                if (txtPuntaje.Text == "" || txtPuntaje.Text == null)
                {

                    lblMensajeError.Text = "Ingrese Puntaje";
                    return;
                }

                Int16 ok = 0;
                if (Convert.ToInt16(txtPuntaje.Text)> 0)
                {
                    ok = 1;
                }

                oPreguntaAlternativaBE = new PreguntaAlternativaBE(0, txtAlternativa.Text, ok, Convert.ToInt16(txtPuntaje.Text), "ACT");
                oExamenPreguntaBE.ListaAlternativa.Add(oPreguntaAlternativaBE);
           
            }
            else
            {
                if (txtPuntaje.Text == "" || txtPuntaje.Text == null)
                {

                    lblMensajeError.Text = "Ingrese Puntaje";
                    return;
                }

                if (Convert.ToInt16(txtPuntaje.Text) < 1)
                {
                    lblMensajeError.Text = "El Puntaje debe ser Mayor a Cero";
                    return;
                }

                if (rblOpcionUnica.SelectedItem.Text == "SI")
                {

                    oPreguntaAlternativaBE = new PreguntaAlternativaBE(0, "SI", 1, Convert.ToInt16(txtPuntaje.Text), "ACT");
                    oExamenPreguntaBE.ListaAlternativa.Add(oPreguntaAlternativaBE);
                    oPreguntaAlternativaBE = new PreguntaAlternativaBE(0, "NO", 0, 0, "ACT");
                    oExamenPreguntaBE.ListaAlternativa.Add(oPreguntaAlternativaBE);
                }
                else if (rblOpcionUnica.SelectedItem.Text == "NO")
                {
                    oPreguntaAlternativaBE = new PreguntaAlternativaBE(0, "NO", 1, Convert.ToInt16(txtPuntaje.Text), "ACT");
                    oExamenPreguntaBE.ListaAlternativa.Add(oPreguntaAlternativaBE);
                    oPreguntaAlternativaBE = new PreguntaAlternativaBE(0, "SI", 0, 0, "ACT");
                    oExamenPreguntaBE.ListaAlternativa.Add(oPreguntaAlternativaBE);
                }
                btnAgregarAlternativa.Enabled = false;
            }

            lblMensajeError.Text = "";

            dgvAlternativa.DataSource = oExamenPreguntaBE.ListaAlternativa;
            dgvAlternativa.DataBind();

            txtAlternativa.Text = "";
            txtPuntaje.Text = "";
            cbkCorrecta.Checked = false;
            txtAlternativa.Focus();
           
            
            
            /*   oPreguntaAlternativaBE = new PreguntaAlternativaBE();
            oPreguntaAlternativaBE.CodigoAlternativa = Convert.ToInt16(txtCodigoAlternativa.Text);
            oPreguntaAlternativaBE.Alternativa = txtAlternativa.Text;
            oPreguntaAlternativaBE.EsCorrecta = Convert.ToInt16(cbkCorrecta.Checked);
            oPreguntaAlternativaBE.Puntaje = Convert.ToInt16(txtPuntaje.Text);
            lAlternativa.Add(oPreguntaAlternativaBE);

            dgvAlternativa.DataSource = lAlternativa;
            dgvAlternativa.DataBind();*/
        }

        protected void btnAgregarExamen_Click(object sender, EventArgs e)
        {
            if(oExamen == null){
                lblMensajeError.Text = "Agrege Preguntas al Examen.";
                return;
            }
            lblMensajeError.Text = "";


            if(dgvPregunta.Rows.Count < 3){
                lblMensajeError.Text = "No se Puede Agregar un Examen con solo 2 preguntas";
                return;
            }

            Int32 TotalPuntaje = 0;
            foreach (ExamenPreguntaBE v_Pregunta in oExamen.ListaPregunta) {
                foreach (PreguntaAlternativaBE v_Alternativa in v_Pregunta.ListaAlternativa)
                {
                    TotalPuntaje += v_Alternativa.Puntaje;
                }
            }

            if (TotalPuntaje != 20)
            {
                lblMensajeError.Text = "El puntaje Total Registrado es: " + TotalPuntaje.ToString() + " Recuerde que el puntaje debe sumar 20";
                return;
            }


            String CodigoExamen = oExamenBL.AgregarExamen(oExamen);

            if (CodigoExamen == "0")
            {
                lblMensajeError.Text = "Error al Guardar el Examen";
                return;
            }

            Int16 i = 1;
            foreach (ExamenPreguntaBE v_Pregunta in oExamen.ListaPregunta) {
                v_Pregunta.CodigoPregunta = i;
                oExamenPreguntaBL.AgregarPregunta(CodigoExamen, v_Pregunta);

                Int16 j = 1;
                foreach (PreguntaAlternativaBE v_Alternativa in v_Pregunta.ListaAlternativa)
                {
                    v_Alternativa.CodigoAlternativa = j;
                    oPreguntaAlternativaBL.AgregarAlternativa(CodigoExamen, v_Pregunta.CodigoPregunta.ToString(), v_Alternativa);
                    j++;
                }
                i++;
            }
            lblMensajeError.Text = "";
            


            /*
              Response.Write("Lista de Examen");
              Response.Write("<br />");
              Response.Write("------------------------------");
              Response.Write("<br />");
              Response.Write("Nombre: " + oExamen.Nombre);
              Response.Write("<br />");
              Response.Write("Descripcion: " + oExamen.Descripcion);
              Response.Write("<br />");
              Response.Write("Tipo Examen: " + oExamen.TipoExamen);
              Response.Write("<br />");
              Response.Write("Estado: " + oExamen.Estado);
              Response.Write("<br />");
              Response.Write("------------------Preguntas----------------");
              Response.Write("<br />");
              Int16 i = 1;
              foreach(ExamenPreguntaBE v_Pregunta in oExamen.ListaPregunta){
                  v_Pregunta.CodigoPregunta = i;

                  Response.Write("Codigo Pregunta: " + v_Pregunta.CodigoPregunta);
                  Response.Write("<br />");
                  Response.Write("Pregunta: " + v_Pregunta.Pregunta);
                  Response.Write("<br />");
                  Response.Write("Tipo Pregunta: " + v_Pregunta.TipoPregunta);
                  Response.Write("<br />");
                  Response.Write("Estado: " + v_Pregunta.EstadoPregunta);
                  Response.Write("<br />");
                  Response.Write("-----------------Alternativas-----------------");
                  Response.Write("<br />");
                
                  Int16 j = 1;
                  foreach(PreguntaAlternativaBE v_Alternativa in v_Pregunta.ListaAlternativa){
                      v_Alternativa.CodigoAlternativa = j;

                      Response.Write("Codigo Alternativa: " + v_Alternativa.CodigoAlternativa);
                      Response.Write("<br />");
                      Response.Write("Alternativa: " + v_Alternativa.Alternativa);
                      Response.Write("<br />");
                      Response.Write("Correcta? : " + v_Alternativa.EsCorrecta);
                      Response.Write("<br />");
                      Response.Write("Puntaje : " + v_Alternativa.Puntaje);
                      Response.Write("<br />");
                      j++;

                  }
                  i++;
              }
            */
            
            Response.Redirect("./ListarExamen.aspx?msg=1");
            oExamen = null;
            txtNombreExamen.Text = "";
            txtDescripcion.Text = "";
            ddlTipoExamen.SelectedIndex = 0;

            dgvPregunta.DataSource = null;
            dgvPregunta.DataBind();
           
        }
        protected void dgvAlternativa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (rblOpcionUnica.Visible == false)
            {
                /*oExamenPreguntaBE.ListaAlternativa.RemoveAt(0);
                oExamenPreguntaBE.ListaAlternativa.RemoveAt(1);*/

                oExamenPreguntaBE.ListaAlternativa.RemoveAt(e.RowIndex);
            }
            else
            {


                oExamenPreguntaBE.ListaAlternativa.RemoveAt(0);
                oExamenPreguntaBE.ListaAlternativa.RemoveAt(0);
                btnAgregarAlternativa.Enabled = true;
            }

            
            dgvAlternativa.DataSource = oExamenPreguntaBE.ListaAlternativa;
            dgvAlternativa.DataBind();
        }
        protected void dgvPregunta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            oExamen.ListaPregunta.RemoveAt(e.RowIndex);

            dgvPregunta.DataSource = oExamen.ListaPregunta;
            dgvPregunta.DataBind();
        }
}

