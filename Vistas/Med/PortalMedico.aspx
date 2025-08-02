<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalMedico.aspx.cs" Inherits="Vistas.Med.PortalMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 394px;
        }
        .auto-style3 {
            text-align: right;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            margin-left: 15px;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnPerfil" runat="server" OnClick="btnPerfil_Click" Text="Mi perfil" Width="70px" />
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="auto-style5" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <h2  style="border: thin solid #000000; background-color: #96f642" class="auto-style4">Portal Medico</h2>
        <h3  style="border: thin solid #000000; background-color: #96f642" class="auto-style4">Mis turnos</h3>

        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Med/VerTurnosMedico.aspx">Ver mis turnos</asp:LinkButton>
                    </td>
                <td>&nbsp;</td>
            </tr>
        </table>
         <h3  style="border: thin solid #000000; background-color: #96f642" class="auto-style4">Informes</h3>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/Med/Informes/CantidadTurnosMes.aspx">Cantidad de turnos en el mes</asp:LinkButton>
                </td>
                <td class="auto-style4">
                        &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
