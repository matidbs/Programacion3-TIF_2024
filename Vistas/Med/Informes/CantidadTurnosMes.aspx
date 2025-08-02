<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CantidadTurnosMes.aspx.cs" Inherits="Vistas.Med.Informes.TurnosPorMes" %>

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
            text-align: center;
            width: 100%;
        }
        
        .auto-style25 {
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
                   <table class="auto-style1">
                <tr>
                    <td class="auto-style77">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style25">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style15">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Med/PortalMedico.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </div>
    <table class="auto-style1">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <h2 class="auto-style2" style="border: thin solid #000000; background-color: #96f642">Cantidad de  turnos este mes</h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">La cantidad de turnos agendados para este mes es:
                <asp:Label ID="lblCantidad" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/Med/VerTurnosMedico.aspx">Ver turnos en detalle</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>
