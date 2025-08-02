using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class AccesoDatos
    {        
        string rutaBD = /* Cadena de conexión */;
        public AccesoDatos() { }

        private SqlConnection obtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private SqlDataAdapter obtenerAdaptador(string consulta, SqlConnection conexion)
        {
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(consulta, conexion);
                return da;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public DataTable obtenerTabla(string NombreTabla, string consulta)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = obtenerConexion();
            SqlDataAdapter adp = obtenerAdaptador(consulta, conexion);
            adp.Fill(ds, NombreTabla);
            conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int ejecutarProcedimientoAlmacenado(SqlCommand comandoConParametros, string nombreSP)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand comando = comandoConParametros;

            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            return filas;
        }

        public bool ejecutarProcedimientoAlmacenadoLectura(SqlCommand comandoConParametros, string nombreSP)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand comando = comandoConParametros;

            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            bool existe = false;

            SqlDataReader lector = comando.ExecuteReader();
            if (lector.Read()) existe = true;
            conexion.Close();
            return existe;
        }

        public bool existeRegistro(string consulta)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            bool existe = false;

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read()) existe = true;
            conexion.Close();
            return existe;
        }
        public int EjecutarNonQuery(String consulta, SqlCommand comando = null)
        {
            SqlConnection Conexion = obtenerConexion();
            SqlCommand cmd;

            if (comando == null) cmd = new SqlCommand(consulta, Conexion);
            else
            {
                cmd = comando;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.Connection = Conexion;
            }

            int filasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return filasCambiadas;

        }

    }
}
