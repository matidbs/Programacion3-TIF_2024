using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas.Med
{
    public partial class PerfilMedico : System.Web.UI.Page
    {
        NegocioMedicos nm = new NegocioMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            string legajo = Application["legajo"].ToString();
            completarPerfil(legajo);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Application["legajo"] = null;
            Response.Redirect("~/Login.aspx");
        }

        public void completarPerfil(String legajo)
        {
            DataTable dt = nm.getPerfilMedico(Convert.ToInt32(legajo));

            lblNombreCompleto.Text = dt.Rows[0]["NombreCompleto"].ToString();
            lblDNI.Text = dt.Rows[0]["DNI_M"].ToString();
            if (dt.Rows[0]["Sexo_M"].ToString() == "F")
            {
                lblSexo.Text = "Femenino";
            }
            else
            {
                lblSexo.Text = "Masculino";
            }
            lblFechaNacimiento.Text = dt.Rows[0]["Fecha Nacimiento_M"].ToString();
            lblLegajo.Text = legajo;
            lblEspecialidad.Text = dt.Rows[0]["descripcion_e"].ToString();
            lblNacionalidad.Text = dt.Rows[0]["Descripcion_N"].ToString();
            lblCorreo.Text = dt.Rows[0]["CorreoElectronico_M"].ToString();
            bandera.ImageUrl = "./imagenes_banderas/" + dt.Rows[0]["IdNacionalidad_M"].ToString() + ".jpg";
        }
    }
}