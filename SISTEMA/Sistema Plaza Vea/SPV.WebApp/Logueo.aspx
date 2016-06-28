<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>
<%//@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Sistema Plaza Vea</title>
<script type="text/javascript" language="javascript" src="Library/JS/Mensajes.js"></script>
<script type="text/javascript" language="javascript" src="Library/JS/fc_FuncDisenho.js"></script>
<script type="text/javascript" language="javascript" src="Library/JS/fc_Validacion.js"></script>
<script type="text/javascript">
    function fc_Enter(e) {
        if (e == null) { e = window.event; }
        if (e != null) {
            if (e.keyCode == 13) {
                document.getElementById('pnlLogueo_LoginButton').click();
            }
        }
        return true;
    }

    function fc_MoverAbajo(e) {
        if (e == null) { e = window.event; }
        if (e != null) {
            if (e.keyCode == 13) {
                document.getElementById('pnlLogueo_Password').focus();
            }
        }
        return true;
    }
</script>
</head>
<body style="background-color: #ffffff;margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;">
    <form id="form1" runat="server">
        <table border='0' cellpadding="0" cellspacing="0" style="width: 100%; height: 650px">
            <tr align="center">
                <td align="center">
                    <div id="divPrincipal">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
		                        <td>
			                        <img src="Images/flash/Login.jpg" width="80%" height="100%"  alt="">
                                </td>
	                        </tr>
                        </table>
                    </div>
                    <div id="fading" runat="server" style="position: absolute; left: 95px; top: 250px; width: 79%; height:80px;
                        background-color: Transparent; z-index: 1;" >
                        <asp:Login ID="pnlLogueo" runat="server" DisplayRememberMe="False" LoginButtonText="Ingresar"
                            UserNameLabelText="Usuario" PasswordLabelText="Contraseña" TitleText="" FailureText=""
                            DestinationPageUrl="Inicio/Default.aspx" OnAuthenticate="Logueo_Authenticate">
                            <LayoutTemplate>
                            <table border="0" style="height:100%; width:100%">
                                <tr>
                                    <td style="width:50%;">
                                        <table cellpadding="0" cellspacing="3" border="0" style="height:100%; width:100%">
                                            <tr style="height:35px;">
                                                <td align="left" style="width:70px;">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                                        ForeColor="Black" Font-Size="15px" Font-Names="Arial" Font-Bold="True">Usuario</asp:Label>
                                                </td>
                                                <td style="width:230px;">
                                                    <asp:TextBox ID="UserName" runat="server" Width="100%" Height="15px" MaxLength="20"
                                                        onkeypress="javascript: return fc_MoverAbajo(event);" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ValidationGroup="Logeo">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr style="height:15px; padding-bottom:5px">
                                                <td align="left">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="#000000" Font-Size="15px" Font-Names="Arial" Font-Bold="True">Contraseña</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="texto" Width="100%" Height="15px" MaxLength="20" 
                                                        onkeypress="javascript: return fc_Enter(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ValidationGroup="Logeo">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr style="height:50px;" valign="top">
                                                <td align="right" colspan="2">&nbsp;<asp:ImageButton ID="LoginButton" 
                                                        CommandName="Login" runat="server" ValidationGroup="Logeo"
                                                                                        ImageUrl="~/Images/botones/Ingresar.gif" 
                                                        onclick="LoginButton_Click"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Label ID="FailureText" runat="server" EnableViewState="False" ForeColor="white" Font-Size="15px" Font-Names="Arial"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </td>
            </tr>                 
        </table>
    </form>
</body>
</html>