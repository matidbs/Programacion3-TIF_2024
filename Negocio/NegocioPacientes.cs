using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioPacientes
    {
        DaoPacientes dao = new DaoPacientes();

        public DataTable getPacientes()
        {
            return dao.traerPacientes();
        }

        public DataTable getPacientesPorSuEdad(string edad)
        {
            return dao.traerPacientesFiltradosPorEdad(edad);
        }

        public bool existeEdad(string edad)
        {
            DaoPacientes dao = new DaoPacientes();
            if (dao.existeEdad(edad)) return true;
            return false;
        }

        public DataTable getPaciente(Paciente pac)
        {
            return dao.traerPacientePorDNI(pac);
        }

        public DataTable getPacientesFiltrados(string filtro)
        {
            return dao.traerPacientesFiltradosPorNombreCompleto(filtro);
        }
        public DataTable getPacientesModificar()
        {
            return dao.traerPacientesModificar();
        }
        public DataTable getPacienteModificar(Paciente pac)
        {
            return dao.traerPacientePorDNIModificar(pac);
        }

        public bool addPaciente(Paciente pac)
        {
            int cantFilas = 0;
            cantFilas = dao.agregarPaciente(pac);
            if (cantFilas == 1) return true;
            return false;
        }
        
        public bool updatePaciente(Paciente pc)
        {
            int cantFilas = 0;
            cantFilas = dao.actualizarPaciente(pc);
            if (cantFilas == 1) return true;
            return false;
        }
        public bool bajaLogicaPaciente(Paciente pac)
        {
            int cantFilas = 0;
            cantFilas = dao.bajaLogicaPaciente(pac);
            if (cantFilas == 1) return true;
            return false;
        }
        public bool existeDNI(Paciente pac)
        {
            DaoPacientes dao = new DaoPacientes();
            if (dao.existeDNI(pac)) return true;
            return false;
        }

        public DataTable getPacientesPorSexo(Paciente pac)
        {
            return dao.traerPacientesPorSexo(pac);
        }

       

        

    }
}
