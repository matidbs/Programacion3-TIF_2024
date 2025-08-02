using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioNacionalidades
    {
        DaoNacionalidades dao = new DaoNacionalidades();

        public DataTable getNacionalidades()
        { 

            return dao.obtenerTodasNacionalidades();
        }

    }
}
