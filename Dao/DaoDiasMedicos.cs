using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;
namespace Dao
{
    public class DaoDiasMedicos
    {
        AccesoDatos ad = new AccesoDatos();        
        public int agregarRegistro(int leg,string codDia,string codHora)
        {
            
            String consulta = "insert into DiasMedicos select "+leg+",'"+codDia+"','"+codHora+"',1";            
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public DataTable obtenerTodosLosDiasMedicos()
        {
            DataTable dt = ad.obtenerTabla("DiasMedicos", "select * from DiasMedicos");
            return dt;
        }

        public DataTable getDiasMedico(Medico med)
        {
            string consulta = "SELECT DISTINCT DiasMedicos.codDia_DM AS CodigoDia, Dias.descripcion_d AS Dia FROM DiasMedicos INNER JOIN Dias ON DiasMedicos.codDia_DM = Dias.codDia_d WHERE legajo_DM = " + med.Legajo_M ; 
            DataTable dt = ad.obtenerTabla("DiasMedico", consulta);
            return dt;
        }

        public int bajaLogicaDiasMedicos(int Legajo)
        {
            String consulta = "UPDATE DiasMedicos SET MedicoActivo_DM = 0 WHERE legajo_DM = "+Legajo;
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public int cambiarEstadoAactivoDM(int Legajo)
        {
            String consulta = "UPDATE DiasMedicos SET MedicoActivo_DM = 1 WHERE legajo_DM = " + Legajo ;
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }
    }
}
