using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincias
    {
        private string codProv_P;
        private string descripcion_P;

        public Provincias() { }

        public string CodProv_P { get => codProv_P; set => codProv_P = value; }
        public string Descripcion_P { get => descripcion_P; set => descripcion_P = value; }
    }
}
