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


namespace Vistas.Admin.ABML_Pacientes
{
    public partial class ModificarPacientes : System.Web.UI.Page
    {
        NegocioPacientes np = new NegocioPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = Application["login"].ToString();
                cargarGrdPacientes();
            }
            lblNotificacion.Text = "";
        }

        public void cargarGrdPacientes()
        {
            grdModificarPaciente.DataSource = np.getPacientesModificar();
            grdModificarPaciente.DataBind();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void grdModificarPaciente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdModificarPaciente.EditIndex = e.NewEditIndex;
            if (ViewState["RegistroPacienteFiltrado"] != null) cargarGrdConRegistroPacienteFiltrado();
            else cargarGrdPacientes();
        }

        protected void grdModificarPaciente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificarPaciente.EditIndex = -1;
            if (ViewState["RegistroPacienteFiltrado"] != null) cargarGrdConRegistroPacienteFiltrado();
            else cargarGrdPacientes();
        }

        protected void grdModificarPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdModificarPaciente.PageIndex = e.NewPageIndex;
            cargarGrdPacientes();
        }

        protected void grdModificarPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Sexo
                RadioButtonList rblSexo = (RadioButtonList)e.Row.FindControl("rbl_eit_Sexo"); 
                if (rblSexo != null)
                {
                    rblSexo.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Sexo_Pac").ToString();
                }

                //Provincias
                DropDownList ddlProv = (DropDownList)e.Row.FindControl("ddl_eit_Provincias"); 
                if (ddlProv != null)
                {
                    NegocioProvincias neg = new NegocioProvincias();
                    ddlProv.DataSource = neg.getProvincias();
                    ddlProv.DataTextField = "descripcion_P";
                    ddlProv.DataValueField = "codProv_P";
                    ddlProv.DataBind();

                    string codigoProvincia = DataBinder.Eval(e.Row.DataItem, "codProv_Pac").ToString();
                    ddlProv.SelectedValue = codigoProvincia;
                }

                //Localidad
                DropDownList ddlLoc = (DropDownList)e.Row.FindControl("ddl_eit_Localidades"); 
                if (ddlLoc != null)
                {
                    int IdProvincia = Convert.ToInt32(ddlProv.SelectedValue);
                    NegocioLocalidades neg = new NegocioLocalidades();
                    ddlLoc.DataSource = neg.getLocalidades(IdProvincia);
                    ddlLoc.DataValueField = "codLoc_L";
                    ddlLoc.DataTextField = "descripcion_L";
                    ddlLoc.DataBind();

                    string codigoLocalidad = DataBinder.Eval(e.Row.DataItem, "codLoc_Pac").ToString();
                    ddlLoc.SelectedValue = codigoLocalidad;
                }

                //Nacionalidad
                DropDownList ddlNac = (DropDownList)e.Row.FindControl("ddl_eit_Nacionalidades"); 
                if (ddlNac != null)
                {
                    NegocioNacionalidades nn = new NegocioNacionalidades();
                    ddlNac.DataSource = nn.getNacionalidades();
                    ddlNac.DataTextField = "descripcion_N";
                    ddlNac.DataValueField = "IdNacionalidad_N";
                    ddlNac.DataBind();

                    string codigoNacionalidad = DataBinder.Eval(e.Row.DataItem, "IdNacionalidad_Pac").ToString();
                    ddlNac.SelectedValue = codigoNacionalidad;
                }

                //Estado
                RadioButtonList rblEstado = (RadioButtonList)e.Row.FindControl("rbl_eit_Estado"); 
                if (rblEstado != null)
                {
                    rblEstado.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Estado_Pac").ToString();
                }
            }
        }

        protected void grdModificarPaciente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Paciente pc = new Paciente();

            //Carga de datos
            String dni = ((Label)grdModificarPaciente.Rows[e.RowIndex].FindControl("lbl_eit_DNI")).Text;
            string nombre = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_Apellido")).Text;
            string sexo = ((RadioButtonList)grdModificarPaciente.Rows[e.RowIndex].FindControl("rbl_eit_Sexo")).SelectedValue;
            string fechaNacimiento = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_FechaNacimiento")).Text;
            string direccion = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;
            string codProvincia = ((DropDownList)grdModificarPaciente.Rows[e.RowIndex].FindControl("ddl_eit_Provincias")).SelectedValue;
            string codLocalidad = ((DropDownList)grdModificarPaciente.Rows[e.RowIndex].FindControl("ddl_eit_Localidades")).SelectedValue;
            string email = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_Email")).Text;
            string telefono = ((TextBox)grdModificarPaciente.Rows[e.RowIndex].FindControl("txt_eit_Telefono")).Text;
            string idNacionalidad = ((DropDownList)grdModificarPaciente.Rows[e.RowIndex].FindControl("ddl_eit_Nacionalidades")).SelectedValue;
            string estado = ((RadioButtonList)grdModificarPaciente.Rows[e.RowIndex].FindControl("rbl_eit_Estado")).SelectedValue;

            pc.DNI_Pac = dni;
            pc.Nombre_Pac = nombre;
            pc.Apellido_Pac = apellido;
            pc.Sexo_Pac = Convert.ToChar(sexo);
            pc.FechaNacimiento_Pac = fechaNacimiento;
            pc.Direccion_Pac = direccion;
            pc.Provincia = new Provincias();
            pc.Provincia.CodProv_P = codProvincia;
            pc.Localidad = new Localidades();
            pc.Localidad.CodLoc_L = codLocalidad;
            pc.CorreoElectronico_Pac = email;
            pc.Nacionalidad = new Nacionalidades();
            pc.Nacionalidad.IdNacionalidad_N1 = idNacionalidad;
            pc.telefono_Pac = telefono;
            pc.Estado_Pac = Convert.ToChar(estado);

            DataTable registroPaciente = np.getPaciente(pc);
            DataRow registro = registroPaciente.Rows[0]; //traigo registro de db

            np.updatePaciente(pc); 

            string rbEstado = ((RadioButtonList)grdModificarPaciente.Rows[e.RowIndex].FindControl("rbl_eit_Estado")).SelectedValue;
            if (rbEstado == "0" && registro[10].ToString() != "0") //evalúo el registro anterior a la actualacion
            {
                Application["dni"] = dni;
                Response.Redirect("~/Admin/ABML Pacientes/DarBajaPaciente.aspx"); 

            }

            lblNotificacion.Text = "Paciente modificado con éxito";
            grdModificarPaciente.EditIndex = -1;

            //si se actualizó un paciente dentro del viewState se recarga la pagina unicamente con ese registro actualizado
            //tengo que volver a cargar el ViewState con la actualizacion y despues se lo paso el Grd
            if (ViewState["RegistroPacienteFiltrado"] != null)
            {
                DataTable dt = np.getPacienteModificar(pc);
                ViewState["RegistroPacienteFiltrado"] = dt;
                cargarGrdConRegistroPacienteFiltrado();
            }
            else cargarGrdPacientes(); //si la actualizacion se hizo sin un ViewState actualiza el grid como siempre
                      

        }

        protected void ddl_eit_Provincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProv = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProv.NamingContainer;
            DropDownList ddlLoc = (DropDownList)row.FindControl("ddl_eit_Localidades");

            if (ddlLoc != null)
            {
                int IdProvincia = Convert.ToInt32(ddlProv.SelectedValue);
                NegocioLocalidades neg = new NegocioLocalidades();
                ddlLoc.DataSource = neg.getLocalidades(IdProvincia);
                ddlLoc.DataValueField = "codLoc_L";
                ddlLoc.DataTextField = "descripcion_L";
                ddlLoc.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioPacientes ng = new NegocioPacientes();
            Paciente paciente = new Paciente();
            paciente.DNI_Pac = txtFiltrar.Text;

            if (np.existeDNI(paciente))
            {
                DataTable dt = np.getPacienteModificar(paciente);
                DataRow dr = dt.Rows[0];
                string estado = dr[14].ToString();

                if (estado == "1")
                {
                    grdModificarPaciente.DataSource = dt;           
                    ViewState["RegistroPacienteFiltrado"] = dt; //si el paciente está activo y existe, lo guardo en el viewstate
                }
                else
                {
                    grdModificarPaciente.DataSource = null;
                    lblNotificacion.Text = "El paciente se encuentra inactivo";
                }

            }
            else
            {
                grdModificarPaciente.DataSource = null;
                lblNotificacion.Text = "No se encontró ningún registro";
            }
            grdModificarPaciente.DataBind();
            txtFiltrar.Text = "";
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarGrdPacientes();
            ViewState["RegistroPacienteFiltrado"] = null;
        }

        private void cargarGrdConRegistroPacienteFiltrado()
        {            
            grdModificarPaciente.DataSource = (DataTable)ViewState["RegistroPacienteFiltrado"];
            grdModificarPaciente.DataBind();
        }
    }
}