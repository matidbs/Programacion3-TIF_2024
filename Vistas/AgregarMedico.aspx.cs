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
            if(!(IsPostBack))
            {
                CargarProvincias();
                CargarEspecialidades();
                CargarDias();
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Medico med = new Medico();
            NegocioMedicos nm = new NegocioMedicos();
            
            CargarMedico(ref med); //SE AGREGA UN MEDICO EN TABLA MEDICOS
            nm.addMedico(med);

            //AHORA GENERO LOS DIAS Y HORAS QUE VA A TRABAJAR EL MEDICO EN LA CLINICA
            //ESTOS REGISTROS APARECERAN EN LA TABLA DIASMEDICOS. 

            //PARA PODER DIVIDIR POR HORA EL 'HORARIO' QUE ELIGÍO EL MEDICO ME AYUDO CON LA 'T' O LA 'M'
            //ESTA 'T' Y 'M' ES LA QUE TAMBIEN SE ENCUENTRAN EN CADA REGISTRO DE LA TABLA HORARIOS. ENTONCES:
            //ME TRAIGO DE LA BASE DE DATOS LA TABLA HORARIOS, DIVIDIDA EN DOS:
            //UNA TABLA CON LOS HORARIOS QUE PERTENCEN AL TURNO MAÑANA 'M'
            NegocioHorarios nh = new NegocioHorarios();
            DataTable TM = nh.getHorarios('M'); //08.00,09.00,10.00...
            //LOS HORARIOS QUE PERTENECEN AL TURNO TARDE 'T
            DataTable TT = nh.getHorarios('T');

            NegocioDiasMedicos ndm = new NegocioDiasMedicos(); //negocio para hacer el insert en tabla DiasMedicos

            //PARA SABER QUE DIAS TRABAJA EL MEDICO AGARRO LOS ITEMS SELECCIONADOS DEL CHECKBOXLISTDIAS.
            foreach(ListItem diaSeleccionado in cblDias.Items)
            {
                if (diaSeleccionado.Selected) //si el dia fue seleccionado..
                {
                    //me fijo en que 'Horario' trabajara el medico
                    if(med.RangoHorario_M == 'M')
                    {
                        //si eligío el turno mañana...
                        //A este medico, en este diaSeleccionado, le voy a generar todas horas que trabajará
                        foreach(DataRow hora in TM.Rows)
                        {
                            ndm.agregarDiaHoraALegajo(med.Legajo_M, diaSeleccionado.Value,hora["codHorario_h"].ToString());
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

        private void CargarMedico(ref Medico m)
        {
            m.Legajo_M = txtNumeroLegajo.Text;
            m.Dni_m = txtDni.Text;
            m.Nombre_M = txtNombre.Text;
            m.Apellido_M = txtApellido.Text;
            m.Sexo_M = Convert.ToChar(rblSexo.SelectedValue);          
            m.Nacionalidad_M = txtNacionalidad.Text;
            m.FechaNacimiento_M = txtFechaNacimiento.Text;
            m.Direccion_M = txtDireccion.Text;
            m.CodLoc_M = ddlLocalidadades.SelectedValue;
            m.CodProv_M = ddlProvincias.SelectedValue;
            m.CorreoElectronico_M = txtCorreo.Text;
            m.CodEspecialidad_M = ddlEspecialidades.SelectedValue;
            m.RangoHorario_M = Convert.ToChar(rblHorario.SelectedValue);
            m.User_M = txtNombreUser.Text;
            m.Password_M = txtPassUser.Text;
        }
        private void CargarProvincias()
        {
            NegocioProvincias np = new NegocioProvincias();
            ddlProvincias.DataSource = np.getProvincias();
            ddlProvincias.DataValueField = "codProv_P";
            ddlProvincias.DataTextField = "descripcion_P";
            ddlProvincias.DataBind();
        }
        private void CargarEspecialidades()
        {
            NegocioEspecialidades ne = new NegocioEspecialidades();
            ddlEspecialidades.DataSource = ne.getEspecialidades();
            ddlEspecialidades.DataValueField = "codEspecialidad_e";
            ddlEspecialidades.DataTextField = "descripcion_e";
            ddlEspecialidades.DataBind();
        }

        private void CargarDias()
        {
            NegocioDias nd = new NegocioDias();
            cblDias.DataSource = nd.getDias();
            cblDias.DataValueField = "codDia_d";
            cblDias.DataTextField = "descripcion_d";
            cblDias.DataBind();
        }

        
    }
}