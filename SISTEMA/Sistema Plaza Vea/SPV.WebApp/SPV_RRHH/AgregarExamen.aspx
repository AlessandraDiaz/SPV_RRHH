<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AgregarExamen.aspx.cs" Inherits="SPV_RRHH_AgregarExamen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="./../Library/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jquery.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jqueryv1-11.js" type="text/javascript"></script>
    <link href="../Library/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
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
        function validar() {
            var nombre = $("#ctl00_ContentPlaceHolder1_txtNombreExamen").val();
            if (nombre == null || nombre == "") {
                $("#ctl00_ContentPlaceHolder1_txtNombreExamen").focus();
                return false;
            }
            var descripcion = $("#ctl00_ContentPlaceHolder1_txtDescripcion").val();
            if (descripcion == null || descripcion == "") {
                $("#ctl00_ContentPlaceHolder1_txtDescripcion").focus();
                return false;
            }
        }
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_btnCancelarPregunta, #ctl00_ContentPlaceHolder1_btnTerminarPregunta{
            float: right;
        }
    </style>


    <!-- Detalle  -->

    <asp:Panel ID="pnlExamen" runat="server">
        <div class="panel panel-danger" style="width: 600px;">
            <div class="panel-heading">
                <div class="panel-title" style="text-align: center;">
                    <asp:Label ID="lblTitulo" runat="server" Text="Agregar Examen"></asp:Label>
                </div>
            </div>
            <div class="panel-body">
                <div class="panel-collapse">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombreExamen" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                    <asp:DropDownList ID="ddlTipoExamen" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1">Evaluacion Perfil</asp:ListItem>
                        <asp:ListItem Value="2">Examen Psicologico</asp:ListItem>
                        <asp:ListItem Value="3">Examen Psicotecnico</asp:ListItem>
                        <asp:ListItem Value="4">Entrevista Personal</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Perfil"></asp:Label>
                    <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control" 
                        Enabled="true">
                    </asp:DropDownList>
                    <br />
                    <div style="text-align: right;">
                        <asp:Button ID="btnAgregar" runat="server" Text="(+) Agregar Pregunta" 
                            CssClass="btn btn-default" onclick="btnAgregar_Click"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                            CssClass="btn btn-default" onclick="btnCancelar_Click"/>
                    </div>
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="dgvPregunta" runat="server" CssClass="table" 
                    AutoGenerateColumns="False" onrowdeleting="dgvPregunta_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                        <asp:BoundField DataField="TipoPregunta" HeaderText="Tipo" />
                        <asp:BoundField DataField="EstadoPregunta" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('¿Esta seguro de Eliminar la Pregunta?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    <br />
                    <div style="text-align: right;">
                        <asp:Button ID="btnAgregarExamen" runat="server" Text="Guardar Examen" 
                            CssClass="btn btn-default" onclick="btnAgregarExamen_Click" />  
                    </div>
                </div>
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
               
                <asp:Label ID="Label2" runat="server" Text="Pregunta"></asp:Label>
                <asp:TextBox ID="txtPregunta" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
                <asp:DropDownList ID="ddlTipoPregunta" runat="server" CssClass="form-control">
                <asp:ListItem Value="MUL">Multiple</asp:ListItem>
                <asp:ListItem Value="UNI">Unica</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstadoPregunta" runat="server" CssClass="form-control" 
                    Enabled="False">
                <asp:ListItem Value="ACT">Activo</asp:ListItem>
                <asp:ListItem Value="INA">Inactivo</asp:ListItem>
                </asp:DropDownList>
                <br />
                 <asp:Button ID="btnPnlAlternativa" runat="server" 
                Text="(+) Agregar" 
                CssClass="btn btn-default" onclick="btnPnlAlternativa_Click" />

            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlAlternativa" runat="server" Visible="false">
        <div class="panel panel-default" style="width: 550px; height: auto;">
            <div class="panel-heading">
                
                <asp:Label ID="lblAlternativa" runat="server" Text="Alternativa"></asp:Label>
            </div>
            <div class="panel-body">
                
               <asp:Label ID="lblUnica" runat="server" Text="Seleccione la Opcion Correcta" Visible="False"></asp:Label>
               <div style="padding-left: 40px;">
                   <asp:RadioButtonList ID="rblOpcionUnica" runat="server"  CssClass="radio">
                        <asp:ListItem Text="SI" Selected="True"/>
                        <asp:ListItem Text="NO"/>
                    </asp:RadioButtonList>
               
               </div>

                <br />
                <asp:Label ID="Label7" runat="server" Text="Alternativa"></asp:Label>
                <asp:TextBox ID="txtAlternativa" runat="server" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:CheckBox ID="cbkCorrecta" runat="server" Text="Alternativa Correcta?" 
                    CssClass="checkbox checkbox-inline" Visible="False"/>
                <br />

                <asp:Label ID="Label9" runat="server" Text="Puntaje"></asp:Label>
                <asp:TextBox ID="txtPuntaje" runat="server" CssClass="form-control"></asp:TextBox>
                <br /> 
                <asp:Button ID="btnAgregarAlternativa" runat="server" Text="(+) Agregar" 
                    CssClass="btn btn-default" onclick="btnAgregarAlternativa_Click"/>
                   
                <br />
                <asp:GridView ID="dgvAlternativa" runat="server" CssClass="table" 
                    AutoGenerateColumns="False" onrowdeleting="dgvAlternativa_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Alternativa" HeaderText="Alternativa" />
                        <asp:BoundField DataField="EsCorrecta" HeaderText="Es Correcta" />
                        <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                        <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
                <div align="right">
                        <asp:Button ID="btnTerminarPregunta" runat="server" Text="Regresar al Examen" 
                        onclientclick="return confirm('Al cerrar esta pestañan estaras guardando la pregunta con su(s) alternativa(s) \n ¿Estas Seguro?')" 
                        onclick="btnTerminarPregunta_Click" CssClass="btn btn-link" />
                 </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlMensaje" runat="server" Visible="true"> 
        <div  align="center" style="width: 600px;">
            <asp:Label ID="lblMensajeCorrecto" runat="server" Text="" ForeColor="White" CssClass="label-primary"></asp:Label>
            <asp:Label ID="lblMensajeError" runat="server" Text=""  ForeColor="White" CssClass="label-danger"></asp:Label>
        </div>
    </asp:Panel>


</asp:Content>

