using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string Dni_Pac;
        private string nombre_Pac;
        private string apellido_Pac;
        private char sexo_Pac;
        private string fechaNacimiento_Pac;
        private string direccion_Pac;
        private string correoElectronico_Pac;
        private int estado_Pac;
        public string telefono_Pac;
        public Paciente() { }
        public Nacionalidades Nacionalidad { get; set; }

        public Provincias Provincia { get; set; }

        public Localidades Localidad { get; set; }
        public string Telefono_Pac
        {
            get { return telefono_Pac; }
            set { telefono_Pac = value; }
        }
        public string DNI_Pac
        {
            get { return Dni_Pac; }
            set { Dni_Pac = value; }
        }

        public string Nombre_Pac
        {
            get { return nombre_Pac; }
            set { nombre_Pac = value; }
        }

        public string Apellido_Pac
        {
            get { return apellido_Pac; }
            set { apellido_Pac = value; }
        }

        public char Sexo_Pac
        {
            get { return sexo_Pac; }
            set { sexo_Pac = value; }
        }
        public string FechaNacimiento_Pac
        {
            get { return fechaNacimiento_Pac; }
            set { fechaNacimiento_Pac = value; }
        }
        public string Direccion_Pac
        {
            get { return direccion_Pac; }
            set { direccion_Pac = value; }
        }

        public string CorreoElectronico_Pac
        {
            get { return correoElectronico_Pac; }
            set { correoElectronico_Pac = value; }
        }
      
        public int Estado_Pac
        {
            get { return estado_Pac; }
            set { estado_Pac = value; }
        }
    }
}
