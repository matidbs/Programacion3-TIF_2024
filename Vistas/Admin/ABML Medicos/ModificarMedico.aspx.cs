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

namespace Vistas.Admin.ABML_Medicos
{
    public partial class ModificarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = Application["login"].ToString();
                cargarGridView();
            }
            lblNotificacion.Text = "";
        }

        public void cargarGridView()
        {
            NegocioMedicos neg = new NegocioMedicos();
            grdModificarMedico.DataSource = neg.getMedicosModificar();
            grdModificarMedico.DataBind();
        }

        protected void grdModificarMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdModificarMedico.EditIndex = e.NewEditIndex;

            if (ViewState["RegistroMedicoFiltrado"] != null)
            {
                grdModificarMedico.DataSource = ViewState["RegistroMedicoFiltrado"];
                grdModificarMedico.DataBind();
            }
            else
            {
                cargarGridView();
            }

        }

        protected void grdModificarMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdModificarMedico.EditIndex = -1;
            
            if(ViewState["RegistroMedicoFiltrado"] != null)
            {
                grdModificarMedico.DataSource = ViewState["RegistroMedicoFiltrado"];
                grdModificarMedico.DataBind();
            }
            else
            {
            cargarGridView();
            }
        }

        protected void grdModificarMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            NegocioMedicos neg = new NegocioMedicos();
            Medico m = new Medico();

            string legajo = ((Label)grdModificarMedico.Rows[e.RowIndex].FindControl("lbl_eit_Legajo")).Text;
            string dni = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_DNI")).Text;
            string nombre = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Apellido")).Text;
            string sexo = ((RadioButtonList)grdModificarMedico.Rows[e.RowIndex].FindControl("rbl_eit_Sexo")).SelectedValue;
            string fechaNacimiento = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_FechaNacimiento")).Text;
            string direccion = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Direccion")).Text;
            string codProvincia = ((DropDownList)grdModificarMedico.Rows[e.RowIndex].FindControl("ddl_eit_Provincias")).SelectedValue;
            string codLocalidad = ((DropDownList)grdModificarMedico.Rows[e.RowIndex].FindControl("ddl_eit_Localidades")).SelectedValue;
            string email = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Email")).Text;    

            //Cargar la especialidad
            NegocioEspecialidades ne = new NegocioEspecialidades();
            Especialidades especialidad = new Especialidades();
            especialidad.Descripcion_e = ((Label)grdModificarMedico.Rows[e.RowIndex].FindControl("lbl_eit_Especialidad")).Text;
            DataTable registroEspe= ne.getEspecialidad(especialidad.Descripcion_e);
            DataRow filaEspe = registroEspe.Rows[0];
            especialidad.CodEspecialidad_e = filaEspe[0].ToString();

            string rangoHorario = ((Label)grdModificarMedico.Rows[e.RowIndex].FindControl("lbl_eit_Horario")).Text;
            string usuario = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Usuario")).Text;
            string contraseña = ((TextBox)grdModificarMedico.Rows[e.RowIndex].FindControl("txt_eit_Contraseña")).Text;
            string idNacionalidad = ((DropDownList)grdModificarMedico.Rows[e.RowIndex].FindControl("ddl_eit_Nacionalidades")).SelectedValue;
            string estado = ((RadioButtonList)grdModificarMedico.Rows[e.RowIndex].FindControl("rbl_eit_Estado")).SelectedValue;

            m.Legajo_M = Convert.ToInt32(legajo);
            m.Dni_m = dni;
            m.Nombre_M = nombre;
            m.Apellido_M = apellido;
            m.Sexo_M = Convert.ToChar(sexo);
            m.FechaNacimiento_M = fechaNacimiento;
            m.Direccion_M = direccion;
            m.Localidad = new Localidades();
            m.Localidad.CodLoc_L = codLocalidad;
            m.Provincia = new Provincias();
            m.Provincia.CodProv_P = codProvincia;
            m.CorreoElectronico_M = email;
            m.Especialidad = new Especialidades();
            m.Especialidad.CodEspecialidad_e = especialidad.CodEspecialidad_e;
            m.Nacionalidad = new Nacionalidades();
            m.Nacionalidad.IdNacionalidad_N1 = idNacionalidad;
            m.RangoHorario_M = Convert.ToChar(rangoHorario);
            m.User_M = usuario;
            m.Password_M = contraseña;
  
            m.Estado = Convert.ToInt32(estado);

            //Me traigo los datos que tenia el medico antes de que este edit sea cargado en la db       
            DataTable registroMedico = neg.filtrarMedicoPorLegajo(m);
            DataRow registro = registroMedico.Rows[0]; 

            string rbEstado = ((RadioButtonList)grdModificarMedico.Rows[e.RowIndex].FindControl("rbl_eit_Estado")).SelectedValue;


            //Me fijo cual era el nombre de User del medico antes del Edit (xq no puede repetirse el user):
            //si el nombre de user es modificado, me fije que no exista en otro registro. Pero si el user es igual al que ya tenia el registro sigo de largo
            if (registro[11].ToString() != m.User_M)
            {
                if (neg.existeUser(m)) { lblNotificacion.Text = "El nombre de Usuario ya existe en los registros"; return; };
            }

            //Si el DNI que estabá en el registro de la db es igual al que está en el textbox del formulario
            //quiere decir que no lo cambío y permito que el mismo dni sea ingresado.
            if (registro[1].ToString() == m.Dni_m)
            {
                checkeoDarDeBaja(rbEstado, registro[14].ToString(), legajo);
                neg.updateMedico(m);
            }
            else
            {
                //si el DNI se modificó, me fijo que ya no exista en otro registro
                if (!(neg.existeDNI(m)))
                {
                    checkeoDarDeBaja(rbEstado, registro[14].ToString(), legajo);
                    neg.updateMedico(m);
                }
                else
                {
                    lblNotificacion.Text = "El número de DNI ya existe en los registros";
                    return;
                }
            }

            lblNotificacion.Text = "Medico Modificado con éxito";
            grdModificarMedico.EditIndex = -1;

            if (ViewState["RegistroMedicoFiltrado"] != null)
            {
                DataTable dt =  neg.getMedicoModificarPorLegajo(m); //traigo el registro que acabo de modificar
                ViewState["RegistroMedicoFiltrado"] = dt;
                grdModificarMedico.DataSource = ViewState["RegistroMedicoFiltrado"];
                grdModificarMedico.DataBind();
            }
            else cargarGridView();

        }

        public void checkeoDarDeBaja(String rbEstado, String BDEstado, String legajo)
        {
            NegocioTurnosJunio tj = new NegocioTurnosJunio();
            NegocioDiasMedicos dm = new NegocioDiasMedicos();

            if (rbEstado == "0" && BDEstado != "0")
            {
                Application["legajo"] = legajo;
                Response.Redirect("~/Admin/ABML Medicos/DarBajaMedico.aspx");
            }
            else if (rbEstado == "1" && BDEstado == "0")
            {
                tj.cambiarEstadoAactivoTJ(Convert.ToInt32(legajo));
                dm.cambiarEstadoAactivoDM(Convert.ToInt32(legajo));
            }
        }

        /*
         Despues de presionar editar, se dispara el rowDataBound
            permite precargar los controles del la row que se quiere editar
        especificamente para los ddl y rb
        obtengo mediante eval la informacion que tiene cierta columna de esta fila
         */
        protected void grdModificarMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Esto es para que aparezca seleccionado El sexo. Traigo el valor que tenia guardado
                RadioButtonList rblSexo = (RadioButtonList)e.Row.FindControl("rbl_eit_Sexo");
                if(rblSexo != null)
                {
                    rblSexo.SelectedValue =  DataBinder.Eval(e.Row.DataItem, "Sexo_M").ToString();
                }       

                //Provincia
                DropDownList ddlProv = (DropDownList)e.Row.FindControl("ddl_eit_Provincias");
                if (ddlProv != null)
                {
                    NegocioProvincias neg = new NegocioProvincias();
                    ddlProv.DataSource = neg.getProvincias();
                    ddlProv.DataTextField = "descripcion_P";
                    ddlProv.DataValueField = "codProv_P";
                    ddlProv.DataBind();

                    string codigoProvincia = DataBinder.Eval(e.Row.DataItem, "codProv_M").ToString();
                    ddlProv.SelectedValue = codigoProvincia;

                }              

                //Esto es para que aparezca seleccionada la localidad que esta en el registro de medicos
                DropDownList ddlLoc = (DropDownList)e.Row.FindControl("ddl_eit_Localidades");
                if (ddlLoc != null)
                {
                    int IdProvincia = Convert.ToInt32(ddlProv.SelectedValue);
                    NegocioLocalidades neg = new NegocioLocalidades();
                    ddlLoc.DataSource = neg.getLocalidades(IdProvincia);
                    ddlLoc.DataValueField = "codLoc_L";
                    ddlLoc.DataTextField = "descripcion_L";
                    ddlLoc.DataBind();

                    string codigoLocalidad = DataBinder.Eval(e.Row.DataItem, "codLoc_M").ToString();
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

                    string codigoNacionalidad = DataBinder.Eval(e.Row.DataItem, "IdNacionalidad_M").ToString();
                    ddlNac.SelectedValue = codigoNacionalidad;
                }

                //Esto es para que aparezca seleccionado el Estado. Traigo el valor que tenia guardado
                RadioButtonList rblEstado = (RadioButtonList)e.Row.FindControl("rbl_eit_Estado");
                if (rblEstado != null)
                {                   
                    rblEstado.SelectedValue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Estado_M")).ToString();
                }

            }
        }
        //Filtrar localidades segun provincia
        protected void ddl_eit_Provincias_SelectedIndexChanged1(object sender, EventArgs e)
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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void grdModificarMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdModificarMedico.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Medico med = new Medico();
            NegocioMedicos nm = new NegocioMedicos();
            int legajo = Convert.ToInt32(txtFiltrar.Text);
            med.Legajo_M = legajo;

            if (nm.existeLegajo(med))
            {
                DataTable dt = nm.getMedicoModificarPorLegajo(med);

                grdModificarMedico.DataSource = dt;
                grdModificarMedico.DataBind();
                ViewState["RegistroMedicoFiltrado"] = dt;
            }
            else
            {
                lblResultadoBusqueda.Text = "El legajo no pertenece a ningún médico";
            }
                txtFiltrar.Text = "";
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {

            cargarGridView();
            ViewState["RegistroMedicoFiltrado"] = null;
            txtFiltrar.Text = "";
        }
    }
}