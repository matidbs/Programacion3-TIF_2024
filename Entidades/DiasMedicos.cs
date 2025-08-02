using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DiasMedicos
    {
        private int legajo_DM;
        private string codDia_DM;
        private string codHorario_DM;
        private int medicoActivo_DM;

        public DiasMedicos() { }

        public int Legajo_DM { get => legajo_DM; set => legajo_DM = value; }
        public string CodDia_DM { get => codDia_DM; set => codDia_DM = value; }
        public string CodHorario_DM { get => codHorario_DM; set => codHorario_DM = value; }
        public int MedicoActivo_DM { get => medicoActivo_DM; set => medicoActivo_DM = value; }
    }
}
