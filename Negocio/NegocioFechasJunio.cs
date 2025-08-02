using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
namespace Negocio
{
    public class NegocioFechasJunio
    {
        public DataTable getFechasJunio()
        {
            DaoFechasJunio dao = new DaoFechasJunio();
            return dao.obtenerTodasLasFechas() ;
        }
    }
}
