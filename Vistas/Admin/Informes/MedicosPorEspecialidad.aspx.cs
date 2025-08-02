using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas.Admin.Informes
{
    public partial class MedicosPorEspecialidad : System.Web.UI.Page
    {
        NegocioMedicos nm = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

        public void cargarGridView()
        {
            grdCantidadMedicos.DataSource = nm.contarMedicosPorEspecialidad();
            grdCantidadMedicos.DataBind();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}