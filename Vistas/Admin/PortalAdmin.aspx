<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalAdmin.aspx.cs" Inherits="Vistas.Admin.PortalAdmin" %>

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
            width: 394px;
        }
        .auto-style3 {
            text-align: right;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 382px;
        }
        .auto-style6 {
            width: 222px;
        }
        .auto-style7 {
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
        </div>
                <h2  style="border: thin solid #000000; background-color: #fc2929" class="auto-style4">Portal Administrador</h2>
                <h3  style="border: thin solid #000000; background-color: #fc2929" class="auto-style4">Medicos</h3>
            <table class="auto-style1">
                <tr>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Admin/ABML Medicos/AgregarMedico.aspx" >Agregar Médico</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Admin/ABML Medicos/DarBajaMedico.aspx">Dar baja a Médico</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Admin/ABML Medicos/ModificarMedico.aspx">Modificar Médico</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Admin/ABML Medicos/ListarMedicos.aspx">Listar médicos</asp:LinkButton>
            </td>
        </tr>
                </table>
            <h3  style="border: thin solid #000000; background-color: #fc2929" class="auto-style4">Pacientes</h3>
            <table class="auto-style1">
                <tr>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Admin/ABML Pacientes/AgregarPaciente.aspx" >Agregar Paciente</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/Admin/ABML Pacientes/DarBajaPaciente.aspx">Dar baja a Paciente</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ModificarPacientes.aspx">Modificar Paciente</asp:LinkButton>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/Admin/ABML Pacientes/ListarPacientes.aspx" >Listar Pacientes</asp:LinkButton>
            </td>
        </tr>
                </table>
        <h3  style="border: thin solid #000000; background-color: #fc2929" class="auto-style4">Turnos</h3>
        <table class="auto-style1">
                <tr>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style5">
                Generar/Actualizar Agenda:&nbsp;
                <asp:DropDownList ID="ddlMeses" runat="server" Width="85px">
                    <asp:ListItem Value="06">Junio</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:Button ID="btn_generarAgenda" runat="server" OnClick="btn_generarAgenda_Click" Text="Generar" />
            &nbsp;<asp:Label ID="lbl_turnosActualizados" runat="server"></asp:Label>
            </td>
            <td background-color: #FFFFFF" style="background-color: #FFFFFF" class="auto-style15">
                
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AgendaTurnos.aspx">Agenda Turnos</asp:HyperLink>
                
            </td>           
        </tr>
                </table>
        <h3  style="border: thin solid #000000; background-color: #fc2929" class="auto-style4">Informes</h3>


        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
                    <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/Admin/Informes/TurnosPorEspecialidades.aspx">Turnos Totales y Reservados Por Especialidad</asp:LinkButton>
                </td>
                <td class="auto-style7">
                    <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="~/Admin/Informes/MedicosPorEspecialidad.aspx">Cantidad de médicos por especialidad</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="~/Admin/Informes/TurnosAsistidosYNoAsistidos.aspx">Turnos Asistidos y No Asistidos</asp:LinkButton>
                </td>
            </tr>
        </table>


    </form>       
</body>
</html>
