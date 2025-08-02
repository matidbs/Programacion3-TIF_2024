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

namespace Vistas.Admin.ABML_Pacientes
{
    public partial class DarBajaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            if (Application["dni"] != null)
            {
                txtBajaLogica.Text = Application["dni"].ToString();
                Application["dni"] = null;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void btnBajaLogica_Click(object sender, EventArgs e)
        {
            Paciente p = new Paciente();
            NegocioPacientes pac = new NegocioPacientes();
            NegocioTurnosJunio turnosPac = new NegocioTurnosJunio(); //da de baja aquellos turnos que tomó pero que todavia no habia concurrido
            p.DNI_Pac = txtBajaLogica.Text;

            if (pac.existeDNI(p))
            {

                if ((pac.bajaLogicaPaciente(p) && turnosPac.bajaLogicaPacienteTurnosJunio(p.DNI_Pac)) ||
                    pac.bajaLogicaPaciente(p))
                {
                    lblBajaLogica.Text = "El paciente con DNI " + p.DNI_Pac + " fue dado de baja";
                }
                else
                {
                    lblBajaLogica.Text = "El paciente ya está dado de baja";
                }
            }
            else
            {
                lblBajaLogica.Text = "No existe el DNI del paciente a dar de baja";
            }

            txtBajaLogica.Text = "";
        }
    }
}