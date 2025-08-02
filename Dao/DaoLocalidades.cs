using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoLocalidades
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerTodasLasLocalidades(int codProv)
        {
            DataTable dt = ad.obtenerTabla("Localidades", "select * from Localidades where codProv_L = " + codProv);
            return dt;
        }
    }
}
