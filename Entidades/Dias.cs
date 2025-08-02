using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dias
    {
        private char codDia_d;
        private string descripcion_d;

        public Dias() { }

        public char CodDia_d { get => codDia_d; set => codDia_d = value; }
        public string Descripcion_d { get => descripcion_d; set => descripcion_d = value; }
    }
}
