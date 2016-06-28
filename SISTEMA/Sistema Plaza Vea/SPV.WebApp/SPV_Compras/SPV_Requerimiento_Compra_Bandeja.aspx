<%@ Language="C#" 
    MasterPageFile="~/Principal.master" 
    AutoEventWireup="true" 
    CodeFile="SPV_Requerimiento_Compra_Bandeja.aspx.cs" 
    Inherits="SPV_Compras_SPV_Requerimiento_Compra_Bandeja" %>
<%@ MasterType VirtualPath="~/Principal.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        var mstrError = "";
        function Fc_Elimina() {
            if (fc_Trim(document.getElementById('<%=this.TxhIdCabPlan.ClientID%>').value) == "") {
                alert(mstrSeleccioneUno);
                return false;
            }
            return confirm(mstrSeguroEliminarUno);
        }

        function Fc_Limpiar() {
            
            return false;
        }

        function Fc_Buscar() {
            
            if (mstrError != "") {
                alert(mstrError);
                mstrError = "";
                return false;
            }
            return true;
        }
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr valign="bottom" >
            <td style="width:30%">
                <table id="Table1" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td><img id="img1" alt="" src="../Images/Tabs/tab-izq.gif" /></td>
                        <td class="TabCabeceraOn">Plan</td>
                        <td><img id="img2" alt="" src="../Images/Tabs/tab-der.gif" /></td>
                    </tr>
                </table>
            </td>
            <td style="width:70%" align="right">
                <table id="Table2" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right">
                            
                        </td>
                    </tr>
                </table> 
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr style="width: 100%">
            <!-- Cabecera -->
            <td><img alt="" width="100%" src="../Images/Mantenimiento/fbarr.gif" /></td>
        </tr>
        <tr style="width: 100%">
            <td style="background-color: #ffffff; vertical-align: top; height: 470px;width: 100%;">
                <table cellpadding="1" cellspacing="1" style="margin-left:5px; margin-right:5px;width: 99%;" border="0">  
                    <tr>
                        <td><asp:Label ID="lbl" runat="server" SkinID="lblcb" >CRITERIOS DE BUSQUEDA</asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:updatepanel id="upBusqueda" runat="server">
                                <contenttemplate>
                                    <table border="0" style="width: 100%" cellspacing="1" cellpadding="2" class="cbusqueda">
                                        <tr>
                                            
                                        </tr>
                                    </table>
                                </contenttemplate>
                                    
                                </asp:updatepanel>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/iconos/fbusqueda.gif" Width="100%" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top:15px;">
                            <asp:UpdatePanel ID="upMantenimiento" runat="server">
                                <contenttemplate>
                                    
                                    <asp:hiddenfield runat="server" id="TxhIdCabPlan" />
                                    
                                </contenttemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>  
            </td>
        </tr>
         <tr>
            <!-- Pie -->
            <td><img alt="" src="../Images/Mantenimiento/fba.gif" Width="100%" /></td>
        </tr>
    </table>
    <script type="text/javascript">
        setTabCabeceraOn("0");
    </script>
</asp:Content>