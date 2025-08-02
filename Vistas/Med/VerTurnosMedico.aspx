<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTurnosMedico.aspx.cs" Inherits="Vistas.Med.VerTurnosMedico" %>

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
        .auto-style26 {
            height: 30px;
            width: 970px;
        }
        .auto-style27 {
            height: 30px;
            width: 532px;
        }
        .auto-style28 {
            height: 28px;
            width: 532px;
            text-align: right;
        }
        .auto-style29 {
            height: 28px;
            width: 970px;
            text-align: left;
        }
        .auto-style30 {
            height: 28px;
        }
        .auto-style31 {
            height: 28px;
            width: 159px;
            text-align: center;
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
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="4">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #96f642">Turnos</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style28"><strong>Búsqueda por n° de turno:</strong>
                        <asp:TextBox ID="txtNturno" runat="server" Width="86px" ValidationGroup="filtrarPorTurno"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNturno" ErrorMessage="N° de turno: Utilice únicamente numeros enteros para buscar, sin espacios." Font-Bold="True" ForeColor="Red" ValidationGroup="filtrarPorTurno" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNturno" ErrorMessage="Ingrese un número de turno" ForeColor="Red" ValidationGroup="filtrarPorTurno" Font-Bold="True">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="btnBuscar" runat="server" Height="26px" Text="Buscar turno" Width="89px" OnClick="btnBuscar_Click" ValidationGroup="filtrarPorTurno" />
                    </td>
                    <td class="auto-style31">
                        <asp:Button ID="btnVerTurnosActivos" runat="server" Height="26px" OnClick="btnVerTurnosActivos_Click" Text="Ver turnos activos" Width="138px" />
                    </td>
                    <td class="auto-style29"><asp:Button ID="btnMostrarTodos" runat="server" Height="26px" Text="Mostrar todos" Width="116px" OnClick="btnMostrarTodos_Click" />
                    </td>
                    <td class="auto-style30"></td>
                </tr>
                <tr>
                    <td class="auto-style27">
                        <h4>Filtrar turnos por mis dias laborales: <asp:DropDownList ID="ddlFiltrosDia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltrosDia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </h4>
                    </td>
                    <td class="auto-style26" colspan="2">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style27">
                        &nbsp;</td>
                    <td class="auto-style26" colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" ValidationGroup="filtrarPorTurno" />
                    </td>
                    <td class="auto-style10">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="4">
                        <asp:GridView ID="grdVerTurnos" runat="server" AllowPaging="True" OnPageIndexChanging="grdVerTurnos_PageIndexChanging" PageSize="5" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="False" HorizontalAlign="Center" OnRowCancelingEdit="grdVerTurnos_RowCancelingEdit" OnRowDataBound="grdVerTurnos_RowDataBound" OnRowEditing="grdVerTurnos_RowEditing" OnRowUpdating="grdVerTurnos_RowUpdating" Width="100%">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:TemplateField HeaderText="N° Turno">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_Turno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Turno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Día">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Dia" runat="server" Text='<%# Bind("Dia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Horario">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI del Paciente">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lb_it_dniPac" runat="server" CommandArgument='<%# Bind("DNI_Pac") %>' CommandName="verDatos" OnCommand="lb_it_dniPac_Command" Text='<%# Bind("DNI_Pac") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Disponibilidad del Turno">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Disponibilidad" runat="server" Text='<%# Bind("Disponibilidad_Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="¿Asistió?">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="rbl_eit_Asistio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList> 
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Asistio" runat="server" Text='<%# Bind("Asistio_Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observación">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Observacion" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Observacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ocupado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Ocupado" runat="server" Text='<%# Bind("MedicoActivo") %>'></asp:Label>
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
                
                
            </table>
        </div>
               <asp:Label ID="lbl_notificacion" runat="server" Font-Bold="True" ForeColor="#009900"></asp:Label>
    </form>
</body>
</html>
