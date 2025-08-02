using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas.Admin
{
    public partial class PortalAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
          
                lblNombre.Text = Application["login"].ToString();
                lbl_turnosActualizados.Text = "";
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application["login"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void btn_generarAgenda_Click(object sender, EventArgs e)
        {
            NegocioDiasMedicos dm = new NegocioDiasMedicos();
            NegocioFechasJunio fj = new NegocioFechasJunio();
            NegocioTurnosJunio tj = new NegocioTurnosJunio();

            DataTable tablaDiasMedico = dm.getTodosLosDiasMedicos(); //traigo tabla DiasMedicos
            DataTable tablaFechasJunio = fj.getFechasJunio(); //traigo tabla FechasJunio
            

            foreach (DataRow registro in tablaDiasMedico.Rows) //Por cada registro de la tabla DiasMedicos, recorro toda la tabla FechasJunio
            {
                DiasMedicos regDM = new DiasMedicos();
                regDM.Legajo_DM = Convert.ToInt32(registro["legajo_DM"]);
                regDM.CodDia_DM = registro["codDia_DM"].ToString();
                regDM.CodHorario_DM = registro["codHorario_DM"].ToString();

                foreach (DataRow fecha in tablaFechasJunio.Rows)
                {
                    FechasJunio regFJ = new FechasJunio();
                    regFJ.CodFecha_F = fecha["codFecha_f"].ToString();
                    regFJ.CodDia_F = fecha["codDia_f"].ToString();

                    if (regDM.CodDia_DM == regFJ.CodDia_F) //Si los codigos de dia coinciden, se genera el turno;
                    {
                        RegistroTurno nuevoTurno = new RegistroTurno();
                        nuevoTurno.Legajo = regDM.Legajo_DM;
                        nuevoTurno.CodDia = regDM.CodDia_DM;
                        nuevoTurno.CodHorario = regDM.CodHorario_DM;
                        nuevoTurno.CodFecha = regFJ.CodFecha_F;

                        //verifico que este medico no tenga ese turno generado en la tabla turnosJunio, de lo contrario se duplicaria.
                        //esto sirve para que solo agregué los turnos de los medicos nuevos. No vuelve a cargar los que ya tienen los turnos generados!!
                        if (!(tj.existeTurno(nuevoTurno))) 
                        {
                            tj.agregarTurno(nuevoTurno);
                        }
                    }
                }
            }

            lbl_turnosActualizados.Text = "Turnos Actualizados con exito";
        }

        
    }
}