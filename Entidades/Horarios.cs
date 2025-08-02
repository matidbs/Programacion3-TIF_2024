using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horarios
    {
        private char codHorario_H;
        private string descripcion_H;

        public Horarios() { }

        public char CodHorario_H { get => codHorario_H; set => codHorario_H = value; }
        public string Descripcion_H { get => descripcion_H; set => descripcion_H = value; }
    }
}
