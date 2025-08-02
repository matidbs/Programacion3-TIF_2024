using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                CargarProvincias();
                CargarEspecialidades();
                CargarDias();
                cargarNacionalidades();
                lblNombre.Text = Application["login"].ToString();
            }
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
            Medico med = new Medico();
            NegocioMedicos nm = new NegocioMedicos();

            //verifica que haya por lo menos un dia seleccionado en el cblist
            if (verificarCheckBoxList()==false) { lblDiasSeleccionados.Text = "Seleccione por lo menos un dia de Atencion Medica"; return; }
            else { lblDiasSeleccionados.Text = ""; }

            CargarMedico(ref med);
            bool existeDni = nm.existeDNI(med);
            bool existeUser = nm.existeUser(med);
            lblAgregado.Text = "";
            if (existeUser) { lblAgregado.Text += "El Nombre de usuario ya existe."; }          
            if (existeDni) {lblAgregado.Text += "El DNI ya existe.";}
            if(lblAgregado.Text != "") { return;}

            //SE INSERTA UN MEDICO EN TABLA MEDICOS
            nm.addMedico(med);             
            //como el Legajo es autonumerico, me traigo el numero de legajo generado en la db y se lo cargo al medico que recien cree. Esto me va a permitir generar los registro de la tabla DIASMEDICOS
            med.Legajo_M = nm.GetLegajoMedicoPorDNI(med);
            //GENERO LOS DIAS Y HORAS QUE VA A TRABAJAR EL MEDICO EN LA CLINICA. ESTOS REGISTROS APARECERAN EN LA TABLA DIASMEDICOS. 

            cargarTablaDiasMedicos(med);
            lblAgregado.Text = "Medico agregado con éxito. Por favor actualice la agenda en la seccion Turnos del Portal";
            limpiarControles();
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }
        private void CargarMedico(ref Medico m)
        {
            m.Dni_m = txtDni.Text;
            m.Nombre_M = txtNombre.Text;
            m.Apellido_M = txtApellido.Text;
            m.Sexo_M = Convert.ToChar(rblSexo.SelectedValue);
            m.FechaNacimiento_M = txtFechaNacimiento.Text;
            m.Direccion_M = txtDireccion.Text;

            m.Localidad = new Localidades();
            m.Localidad.CodLoc_L = ddlLocalidadades.SelectedValue;

            m.Provincia = new Provincias();
            m.Provincia.CodProv_P = ddlProvincias.SelectedValue;

            m.CorreoElectronico_M = txtCorreo.Text;

            //m.Nacionalidad_M = ddlNacionalidades.SelectedValue;
            m.Nacionalidad = new Nacionalidades();
            m.Nacionalidad.IdNacionalidad_N1 = ddlNacionalidades.SelectedValue;

            m.Especialidad = new Especialidades();
            m.Especialidad.CodEspecialidad_e = ddlEspecialidades.SelectedValue;

            m.RangoHorario_M = Convert.ToChar(rblHorario.SelectedValue);

            m.User_M = txtNombreUser.Text;
            m.Password_M = txtPassUserConfirmar.Text;
           
            m.Estado = 1;
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
        private void CargarEspecialidades()
        {
            NegocioEspecialidades ne = new NegocioEspecialidades();
            ddlEspecialidades.DataSource = ne.getEspecialidades();
            ddlEspecialidades.DataValueField = "codEspecialidad_e";
            ddlEspecialidades.DataTextField = "descripcion_e";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlEspecialidades.SelectedValue = ddlEspecialidades.Items.FindByValue("---Seleccionar---").ToString();
        }

        private void CargarDias()
        {
            NegocioDias nd = new NegocioDias();
            cblDias.DataSource = nd.getDias();
            cblDias.DataValueField = "codDia_d";
            cblDias.DataTextField = "descripcion_d";
            cblDias.DataBind();
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

        private void cargarTablaDiasMedicos(Medico med)
        {
            //Para poder dividir los turnos por hora  ME AYUDO CON el 'HORARIO' QUE ELIGÍO EL MEDICO (El Value de Tarde es 'T' y el de Mañana es 'M')
            //ESTA 'T' Y 'M' ES LA QUE TAMBIEN SE ENCUENTRAN EN CADA REGISTRO DE LA TABLA HORARIOS. ENTONCES:
            //ME TRAIGO DE LA TABLA HORARIOS, DIVIDIDA EN DOS:
            //UNA TABLA CON LOS HORARIOS QUE PERTENCEN AL TURNO MAÑANA 'M'
            NegocioHorarios nh = new NegocioHorarios();
            DataTable TM = nh.getHorarios('M'); //08.00,09.00,10.00...
            //LOS HORARIOS QUE PERTENECEN AL TURNO TARDE 'T
            DataTable TT = nh.getHorarios('T');

            NegocioDiasMedicos ndm = new NegocioDiasMedicos(); //negocio para hacer el insert en tabla DiasMedicos

            //PARA SABER QUE DIAS TRABAJA EL MEDICO AGARRO LOS ITEMS SELECCIONADOS DEL CHECKBOXLISTDIAS.
            foreach (ListItem diaSeleccionado in cblDias.Items)
            {
                if (diaSeleccionado.Selected) //si el dia fue seleccionado..
                {
                    //me fijo en que 'Horario' trabajara el medico
                    if (med.RangoHorario_M == 'M')
                    {
                        //si eligío el turno mañana...
                        //A este medico, en este diaSeleccionado, le voy a generar todas horas que trabajará
                        foreach (DataRow hora in TM.Rows)
                        {
                            ndm.agregarDiaHoraALegajo(med.Legajo_M, diaSeleccionado.Value, hora["codHorario_h"].ToString());
                        }
                    }
                    else //quiere decir que el medico trabjará en turno tarde
                    {
                        //A este medico, en este diaSeleccionado, le voy a generar todas horas que trabajará
                        foreach (DataRow hora in TT.Rows)
                        {
                            ndm.agregarDiaHoraALegajo(med.Legajo_M, diaSeleccionado.Value, hora["codHorario_h"].ToString());
                        }

                    }
                }
            }
        }

        private bool verificarCheckBoxList()
        {
            bool porLoMenosUnDiaSeleccionado = false;
            foreach(ListItem item in cblDias.Items)
            {
                if (item.Selected)
                {
                    porLoMenosUnDiaSeleccionado = true;
                    return porLoMenosUnDiaSeleccionado;
                }
            }
            return porLoMenosUnDiaSeleccionado;
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
            ddlEspecialidades.SelectedValue = ddlNacionalidades.Items.FindByValue("---Seleccionar---").ToString();
            rblHorario.SelectedItem.Selected = false;
            foreach(ListItem item in cblDias.Items)
            {
                if (item.Selected) item.Selected = false;
            }
            txtNombreUser.Text = "";
            txtPassUser.Text = "";
            txtPassUserConfirmar.Text = "";
        }

        
    }
}