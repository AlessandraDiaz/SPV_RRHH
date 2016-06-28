using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPV.BL;

public partial class SPV_RRHH_ListarExamen : System.Web.UI.Page
{

    ExamenBL oExamenBL = new ExamenBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {
            return;
        }
        this.ListarExamenes();
    }



    private void ListarExamenes()
    {
        dgvExamen.DataSource = new ExamenBL().ListarExamen();
        dgvExamen.DataBind();
    }

    protected void btnAgregarExamen_Click(object sender, EventArgs e)
    {
        Response.Redirect("./AgregarExamen.aspx");
    }

    protected void dgvExamen_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        int filaSeleccionada = dgvExamen.SelectedIndex;
        String codigo = dgvExamen.Rows[filaSeleccionada].Cells[0].Text;
        //  string columnaSeleccionada = gv.SelectedValue.ToString() ;
        Response.Redirect("./EditarExamen.aspx?id=" + codigo + "");

        //  LinkButton lb = gv.Rows[filaSeleccionada].Cells[0].Controls[0] as LinkButton;
    }

    protected void dgvExamen_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


        if (oExamenBL.EliminarExamen(dgvExamen.Rows[e.RowIndex].Cells[0].Text) == true)
        {
            //lblMensaje.Text = "El examen Fue eliminado";
            this.ListarExamenes();
        }
        else
        {
            lblMensaje.Text = "Error: Al eliminar el Examen.";
        }
    }

}