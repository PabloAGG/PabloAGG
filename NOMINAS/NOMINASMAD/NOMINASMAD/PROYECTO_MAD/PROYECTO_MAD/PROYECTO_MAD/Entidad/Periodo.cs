using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Periodo
    {
        public int idPeriodo { get; set; }
        public int mes { get; set; }

        public int año { get; set; }


        public Periodo() { }

        public Periodo(int idPeriodo, int mes, int año)
        {
            this.idPeriodo = idPeriodo;
            this.mes = mes;

            this.año = año;

        }

    }
}
