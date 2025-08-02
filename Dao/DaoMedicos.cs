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
    public class DaoMedicos
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable traerMedicos()
        {
            DataTable dt = ad.obtenerTabla("Medicos", "select * from TraerMedicos ");
            return dt;
        }

        public DataTable traerMedicosModificar()
        {
            DataTable dt = ad.obtenerTabla("MedicosModificar", "SELECT M.*, E.descripcion_e as Especialidad, 'Estado_Descripcion' = case when Estado_M = 1 then 'Activo' when Estado_M = 0 then 'Inactivo' end, P.descripcion_P as DescripcionProvincia_M, L.descripcion_L as DescripcionLocalidad_M, N.Descripcion_N as DescripcionNacionalidad_M  FROM (((Medicos M inner Join Especialidades E on M.codEspecialidad_M = E.codEspecialidad_e) inner join Provincias P on M.codProv_M = P.codProv_P)  inner join Localidades L on M.codLoc_M = L.codLoc_L)  inner join Nacionalidades N on M.IdNacionalidad_M = N.IdNacionalidad_N");
            return dt;
        }

        public DataTable trarMedicoModificar(Medico med)
        {
            DataTable dt = ad.obtenerTabla("MedicosModificar", "SELECT M.*, E.descripcion_e as Especialidad, 'Estado_Descripcion' = case when Estado_M = 1 then 'Activo' when Estado_M = 0 then 'Inactivo' end, P.descripcion_P as DescripcionProvincia_M, L.descripcion_L as DescripcionLocalidad_M, N.Descripcion_N as DescripcionNacionalidad_M  FROM (((Medicos M inner Join Especialidades E on M.codEspecialidad_M = E.codEspecialidad_e) inner join Provincias P on M.codProv_M = P.codProv_P)  inner join Localidades L on M.codLoc_M = L.codLoc_L)  inner join Nacionalidades N on M.IdNacionalidad_M = N.IdNacionalidad_N WHERE Legajo_M = " + med.Legajo_M);
            return dt;
        }

        public DataTable traerPerfilMedico(int Legajo)
        {
            DataTable dt = ad.obtenerTabla("PerfilMedico", "SELECT * FROM TraerPerfilMedico WHERE legajo_M = "+ Legajo);
            return dt;
        }

        public DataTable traerMedicosPorEspecialidad(string busqueda)
        {
            DataTable dt = ad.obtenerTabla("Medicos", "select * from TraerMedicos where Especialidad like '"+busqueda+"%'");
            return dt;
        }

        public int agregarMedico(Medico m)
        {
            SqlCommand comando = new SqlCommand();
            agregarMedicoParametros(ref comando, m);
            int filasCambiadas = ad.ejecutarProcedimientoAlmacenado(comando, "sp_AgregarMedico");
            return filasCambiadas;
        }

        public int actualizarMedico(Medico m)
        {
            SqlCommand cmd = new SqlCommand();
            agregarMedicoParametros(ref cmd, m, true);
            int filasCambiadas = ad.ejecutarProcedimientoAlmacenado(cmd, "SP_ActualizarMedico");
            return filasCambiadas;
        }

        public int bajaLogicaMedico(int Legajo)
        {
            String consulta = "UPDATE Medicos SET Estado_M = 0 WHERE legajo_M = " + Legajo;
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public DataTable filtrarMedicoPorLegajo(Medico med)
        {
            DataTable dt = ad.obtenerTabla("FiltrarMedico", "SELECT DISTINCT legajo_M AS Legajo, DNI_M as DNI, CONCAT(Nombre_M, ' ', Apellido_M) AS [Nombre completo], Sexo_M AS Sexo, [Fecha Nacimiento_M] AS [Fecha de nacimiento], Direccion_M AS Direccion, Localidades.descripcion_L AS Localidad, Provincias.descripcion_P AS Provincia, CorreoElectronico_M AS Email, Especialidades.descripcion_e AS Especialidad, [Rango Horario_M] AS [Horario], User_M AS Usuario, Password_M AS Contraseña, Nacionalidades.Descripcion_N AS Nacionalidad, Estado_M FROM (Medicos INNER JOIN Provincias	ON Medicos.codProv_M = Provincias.codProv_P) INNER JOIN Localidades ON Medicos.codLoc_M = Localidades.codLoc_L INNER JOIN Especialidades ON Medicos.codEspecialidad_M = Especialidades.codEspecialidad_e INNER JOIN Nacionalidades ON Medicos.IdNacionalidad_M = Nacionalidades.IdNacionalidad_N WHERE legajo_M = " + med.Legajo_M);
            return dt;
        }

        public DataTable TraerLegajoMedicoPorDNI(Medico med)
        {
            DataTable dt = ad.obtenerTabla("FiltrarMedico", "select legajo_M from Medicos where DNI_M = '"+med.Dni_m+"'");
            return dt;
        }
        public DataTable filtrarMedicoPorUser(Medico med)
        {
            DataTable dt = ad.obtenerTabla("FiltrarMedico", "select legajo_M, Nombre_M, Apellido_M from medicos where User_M = '"+med.User_M+"' and Password_M = '"+med.Password_M+"'");
            return dt;
        }

        public bool existeLegajo(Medico med)
        {
            if (ad.existeRegistro("select * from Medicos where legajo_M = " + med.Legajo_M)) return true;
            return false;
        }

        public bool existeDni(Medico med)
        {
            if (ad.existeRegistro("select * from Medicos where DNI_M = '"+med.Dni_m+"'")) return true;
            return false;
        }
        public bool existeUser(Medico med)
        {
            if (ad.existeRegistro("select * from medicos where User_M = '"+med.User_M+"'")) return true;
            return false;
        }
        public bool verificarUserYContraseña(Medico med)
        {
            if (ad.existeRegistro("select * from medicos where User_M = '"+med.User_M+"' and Password_M = '"+med.Password_M+"'")) return true;
            return false;
        }

        public DataTable countMedicosPorEspecialidad()
        {
            DataTable dt = ad.obtenerTabla("CantidadMedicosPorEspecialidad", "Select codEspecialidad_e,descripcion_e,Count(Medicos.codEspecialidad_M) as cantidadMedicosporE From Especialidades  Left Join Medicos on Especialidades.codEspecialidad_e = Medicos.codEspecialidad_M And Medicos.Estado_M = 1 Group by codEspecialidad_e,descripcion_e Order By cantidadMedicosporE desc");
            return dt;
        }

        public DataTable filtrarMedicosHorario(Medico med)
        {
            DataTable dt = ad.obtenerTabla("MedicosPorDia", "select * from TraerMedicos Where Horario = '"+ med.RangoHorario_M + "'");
            return dt;
        }
        public DataTable filtrarMedicoPorEspecialidadYHorario(Medico med, string busqueda)
        {
            DataTable dt = ad.obtenerTabla("MedicosPorEspecialidadYHorario", "select * from TraerMedicos Where Horario = '" + med.RangoHorario_M + "' And Especialidad like '" + busqueda + "%'");
            return dt;
        }

        private void agregarMedicoParametros(ref SqlCommand comando, Medico m, bool modificar=false)
        {
            SqlParameter parametros = new SqlParameter();
            
            if(modificar)
            {
                parametros = comando.Parameters.Add("@Legajo", SqlDbType.Int);
                parametros.Value = m.Legajo_M;
            }

            parametros = comando.Parameters.Add("@Dni", SqlDbType.Char);
            parametros.Value = m.Dni_m;
            parametros = comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            parametros.Value = m.Nombre_M;
            parametros = comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            parametros.Value = m.Apellido_M;
            parametros = comando.Parameters.Add("@sexo", SqlDbType.Char);
            parametros.Value = m.Sexo_M;
            parametros = comando.Parameters.Add("@fechaN", SqlDbType.Char);
            parametros.Value = m.FechaNacimiento_M;           
            parametros = comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
            parametros.Value = m.Direccion_M;
            parametros = comando.Parameters.Add("@codLoc", SqlDbType.Char);
            parametros.Value = m.Localidad.CodLoc_L;
            parametros = comando.Parameters.Add("@codProv", SqlDbType.Char);
            parametros.Value = m.Provincia.CodProv_P;
            parametros = comando.Parameters.Add("@Correo", SqlDbType.VarChar);
            parametros.Value = m.CorreoElectronico_M;
            parametros = comando.Parameters.Add("@CodEspe", SqlDbType.Char);
            parametros.Value = m.Especialidad.CodEspecialidad_e;
            parametros = comando.Parameters.Add("@RangoHorario", SqlDbType.Char);
            parametros.Value = m.RangoHorario_M;
            parametros = comando.Parameters.Add("@Usuario", SqlDbType.VarChar);
            parametros.Value = m.User_M;
            parametros = comando.Parameters.Add("@Contra", SqlDbType.VarChar);
            parametros.Value = m.Password_M;
            parametros = comando.Parameters.Add("@IdNac", SqlDbType.Char);
            parametros.Value = m.Nacionalidad.IdNacionalidad_N1;
            parametros = comando.Parameters.Add("@Estado", SqlDbType.Bit);
            parametros.Value = m.Estado;
        }
    }
}
