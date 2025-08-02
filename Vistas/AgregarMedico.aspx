<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Vistas.AgregarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style5 {
            width: 268px;
        }
        .auto-style6 {
            background-color: #CC3300;
        }
        .auto-style7 {
            width: 408px;
        }
        .auto-style8 {
            width: 408px;
            height: 23px;
        }
        .auto-style9 {
            height: 23px;
        }
        .auto-style11 {
            width: 100%;
            background-color: #CC3300;
        }
        .auto-style13 {
            width: 240px;
        }
        .auto-style14 {
            width: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>Agregar Medico</strong></div>
    <table class="auto-style11">
        <tr>
            <td class="auto-style6"><strong><span class="auto-style6">DATOS PERSONALES:</span></strong></td>
        </tr>
    </table>

    <table class="auto-style2">
        <tr>
            <td class="auto-style13">DNI:
                <asp:TextBox ID="txtDni" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td class="auto-style13">NOMBRE:&nbsp;
                <asp:TextBox ID="txtNombre" runat="server" Width="145px"></asp:TextBox>
            </td>
            <td>APELLIDO:<asp:TextBox ID="txtApellido" runat="server" Width="143px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td class="auto-style14">SEXO:<asp:RadioButtonList ID="rblSexo" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style5">NACIONALIDAD:<asp:TextBox ID="txtNacionalidad" runat="server" Width="201px"></asp:TextBox>
            </td>
            
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td>FECHA DE NACIMIENTO:
                <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="170px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td class="auto-style13">PROVINCIA:
                <asp:DropDownList ID="ddlProvincias" runat="server" Height="19px" Width="119px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style13">LOCALIDAD:<asp:DropDownList ID="ddlLocalidadades" runat="server" Height="18px" Width="120px">
                </asp:DropDownList>
            </td>
            <td>DIRECCION:
                <asp:TextBox ID="txtDireccion" runat="server" Width="128px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td>CORREO ELECTRONICO:<asp:TextBox ID="txtCorreo" runat="server" Width="166px"></asp:TextBox>
            </td>
        </tr>
    </table>
   
   
   
    <table class="auto-style2">
       
        <tr class="auto-style6">
            <td><strong>DATOS LABORALES:</strong></td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td>NUMERO DE LEGAJO: <asp:TextBox ID="txtNumeroLegajo" runat="server" Width="166px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td class="auto-style8">ESPECIALIDAD:
                <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="145px">
                </asp:DropDownList>
            </td>
            <td class="auto-style9">HORARIO: <asp:RadioButtonList ID="rblHorario" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="M">Mañana</asp:ListItem>
                <asp:ListItem Value="T">Tarde</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>DIAS DE ATENCION MEDICA:
                <asp:CheckBoxList ID="cblDias" runat="server" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
        
    </table>
    <table class="auto-style2">
       
        <tr class="auto-style6">
            <td><strong>GENERAR USUARIO EN EL SISTEMA::</strong></td>
        </tr>
    </table>
    <table class="auto-style2">       
        <tr>
            <td class="auto-style7">NOMBRE USUARIO : <asp:TextBox ID="txtNombreUser" runat="server" Width="166px"></asp:TextBox>
            </td>
            <td>CONTRASEÑA: <asp:TextBox ID="txtPassUser" runat="server" Width="166px"></asp:TextBox>
            </td>
        </tr>
    </table>
         <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
         </form>
</body>
</html>
