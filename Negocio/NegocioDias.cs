using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioDias
    {
        public DataTable getDias()
        {
            DaoDias dao = new DaoDias();
            return dao.obtenerTodosLosDias();
        }
    }
}
