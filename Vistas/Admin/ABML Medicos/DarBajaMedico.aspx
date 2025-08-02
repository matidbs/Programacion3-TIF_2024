<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DarBajaMedico.aspx.cs" Inherits="Vistas.Admin.ABML_Medicos.DarBajaMedico" %>

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
        }
        .auto-style3 {
            text-align: center;
            width: 177px;
            height: 23px;
        }
        .auto-style4 {
            width: 177px;
        }
        .auto-style5 {
            text-align: center;
            width: 233px;
            height: 23px;
        }
        .auto-style6 {
            width: 233px;
        }
        .auto-style8 {
            height: 50px;
        }
        .auto-style10 {
            height: 30px;
        }
        .auto-style12 {
            height: 30px;
            width: 108px;
        }
        .auto-style14 {
            width: 140px;
            height: 30px;
        }
        .auto-style15 {
            text-align: center;
            height: 23px;
        }
        .auto-style16 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style77">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style15">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admin/ABML Medicos/AgregarMedico.aspx">Agregar Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style3">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admin/ABML Medicos/DarBajaMedico.aspx">Dar baja a Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style5" colspan="3">
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Admin/ABML Medicos/ModificarMedico.aspx">Modificar Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style15">
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Admin/ABML Medicos/ListarMedicos.aspx">Listar médicos</asp:LinkButton>
                    </td>
                    <td class="auto-style15">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Admin/PortalAdmin.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" colspan="3">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Dar de baja médico</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Ingrese legajo para dar de baja:</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtBajaLogica" runat="server" Width="125px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnBajaLogica" runat="server" Text="Eliminar" Width="69px" OnClick="btnBajaLogica_Click" ValidationGroup="Baja" />
                        <asp:RequiredFieldValidator ID="rfvBaja" runat="server" ControlToValidate="txtBajaLogica" ErrorMessage="Ingrese un Legajo" ForeColor="#990000" ValidationGroup="Baja">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revBaja" runat="server" ControlToValidate="txtBajaLogica" ErrorMessage="Solo Numeros (sin espacios)" ValidationExpression="^\s*\d+\s*$" ForeColor="#990000" ValidationGroup="Baja">*</asp:RegularExpressionValidator>
                        <asp:RangeValidator ID="rvBaja" runat="server" ControlToValidate="txtBajaLogica" ErrorMessage="Valor muy alto" ForeColor="#990000" MaximumValue="99999" MinimumValue="0" Type="Integer" ValidationGroup="Baja">*</asp:RangeValidator>

                    </td>
                    <td class="auto-style10" colspan="3">
        <asp:Label ID="lblBajaLogica" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Black" ValidationGroup="Baja" />
                    </td>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </div>
    <p>
        &nbsp;</p>
    </form>
    </body>
</html>
