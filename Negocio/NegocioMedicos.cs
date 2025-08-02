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
    public class NegocioMedicos
    {
        DaoMedicos dao = new DaoMedicos();

        public DataTable getMedicos()
        {
            return dao.traerMedicos();
        }

        public DataTable getMedicosModificar()
        {
            return dao.traerMedicosModificar();
        }

        public DataTable getMedicoModificarPorLegajo(Medico med)
        {
            return dao.trarMedicoModificar(med);
        }

        public DataTable getMedicosPorEspecialidad(string busqueda)
        {
            return dao.traerMedicosPorEspecialidad(busqueda);
        }

        public DataTable getPerfilMedico(int legajo)
        {
            return dao.traerPerfilMedico(legajo);
        }

        public int GetLegajoMedicoPorDNI(Medico med)
        {
            DataTable registro =  dao.TraerLegajoMedicoPorDNI(med);
            DataRow fila = registro.Rows[0];
            int legajo = Convert.ToInt32(fila[0]);
            return legajo;
        }
        public bool addMedico(Medico med)
        {
            int cantFilas = 0;
            cantFilas = dao.agregarMedico(med);
            if (cantFilas == 1) return true;
            return false;
        }

        public bool updateMedico(Medico m)
        {
            int cantFilas = 0;
            cantFilas = dao.actualizarMedico(m);
            if (cantFilas == 1) return true;
            return false;
        }

        public bool bajaLogica(int legajo)
        {
            int cantFilas = 0;
            cantFilas = dao.bajaLogicaMedico(legajo);
            if (cantFilas == 1) return true;
            return false;
        }
       
        public DataTable filtrarMedicoPorLegajo(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.filtrarMedicoPorLegajo(med);
        }

        public DataTable filtrarMedicoPorUser(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            return dao.filtrarMedicoPorUser(med);
        }

        public bool existeLegajo(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            if (dao.existeLegajo(med)) return true;
            return false;
        }

        public bool existeDNI(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            if (dao.existeDni(med)) return true;
            return false;
        }

        public bool existeUser(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            if (dao.existeUser(med)) return true;
            return false;
        }

        public bool verificarUserYContraseña(Medico med)
        {
            DaoMedicos dao = new DaoMedicos();
            if (dao.verificarUserYContraseña(med)) return true;
            return false;
        }

        public DataTable contarMedicosPorEspecialidad()
        {
            return dao.countMedicosPorEspecialidad();
        }

        public DataTable getMedicosPorHorario(Medico med)
        {
            return dao.filtrarMedicosHorario(med);
        }
        public DataTable getMedicosPorEspecialidadYHorario(Medico med, string especialidad)
        {
            return dao.filtrarMedicoPorEspecialidadYHorario(med, especialidad);
        }
    }
}
