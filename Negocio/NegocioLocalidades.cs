using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioLocalidades
    {
        public DataTable getLocalidades(int codProv)
        {
            DaoLocalidades dao = new DaoLocalidades();
            return dao.obtenerTodasLasLocalidades(codProv);
        }
    }
}
