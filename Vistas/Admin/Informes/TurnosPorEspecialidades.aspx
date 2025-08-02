<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosPorEspecialidades.aspx.cs" Inherits="Vistas.Admin.Informes.TurnosPorEspecialidades" %>

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
                    <td class="auto-style25">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Admin/PortalAdmin.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
            </table>
             <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Turnos Totales y Reservados por Especialidad</h2>
        </div>
        <table align="center" class="auto-style26">
            <tr>
                <td class="auto-style27">Filtrar por fecha:</td>
                <td class="auto-style28">
                    <asp:DropDownList ID="ddlFechas" runat="server" Height="25px" Width="150px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                &nbsp;
                    <asp:Button ID="btnEliminarFiltros" runat="server" OnClick="btnEliminarFiltros_Click" Text="Eliminar Filtros" />
                    <asp:Label ID="lbl_notificacion" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gdTurnos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Especialidad">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Turnos Totales">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_TurnosTotales" runat="server" Text='<%# Eval("Turnos Totales") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Turnos Reservados">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_TurnosAsignados" runat="server" Text='<%# Eval("Turnos Asignados") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
    </form>
</body>
</html>
