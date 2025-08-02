using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas.Admin.ABML_Medicos
{
    public partial class DarBajaMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNombre.Text = Application["login"].ToString();
            if (Application["legajo"] != null)
            {
                txtBajaLogica.Text = Application["legajo"].ToString();
                Application["legajo"] = null;
            }
        }
        protected void btnBajaLogica_Click(object sender, EventArgs e)
        {
            NegocioTurnosJunio nTurnosJunio = new NegocioTurnosJunio();
            NegocioDiasMedicos nDiasMedicos = new NegocioDiasMedicos();
            NegocioMedicos nMedicos = new NegocioMedicos();
            Medico medico = new Medico();

            int legajo = Convert.ToInt32(txtBajaLogica.Text);
            medico.Legajo_M = legajo;

            if (nMedicos.existeLegajo(medico))
            {
                if ((nTurnosJunio.bajaLogicaTurnosJunio(legajo) && nDiasMedicos.bajaLogicaDiasMedicos(legajo) && nMedicos.bajaLogica(legajo))
                    || (nDiasMedicos.bajaLogicaDiasMedicos(legajo) && nMedicos.bajaLogica(legajo)))
                {
                    lblBajaLogica.Text = "El médico con legajo " + legajo + " fue dado de baja.";
                }
                else
                {
                    lblBajaLogica.Text = "El médico ya está dado de baja";
                }
                Application["legajo"] = null;
            }
            else
            {
                lblBajaLogica.Text = "El legajo no pertenece a ningún médico";
            }
            txtBajaLogica.Text = "";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}