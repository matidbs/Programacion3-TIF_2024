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

namespace Vistas.Med
{
    public partial class MostrarDatosPaciente : System.Web.UI.Page
    {
        NegocioPacientes np = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = Application["login"].ToString();
                cargarGrdDatos();
                cargarGrdHistoriaClinica();
            }

        }

        public void cargarGrdDatos()
        {
            Paciente p = new Paciente();
            p.DNI_Pac = Application["dni"].ToString();
            grdVerDatos.DataSource = np.getPaciente(p);
            grdVerDatos.DataBind();
        }

        public void cargarGrdHistoriaClinica()
        {
            NegocioTurnosJunio ntj = new NegocioTurnosJunio();
            Paciente p = new Paciente();
            Medico med = new Medico();
            p.DNI_Pac = Application["dni"].ToString();
            med.Legajo_M = Convert.ToInt32(Application["legajo"]);
            grdHistoriaClinica.DataSource = ntj.getTurnosPorDNIyLegajo(p, med);
            grdHistoriaClinica.DataBind();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Application["legajo"] = null;
            Application["dni"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}