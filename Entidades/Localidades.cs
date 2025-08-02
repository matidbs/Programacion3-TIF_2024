using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidades
    {
        private string codLoc_L;
        private string descripcion_L;
        private string codProv_L;

        public Localidades() { }

        public string CodLoc_L { get => codLoc_L; set => codLoc_L = value; }
        public string Descripcion_L { get => descripcion_L; set => descripcion_L = value; }
        public string CodProv_L { get => codProv_L; set => codProv_L = value; }
    }
}
