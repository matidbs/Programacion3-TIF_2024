using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador
    {
        public Administrador() { }
        private string nombre;
        private string contraseña;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Constraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

    }
}
