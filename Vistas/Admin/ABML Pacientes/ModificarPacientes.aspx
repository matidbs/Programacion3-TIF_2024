<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPacientes.aspx.cs" Inherits="Vistas.Admin.ABML_Pacientes.ModificarPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
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
        .auto-style13 {
            height: 23px;
        }
        .auto-style14 {
            text-align: left;
        }
        .auto-style15 {
            text-align: right;
        }
        .auto-style16 {
            width: 1203px;
        }
        .auto-style17 {
            width: 2219px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style14">
                        Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3" colspan="3">
                        &nbsp;</td>
                    <td class="auto-style15">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admin/ABML Pacientes/AgregarPaciente.aspx">Agregar Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style3">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admin/ABML Pacientes/DarBajaPaciente.aspx">Dar baja a Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style5">
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ModificarPacientes.aspx">Modificar Paciente</asp:LinkButton>
                    </td>
                    <td class="auto-style15">
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ListarPacientes.aspx">Listar Paciente</asp:LinkButton>
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
                    <td class="auto-style16" colspan="3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929"">Modificación de Paciente</h2>
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
                    <td colspan="6" class="auto-style13">
                        
                        <asp:GridView ID="grdModificarPaciente" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdModificarPaciente_RowCancelingEdit" OnRowEditing="grdModificarPaciente_RowEditing" OnRowUpdating="grdModificarPaciente_RowUpdating" OnRowDataBound="grdModificarPaciente_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdModificarPaciente_PageIndexChanging" Width="100%" AllowPaging="True">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowEditButton="True" ValidationGroup="Modificar" />
                                <asp:TemplateField HeaderText="DNI">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_DNI" runat="server" Text='<%# Eval("DNI_Pac") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Eval("DNI_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txt_eit_Nombre" ErrorMessage="Ingrese un Nombre" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Eval("Nombre_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txt_eit_Apellido" ErrorMessage="Ingrese un Apellido" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Eval("Apellido_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_FechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento_Pac") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txt_eit_FechaNacimiento" ErrorMessage="Ingrese un Apellido" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revFechaNacimiento" runat="server" ControlToValidate="txt_eit_FechaNacimiento" ErrorMessage="Format dd/mm/aaaa" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/(19[5-9][0-9]|20[0-1][0-9]|202[0-4])$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Eval("FechaNacimiento_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sexo">
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="rbl_eit_Sexo" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Eval("Sexo_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dirección">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txt_eit_Direccion" ErrorMessage="Ingrese una fecha" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Eval("Direccion_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Provincia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Provincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincias_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Eval("descripcion_P") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Localidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Localidades" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Eval("descripcion_L") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nacionalidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Nacionalidades" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Eval("Descripcion_N") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo Electrónico">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Email" runat="server" Text='<%# Bind("CorreoElectronico_Pac") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txt_eit_Email" ErrorMessage="Ingrese Correo Electronico" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txt_eit_Email" ErrorMessage="Formato de correo Invalido" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Eval("CorreoElectronico_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Teléfono">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txt_eit_Telefono" ErrorMessage="Ingrese número de télefono" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txt_eit_Telefono" ErrorMessage="Formato: 1141234567" ValidationExpression="^(?:11|[2368][1-4]\d{1}|[34]\d{2})?\d{6,8}$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Eval("Telefono_Pac") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <EditItemTemplate>
                                        <asp:RadioButtonList ID="rbl_eit_Estado" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Activar</asp:ListItem>
                                            <asp:ListItem Value="0">Desactivar</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Eval("Estado_Descripcion") %>'></asp:Label>
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
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">
                        <asp:Label ID="lblNotificacion" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:ValidationSummary ID="vsModificar" runat="server" ValidationGroup="Modificar" />
                    </td>
                    <td class="auto-style16">
                        <asp:ValidationSummary ID="vsFiltrar" runat="server" ValidationGroup="filtrar" />
                    </td>
                </tr>
            </table>
        </div>
        
    </form>
</body>
</html>
