<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SeleccionConvocatoria.aspx.cs" Inherits="SPV_RRHH_SeleccionConvocatoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="./../Library/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jquery.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jqueryv1-11.js" type="text/javascript"></script>
    <link href="./../Library/css/bootstrap.min.css" rel="stylesheet" type="text/css" />


<!-- Detalle -->
    <div class="container">
        <asp:Panel ID="pnlSeleccionConvocatoria" runat="server">
            <div align="center">
                <asp:DropDownList ID="ddlConvocatoriaVigente" runat="server" 
                    CssClass="form-control" 
                    onselectedindexchanged="ddlConvocatoriaVigente_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:GridView ID="dgvPostulantes" runat="server" CssClass="table" EmptyDataText ="No hay Datos a Mostrar"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="CodigoPostulante" HeaderText="Codigo" />
                        <asp:BoundField DataField="NombreApellido" HeaderText="Nombres y Apellidos" />
                        <asp:BoundField DataField="NotaEvaPerfil" HeaderText="Nota Eva. Perfil" />
                        <asp:BoundField DataField="NotaExaPsicologico" 
                            HeaderText="Nota Exam. Psicologico" />
                        <asp:BoundField DataField="NotaExaPsicotecnico" 
                            HeaderText="Nota Exa. Psicotecnico" />
                        <asp:BoundField DataField="NotaEntrevista" HeaderText="Nota Entrevista" />
                        <asp:TemplateField HeaderText="Seleccion">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbkSeleccion" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlBotones" runat="server">
            <div class="form-group" align="right">
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
                    onclick="btnGrabar_Click" CssClass="btn btn-danger" 
                    OnClientClick="return confirm('¿Esta seguro de Grabar?')" Visible="False"/>
            </div>
            <div align="center">
                <asp:Label ID="lblMensajeError" runat="server" Text="" CssClass="label-danger" ForeColor="White"></asp:Label>
                <asp:Label ID="lblMensajeGood" runat="server" Text="" CssClass="label-success" ForeColor="White"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

