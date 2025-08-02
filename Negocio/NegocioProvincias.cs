using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioProvincias
    {
        public DataTable getProvincias()
        {
            DaoProvincias dao = new DaoProvincias();
            return dao.obtenerTodasLasProvincias();
        }
    }
}
