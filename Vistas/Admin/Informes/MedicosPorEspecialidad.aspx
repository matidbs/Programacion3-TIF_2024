<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicosPorEspecialidad.aspx.cs" Inherits="Vistas.Admin.Informes.MedicosPorEspecialidad" %>

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
             <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Cantidad de médicos por especialidad</h2>
        </div>
        <asp:GridView ID="grdCantidadMedicos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Codigo de la especialidad">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_CodEspecialidad" runat="server" Text='<%# Eval("codEspecialidad_e") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre de la especialidad">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_DescEspecialidad" runat="server" Text='<%# Eval("descripcion_e") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad de médicos">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_CantidadMedicos" runat="server" Text='<%# Eval("cantidadMedicosporE") %>'></asp:Label>
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
