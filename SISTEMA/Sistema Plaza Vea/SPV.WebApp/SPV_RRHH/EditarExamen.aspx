<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="EditarExamen.aspx.cs" Inherits="SPV_RRHH_EditarExamen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="./../Library/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jquery.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jqueryv1-11.js" type="text/javascript"></script>
    <link href="../Library/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_btnCancelarPregunta, #ctl00_ContentPlaceHolder1_btnTerminarPregunta{
            float: right;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_txtPuntaje').keypress(function (e) {
                if (e.which >= 48 && e.which <= 57) {
                    return true;
                } else {
                    return false;
                }
            });
        });


        function ValidarAlternativa() {
            var Alternativa = $("#ctl00_ContentPlaceHolder1_txtAlternativa").val();
            if (Alternativa == null || Alternativa == "") {
                $("#txtAlternativa").focus();
                return false;
            }
            var Puntaje = $("#ctl00_ContentPlaceHolder1_txtPuntaje").val();
            if (Puntaje == "" || Puntaje == null) {
                $("#txtPuntaje").val("0");
                $("#txtPuntaje").focus();
                return false;
            }
            if (isNaN(Puntaje)) {
                $("#txtPuntaje").val("0");
                $("#txtPuntaje").focus();
                return false;
            }
        }

        function ValidarPregunta() {
            var Pregunta = $("#ctl00_ContentPlaceHolder1_txtPregunta").val();
            if (Pregunta == null || Pregunta == "") {
                $("#txtPregunta").focus();
                return false;
            }
        }

    </script>
    <!-- Detalle -->


    <asp:Panel ID="pnlExamen" runat="server" Visible="true">
        <div class="container" style="width: 600px; float: left; padding-left: 30px; padding-top: 20px;">
        <div class="form-inline">
            <label>Codigo</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" 
            Enabled="False"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombreExamen" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Descripcion</label>
            <asp:TextBox ID="txtDescripcionExamen" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Perfil</label>
            <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control" 
            Enabled="true">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Tipo</label>
            <asp:DropDownList ID="ddlTipoExamen" runat="server"  CssClass="form-control" 
            Enabled="true">
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnAgregarPregunta" runat="server" Text="(+) Agregar Pregunta" 
        CssClass="btn btn-default" onclick="btnAgregarPregunta_Click"/>

        <div class="container form-group" style="padding-top: 20px;">
            <asp:Label ID="lblListaPreguntas" runat="server" Text="Preguntas" 
            Font-Size="X-Large"></asp:Label>
            <br />
           
            <asp:GridView ID="dgvPregunta" runat="server" CssClass="table" 
                AutoGenerateColumns="False" onrowdeleting="dgvPregunta_RowDeleting" 
                onselectedindexchanged="dgvPregunta_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CodigoPregunta" HeaderText="Codigo" />
                    <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                    <asp:BoundField DataField="TipoPregunta" HeaderText="Tipo" />
                    <asp:BoundField DataField="EstadoPregunta" HeaderText="Estado" />
                    <asp:CommandField HeaderText="Editar" SelectText="Editar" 
                        ShowSelectButton="True" />
                    <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Esta Seguro de Eliminar la Pregunta?');" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnGuardarExamen" runat="server" Text="Guardar" 
            onclick="btnGuardarExamen_Click" 
            onclientclick="return confirm('¿Esta Seguro?')" CssClass="btn btn-default" />
        </div>
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlPregunta" runat="server" Visible="false">
        <div class="panel panel-default" style="width: 450px; height: auto;">
            <div class="panel-heading">
                     <asp:Button ID="btnCancelarPregunta" runat="server" Text="X" 
                         onclick="btnCancelarPregunta_Click" />
                     <asp:Label ID="Label5" runat="server" Text="Pregunta"></asp:Label>
            </div>
            <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
                <asp:TextBox ID="txtCodigoPregunta" runat="server" CssClass="form-control" 
                    Enabled="False"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Pregunta"></asp:Label>
                <asp:TextBox ID="txtPregunta" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
                <asp:DropDownList ID="ddlTipoPregunta" runat="server" CssClass="form-control">
                <asp:ListItem Value="MUL">Multiple</asp:ListItem>
                <asp:ListItem Value="UNI">Unica</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Estado" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlEstadoPregunta" runat="server" CssClass="form-control" 
                    Enabled="False" Visible="False">
                <asp:ListItem Value="ACT">Activo</asp:ListItem>
                <asp:ListItem Value="INA">Inactivo</asp:ListItem>
                </asp:DropDownList>
                <br />
                 <asp:Button ID="btnPnlAlternativa" runat="server" 
                Text="(+) Agregar" 
                CssClass="btn btn-default" onclick="btnPnlAlternativa_Click" Visible="false" />

                <asp:Button ID="btnActualizarAlternativa" runat="server" 
                Text="Actualizar" 
                CssClass="btn btn-default" Visible="false" 
                    onclick="btnActualizarAlternativa_Click"/>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlAlternativa" runat="server" Visible="false">
        <div class="panel panel-default" style="width: 550px; height: auto;">
            <div class="panel-heading">
                
                <asp:Label ID="lblAlternativa" runat="server" Text="Alternativa"></asp:Label>
            </div>
            <div class="panel-body">
                <asp:Label ID="Label6" runat="server" Text="Codigo"></asp:Label>
                <asp:TextBox ID="txtCodigoAlternativa" runat="server" CssClass="form-control" 
                    Enabled="False"></asp:TextBox>
                <br />
                <asp:Label ID="lblUnica" runat="server" Text="Seleccione la respuesta correcta"></asp:Label>
                <div style="padding: 40px;">
                    <asp:RadioButtonList ID="rblUnica" runat="server" CssClass="radio">
                        <asp:ListItem Text="SI" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="NO"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <asp:Label ID="lblAlternativaText" runat="server" Text="Alternativa"></asp:Label>
                <asp:TextBox ID="txtAlternativa" runat="server" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:CheckBox ID="cbkCorrecta" runat="server" Text="Alternativa Correcta?" 
                    CssClass="checkbox checkbox-inline" Visible="False"/>
                <br />

                <br />
                <asp:Label ID="Label9" runat="server" Text="Puntaje"></asp:Label>
                <asp:TextBox ID="txtPuntaje" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="btnAgregarAlternativa" runat="server" Text="(+) Agregar" 
                    CssClass="btn btn-default" onclick="btnAgregarAlternativa_Click"/>
                <br />
                <br />
                <br />
                <asp:GridView ID="dgvAlternativa" runat="server" CssClass="table" 
                    AutoGenerateColumns="False" onrowdeleting="dgvAlternativa_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="CodigoAlternativa" HeaderText="Codigo" />
                        <asp:BoundField DataField="Alternativa" HeaderText="Alternativa" />
                        <asp:BoundField DataField="EsCorrecta" HeaderText="EsCorrecta" />
                        <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Esta seguro de Eliminar la Alternativa?');" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div align="right">
                    <asp:Button ID="btnTerminarPregunta" runat="server" Text="Retornar al Examen" CssClass="btn btn-link"
                        onclick="btnTerminarPregunta_Click" 
                        onclientclick="return confirm('Al cerrar esta pestañan estaras guardando la pregunta con su(s) alternativa(s) \n ¿Estas Seguro?')" Visible="false" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlMensajes" runat="server">
    <div align="center">
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="label-primary center-block"></asp:Label>
    <div>
    </asp:Panel>

</asp:Content>

