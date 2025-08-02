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
    public partial class ListarMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrdMedicos();
                cargarDDLHorarios();
            }
            lblNombre.Text = Application["login"].ToString();
            txt_notificacion.Text = "";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Medico m = new Medico();
            NegocioMedicos neg = new NegocioMedicos();
            m.Legajo_M = Convert.ToInt32(txtFiltrar.Text);

            if(neg.existeLegajo(m))
            {
                DataTable dt = neg.filtrarMedicoPorLegajo(m);
                DataRow registroMedico = dt.Rows[0];
                int estadoMedico = Convert.ToInt32(registroMedico[14]);

                if (estadoMedico == 1) grdMedicos.DataSource = dt;
                else
                { 
                    grdMedicos.DataSource = null;
                    txt_notificacion.Text = "El medico se encuentra inactivo";
                }
                    grdMedicos.DataBind();
                
            }
            else txt_notificacion.Text = "El legajo no existe";
            ddlHorarios.SelectedValue = ddlHorarios.Items.FindByValue("---Seleccionar---").ToString();
            txtFiltrar.Text = "";
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarGrdMedicos();
            txtFiltrar.Text = "";
            txtBuscarEspe.Text = "";
            ddlHorarios.SelectedValue = ddlHorarios.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            NegocioMedicos neg = new NegocioMedicos();

            if (ddlHorarios.SelectedValue == "---Seleccionar---") //Pregunto si tiene seleccionado ese value. Si lo tiene, filtro solo por espec
            {
                dt = neg.getMedicosPorEspecialidad(txtBuscarEspe.Text);
            }
            else //Si tiene seleccionado un horario, filtro con Especialidad y horario 
            {
                Medico med = new Medico();
                string horario = ddlHorarios.SelectedValue;
                med.RangoHorario_M = Convert.ToChar(horario);
                dt = neg.getMedicosPorEspecialidadYHorario(med, txtBuscarEspe.Text);
            }
            if (dt.Rows.Count > 0) //Pregunto si la datatable tiene alguna fila 
            {
                grdMedicos.DataSource = dt;

            }
            else //Si no tiene, la cargo null y aviso
            {
                grdMedicos.DataSource = null;
                txt_notificacion.Text = "Sin coincidencias";
            }
            grdMedicos.DataBind();
            txtBuscarEspe.Text = "";
            ddlHorarios.SelectedValue = ddlHorarios.Items.FindByValue("---Seleccionar---").ToString();
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void grdMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedicos.PageIndex = e.NewPageIndex;
            cargarGrdMedicos();
        }
        protected void ddlHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioMedicos nm = new NegocioMedicos();

            if (ddlHorarios.SelectedValue != "---Seleccionar---") //Pregunto si tiene seleccionado algo distinto a ese value
            {
                Medico med = new Medico();
                string horario = ddlHorarios.SelectedValue;
                med.RangoHorario_M = Convert.ToChar(horario);
                DataTable dt = nm.getMedicosPorHorario(med);

                if (dt.Rows.Count > 0) //Pregunto si la dt tiene filas
                {
                    grdMedicos.DataSource = dt;
                }
                else //Si no tiene, notifico y cargo en null la gridview
                {
                    txt_notificacion.Text = "Sin coincidencias";
                    grdMedicos.DataSource = null;
                }
                grdMedicos.DataBind();
            }
            else
            {
                cargarGrdMedicos();
            }
        }
        public void cargarGrdMedicos()
        {
            NegocioMedicos neg = new NegocioMedicos();
            grdMedicos.DataSource = neg.getMedicos();
            grdMedicos.DataBind();
        }

        public void cargarDDLHorarios()
        {
            ddlHorarios.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlHorarios.Items.Add(new ListItem("Mañana", "M"));
            ddlHorarios.Items.Add(new ListItem("Tarde", "T"));
            ddlHorarios.SelectedValue = ddlHorarios.Items.FindByValue("---Seleccionar---").ToString();
        }

        
    }
}