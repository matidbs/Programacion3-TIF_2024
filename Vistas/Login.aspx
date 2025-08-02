<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
             margin-left: auto;
             margin-right: auto;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            margin-left: auto;
             margin-right: auto;
            height: 30px;
            width: 187px;
        }
        .auto-style5 {
            width: 187px;
        }
        .auto-style6 {
            width: 10px;
        }
        .auto-style7 {
            height: 30px;
            width: 10px;
        }
        .auto-style9 {
            margin-left: 14.8em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2" colspan="2">
                        <h2 style="border: thin solid #000000; background-color: #CC3300">INICIAR SESIÓN</h2>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <h3>Seleccione tipo de usuario: </h3>
                                             
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <asp:RadioButtonList ID="rblTipoUsuario" runat="server"  ValidationGroup="G1" RepeatDirection="Horizontal" Font-Bold="True" >
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Médico</asp:ListItem>
                            </asp:RadioButtonList>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="rfvTipoUsuario"  runat="server" ControlToValidate="rblTipoUsuario" Font-Bold="True" ForeColor="Red" ValidationGroup="G1">Seleccione un tipo de usuario</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <h4>Ingrese su nombre de usuario:
                        </h4>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtUsuario" runat="server" ValidationGroup="G1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" Font-Bold="True" ForeColor="Red" ValidationGroup="G1">Ingrese un usuario</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5">
                        <h4>Ingrese su contraseña:</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" ValidationGroup="G1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" Font-Bold="True" ForeColor="Red" ValidationGroup="G1">Ingrese una contraseña</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:Button  ID="btnIngresar" runat="server" Text="Ingresar" ValidationGroup="G1" OnClick="btnIngresar_Click" CssClass="auto-style9" />
                    &nbsp;<asp:Label ID="lbl_Notificacion" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
