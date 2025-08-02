using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
using Entidades;

namespace Negocio
{
    public class NegocioAdmins
    {
        public bool searchAdmin(Administrador a)
        {
            DaoAdmins dao = new DaoAdmins();
            bool res = false;
            res = dao.buscarAdministrador(a);
            return res;
        }
    }
}
