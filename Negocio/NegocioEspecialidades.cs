using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
namespace Negocio
{
    public class NegocioEspecialidades
    {
        public DataTable getEspecialidades()
        {
            DaoEspecialidades dao = new DaoEspecialidades();
            return dao.obtenerTodasLasEspecialidades();
        }

        public DataTable getEspecialidad(string descripcionE)
        {
            DaoEspecialidades dao = new DaoEspecialidades();
            return dao.obtenerEspecialidad(descripcionE);
        }

    }
}
