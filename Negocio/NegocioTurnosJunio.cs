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
    public class NegocioTurnosJunio
    {
        DaoTurnosJunio dao = new DaoTurnosJunio();
        public DataTable getTurnosJunioGRID(string filtroEspecilidad = "", RegistroTurno turno = null)
        {
            //trae la tabla TurnosJunio completa
            if (filtroEspecilidad == "" && turno == null) return dao.traerTurnosJunioGRID();
            //trae de TunosJunio los medicos que tengan turnos de cierta especialidad 
            if (filtroEspecilidad != "") return dao.traerTurnosJunioGRID(filtroEspecilidad);
            if (turno != null) return dao.traerTurnosJunioGRID("", turno);
            return null;
        }
        public DataTable getTurnosJunioGRIDFiltrado(string codEspe, RegistroTurno turno)
        {
            return dao.traerTurnosJunioGRIDFiltrado(codEspe, turno);
        }


        public bool existeTurno(RegistroTurno turno)
        {
            return dao.existeRegistro(turno);
        }

        public bool agregarTurno(RegistroTurno turno)
        {
            int filas = 0;
            filas = dao.agregarRegistro(turno);

            if (filas == 1) return true;
            return false;
        }

        public bool tomarTurno(RegistroTurno turno)
        {
            int filas = 0;
            filas = dao.tomarTurno(turno);

            if (filas == 1) return true;
            return false;
        }

        public bool AsistenciaPaciente(RegistroTurno turno)
        {
            int filas = 0;
            filas = dao.AsistenciaPacienteTurno(turno);

            if (filas == 1) return true;
            return false;
        }
        public bool bajaLogicaTurnosJunio(int legajo) //baja de un medico!
        {
            int cantFilas = 0;
            cantFilas = dao.bajaLogicaTurnosJunio(legajo);
            if (cantFilas != 0) return true;
            return false;
        }

        public bool bajaLogicaPacienteTurnosJunio(String dniPaciente) //Pone como 'Disponible' aquellos turnos que el paciente tenia asignados pero antes de asistir a ellos se dio de baja en el sistema
        {
            int cantFilas = 0;
            cantFilas = dao.bajaLogicaPacienteTurnosJunio(dniPaciente);
            if (cantFilas != 0) return true;
            return false;
        }
        public bool cambiarEstadoAactivoTJ(int legajo) //esto es por si se modifica el medico
        {
            int cantFilas = 0;
            cantFilas = dao.cambiarEstadoAactivoTJ(legajo);
            if (cantFilas != 0) return true;
            return false;
        }

        public DataTable TurnosPorEspecialidad()
        {
            return dao.TurnosOrganizadosPorEspecialidad();
        }
        public DataTable TurnosPorEspecialidadyFecha(string fecha)
        {
            return dao.TurnosOrganizadosPorEspecialidadyFecha(fecha);
        }

        public DataTable traerTurnosJunioPorLegajo(Medico med)
        {
            return dao.traerTurnosJunioPorLegajo(med);
        }
        public DataTable getTurnosPorDNIyLegajo(Paciente pc, Medico med)
        {
            return dao.traerTurnosPorDNIyLegajo(pc, med);
        }
        public DataTable traerTurnosJunioPorSuNumero(Medico med, RegistroTurno t) //numero de turno
        {
            return dao.traerTurnoPorSuNumero(med, t);
        }

        public DataTable traerTurnosJunioPorDia(Medico med, RegistroTurno t)
        {
            return dao.traerTurnoPorDia(med, t);
        }

        public DataTable traerTurnosJunioNoDisponibles(Medico med)
        {
            return dao.traerTurnosJunioNoDisponibles(med);
        }
        public DataTable traerTurnosJunioNoDisponiblesPorDia(Medico med, RegistroTurno t)
        {
            return dao.traerTurnosJunioNoDisponiblesPorDia(med, t);
        }

        //estos son para informes:
        public DataTable contarTurnosDelMes(Medico med)
        {
            return dao.countTurnosMes(med);
        }

        public DataTable contarAsistenciasDeTurnos()
        {
            return dao.countAsistenciasTurnosMes();
        }




    }

}

