using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Vistas.Admin.ABML_Pacientes
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        NegocioPacientes np = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrdPacientes();
                cargarDDLSexo();
            }
            lblNombre.Text = Application["login"].ToString();
        }

        public void cargarGrdPacientes()
        {
            grdPacientes.DataSource = np.getPacientes();
            grdPacientes.DataBind();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            lblNotificacion.Text = "";
            cargarGrdPacientes();
            ddlSexo.SelectedValue = ddlSexo.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            lblNotificacion.Text = "";
            Paciente pac = new Paciente();
            pac.DNI_Pac = txtFiltrar.Text;

            if (np.existeDNI(pac))
            {
                DataTable dt = np.getPaciente(pac);
                DataRow dr = dt.Rows[0];
                string estado = dr[10].ToString();

                if(estado == "1")
                {
                    grdPacientes.DataSource = dt;
                }
                else
                {
                    grdPacientes.DataSource = null;
                    lblNotificacion.Text = "El paciente se encuentra inactivo";
                }

            }
            else
            {
                grdPacientes.DataSource = null;
                lblNotificacion.Text = "No se encontró ningún registro";
            }
            grdPacientes.DataBind();
            txtFiltrar.Text = "";
            ddlSexo.SelectedValue = ddlSexo.Items.FindByValue("---Seleccionar---").ToString();
        }

        public void cargarDDLSexo()
        {
            ddlSexo.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlSexo.Items.Add(new ListItem("Masculino", "M"));
            ddlSexo.Items.Add(new ListItem("Femenino", "F"));
            ddlSexo.SelectedValue = ddlSexo.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSexo.SelectedValue != "---Seleccionar---")
            {
                Paciente pc = new Paciente();
                string sexo = ddlSexo.SelectedValue;
                pc.Sexo_Pac = Convert.ToChar(sexo);
                DataTable dt = np.getPacientesPorSexo(pc);

                if(dt.Rows.Count > 0)
                {
                    grdPacientes.DataSource = dt;
                }
                else
                {
                    grdPacientes.DataSource = null;
                    lblNotificacion.Text = "Sin coincidencias";
                }
                grdPacientes.DataBind();
            }
            else
            {
                cargarGrdPacientes();
            }
        }

        protected void btnFiltrarEdad_Click(object sender, EventArgs e)
        {
            lblNotificacion.Text = "";
            NegocioPacientes neg = new NegocioPacientes();
            string edad = txtEdad.Text;

            if (neg.existeEdad(edad))
            {
                grdPacientes.DataSource = neg.getPacientesPorSuEdad(edad);
            }
            else
            {
                grdPacientes.DataSource = null;
                lblNotificacion.Text = "No hay registros de pacientes mayores o iguales a la edad seleccionada";
            }
            grdPacientes.DataBind();
            txtEdad.Text = "";
        }

        protected void grdPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPacientes.PageIndex = e.NewPageIndex;
            cargarGrdPacientes();
        }
    }
}