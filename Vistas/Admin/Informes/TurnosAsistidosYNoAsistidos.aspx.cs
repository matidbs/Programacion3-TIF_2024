using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using System.Data.SqlClient;

namespace Vistas.Admin.Informes
{
    public partial class TurnosAsistidosYNoAsistidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        public void cargarGridView()
        {
            NegocioTurnosJunio nj = new NegocioTurnosJunio();
            grdAsistencias.DataSource = nj.contarAsistenciasDeTurnos();
            grdAsistencias.DataBind();
        }
    }
}