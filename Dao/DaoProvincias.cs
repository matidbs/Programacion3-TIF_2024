using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoProvincias
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerTodasLasProvincias()
        {
            DataTable dt = ad.obtenerTabla("Provincias", "select * from Provincias");
            return dt;
        }
    }
}

