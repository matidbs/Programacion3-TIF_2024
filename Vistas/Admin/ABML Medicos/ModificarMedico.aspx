<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="Vistas.Admin.ABML_Medicos.ModificarMedico" %>

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
        .auto-style19 {
            width: 316px;
        }
        .auto-style20 {
            width: 216px;
        }
        .auto-style21 {
            margin-left: 30px;
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
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admin/ABML Medicos/AgregarMedico.aspx">Agregar Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style3">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admin/ABML Medicos/DarBajaMedico.aspx">Dar baja a Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style5">
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
                    <td class="auto-style16" colspan="3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929"">Modificación de Médico</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">Buscar por número de legajo: </td>
                    <td class="auto-style19">
                        <asp:TextBox ID="txtFiltrar" runat="server" Width="211px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revTxtFiltrar" runat="server" ErrorMessage="Legajo: Ingrese unicamente numeros, sin espacios." ControlToValidate="txtFiltrar" ValidationExpression="^\s*\d+\s*$" Font-Bold="True" ForeColor="Red" ValidationGroup="legajo">*</asp:RegularExpressionValidator>

                        <asp:RequiredFieldValidator ID="rfvTxtFiltrar" runat="server" ErrorMessage="Ingrese un número de legajo" ControlToValidate="txtFiltrar" ForeColor="Red" ValidationGroup="legajo">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" ValidationGroup="legajo" />
                        <asp:Button ID="btnMostrarTodos" runat="server" CssClass="auto-style21" OnClick="btnMostrarTodos_Click" Text="Mostrar todos" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr><td colspan="6">
                    <asp:Label ID="lblResultadoBusqueda" runat="server" ForeColor="Red"></asp:Label>
                    </td></tr>
                <tr>
                    <td colspan="6" class="auto-style13">
                        
                        <asp:GridView ID="grdModificarMedico" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdModificarMedico_RowCancelingEdit" OnRowEditing="grdModificarMedico_RowEditing" OnRowUpdating="grdModificarMedico_RowUpdating" OnRowDataBound="grdModificarMedico_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdModificarMedico_PageIndexChanging" Width="100%" AllowPaging="True">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowEditButton="True" ValidationGroup="Modificar" />
                                <asp:TemplateField HeaderText="Legajo">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_Legajo" runat="server" Text='<%# Eval("legajo_M") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Eval("legajo_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_DNI" runat="server" Text='<%# Bind("DNI_M") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txt_eit_DNI" ErrorMessage="Ingrese DNI. Maximo 8 Caracteres" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txt_eit_DNI" ErrorMessage="DNI con solo Numeros. 8 Digitos" ValidationExpression="^\d{8}$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Eval("DNI_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Nombre" runat="server" Text='<%# Bind("Nombre_M") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txt_eit_Nombre" ErrorMessage="Ingrese un Nombre" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Eval("Nombre_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Apellido" runat="server" Text='<%# Bind("Apellido_M") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txt_eit_Apellido" ErrorMessage="Ingrese un Apellido" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Eval("Apellido_M") %>'></asp:Label>
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
                                        <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Eval("Sexo_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_FechaNacimiento" runat="server" Text='<%# Bind("[Fecha Nacimiento_M]") %>' MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txt_eit_FechaNacimiento" ErrorMessage="Ingrese una fecha" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_eit_FechaNacimiento" ErrorMessage="Format dd/mm/aaaa. Solo hasta el 2000" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19[5-9][0-9]|20[0][0-1])$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Eval("Fecha Nacimiento_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dirección">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion_M") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txt_eit_Direccion" ErrorMessage="Ingrese Direccion" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Eval("Direccion_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Provincia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Provincias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincias_SelectedIndexChanged1">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_codProv" runat="server" Text='<%# Eval("DescripcionProvincia_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Localidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Localidades" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_codLoc" runat="server" Text='<%# Eval("DescripcionLocalidad_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo Electrónico">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Email" runat="server" Text='<%# Bind("CorreoElectronico_M") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txt_eit_Email" ErrorMessage="Ingrese Correo Electronico" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txt_eit_Email" ErrorMessage="Formato de correo Invalido" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Modificar">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Correo" runat="server" Text='<%# Eval("CorreoElectronico_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Especialidad">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_Especialidad" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rango Horario">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl_eit_Horario" runat="server" Text='<%# Eval("Rango Horario_M") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Eval("Rango Horario_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuario">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Usuario" runat="server" Text='<%# Bind("User_M") %>' MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txt_eit_Usuario" ErrorMessage="Ingrese Nombre de Usuario" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_User" runat="server" Text='<%# Eval("User_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contraseña">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_eit_Contraseña" runat="server" Text='<%# Bind("Password_M") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txt_eit_Contraseña" ErrorMessage="Ingrese Contraseña" ValidationGroup="Modificar">*</asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Contraseña" runat="server" Text='<%# Eval("Password_M") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nacionalidad">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_eit_Nacionalidades" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_idNacionalidad" runat="server" Text='<%# Eval("DescripcionNacionalidad_M ") %>'></asp:Label>
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
                    <td class="auto-style20">
                        <asp:Label ID="lblNotificacion" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style19">
                        <asp:ValidationSummary ID="vsModificar" runat="server" ValidationGroup="Modificar" Width="350px" ForeColor="#990000" />
                    </td>
                    <td class="auto-style16">
                        <asp:ValidationSummary ID="vsLegajo" runat="server" ForeColor="#990000" Height="56px" ValidationGroup="legajo" />
                    </td>
                </tr>
            </table>
        </div>
        
    </form>
</body>
</html>
