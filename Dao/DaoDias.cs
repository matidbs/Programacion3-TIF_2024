using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoDias
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerTodosLosDias()
        {
            DataTable dt = ad.obtenerTabla("Dias", "select * from Dias");
            return dt;
        }
    }
}
