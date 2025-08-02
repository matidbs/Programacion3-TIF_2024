using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
using System.Data.SqlClient;
namespace Vistas
{
    public partial class AgendaTurnos : System.Web.UI.Page
    {
        NegocioTurnosJunio nj = new NegocioTurnosJunio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                CargarTurnos();
                CargarEspecialidades();
            }
            lblNombre.Text = Application["login"].ToString();
            lbl_turnoConfirmado.Text = "";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }
        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            CargarTurnos();

        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarddlMedicos();
            limpiarddlDias();
            limpiarddlHorarios();
            string codEspecialidad = ddlEspecialidades.SelectedValue;
            DataTable medicosEspecialidad = nj.getTurnosJunioGRID(codEspecialidad);

            ddlMedicos.DataSource = medicosEspecialidad;
            ddlMedicos.DataTextField = "NombreCompleto";
            ddlMedicos.DataValueField = "Legajo_TJ";
            ddlMedicos.DataBind();
            ddlMedicos.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlMedicos.SelectedValue = ddlMedicos.Items.FindByValue("---Seleccionar---").ToString();

        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarddlHorarios();
            
            RegistroTurno turno = new RegistroTurno();
            turno.Legajo = Convert.ToInt32(ddlMedicos.SelectedValue);
            DataTable dias = nj.getTurnosJunioGRID("", turno);
            ddlDias.DataSource = dias;
            ddlDias.DataTextField = "Dias";
            ddlDias.DataValueField = "CodDia_TJ";
            ddlDias.DataBind();
            ddlDias.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlDias.SelectedValue = ddlDias.Items.FindByValue("---Seleccionar---").ToString();

        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistroTurno turno = new RegistroTurno();
            turno.Legajo = Convert.ToInt32(ddlMedicos.SelectedValue);
            turno.CodDia = ddlDias.SelectedValue;
            DataTable Horarios = nj.getTurnosJunioGRID("", turno);
            ddlHorarios.DataSource = Horarios;
            ddlHorarios.DataTextField = "CodHorario_TJ";
            ddlHorarios.DataValueField = "CodHorario_TJ";
            ddlHorarios.DataBind();
            ddlHorarios.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlHorarios.SelectedValue = ddlHorarios.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void btnFiltrarMedico_Click(object sender, EventArgs e)
        {
            string CodEspe = ddlEspecialidades.SelectedValue;
            RegistroTurno turno = new RegistroTurno();
            turno.Legajo = Convert.ToInt32(ddlMedicos.SelectedValue);
            turno.CodDia = ddlDias.SelectedValue;
            turno.CodHorario = ddlHorarios.SelectedValue;
            CargarTurnos(true, CodEspe, turno);
        }
        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            NegocioPacientes np = new NegocioPacientes();
            DataTable pacientes = np.getPacientesFiltrados(txtPaciente.Text);
            ddlPacientes.Items.Clear(); //para que siempre limpie el ddl antes de cargarla con cada busqueda

            if (pacientes.Rows.Count == 0)
            {
                ddlPacientes.Items.Add(new ListItem("---Sin coincidencias---", "---Sin coincidencias---"));
                ddlPacientes.SelectedValue = ddlPacientes.Items.FindByValue("---Sin coincidencias---").ToString();
                ddlPacientes.DataBind();
            }
            else
            {
                
                ddlPacientes.DataSource = pacientes;
                ddlPacientes.DataValueField = "DNI";
                ddlPacientes.DataTextField = "Nombre Completo";
                ddlPacientes.DataBind();
                ddlPacientes.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
                ddlPacientes.SelectedValue = ddlPacientes.Items.FindByValue("---Seleccionar---").ToString();
                
            }
            

        }
        protected void btnTomarTurno_Command(object sender, CommandEventArgs e)
        {
        
            if (e.CommandName == "eventoTomarTurno")
            {
                /*
                if(ddlPacientes.SelectedValue == ddlPacientes.Items.FindByValue("---Sin coincidencias---").ToString())
                {
                    lbl_turnoConfirmado.Text = "Busque otro paciente"; return;
                }
                */

                if(ddlPacientes.SelectedValue == ("---Sin coincidencias---"))
                {
                    lbl_turnoConfirmado.Text = "Busque otro paciente"; return;
                }

                string argumentoCompleto = e.CommandArgument.ToString();
                int Idturno = Convert.ToInt32(argumentoCompleto.Split(';')[0]);
                string nombreMedico = argumentoCompleto.Split(';')[1];
                string diaYhora = argumentoCompleto.Split(';')[2] + " a las " + argumentoCompleto.Split(';')[3];
                string fecha = argumentoCompleto.Split(';')[4];
                string nombrePaciente = ddlPacientes.SelectedItem.ToString(); //me guardo el nombre del paciente para el mensaje
                string dniPaciente = ddlPacientes.SelectedValue; //me guardo el dni del paciente para la tabla turnosJunio

                RegistroTurno turno = new RegistroTurno();
                turno.Id_Turno = Idturno;
                turno.Dni_paciente = dniPaciente;


                if (nj.tomarTurno(turno))
                {
                    lbl_turnoConfirmado.Text = "Turno confirmado para el Paciente: "+nombrePaciente+". Detalles del Turno: Turno NRO:"+ Convert.ToString(Idturno) + ".Medico: " + nombreMedico + ".Dia y hora: " + diaYhora + " .Fecha: " + fecha;
                }
                //se vuelve a actualizar el grid con todos turnos
                CargarTurnos();
                limpiarddlEspecialidades();
                limpiarddlMedicos();
                limpiarddlDias();
                limpiarddlHorarios();
                txtPaciente.Text = "";
                ddlPacientes.Items.Clear();
            }
        }

        private void CargarTurnos(bool filtrado = false, string codEspe = "", RegistroTurno turno = null)
        {
            if (!(filtrado)) gvTurnos.DataSource = nj.getTurnosJunioGRID();
            else gvTurnos.DataSource = nj.getTurnosJunioGRIDFiltrado(codEspe, turno);
            gvTurnos.DataBind();
        }

        private void CargarEspecialidades()
        {
            NegocioEspecialidades ne = new NegocioEspecialidades();
            ddlEspecialidades.DataSource = ne.getEspecialidades();
            ddlEspecialidades.DataValueField = "codEspecialidad_e";
            ddlEspecialidades.DataTextField = "descripcion_e";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlEspecialidades.SelectedValue = ddlEspecialidades.Items.FindByValue("---Seleccionar---").ToString();
        }

        private void limpiarddlEspecialidades()
        {
            ddlEspecialidades.SelectedValue = ddlEspecialidades.Items.FindByValue("---Seleccionar---").ToString();
        }
        private void limpiarddlMedicos()
        {
            ddlMedicos.Items.Clear();
        }
        private void limpiarddlDias()
        {
            ddlDias.Items.Clear();
        }
        private void limpiarddlHorarios()
        {
            ddlHorarios.Items.Clear();
        }

        
    }
}