<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Vistas.AgregarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {         
            
            width: 881px;
        }
        .auto-style7 {
            width: 408px;
            height: 42px;
        }
        .auto-style11 {
            width: 100%;
            background-color: white;
        }
        .auto-style22 {
            background-color: #fc2929;
            text-align: center;
            width: 1039px;
        }
        .auto-style37 {
            text-align: left;
        }
        .auto-style38 {
            width: 100%;
        }
        .auto-style39 {
            width: 80px;
        }
        .auto-style41 {
            width: 83px;
        }
        .auto-style44 {
            width: 195px;
        }
        .auto-style45 {
            width: 83px;
            text-align: right;
            height:42px;
        }
        .auto-style46 {
            width: 101px;
            height:42px;
        }
        .auto-style47 {
            width: 175px;
            height:42px;
        }
        .auto-style48 {
            width: 250px;
            height:42px;
        }
        .auto-style49 {
            width: 231px;
        }
        .auto-style52 {
            width: 80px;
            height: 42px;
        }
        .auto-style53 {
            width: 83px;
            height: 42px;
        }
        .auto-style55 {
            width: 195px;
            height: 42px;
        }
        .auto-style56 {
            height: 42px;
        }
        .auto-style59 {
            width: 80px;
            height: 42px;
        }
        .auto-style61 {
            width: 195px;
            height: 42px;
        }
        .auto-style62 {
            height: 42px;
        }
        .auto-style64 {
            width: 193px;
            height: 42px;
        }
        .auto-style65 {
            width: 231px;
            height: 42px;
        }
        .auto-style66 {
            text-align: center;
            background-color: #fc2929;
            border: thin solid #000000;
        }
        .auto-style67 {
            text-align: center;
        }
        .auto-style73 {
            width: 171px;
            height: 42px;
        }
        .auto-style74 {
            width: 171px;
        }
        .auto-style76 {
            width: 193px;
        }
        .auto-style77 {
            width: 370px;
        }
        .auto-style78 {
            text-align: right;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style37">
            <table class="auto-style11">
                <tr>
                    <td class="auto-style77">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style78">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style11">
                <tr>
                    <td class="auto-style67">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admin/ABML Medicos/AgregarMedico.aspx">Agregar Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style67">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admin/ABML Medicos/DarBajaMedico.aspx">Dar baja a Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style67" colspan="3">
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Admin/ABML Medicos/ModificarMedico.aspx">Modificar Médico</asp:LinkButton>
                    </td>
                    <td class="auto-style67">
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Admin/ABML Medicos/ListarMedicos.aspx">Listar médicos</asp:LinkButton>
                    </td>
                    <td class="auto-style67">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Admin/PortalAdmin.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>
                </table>
            <h2 class="auto-style66">Agregar Médico</h2>      
    <table class="auto-style11">     
        <tr>
            <td class="auto-style22" colspan="4" style="border: thin solid #000000"><strong><span class="auto-style6">DATOS PERSONALES</span></strong></td>
        </tr>
    </table>

            <table class="auto-style38">
                <tr>
                    <td class="auto-style46">DNI:</td>
                    <td class="auto-style48">
                <asp:TextBox ID="txtDni" runat="server" Width="143px" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingrese DNI" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" ErrorMessage="DNI con solo Numeros.8 Digitos" ValidationExpression="^\d{8}$" ValidationGroup="Agregar">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style52">NOMBRE:</td>
                    <td class="auto-style55">
                <asp:TextBox ID="txtNombre" runat="server" Width="143px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style53">APELLIDO:</td>
                    <td class="auto-style73"><asp:TextBox ID="txtApellido" runat="server" Width="143px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style55">FECHA DE NACIMIENTO:</td>
                    <td class="auto-style56">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="143px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Ingrese Fecha de Nacimiento, Formato dd/mm/aaaa" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Fechas hasta el año 2000.Formato dd/mm/aaaa" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19[5-9][0-9]|20[0][0-1])$" ValidationGroup="Agregar">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style46">SEXO: 
            </td>
                    <td class="auto-style48"><asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal" Width="205px">
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:RadioButtonList>  <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="rblSexo" ErrorMessage="Seleccione Sexo" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>

                    </td>
                    <td class="auto-style59">
                        
                        NACIONALIDAD: 
            </td>
                    <td class="auto-style55">
                <asp:DropDownList ID="ddlNacionalidades" runat="server" Width="168px" Height="25px">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                    
            
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidades" ErrorMessage="Seleccione Nacionalidad" InitialValue="---Seleccionar---" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    
            
                    </td>
                    <td class="auto-style45">CORREO </td>
                    <td class="auto-style73">ELECTRONICO:</td>
                    <td class="auto-style61"><asp:TextBox ID="txtCorreo" runat="server" Width="166px"></asp:TextBox>
                    </td>
                    <td class="auto-style62">
                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Ingrese Correo Electronico" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Formato de correo Invalido" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Agregar">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style46">PROVINCIA:</td>
                    <td class="auto-style76">
                <asp:DropDownList ID="ddlProvincias" runat="server" Height="28px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged">
                </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincias" ErrorMessage="Seleccione Provincia" InitialValue="---Seleccionar---" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style39">LOCALIDAD:</td>
                    <td class="auto-style44"><asp:DropDownList ID="ddlLocalidadades" runat="server" Height="26px" Width="150px">
                </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidadades" ErrorMessage="Seleccione Localidad" InitialValue="---Seleccionar---" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style41">DIRECCION:</td>
                    <td class="auto-style74">
                <asp:TextBox ID="txtDireccion" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td class="auto-style44">
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Ingrese Direccion" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table> 

   <table class="auto-style11">     
        <tr>
            <td class="auto-style22" colspan="4" style="border: thin solid #000000"><strong><span class="auto-style6">DATOS LABORALES</td>
        </tr>
    </table>

            <table class="auto-style38">
                <tr>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style64"> &nbsp;</td>
                    <td class="auto-style65">ESPECIALIDAD:</td>
                    <td class="auto-style56">
                <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="150px" Height="25px">
                </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Seleccione Especialidad" InitialValue="---Seleccionar---" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style47">HORARIO:</td>
                    <td class="auto-style48"> <asp:RadioButtonList ID="rblHorario" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="M">Mañana</asp:ListItem>
                <asp:ListItem Value="T">Tarde</asp:ListItem>
                </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvHorario" runat="server" ControlToValidate="rblHorario" ErrorMessage="Seleccione Un Horario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style49">DIAS DE ATENCION MEDICA:</td>
                    <td>
                <asp:CheckBoxList ID="cblDias" runat="server" RepeatDirection="Horizontal" >
                </asp:CheckBoxList>
                        
                    </td>
                </tr>
            </table>

    <table class="auto-style11">     
        <tr>
            <td class="auto-style22" colspan="4" style="border: thin solid #000000"><strong><span class="auto-style6">GENERAR USUARIO EN EL SISTEMA</span></strong></td>
        </tr>
    </table>
    <table class="auto-style2">       
        <tr>
            <td class="auto-style7">NOMBRE USUARIO : <asp:TextBox ID="txtNombreUser" runat="server" Width="166px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreUser" ErrorMessage="Ingrese Nombre de Usuario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style56">CONTRASEÑA: <asp:TextBox ID="txtPassUser" runat="server" Width="166px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtPassUser" ErrorMessage="Ingrese Contraseña" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style56">REPETIR CONTRASEÑA: <asp:TextBox ID="txtPassUserConfirmar" runat="server" Width="166px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraseñaConfirmar" runat="server" ControlToValidate="txtPassUserConfirmar" ErrorMessage="Repita la Contraseña" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvContraseñas" runat="server" ControlToCompare="txtPassUser" ControlToValidate="txtPassUserConfirmar" ErrorMessage="Las contraseñas no son iguales" ValidationGroup="Agregar">*</asp:CompareValidator>
            </td>
        </tr>
    </table>
         <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" ValidationGroup="Agregar" />
         &nbsp;<asp:Label ID="lblAgregado" runat="server"></asp:Label>
         </div> 
        <asp:Label ID="lblDiasSeleccionados" runat="server"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Agregar" />
   </form>   
</body>
</html>
