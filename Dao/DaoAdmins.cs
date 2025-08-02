using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoAdmins
    {
        AccesoDatos ad = new AccesoDatos();
        public bool buscarAdministrador(Administrador a)
        {
            SqlCommand comando = new SqlCommand();
            agregarParametrosAdmin(ref comando, a);
            bool res = false; 
            res = ad.ejecutarProcedimientoAlmacenadoLectura(comando, "sp_BuscarAdmin");
            return res;
        }
        private void agregarParametrosAdmin(ref SqlCommand comando, Administrador a)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            parametros.Value = a.Nombre;
            parametros = comando.Parameters.Add("@Contraseña", SqlDbType.VarChar);
            parametros.Value = a.Constraseña;
           
        }
    }
}
