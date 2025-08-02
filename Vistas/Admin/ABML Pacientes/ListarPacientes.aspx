<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPacientes.aspx.cs" Inherits="Vistas.Admin.ABML_Pacientes.ListarPacientes" %>

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
        .auto-style4 {
            width: 205px;
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
        .auto-style11 {
            width: 205px;
            height: 30px;
        }
        .auto-style12 {
            height: 30px;
            width: 79px;
        }
        .auto-style13 {
            height: 23px;
        }
        .auto-style14 {
            width: 165px;
            height: 30px;
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
                <asp:LinkButton ID="linkBAgregarPacientes" runat="server" PostBackUrl="~/Admin/ABML Pacientes/AgregarPaciente.aspx">Agregar Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style3">
                <asp:LinkButton ID="linkBDarBajaPaciente" runat="server" PostBackUrl="~/Admin/ABML Pacientes/DarBajaPaciente.aspx">Dar baja a Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style5" colspan="3">
                <asp:LinkButton ID="linkBModificarPaciente" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ModificarPacientes.aspx">Modificar Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style15">
                <asp:LinkButton ID="linkBListarPacientes" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ListarPacientes.aspx">Listar Pacientes</asp:LinkButton>
                    </td>
                    <td class="auto-style15">
                        <asp:LinkButton ID="linkBRegresar" runat="server" PostBackUrl="~/Admin/PortalAdmin.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" colspan="3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Listado de pacientes</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11">Filtrar por número de DNI:</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtFiltrar" runat="server" Width="125px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revTxtFiltrar" runat="server" ErrorMessage="Ingrese únicamente 8 dígitos numéricos." ControlToValidate="txtFiltrar" ValidationExpression="^\d{8}$" ValidationGroup="filtrar" ForeColor="#990000">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvTxtFiltrar" runat="server" ControlToValidate="txtFiltrar" ErrorMessage="Ingrese un DNI" ValidationGroup="filtrar" ForeColor="#990000">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar por DNI" Width="97px" ValidationGroup="filtrar" OnClick="btnFiltrar_Click" />
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todos" OnClick="btnMostrarTodos_Click" />
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>

                        Filtrar por sexo:</td>
                    <td>

                        <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSexo_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>

                        &nbsp;</td>
                    <td>

                        Filtrar por edad: </td>
                    <td>

                        <asp:TextBox ID="txtEdad" runat="server" Width="125px" MaxLength="3" TextMode="Number" Min="0" Max="120"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="revEdad" runat="server" ErrorMessage="Edades permitidas: hasta (3) dígitos" ControlToValidate="txtEdad" ValidationExpression="^\d{1,3}$" ValidationGroup="edad" ForeColor="#990000">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvEdad" runat="server" ControlToValidate="txtEdad" ErrorMessage="Ingrese una edad" ValidationGroup="edad" ForeColor="#990000">*</asp:RequiredFieldValidator>

                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnFiltrarEdad" runat="server" Text="Filtrar por Edad" Width="109px" ValidationGroup="edad" OnClick="btnFiltrarEdad_Click" />
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td class="auto-style4">

                        <asp:ValidationSummary ID="vsValidaciones" runat="server" ValidationGroup="filtrar" ForeColor="#990000" />

                        <asp:ValidationSummary ID="vsValidaciones2" runat="server" ValidationGroup="edad" ForeColor="#990000" />

                        <br />

                        <asp:Label ID="lblNotificacion" runat="server" ForeColor="#990000"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="6" class="auto-style13">
                        <asp:GridView ID="grdPacientes" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="100%" OnPageIndexChanging="grdPacientes_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
