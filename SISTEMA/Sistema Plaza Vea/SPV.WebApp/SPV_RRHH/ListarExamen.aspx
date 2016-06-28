<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ListarExamen.aspx.cs" Inherits="SPV_RRHH_ListarExamen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="./../Library/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jquery.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jqueryv1-11.js" type="text/javascript"></script>
    <link href="./../Library/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <%
        String msg = ((String)Request.QueryString["msg"].ToString()) != null ? Request.QueryString["msg"].ToString() : "0";

        if (msg == "1")
        {
            lblMensaje.Text = "El Examen Fue Grabado con Exito";
        }
        %>
    <script runat="server">
    
        
    
        void dgvExamen_RowCreated(Object sender, GridViewRowEventArgs e) { 
            
           /* if(e.Row.RowType == DataControlRowType.Header){
                int sortColumnIndex = GetSortColumnIndex();
                if(sortColumnIndex != -1){
                    AddSortImage(sortColumnIndex, e.Row);
                }
            }*/
            
        }

      /* int GetSortColumnIndex() { 
            foreach(DataControlField field in dgvExamen.Columns){
                if (field.SortExpression == dgvExamen.SortExpression)
                {
                    return dgvExamen.Columns.IndexOf(field);
                }
            }

            return -1;
        }

        void AddSortImage(int columnIndex, GridViewRow headerRow) {
            Image sortImage = new Image();
            if (dgvExamen.SortDirection == SortDirection.Ascending)
            {
                sortImage.ImageUrl = "~/Images/iconos/expander_ic_maximized.9.png";
                sortImage.AlternateText = "Ascendiendo";
            }
            else
            {
                sortImage.ImageUrl = "~/Images/iconos/expander_ic_minimized.9.png";
                sortImage.AlternateText = "Descendiendo";
            }
            headerRow.Cells[columnIndex].Controls.Add(sortImage);
        }*/
    
        </script>

    <!-- Detalle -->

    <div class="container">
            <div style="padding-top: 20px;" class="form-group">
                <asp:Label ID="lblLista" runat="server" Text="Lista de Examenes" 
                    Font-Size="Large"></asp:Label>
            </div>
            <div style="padding-top: 20px;" class="form-group">
                <asp:Button ID="btnAgregarExamen" runat="server" Text="(+) AgregarExamen" 
                    CssClass="btn btn-default" onclick="btnAgregarExamen_Click" />
            </div>
            <div style="padding-top: 20px;" class="form-group">
                <asp:GridView ID="dgvExamen" runat="server" AutoGenerateColumns="False"  EmptyDataText="Data Not Found"
                    CssClass="table" AllowSorting="True" onselectedindexchanged="dgvExamen_SelectedIndexChanged" 
                    onrowdeleting="dgvExamen_RowDeleting" onrowcreated="dgvExamen_RowCreated">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="Codigo" ReadOnly="True" />
                        <asp:BoundField HeaderText="Examen" DataField="Nombre" ReadOnly="True" />
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" 
                            ReadOnly="True" />
                        <asp:BoundField HeaderText="Tipo" DataField="TipoExamen" ReadOnly="True" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" ReadOnly="True" />
                        <asp:CommandField HeaderText="Editar" InsertText="Editar" SelectText="Editar" 
                            ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Esta Seguro que desea Eliminar este Examen?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div align="center">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="label-primary center-block"></asp:Label>
            </div>
        </div>


</asp:Content>

