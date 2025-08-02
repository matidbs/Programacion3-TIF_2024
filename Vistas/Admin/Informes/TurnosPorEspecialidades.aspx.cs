using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Vistas.Admin.Informes
{
    public partial class TurnosPorEspecialidades : System.Web.UI.Page
    {
        NegocioTurnosJunio tj = new NegocioTurnosJunio();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            if (!(IsPostBack))
            {
                cargarGrid();
                cargarFechas();
            }
            lbl_notificacion.Text = "";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        private void cargarGrid()
        {

            gdTurnos.DataSource = tj.TurnosPorEspecialidad();
            gdTurnos.DataBind();
        }
        private void cargarFechas()
        {
            NegocioFechasJunio fj = new NegocioFechasJunio();
            ddlFechas.DataSource = fj.getFechasJunio();
            ddlFechas.DataTextField = "codFecha_f";
            ddlFechas.DataValueField = "codFecha_f";
            ddlFechas.DataBind();
            ddlFechas.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlFechas.SelectedValue = ddlFechas.Items.FindByValue("---Seleccionar---").ToString();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (!(ddlFechas.SelectedValue == "---Seleccionar---")) //Si no tiene seleccionado ese value. Filtro y cargo el grid
            {
                string codFecha = ddlFechas.SelectedValue.ToString();
                dt = tj.TurnosPorEspecialidadyFecha(codFecha);
                if (dt.Rows.Count > 0) gdTurnos.DataSource = dt;
                else { lbl_notificacion.Text = "Sin coincidencias"; }
            }
            else
            {
                gdTurnos.DataSource = tj.TurnosPorEspecialidad();
            }
            gdTurnos.DataBind();
           
        }

        protected void btnEliminarFiltros_Click(object sender, EventArgs e)
        {
            cargarGrid();
            ddlFechas.SelectedValue = ddlFechas.Items.FindByValue("---Seleccionar---").ToString();
        }
    }
}