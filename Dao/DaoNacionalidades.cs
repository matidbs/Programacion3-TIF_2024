using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoNacionalidades
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerTodasNacionalidades()
        {
            DataTable dt = ad.obtenerTabla("Nacionalidades", "select * from Nacionalidades");
            return dt;
        }

    }
}
