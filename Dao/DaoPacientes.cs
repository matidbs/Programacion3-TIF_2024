using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoPacientes
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable traerPacientes()
        {
            DataTable dt = ad.obtenerTabla("Pacientes", "SELECT * FROM  TraerPacientes");
            return dt;
        }

        public DataTable traerPacientesFiltradosPorEdad(string edad)
        {
            DataTable dt = ad.obtenerTabla("Pacientes", "SELECT * FROM TraerPacientes WHERE DATEDIFF(YEAR, CONVERT(datetime, [Fecha de Nacimiento], 105), GETDATE()) >= '" + edad + "'" );
            return dt;
        }

        public bool existeEdad(string edad)
        {
            if (ad.existeRegistro("SELECT * FROM TraerPacientes WHERE DATEDIFF(YEAR, CONVERT(datetime, [Fecha de Nacimiento], 105), GETDATE()) >= '" + edad + "'")) return true;
            return false;
        }

        public DataTable traerPacientesFiltradosPorNombreCompleto(string filtro)
        {
            DataTable dt = ad.obtenerTabla("Pacientes", "SELECT * FROM  TraerPacientes where [Nombre Completo] like '%"+ filtro + "%'");
            return dt;
        }

        public int agregarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            agregarPacienteParametros(ref comando, pac);
            int filasCambiadas = ad.ejecutarProcedimientoAlmacenado(comando, "sp_AgregarPaciente");
            return filasCambiadas;
        }

        public DataTable traerPacientePorDNI(Paciente pac)
        {
            DataTable dt = ad.obtenerTabla("FiltarPaciente", "SELECT DNI_Pac AS DNI, CONCAT(Nombre_Pac,' ' ,Apellido_Pac) AS [Nombre Completo], Sexo_Pac AS Sexo, [Fecha Nacimiento_Pac] AS [Fecha de nacimiento], Direccion_Pac AS Direccion, Localidades.descripcion_L AS Localidad, Provincias.descripcion_P AS Provincia, Nacionalidades.Descripcion_N AS Nacionalidad,CorreoElectronico_Pac AS [Correo Electronico], Telefono_Pac AS Telefono, Estado_Pac FROM Pacientes INNER JOIN Provincias ON CodProv_Pac = codProv_P INNER JOIN Localidades ON CodLoc_Pac = codLoc_L INNER JOIN Nacionalidades ON IdNacionalidad_Pac = IdNacionalidad_N WHERE DNI_Pac = " + pac.DNI_Pac);
            return dt;
        }

        public bool existeDNI(Paciente pac)
        {
            if (ad.existeRegistro("select * from Pacientes where DNI_Pac = '" + pac.DNI_Pac + "'")) return true;
            return false;
        }

        public int bajaLogicaPaciente(Paciente pac)
        {
            String consulta = "UPDATE Pacientes SET Estado_Pac = 0 WHERE DNI_Pac = '" + pac.DNI_Pac + "'";
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public DataTable traerPacientesModificar()
        {
            DataTable dt = ad.obtenerTabla("ModificarPacientes", "Select * From TraerPacientesModificar");
            return dt;
        }
        public DataTable traerPacientePorDNIModificar(Paciente pc)
        {
            DataTable dt = ad.obtenerTabla("ModificarPacientes", "select * from TraerPacientesModificar where DNI_Pac = '"+pc.DNI_Pac+"'");
            return dt;
        }

        public int actualizarPaciente(Paciente pc)
        {
            SqlCommand cmd = new SqlCommand();
            agregarPacienteParametros(ref cmd, pc);
            int filasCambiadas = ad.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarPaciente");
            return filasCambiadas;
        }

        public DataTable traerPacientesPorSexo(Paciente pac)
        {
            DataTable dt = ad.obtenerTabla("PacientesPorSexo", "Select * From TraerPacientes WHERE Sexo = '" + pac.Sexo_Pac + "'");
            return dt;
        }

        private void agregarPacienteParametros(ref SqlCommand comando, Paciente pac)
        {
            SqlParameter parametros = new SqlParameter();          
            parametros = comando.Parameters.Add("@Dni", SqlDbType.Char);
            parametros.Value = pac.DNI_Pac;
            parametros = comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            parametros.Value = pac.Nombre_Pac;
            parametros = comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            parametros.Value = pac.Apellido_Pac;
            parametros = comando.Parameters.Add("@fechaN", SqlDbType.Char);
            parametros.Value = pac.FechaNacimiento_Pac;
            parametros = comando.Parameters.Add("@sexo", SqlDbType.Char);
            parametros.Value = pac.Sexo_Pac;
            parametros = comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
            parametros.Value = pac.Direccion_Pac;
            parametros = comando.Parameters.Add("@codLoc", SqlDbType.Char);
            parametros.Value = pac.Localidad.CodLoc_L;
            parametros = comando.Parameters.Add("@codProv", SqlDbType.Char);
            parametros.Value = pac.Provincia.CodProv_P;
            parametros = comando.Parameters.Add("@IdNac", SqlDbType.Char);
            parametros.Value = pac.Nacionalidad.IdNacionalidad_N1;
            parametros = comando.Parameters.Add("@Correo", SqlDbType.VarChar);
            parametros.Value = pac.CorreoElectronico_Pac;
            parametros = comando.Parameters.Add("@Telefono", SqlDbType.VarChar);
            parametros.Value = pac.Telefono_Pac;
            parametros = comando.Parameters.Add("@Estado", SqlDbType.Bit);
            parametros.Value = pac.Estado_Pac;
        }

    }
}
