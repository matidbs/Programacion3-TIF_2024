<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedicos.aspx.cs" Inherits="Vistas.Admin.ABML_Medicos.ListarMedicos" %>

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
            width: 177px;
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
            width: 177px;
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
            width: 140px;
            height: 30px;
        }
        .auto-style25 {
            text-align: right;
        }
        .auto-style26 {
            width: 42px;
            height: 30px;
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
            </table>
            </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6" colspan="4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Listado de médicos</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11">Filtrar por número de legajo:</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtFiltrar" runat="server" Width="125px"></asp:TextBox>
                    </td>
                    <td class="auto-style26">
                        <asp:RegularExpressionValidator ID="revTxtFiltrar" runat="server" ErrorMessage="Legajo: Ingrese unicamente numeros, sin espacios." ControlToValidate="txtFiltrar" ValidationExpression="^\s*\d+\s*$" Font-Bold="True" ForeColor="Red" ValidationGroup="legajo">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtFiltrar" ErrorMessage="Legajo: Ingrese un N° de legajo" ForeColor="#990000" ValidationGroup="legajo">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" Width="69px" OnClick="btnFiltrar_Click" ValidationGroup="legajo" />
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:Button ID="btnMostrarTodos" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar todos" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11">Busque por especialidad:</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtBuscarEspe" runat="server" Width="125px"></asp:TextBox>
                    </td>
                    <td class="auto-style26">
                        <asp:RegularExpressionValidator ID="revEspecialidad" runat="server" ErrorMessage="Especialidad: Ingrese unicamente letras, sin espacios." ControlToValidate="txtBuscarEspe" ValidationExpression="^[A-Za-z]+$" Font-Bold="True" ForeColor="Red" ValidationGroup="especialidad">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style12">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="69px" OnClick="btnBuscar_Click" ValidationGroup="especialidad"  />
                    </td>
                    <td class="auto-style10" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>

                        Filtrar por horario:</td>
                    <td>

                        <asp:DropDownList ID="ddlHorarios" runat="server" OnSelectedIndexChanged="ddlHorarios_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </td>
                    <td>

                    </td>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="7">
                        <asp:Label ID="txt_notificacion" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="7">
                        <asp:ValidationSummary ID="vsLegajo" runat="server" ForeColor="Red" Font-Bold="True" ValidationGroup="legajo" Width="204px" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" Width="217px" ValidationGroup="especialidad" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" class="auto-style13">
                        <asp:GridView ID="grdMedicos" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="10" OnPageIndexChanging="grdMedicos_PageIndexChanging" Width="100%">
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
