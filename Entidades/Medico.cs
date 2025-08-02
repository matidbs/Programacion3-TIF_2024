using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        public Medico() { }
        private int legajo_M;
        private string DNI_M;
        private string nombre_M;
        private string apellido_M;
        private char sexo_M;
       // private string nacionalidad_M;
        private string fechaNacimiento_M;
        private string direccion_M;
       // private string codLoc_M;
       // private string codProv_M;
        private string correoElectronico_M;
        //private string codEspecialidad_M;
        private char rangoHorario_M;
        private string user_M;
        private string password_M;
        private int estado;

        public Especialidades Especialidad { get; set; }

        public Nacionalidades Nacionalidad { get; set; }

        public Provincias Provincia { get; set; }

        public Localidades Localidad { get; set; }


        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public int Legajo_M
        {
            get { return legajo_M; }
            set { legajo_M = value; }
        }
        public string Dni_m
        {
            get { return DNI_M; }
            set { DNI_M = value; }
        }
        public string Nombre_M
        {
            get { return nombre_M; }
            set { nombre_M = value; }
        }
        public string Apellido_M
        {
            get { return apellido_M; }
            set { apellido_M = value; }
        }
        public char Sexo_M
        {
            get { return sexo_M; }
            set { sexo_M = value; }
        }

        /*public string Nacionalidad_M
        {
            get { return nacionalidad_M; }
            set { nacionalidad_M = value; }
        }*/

        public string FechaNacimiento_M
        {
            get { return fechaNacimiento_M; }
            set { fechaNacimiento_M = value; }
        }

        public string Direccion_M
        {
            get { return direccion_M; }
            set { direccion_M = value; }
        }

        /*public string CodLoc_M
        {
            get { return codLoc_M; }
            set { codLoc_M = value; }
        }*/

        /*public string CodProv_M
        {
            get { return codProv_M; }
            set { codProv_M = value; }
        }*/

        public string CorreoElectronico_M
        {
            get { return correoElectronico_M; }
            set { correoElectronico_M = value; }
        }

        /*public string CodEspecialidad_M
        {
            get { return codEspecialidad_M; }
            set { codEspecialidad_M = value; }
        }*/

        public char RangoHorario_M
        {
            get { return rangoHorario_M; }
            set { rangoHorario_M = value; }
        }

        public string User_M
        {
            get { return user_M; }
            set { user_M = value; }
        }

        public string Password_M
        {
            get { return password_M; }
            set { password_M = value; }
        }
        
    }
}
