using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dao
{
    public class DaoHorarios
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable obtenerHorarios(char turno)
        {
            DataTable dt = ad.obtenerTabla("Horarios", "select * from Horarios where descripcion_h = '"+turno+"'");
            return dt;
        }
    }
}
