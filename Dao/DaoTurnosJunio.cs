using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoTurnosJunio
    {
        AccesoDatos ad = new AccesoDatos();
        public DataTable traerTurnosJunioGRID(string filtroEspecilidad = "", RegistroTurno turno = null)
        {
            string consulta = "";
            if (filtroEspecilidad == "" && turno == null) //trae toda la tabla sin filtro
            {
                consulta = "select Id_turno,Legajo_TJ,(M.Apellido_M+', '+ M.Nombre_M) as NombreCompleto,m.codEspecialidad_M as Especialidad ,CodDia_TJ,Dias.descripcion_d as Dias ,CodHorario_TJ ,CodFecha_TJ  from(TurnosJunio T inner Join Medicos M on T.Legajo_TJ = M.legajo_M) inner join Dias on T.CodDia_TJ = Dias.codDia_d  where Disponibilidad_TJ = 1 and MedicoActivo_TJ = 1 ORDER BY CodFecha_TJ";

            }
            if (filtroEspecilidad != "" && turno == null)  //trae de la tabla los turnos con la especialidad seleccionada        
            {
                consulta = "select distinct Legajo_TJ,(M.Apellido_M+', '+ M.Nombre_M) as NombreCompleto,m.codEspecialidad_M as Especialidad from(TurnosJunio T inner Join Medicos M on T.Legajo_TJ = M.legajo_M) where Disponibilidad_TJ = 1 and MedicoActivo_TJ = 1 and m.codEspecialidad_M = '" + filtroEspecilidad + "'";
            }
            if (turno != null)
            {
                if (turno.CodDia != null) //trae de la tabla los horarios de ese dia que trabaja el medico
                {
                    consulta = "select distinct CodHorario_TJ from TurnosJunio T inner Join  Dias on T.CodDia_TJ = Dias.codDia_d  where Disponibilidad_TJ = 1 and MedicoActivo_TJ = 1 and  CodDia_TJ = '" + turno.CodDia + "' and Legajo_TJ = " + turno.Legajo ;
                }
                else//trae de la tabla los dias que trabaja el medico seleccionado
                {
                    consulta = "select distinct CodDia_TJ,Dias.descripcion_d as Dias   from TurnosJunio T inner join Dias  on T.CodDia_TJ = Dias.codDia_d  where Disponibilidad_TJ = 1 and MedicoActivo_TJ = 1 and Legajo_TJ = " + turno.Legajo;
                }
                
            }

            return ad.obtenerTabla("TurnosJunio", consulta);
        }

        public DataTable traerTurnosJunioGRIDFiltrado(string codEspe, RegistroTurno turno) //trae todos los turnos de un medico filtrado por dia y hora
        {
            string consulta = "select Id_turno,Legajo_TJ,(M.Apellido_M+', '+ M.Nombre_M) as NombreCompleto,m.codEspecialidad_M as Especialidad ,CodDia_TJ,Dias.descripcion_d as Dias ,CodHorario_TJ ,CodFecha_TJ  from(TurnosJunio T inner Join Medicos M on T.Legajo_TJ = M.legajo_M) inner join Dias on T.CodDia_TJ = Dias.codDia_d  where Disponibilidad_TJ = 1 and MedicoActivo_TJ = 1  and m.codEspecialidad_M = '" + codEspe + "' and Legajo_TJ = " + turno.Legajo + " and codDia_TJ = '" + turno.CodDia + "' and CodHorario_TJ = '" + turno.CodHorario + "' ORDER BY CodFecha_TJ";
            return ad.obtenerTabla("TurnosJunioFiltrado", consulta);
        }
        public bool existeRegistro(RegistroTurno turno)
        {
            return ad.existeRegistro("select * from TurnosJunio where Legajo_TJ = " + turno.Legajo + " and CodDia_TJ = '" + turno.CodDia + "' and CodHorario_TJ = '" + turno.CodHorario + "' and CodFecha_TJ = '" + turno.CodFecha + "'");
        }

        public int agregarRegistro(RegistroTurno turno)
        {
            int filasAfectadas = 0;
            filasAfectadas = ad.EjecutarNonQuery("insert into TurnosJunio (Legajo_TJ,CodDia_TJ,CodHorario_TJ,CodFecha_TJ) select " + turno.Legajo + ",'" + turno.CodDia + "', '" + turno.CodHorario + "','" + turno.CodFecha + "'");
            return filasAfectadas;
        }
        public int tomarTurno(RegistroTurno turno)
        {
            int filasAfectadas = 0;
            filasAfectadas = ad.EjecutarNonQuery("update TurnosJunio set Disponibilidad_TJ = 0 , DNI_TJ = '"+turno.Dni_paciente+"' where Id_turno =" + turno.Id_Turno);
            return filasAfectadas;
        }

        public int AsistenciaPacienteTurno(RegistroTurno turno)
        {
            int filasAfectadas = 0;
            filasAfectadas = ad.EjecutarNonQuery("update TurnosJunio  set Asistío_TJ = "+turno.Asistio+", Observacion_TJ = '"+turno.Observacion+"' where Id_turno = " + turno.Id_Turno);
            return filasAfectadas;
        }


        public int bajaLogicaTurnosJunio(int Legajo)//cuando un medico es dado de baja, tambien se dan de baja sus turnos
        {
            String consulta = "UPDATE TurnosJunio SET MedicoActivo_TJ = 0 WHERE legajo_TJ = " + Legajo ;
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public int bajaLogicaPacienteTurnosJunio(String dniPaciente) //actualiza como 'Disponible' aquellos turnos que el paciente tenia asignados pero antes de asistir a estos, se dío de baja 
        {
            String consulta = "update TurnosJunio set Disponibilidad_TJ = 1, DNI_TJ = null where DNI_TJ = '"+dniPaciente+"' and Asistío_TJ is null";
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }
        public int cambiarEstadoAactivoTJ(int Legajo)//cuando el medico se vuelve a activar, tambien se activan sus turnos
        {
            String consulta = "UPDATE TurnosJunio SET MedicoActivo_TJ = 1 WHERE legajo_TJ = " + Legajo ;
            int filasCambiadas = ad.EjecutarNonQuery(consulta);
            return filasCambiadas;
        }

        public DataTable TurnosOrganizadosPorEspecialidad()
        {
            string consulta = "select E.descripcion_e as Especialidad,count(Id_turno) [Turnos Totales] , count(case Disponibilidad_TJ when '0' then 1 else null end) [Turnos Asignados] from (TurnosJunio T right join Medicos M  on T.Legajo_TJ = M.legajo_M) right join Especialidades E  on M.codEspecialidad_M = E.codEspecialidad_e group by E.descripcion_e";
            return ad.obtenerTabla("TurnosJunio", consulta);
        }
        public DataTable TurnosOrganizadosPorEspecialidadyFecha(string fecha) //trae todos los turnos en total de cada especialidad filtrados por fecha
        {
            string consulta = "select E.descripcion_e as Especialidad,count(Id_turno) [Turnos Totales] , count(case Disponibilidad_TJ when '0' then 1 else null end) [Turnos Asignados] from (TurnosJunio T right join Medicos M  on T.Legajo_TJ = M.legajo_M) right join Especialidades E  on M.codEspecialidad_M = E.codEspecialidad_e where T.CodFecha_TJ = '" + fecha + "' group by E.descripcion_e";
            return ad.obtenerTabla("TurnosJunio", consulta);
        }

        public DataTable traerTurnosJunioPorLegajo(Medico med)
        {
            string consulta = "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + "ORDER BY Fecha";
            return ad.obtenerTabla("TurnosJunioPorLegajo", consulta);
        }

        public DataTable traerTurnoPorSuNumero(Medico med, RegistroTurno t)
        { 
            string consulta = "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + "AND Id_turno = " + t.Id_Turno + "ORDER BY Fecha";
            return ad.obtenerTabla("TurnosJunioPorSuNumero", consulta);
        }

        public DataTable traerTurnoPorDia(Medico med, RegistroTurno t)
        {
            string consulta = "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + "AND CodDia_TJ = " + t.CodDia + "ORDER BY Fecha";
            return ad.obtenerTabla("TurnosJunioPorDia", consulta);
        }

        public DataTable traerTurnosJunioNoDisponibles(Medico med)
        {
            string consulta = "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + "AND Disponibilidad_TJ = 0";
            return ad.obtenerTabla("TurnosJunioNoDisponibles", consulta);
        }

        public DataTable traerTurnosJunioNoDisponiblesPorDia(Medico med, RegistroTurno t)
        {
            string consulta = "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + " AND Disponibilidad_TJ = 0 and CodDia_TJ = " + t.CodDia + " Order By Fecha";
            return ad.obtenerTabla("TurnosJunioNoDisponiblesPorDia", consulta);
        }
        public DataTable traerTurnosPorDNIyLegajo(Paciente pc, Medico med)
        {
            return ad.obtenerTabla("TurnosPaciente", "SELECT Id_turno AS Turno, Legajo_TJ AS Legajo, Dias.descripcion_d AS Dia, Horarios.codHorario_h AS Horario, FechasJunio.codFecha_f AS Fecha, DNI_TJ AS DNI_Pac, Disponibilidad_TJ AS Disponibilidad, Asistío_TJ AS Asistio, Observacion_TJ AS Observacion, MedicoActivo_TJ AS MedicoActivo, 'Disponibilidad_Descripcion' = case when Disponibilidad_TJ = 1 then 'Disponible' when Disponibilidad_TJ = 0 then 'No disponible' end, 'Asistio_Descripcion' = case when Asistío_TJ = 1 then 'Asistió' when Asistío_TJ = 0  then 'No asistió' end FROM TurnosJunio INNER JOIN Dias ON TurnosJunio.CodDia_TJ = Dias.codDia_d INNER JOIN Horarios ON TurnosJunio.CodHorario_TJ = Horarios.codHorario_h INNER JOIN FechasJunio ON TurnosJunio.CodFecha_TJ = FechasJunio.codFecha_f Where Legajo_TJ = " + med.Legajo_M + " and DNI_TJ = " + pc.DNI_Pac + " ORDER BY Fecha");
        }


        //esto es para informes
        public DataTable countTurnosMes(Medico med)
        {
            return ad.obtenerTabla("TurnosMes","SELECT COUNT(Id_turno) AS Cantidad FROM TurnosJunio INNER JOIN Medicos ON Legajo_TJ = Legajo_M WHERE Legajo_TJ = " + med.Legajo_M + " AND Disponibilidad_TJ = 0");
        }

        public DataTable countAsistenciasTurnosMes()
        {
            return ad.obtenerTabla("TurnosMes", "Declare @Total float,  @Asistidos int, @NoAsistidos int  Select @Total = count(Id_turno) from TurnosJunio IF (@Total = 0) Select @Total = 1 Select @Total as [Turnos Totales],count(case Asistío_TJ when '1' then 1 else null end) as Asistidos, ROUND(CAST(count(case Asistío_TJ when '1' then 1 else null end)*100 AS float) / @Total,2) as Porcentaje, count(case Asistío_TJ when '0' then 1 else null end) as [No Asistidos],ROUND(CAST(count(case Asistío_TJ when '0' then 1 else null end)*100 AS float) / @Total,2) as Porcentaje from TurnosJunio");
            //return ad.obtenerTabla("TurnosMes", "Declare @Total float,  @Asistidos int, @NoAsistidos int If (Select count(Asistío_TJ) from TurnosJunio) != 0 Select @Total = count(Asistío_TJ) from TurnosJunio where Asistío_TJ is not NULL  else Select @Total = 1 Select @Total as [Turnos Totales],count(case Asistío_TJ when '1' then 1 else null end) as Asistidos, ROUND(CAST(count(case Asistío_TJ when '1' then 1 else null end)*100 AS float) / @Total,2) as Porcentaje, count(case Asistío_TJ when '0' then 1 else null end) as [No Asistidos],ROUND(CAST(count(case Asistío_TJ when '0' then 1 else null end)*100 AS float) / @Total,2) as Porcentaje from TurnosJunio");
        }


    }
}
