<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="SolicitudPersonal.aspx.cs" Inherits="SPV_RRHH_SolicitudPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="./../Library/JS/bootstrap.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jquery.min.js" type="text/javascript"></script>
    <script src="./../Library/JS/jqueryv1-11.js" type="text/javascript"></script>
    <link href="../Library/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_txtSueldoPerfil').keypress(function (e) {
                if ((e.which >= 48 && e.which <= 57) || e.which == 46) {
                    return true;
                } else {
                    return false;
                }
            });

            $('#ctl00_ContentPlaceHolder1_txtTiempoContrato, #ctl00_ContentPlaceHolder1_txtTiempoApoyo').keypress(function (e) {
                if (e.which >= 48 && e.which <= 57) {
                    return true;
                } else {
                    return false;
                }
            });

            $('#ctl00_ContentPlaceHolder1_ddlHorario').change(function () {
                //     $('#ctl00_ContentPlaceHolder1_txtHorario').val($(this).val());
            });

        });

        function ValidarPnlPerfil() {
           
            var Areas = $("#ctl00_ContentPlaceHolder1_txtAreasPerfil").val();
            if (Areas == null || Areas == "") {
                $("#ctl00_ContentPlaceHolder1_txtAreasPerfil").focus();
                return false;
            }

            var Descripcion = $("#ctl00_ContentPlaceHolder1_txtDescripcionPerfil").val();
            if (Descripcion == null || Descripcion == "") {
                $("#ctl00_ContentPlaceHolder1_txtDescripcionPerfil").focus();
                return false;
            }

            var Sueldo = $("#ctl00_ContentPlaceHolder1_txtSueldoPerfil").val();
            if (Sueldo == null || Sueldo == "") {
                $("#ctl00_ContentPlaceHolder1_txtSueldoPerfil").focus();
                return false;
            }

        }

        function ValidarPnlOrden() {
            var Motivo = $("#ctl00_ContentPlaceHolder1_txtMotivo").val();
            if (Motivo == null || Motivo == "") {
                $("#ctl00_ContentPlaceHolder1_txtMotivo").focus();
                return false;
            }

            /*   var Areas = $("#ctl00_ContentPlaceHolder1_txtAreasPerfil").val();
            if (Areas == null || Areas == "") {
            $("#ctl00_ContentPlaceHolder1_txtAreasPerfil").focus();
            return false;
            }*/
        }

        function ValidarAgregarRequisito() {
            var PerfilRequisito = $("#ctl00_ContentPlaceHolder1_txtPerfilRequisito").val();
            if (PerfilRequisito == null || PerfilRequisito == "") {
                $("#ctl00_ContentPlaceHolder1_txtPerfilRequisito").focus();
                return false;
            }
        }
    </script>
    <style type="text/css">
        .Descripcion
        {
            max-width: 688px; 
            max-height: 100px;
            min-height: 100px;
            }
    </style>


    <!-- Contenido :V   No tocar... please-->
    
    <div class="container" style="width: 700px;">
        <div class="panel panel-danger">
            <div class="panel-heading center-block" >
                <div class="panel-title" style="text-align: center;">Generar Solicitud de Personal</div>
            </div>
            <div class="panel-body">
                
                <asp:Panel ID="pnlSolicitudPersonal" runat="server">
                    <div class="form-inline">
                        <asp:Label ID="Label1" runat="server" Text="Tipo de Solicitud"></asp:Label>
                    <asp:DropDownList ID="ddlTipoSolicitudPersonal" runat="server" 
                            CssClass="form-control"  AutoPostBack="true"
                            onselectedindexchanged="ddlTipoSolicitudPersonal_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Seleccione una Opcion" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Apoyo Eventual" Text="Apoyo Eventual"></asp:ListItem>
                        <asp:ListItem Value="Cubrir Vacante" Text="Cubrir Vacante" ></asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="form-inline" align="right">
                        <asp:Button ID="btnContinuarPnlPerfil" runat="server" Text="-> Continuar" 
                            CssClass="btn btn-link" onclick="btnContinuarPnlPerfil_Click" 
                            Visible="False" /> 
                    </div>
                    <br />
                    <br />
                </asp:Panel>

                <asp:Panel ID="pnlPerfil" runat="server" Visible="true">
                    <div class="form-inline">
                        <asp:Label ID="Label2" runat="server" Text="Perfil"></asp:Label>
                        <asp:DropDownList ID="ddlPerfil" runat="server"  CssClass="form-control" 
                            onselectedindexchanged="ddlPerfil_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Seleccione un perfil" Value="" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="">
                        <asp:Label ID="Label3" runat="server" Text="Areas del Perfil"></asp:Label>
                        <asp:TextBox ID="txtAreasPerfil" runat="server" TextMode="MultiLine" CssClass="form-control Descripcion"></asp:TextBox>
                    </div>
                    <br />
                    <div class="">
                        <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="txtDescripcionPerfil" runat="server"  CssClass="form-control Descripcion" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-inline">
                        <asp:Label ID="Label5" runat="server" Text="Sueldo"></asp:Label>
                        <asp:TextBox ID="txtSueldoPerfil" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div>
                        <asp:ListBox ID="lbxRequisito" runat="server" CssClass="form-control"></asp:ListBox>
                    </div>
                    <div class="form-inline" align="right">
                        <asp:Button ID="btnContinuarPnlOrden" runat="server" Text="-> Continuar" 
                            CssClass="btn btn-link" onclick="btnContinuarPnlOrden_Click" 
                            Visible="False" /> 
                    </div>
                    <br />
                </asp:Panel>

                <asp:Panel ID="pnlOrden" runat="server" Visible="true">
                    <div class="">
                        <asp:Label ID="lblMotivo" runat="server" Text="Motivo"></asp:Label>
                        <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control Descripcion"  TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-inline">
                        <asp:Label ID="Label8" runat="server" Text="Horario"></asp:Label>
                        <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-control" 
                            onselectedindexchanged="ddlHorario_SelectedIndexChanged">
                            <asp:ListItem Value="" Text="Seleccione un Horario" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtHorario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-inline">
                        <asp:Label ID="Label7" runat="server" Text="Cantidad Requerida"></asp:Label>
                        <asp:DropDownList ID="ddlCantidadRequerida" runat="server" CssClass="form-control">
                            <asp:ListItem Value="" Text="Seleccione una Cantidad Requerida" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="form-inline">
                        <asp:Label ID="lblTiempoApoyo" runat="server" Text="Tiempo Apoyo" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtTiempoApoyo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                        <asp:Label ID="lblTiempoContrato" runat="server" Text="Tiempo Contrato" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtTiempoContrato" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddlTiempoOrden" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Año" Value="Año"></asp:ListItem>
                            <asp:ListItem Text="Meses" Value="Meses"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
                    <br />
                    <br />
                <asp:Panel ID="pnlOpcion" runat="server"> 
                <div class="form-inline" align="right">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Solicitud Personal" 
                            CssClass="btn btn-danger" onclick="btnCancelar_Click" 
                            onclientclick="return confirm('¿Esta seguro de Cancelar?')" />
                        <asp:Button ID="btnAgregarSolicitudPersonal" runat="server" 
                            Text="Agregar Solicitud Personal" CssClass="btn btn-default" 
                            OnClick="btnAgregarSolicitudPersonal_Click" Visible ="true" 
                            onclientclick="return confirm('Confimar Solicitud.')" />
                </div>
                <div class="center-block">
                    <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false" CssClass="label-danger" ForeColor="White"></asp:Label>
                </div>
                </asp:Panel>
                
            </div>
        </div>
    </div>

</asp:Content>

