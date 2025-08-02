using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if(rblTipoUsuario.SelectedValue.ToString() == "Administrador")
            {
                NegocioAdmins na = new NegocioAdmins();
                Administrador a = new Administrador();
                a.Nombre = txtUsuario.Text;
                a.Constraseña = txtContraseña.Text;

                if (na.searchAdmin(a))
                {
                    Application["login"] = a.Nombre;
                    Response.Redirect("~/Admin/PortalAdmin.aspx");
                }
            }
            else // else para buscar al medico
            {
                NegocioMedicos nm = new NegocioMedicos();
                Medico m = new Medico();
                m.User_M = txtUsuario.Text;
                m.Password_M = txtContraseña.Text;
                if (nm.verificarUserYContraseña(m)) //si user y contra son correctos
                {
                    DataTable regmedico = nm.filtrarMedicoPorUser(m); //busco su nombre y apellido
                    DataRow fila = regmedico.Rows[0];
                    string legajo = fila[0].ToString();
                    string nombreMed = fila[1].ToString();
                    string apellidoMed = fila[2].ToString();
                    Application["login"] = nombreMed + " " + apellidoMed;
                    Application["legajo"] = legajo;
                    Response.Redirect("~/Med/PortalMedico.aspx");
                }
            }
            //si tampoco es medico se notifica que el user no existe en registro 
            txtUsuario.Text = "";
            rblTipoUsuario.SelectedItem.Selected = false;
            lbl_Notificacion.Text = "Usuario No encontrado en el sistema";

        }
    }
}