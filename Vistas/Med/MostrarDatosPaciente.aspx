<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarDatosPaciente.aspx.cs" Inherits="Vistas.Med.MostrarDatosPaciente" %>

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
        .auto-style8 {
            height: 50px;
        }
        .auto-style10 {
            height: 30px;
        }
        .auto-style25 {
            text-align: right;
        }
        .auto-style29 {
            height: 28px;
            width: 2006px;
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
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="3">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #96f642">Datos del paciente</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style29">
                        <asp:GridView ID="grdVerDatos" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("Dni") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre completo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_NombreCompleto" runat="server" Text='<%# Eval("Nombre Completo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha de nacimiento">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Eval("Fecha de nacimiento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sexo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>                  
                    <td class="auto-style10" colspan="3" style="text-align: center">
                        
                        <b>Historia clínica:</b></td>
                </tr>
                <tr>
                    <td>

                        <asp:GridView ID="grdHistoriaClinica" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="N° Turno">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_NTurno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Horario">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asistió">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Asitio" runat="server" Text='<%# Bind("Asistio_Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observación">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Observacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/Med/VerTurnosMedico.aspx">Regresar a ver turnos</asp:LinkButton>

                    </td>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
