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
    public class NegocioDiasMedicos
    {
        DaoDiasMedicos dao = new DaoDiasMedicos();
        public bool agregarDiaHoraALegajo(int leg, string codDia, string codHora)
        {
            int cantFilas = 0;

                cantFilas = dao.agregarRegistro(leg, codDia, codHora);
            

            if (cantFilas == 1) return true;
            else return false;
        }

        public DataTable getTodosLosDiasMedicos() //trae todos los registros
        {
            DataTable dt = dao.obtenerTodosLosDiasMedicos();
            return dt;
        }

        public DataTable getDiasMedico(Medico med) //trae los dias que trabja un medico
        {
            DataTable dt = dao.getDiasMedico(med);
            return dt;
        }

        public bool bajaLogicaDiasMedicos(int legajo)
        {
            int cantFilas = 0;
            cantFilas = dao.bajaLogicaDiasMedicos(legajo);
            if (cantFilas != 0) return true;
            return false;
        }

        public bool cambiarEstadoAactivoDM(int legajo)
        {
            int cantFilas = 0;
            cantFilas = dao.cambiarEstadoAactivoDM(legajo);
            if (cantFilas != 0) return true;
            return false;
        }

    }
}
