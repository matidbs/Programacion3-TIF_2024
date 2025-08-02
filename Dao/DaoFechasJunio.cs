using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoFechasJunio
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerTodasLasFechas()
        {
            DataTable dt = ad.obtenerTabla("FechasJunio", "select * from FechasJunio");
            return dt;
        }
    }
}
