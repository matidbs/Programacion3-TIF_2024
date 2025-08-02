using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Med
{
    public partial class PortalMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilMedico.aspx");
        }
    }
}