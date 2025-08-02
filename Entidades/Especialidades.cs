using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidades
    {
        private string codEspecialidad_e;
        private string descripcion_e;

        public Especialidades() { }

        public string CodEspecialidad_e { get => codEspecialidad_e; set => codEspecialidad_e = value; }
        public string Descripcion_e { get => descripcion_e; set => descripcion_e = value; }
    }
}
