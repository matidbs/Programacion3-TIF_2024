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

namespace Vistas.Med
{
    public partial class VerTurnosMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = Application["login"].ToString();
                cargarGrdVerTurnos();
                cargarDdlFiltrosDia();
            }
            lbl_notificacion.Text = "";
        }

        public void cargarGrdVerTurnos()
        {
            NegocioTurnosJunio neg = new NegocioTurnosJunio();
            string legajo = Application["legajo"].ToString();
            Medico med = new Medico();
            med.Legajo_M = Convert.ToInt32(legajo);
            grdVerTurnos.DataSource = neg.traerTurnosJunioPorLegajo(med);
            grdVerTurnos.DataBind();
        }

        public void cargarDdlFiltrosDia()
        {//Carga el ddl con los dias que trabaja el médico que se encuentra utilizando el sistema
            NegocioDiasMedicos neg = new NegocioDiasMedicos();
            Medico med = new Medico();
            med.Legajo_M = Convert.ToInt32(Application["legajo"]);
            ddlFiltrosDia.DataSource = neg.getDiasMedico(med);
            ddlFiltrosDia.DataTextField = "Dia";
            ddlFiltrosDia.DataValueField = "CodigoDia";
            ddlFiltrosDia.DataBind();
            ddlFiltrosDia.Items.Add(new ListItem("---Seleccionar---", "---Seleccionar---"));
            ddlFiltrosDia.SelectedValue = ddlFiltrosDia.Items.FindByValue("---Seleccionar---").ToString();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Application["legajo"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void grdVerTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVerTurnos.PageIndex = e.NewPageIndex;
            if (ViewState["RegistroFiltrado"] != null)
            {
                grdVerTurnos.DataSource = (DataTable)ViewState["RegistroFiltrado"];
                grdVerTurnos.DataBind();
            }
            else
            {
                cargarGrdVerTurnos();
            }
        }

        protected void grdVerTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdVerTurnos.EditIndex = e.NewEditIndex;
            
            if (ViewState["RegistroFiltrado"] != null)
            {
                grdVerTurnos.DataSource = (DataTable)ViewState["RegistroFiltrado"];
                grdVerTurnos.DataBind();
            }
            else
            {
                cargarGrdVerTurnos();
            }
        }

        protected void grdVerTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdVerTurnos.EditIndex = -1;
            if (ViewState["RegistroFiltrado"] != null)
            {
                grdVerTurnos.DataSource = (DataTable)ViewState["RegistroFiltrado"];
                grdVerTurnos.DataBind();
            }
            else
            {
                cargarGrdVerTurnos();
            }
        }

        protected void grdVerTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if(((Label)grdVerTurnos.Rows[e.RowIndex].FindControl("lbl_it_Disponibilidad")).Text == "Disponible")
            {
                lbl_notificacion.Text = "No se puede editar un turno no asignado. Presione Cancelar";
                e.Cancel = true;
                return;
            }
            int asistio = Convert.ToInt32(((RadioButtonList)grdVerTurnos.Rows[e.RowIndex].FindControl("rbl_eit_Asistio")).SelectedValue);
            string observacion = "Paciente no asistió";
            int nroTurno = Convert.ToInt32(((Label)grdVerTurnos.Rows[e.RowIndex].FindControl("lbl_eit_Turno")).Text);
            if (asistio == 1)
            {
                observacion = ((TextBox)grdVerTurnos.Rows[e.RowIndex].FindControl("txt_eit_Observacion")).Text;
            }

            NegocioTurnosJunio tj = new NegocioTurnosJunio();
            RegistroTurno turno = new RegistroTurno();
            turno.Id_Turno = nroTurno;
            turno.Asistio = asistio;
            turno.Observacion = observacion;
            if (tj.AsistenciaPaciente(turno)) lbl_notificacion.Text = "Registro actualizado con éxito";
            grdVerTurnos.EditIndex = -1;
            if (ViewState["RegistroFiltrado"] != null)
            {
                grdVerTurnos.DataSource = (DataTable)ViewState["RegistroFiltrado"];
                grdVerTurnos.DataBind();
            }

            LimpiarFiltros();
        }

        protected void grdVerTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Radio button marcado con lo que tenga el registro en la BD
                RadioButtonList rblAsistio = (RadioButtonList)e.Row.FindControl("rbl_eit_Asistio");
                TextBox observacion = (TextBox)e.Row.FindControl("txt_eit_Observacion");
                if (rblAsistio != null)
                {
                    if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Disponibilidad")) == 0) //Turno tomado
                    {
                        if (!(DataBinder.Eval(e.Row.DataItem, "Asistio") is DBNull)) //si el campo 'Asistio' no está nulo en la DB es porque algo ya le cargó el medico
                        //traigo lo que el medico cargó en el campo 'Asistio' y se lo mando al RadioButton
                        {
                            rblAsistio.SelectedValue = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Asistio")).ToString();
                        }
                        else
                        {
                            //si el campo 'Asistio' estaba null, le pongo por defecto 'No'
                            rblAsistio.SelectedValue = "0";
                        }

                        observacion.Text = DataBinder.Eval(e.Row.DataItem, "Observacion").ToString();
                    }
                    else //el turno no está tomado. En el RowUpdating no va a permitir la carga.
                    {
                        lbl_notificacion.Text = "No se puede editar un turno no asignado";

                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegocioTurnosJunio neg = new NegocioTurnosJunio();
            Medico med = new Medico();
            RegistroTurno reg = new RegistroTurno();
            med.Legajo_M = Convert.ToInt32(Application["legajo"]);
            reg.Id_Turno = Convert.ToInt32(txtNturno.Text);
            DataTable dt = neg.traerTurnosJunioPorSuNumero(med, reg);
            grdVerTurnos.DataSource = dt;
            grdVerTurnos.DataBind();
            txtNturno.Text = "";
            ViewState["RegistroFiltrado"] = dt; //El ViewState funciona como una session pero a nivel local del formulario
            ddlFiltrosDia.SelectedValue = "---Seleccionar---";
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        protected void ddlFiltrosDia_SelectedIndexChanged(object sender, EventArgs e)
        {   if (ddlFiltrosDia.SelectedValue != "---Seleccionar---")
            {
                string dia = ddlFiltrosDia.SelectedValue.ToString();
                NegocioTurnosJunio neg = new NegocioTurnosJunio();
                Medico med = new Medico();
                RegistroTurno reg = new RegistroTurno();
                med.Legajo_M = Convert.ToInt32(Application["legajo"]);
                reg.CodDia = dia;
                DataTable dt = neg.traerTurnosJunioPorDia(med, reg);
                grdVerTurnos.DataSource = dt;
                grdVerTurnos.DataBind();
                ViewState["RegistroFiltrado"] = dt;
            }
            else
            {   //La opción ---Seleccionar--- por defecto volvería a cargar el gridview
                cargarGrdVerTurnos();
            }
        }

        public void LimpiarFiltros()
        {
            ViewState["RegistroFiltrado"] = null;
            cargarGrdVerTurnos();
            ddlFiltrosDia.SelectedValue = "---Seleccionar---";
            txtNturno.Text = "";
        }

        protected void lb_it_dniPac_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "verDatos")
            {
                string dni = e.CommandArgument.ToString();
                Application["dni"] = dni;
                Response.Redirect("~/Med/MostrarDatosPaciente.aspx");
            }
        }

        protected void btnVerTurnosActivos_Click(object sender, EventArgs e)
        {
            NegocioTurnosJunio neg = new NegocioTurnosJunio();
            Medico med = new Medico();
            DataTable dt = new DataTable();
            med.Legajo_M = Convert.ToInt32(Application["legajo"]);
            if (ddlFiltrosDia.SelectedValue == "---Seleccionar---") //NO tiene ningún día seleccionado la DDL 
            {
                dt = neg.traerTurnosJunioNoDisponibles(med);
                grdVerTurnos.DataSource = dt;
                grdVerTurnos.DataBind();
            } else //SI tiene seleccionado un día la DDL
            {
                RegistroTurno t = new RegistroTurno();
                string dia = ddlFiltrosDia.SelectedValue.ToString();
                t.CodDia = dia;
                dt = neg.traerTurnosJunioNoDisponiblesPorDia(med, t);
                grdVerTurnos.DataSource = dt;
                grdVerTurnos.DataBind();
            }
                ViewState["RegistroFiltrado"] = dt;

        }
    }

}