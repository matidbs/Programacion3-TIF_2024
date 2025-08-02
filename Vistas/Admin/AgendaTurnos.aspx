<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgendaTurnos.aspx.cs" Inherits="Vistas.AgendaTurnos" %>

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
        }
        .auto-style8 {
            height: 25px;
        }
        .auto-style16 {
            text-align: right;
        }
         .auto-style19 {
             width: 100%;
             text-align: right;
         }
         .auto-style22 {
             height: 28px;
             text-align: center;
         }
         .auto-style23 {
             width: 210px;
             text-align: center;
             height: 28px;
         }
         .auto-style26 {
             width: 210px;
             height: 49px;
         }
         .auto-style29 {
             width: 201px;
         }
         .auto-style30 {
             width: 95px;
         }
         .auto-style31 {
             height: 322px;
         }
         .auto-style32 {
             height: 46px;
         }
         .auto-style33 {
             width: 210px;
             height: 46px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style77">Bienvenido
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style16">
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">
                        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Admin/PortalAdmin.aspx">Regresar</asp:LinkButton>
                    </td>
                </tr>              
                <tr>
                    <td colspan="7" class="auto-style8">
                        <h2 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Turnos Medicos</h2>
                    </td>
                </tr>            
            </table>
        </div>
        <div class="auto-style31">
            <h3 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Seleccione la Especialidad para comenzar la busqueda de un turno disponible</h3>
            <table class="auto-style1" style="column-width:154px; height:50px"  >
                <tr>
                    <td class="auto-style23">Especialidad</td>
                    <td class="auto-style23">Medico</td>
                    <td class="auto-style23">Día</td>
                    <td class="auto-style23">Horario</td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style33">
                        <asp:DropDownList ID="ddlEspecialidades" runat="server" Height="25px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEspecilidad" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Seleccione una Especialidad para comenzar a filtrar" InitialValue="---Seleccionar---" ValidationGroup="Filtrar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style33">
                        <asp:DropDownList ID="ddlMedicos" runat="server" Height="25px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged" ValidationGroup="Filtrar">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMedico" runat="server" ControlToValidate="ddlMedicos" ErrorMessage="Seleccione Medico" InitialValue="---Seleccionar---" ValidationGroup="Filtrar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style33">
                        <asp:DropDownList ID="ddlDias" runat="server" Height="25px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged" ValidationGroup="Filtrar">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDias" runat="server" ControlToValidate="ddlDias" ErrorMessage="Seleccione un dia" ValidationGroup="Filtrar" InitialValue="---Seleccionar---">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style33">
                        <asp:DropDownList ID="ddlHorarios" runat="server" AutoPostBack="True" Height="25px" Width="130px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvHorarios" runat="server" ControlToValidate="ddlHorarios" ErrorMessage="Seleccione un horario" InitialValue="---Seleccionar---" ValidationGroup="Filtrar">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style32">

            <asp:Button ID="btnFiltrarMedico" runat="server" Text="Filtrar " ValidationGroup="Filtrar" OnClick="btnFiltrarMedico_Click" />
                    </td>
                </tr>
                </table>
            <asp:ValidationSummary ID="vsFiltrarMedico" runat="server" ValidationGroup="Filtrar" Height="20px" />
            <h3 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Busque un paciente</h3>
            <table class="auto-style1" style="column-width:154px; height:50px" >
                 <tr>
                     <td class="auto-style26">Nombre o Apellido del Paciente: </td>
                     <td class="auto-style29"><asp:TextBox ID="txtPaciente" runat="server" Width="179px" ></asp:TextBox> </td>
                     <td class="auto-style30">
            <asp:Button ID="btnBuscarPaciente" runat="server" Text="Buscar " ValidationGroup="Paciente" OnClick="btnBuscarPaciente_Click" />
                         <asp:RequiredFieldValidator ID="rfvPaciente" runat="server" ErrorMessage="Ingrese un Paciente" ValidationGroup="Paciente" ControlToValidate="txtPaciente">*</asp:RequiredFieldValidator>
                     </td>
                     <td>
                         <asp:DropDownList ID="ddlPacientes" runat="server" Height="21px" Width="233px">
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="rfvDDLPacienteSeleccione" runat="server" ControlToValidate="ddlPacientes" ErrorMessage="Seleccione un Paciente" InitialValue="---Seleccionar---" ValidationGroup="Paciente">*</asp:RequiredFieldValidator>
                     </td>
                 </tr>
            </table>

             <asp:ValidationSummary ID="vsPaciente" runat="server" Height="20px" ValidationGroup="Paciente" />       
             <h3 class="auto-style2" style="border: thin solid #000000; background-color: #fc2929">Presione 'OK' para asignar el turno</h3>
        </div>
        <div class="auto-style2">
            <asp:Label ID="lbl_turnoConfirmado" runat="server"></asp:Label>
        <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" Width="540px" OnPageIndexChanging="gvTurnos_PageIndexChanging" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Turno">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Turno" runat="server" Text='<%# Bind("Id_turno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medico">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_medico" runat="server" Text='<%# Bind("NombreCompleto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dia">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Dia" runat="server" Text='<%# Bind("Dias") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Horario">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("CodHorario_TJ") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Bind("CodFecha_TJ") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tomar Turno">
                    <ItemTemplate>
                        <asp:Button ID="btnTomarTurno" runat="server" CommandArgument='<%# Eval("Id_turno")+";"+Eval("NombreCompleto")+";"+Eval("Dias")+";"+Eval("CodHorario_TJ")+";"+Eval("CodFecha_TJ") %>' CommandName="eventoTomarTurno" OnCommand="btnTomarTurno_Command" Text="OK" ValidationGroup="Paciente" />
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
            <br />
            
        </div>
        
    </form>
</body>
</html>
