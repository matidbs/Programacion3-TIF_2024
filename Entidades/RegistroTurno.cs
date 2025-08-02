using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegistroTurno
    {
        public RegistroTurno() { }
        private int id_turno;
        private int legajo;
        private string codDia;
        private string codHorario;
        private string codFecha;
        private string dni_paciente;
        private int disponibilidad;
        private int asistio;
        private string observacion;
        private int medicoActivo;

        public int Id_Turno
        {
            get { return id_turno; }
            set { id_turno = value; }
        }
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        public string CodDia
        {
            get { return codDia; }
            set { codDia = value; }
        }
        public string CodHorario
        {
            get { return codHorario; }
            set { codHorario = value; }
        }
        public string CodFecha
        {
            get { return codFecha; }
            set { codFecha = value; }
        }

        public string Dni_paciente
        {
            get { return dni_paciente; }
            set { dni_paciente = value; }
        }
        public int Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
        public int Asistio
        {
            get { return asistio; }
            set { asistio = value; }
        }
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        public int MedicoActivo
        {
            get { return medicoActivo; }
            set { medicoActivo = value; }
        }







    }
}
