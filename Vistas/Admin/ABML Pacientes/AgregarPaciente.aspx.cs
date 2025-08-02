using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas.Admin.ABML_Pacientes
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                cargarNacionalidades();
                lblNombre.Text = Application["login"].ToString();
            }
        }


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        private void CargarProvincias()
        {
            NegocioProvincias np = new NegocioProvincias();
            ddlProvincias.DataSource = np.getProvincias();
            ddlProvincias.DataValueField = "codProv_P";
            ddlProvincias.DataTextField = "descripcion_P";
            ddlProvincias.DataBind();
            ddlProvincias.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlProvincias.SelectedValue = ddlProvincias.Items.FindByValue("---Seleccionar---").ToString();
        }
        private void cargarNacionalidades()
        {
            NegocioNacionalidades nn = new NegocioNacionalidades();
            ddlNacionalidades.DataSource = nn.getNacionalidades();
            ddlNacionalidades.DataValueField = "IdNacionalidad_N";
            ddlNacionalidades.DataTextField = "Descripcion_N";
            ddlNacionalidades.DataBind();
            ddlNacionalidades.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlNacionalidades.SelectedValue = ddlNacionalidades.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList itemSeleccionado = (DropDownList)sender;
            int provCod = Convert.ToInt32(itemSeleccionado.SelectedValue);
            NegocioLocalidades nl = new NegocioLocalidades();
            ddlLocalidadades.DataSource = nl.getLocalidades(provCod);
            ddlLocalidadades.DataValueField = "codLoc_L";
            ddlLocalidadades.DataTextField = "descripcion_L";
            ddlLocalidadades.DataBind();
            ddlLocalidadades.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlLocalidadades.SelectedValue = ddlLocalidadades.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioPacientes np = new NegocioPacientes();
            Paciente p = new Paciente();

            p.DNI_Pac = txtDni.Text; //me fijo si el dni existe en registros
            if(!(np.existeDNI(p)))
            {
                CargarPaciente(ref p);
                if (np.addPaciente(p)) lblResultado.Text = "Paciente agregado con éxito";
                limpiarControles();
            }
            else 
            {
                lblResultado.Text = "El DNI ya existe en los registros"; return;
            }
        }


        private void CargarPaciente(ref Paciente p)
        {          
            p.DNI_Pac = txtDni.Text;
            p.Nombre_Pac = txtNombre.Text;
            p.Apellido_Pac = txtApellido.Text;
            p.Sexo_Pac = Convert.ToChar(rblSexo.SelectedValue);
            p.Nacionalidad = new Nacionalidades();
            p.Nacionalidad.IdNacionalidad_N1 = ddlNacionalidades.SelectedValue;
            p.FechaNacimiento_Pac = txtFechaNacimiento.Text;
            p.Direccion_Pac = txtDireccion.Text;
            p.Localidad = new Localidades();
            p.Localidad.CodLoc_L = ddlLocalidadades.SelectedValue;
            p.Provincia = new Provincias();
            p.Provincia.CodProv_P= ddlProvincias.SelectedValue;
            p.CorreoElectronico_Pac = txtCorreo.Text;
            p.telefono_Pac = txtTelefono.Text;
            p.Estado_Pac = 1;
        }

        private void limpiarControles()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNacimiento.Text = "";
            rblSexo.SelectedItem.Selected = false;
            ddlNacionalidades.SelectedValue = ddlNacionalidades.Items.FindByValue("---Seleccionar---").ToString();
            txtCorreo.Text = "";
            ddlProvincias.SelectedValue = ddlProvincias.Items.FindByValue("---Seleccionar---").ToString();
            ddlLocalidadades.Items.Clear();
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
    }
}