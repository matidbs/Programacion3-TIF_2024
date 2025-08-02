using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
namespace Negocio
{
    public class NegocioHorarios
    {
        public DataTable getHorarios(char turno)
        {
            DaoHorarios dao = new DaoHorarios();
            return dao.obtenerHorarios(turno);
        }
    }
}
