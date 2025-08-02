<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilMedico.aspx.cs" Inherits="Vistas.Med.PerfilMedico" %>

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
        .auto-style5{
            width: 50%;
            margin: 16px auto;
            background-color: #FEFDED;
            padding: 16px;
            border: 1px solid black;
        }
        .img_bandera{
            width: 24px;
            max-width: 24px;
            margin-left: 8px;
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
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Med/PortalMedico.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <h2  style="border: thin solid #000000; background-color: #96f642" class="auto-style4">Perfil Medico</h2>

            <div class="auto-style5">
                <p>Nombre completo: <asp:Label ID="lblNombreCompleto" runat="server" Text=""></asp:Label></p>
                <p>DNI: <asp:Label ID="lblDNI" runat="server" Text=""></asp:Label></p>
                <p>Sexo: <asp:Label ID="lblSexo" runat="server" Text=""></asp:Label></p>
                <p>Fecha de nacimiento: <asp:Label ID="lblFechaNacimiento" runat="server" Text=""></asp:Label></p>
                <p>Legajo: <asp:Label ID="lblLegajo" runat="server" Text=""></asp:Label></p>
                <p>Especialidad: <asp:Label ID="lblEspecialidad" runat="server" Text=""></asp:Label></p>
                <p>Nacionalidad: <asp:Label ID="lblNacionalidad" runat="server" Text=""></asp:Label>
                    <asp:ImageButton ID="bandera" CssClass="img_bandera" runat="server" />
                </p>
                <p>Contacto: <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label></p>
            </div>
        </div>
    </form>
</body>
</html>
