using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas.Med.Informes
{
    public partial class TurnosPorMes : System.Web.UI.Page
    {
        NegocioTurnosJunio ntj = new NegocioTurnosJunio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = Application["login"].ToString();
                int legajo = Convert.ToInt32(Application["legajo"]);
                Medico med = new Medico();
                med.Legajo_M = legajo;

                DataTable resultado = ntj.contarTurnosDelMes(med);
                string cantidad = resultado.Rows[0]["Cantidad"].ToString();
                lblCantidad.Text = cantidad;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Application["legajo"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}