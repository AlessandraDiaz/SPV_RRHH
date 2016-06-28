using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BL;
using SPV.BE;

public partial class SPV_RRHH_SeleccionConvocatoria : System.Web.UI.Page
{
    private ConvocatoriaBL oConvocatoriaBL = new ConvocatoriaBL();
    private RankingPostulanteBL oRankingPostulanteBL = new RankingPostulanteBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true) {
            return;
        }
        this.ListarDLL();
        dgvPostulantes.DataSource = null;
        dgvPostulantes.DataBind();
    }


    private void ListarDLL() {
        ddlConvocatoriaVigente.Items.Clear();
        ddlConvocatoriaVigente.Items.Add("Seleccione Convocatoria");
        foreach(ConvocatoriaBE oCon in oConvocatoriaBL.ListarConvocatoriaVigente()){
            ddlConvocatoriaVigente.Items.Add(oCon.CodigoConvocatoria);
        }
        ddlConvocatoriaVigente.DataBind();
        ddlConvocatoriaVigente.AutoPostBack = true;
        ddlConvocatoriaVigente.SelectedIndex = 0;
    }

    protected void ddlConvocatoriaVigente_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajeGood.Text = "";
        lblMensajeError.Text = "";
        if (ddlConvocatoriaVigente.SelectedIndex == 0)
        {
            dgvPostulantes.DataSource = null;
            dgvPostulantes.DataBind();
            btnGrabar.Visible = false;
            return;
        }
        dgvPostulantes.DataSource = null;
        dgvPostulantes.DataBind();

        if (oRankingPostulanteBL.ListaRankingPostulanteConvocatoriaVigente(ddlConvocatoriaVigente.SelectedItem.Text).Count == 0)
        {
            lblMensajeError.Text = "Los postulantes no pasaron al nota aprobatoria.";
            return;
        }

        lblMensajeGood.Text = "";
        lblMensajeError.Text = "";

        btnGrabar.Visible = true;
        dgvPostulantes.DataSource = oRankingPostulanteBL.ListaRankingPostulanteConvocatoriaVigente(ddlConvocatoriaVigente.SelectedItem.Text);
        dgvPostulantes.DataBind();

        Int32 cantidad = oConvocatoriaBL.ObtenerCantidadConvocatoria(ddlConvocatoriaVigente.SelectedItem.Text);

        if (cantidad > dgvPostulantes.Rows.Count)
        {
            cantidad = dgvPostulantes.Rows.Count;
        }
        for (int i = 0; i < dgvPostulantes.Rows.Count; i++){
            if (i < cantidad){
                ((CheckBox)dgvPostulantes.Rows[i].Cells[6].FindControl("cbkSeleccion")).Checked = true;
            }
        }


    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        lblMensajeGood.Text = "";
        lblMensajeError.Text = "";
        if (ddlConvocatoriaVigente.SelectedIndex == 0)
        {
            dgvPostulantes.DataSource = null;
            dgvPostulantes.DataBind();
            btnGrabar.Visible = false;
            return;
        }

        Int16 contador = 0;
         for (int i = 0; i < dgvPostulantes.Rows.Count; i++)
         {
             if (((CheckBox)dgvPostulantes.Rows[i].Cells[6].FindControl("cbkSeleccion")).Checked) {
                 contador++;
             }
         }

         Int32 cantidad = oConvocatoriaBL.ObtenerCantidadConvocatoria(ddlConvocatoriaVigente.SelectedItem.Text);

         if (contador > cantidad)
         {
             lblMensajeError.Text = "Recuerde que le piden: " + cantidad + " ganador(es), Usted seleccionó: " + contador + " ganador(es)";
             return;
         }





         for (int i = 0; i < dgvPostulantes.Rows.Count; i++)
         {
             if (((CheckBox)dgvPostulantes.Rows[i].Cells[6].FindControl("cbkSeleccion")).Checked)
             {
                 oConvocatoriaBL.RegistrarGanadorConvocatoria(dgvPostulantes.Rows[i].Cells[0].Text);
             }
         }

         if (oConvocatoriaBL.CerrarConvocatoria(ddlConvocatoriaVigente.SelectedItem.Text))
         {
             lblMensajeError.Text = "";
             lblMensajeGood.Text = "La Convocatoria fue Cerrada.";
             dgvPostulantes.DataSource = null;
             dgvPostulantes.DataBind();
             ListarDLL();
             btnGrabar.Visible = false;
         }
         else {
             lblMensajeError.Text = "Error";
         }
         
    }
}
