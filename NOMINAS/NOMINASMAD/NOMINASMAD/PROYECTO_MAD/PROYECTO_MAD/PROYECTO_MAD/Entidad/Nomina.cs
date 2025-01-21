using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Nomina
    {
        public int idNomina { get; set; }      // ID de la nómina
        public int idEmpleado { get; set; }   // ID del empleado
        public int idPD { get; set; }        // ID de percepciones/deducciones
        public int Mes { get; set; }          // Mes de la nómina
        public DateTime FechaPago { get; set; } // Fecha de pago
        public int Año { get; set; }          // Año de la nómina
        public decimal SueldoNeto { get; set; }   // Sueldo neto
        public decimal SueldoBruto { get; set; }

        public Nomina() { }

        public Nomina(int idNomina, int idEmpleado, int idPD, int Mes, DateTime FechaPago, int Año, decimal SueldoNeto, decimal SueldoBruto)
        {
            this.idNomina = idNomina;
            this.idEmpleado = idEmpleado;
            this.idPD = idPD;
            this.FechaPago = FechaPago;
            this.Año = Año;
            this.SueldoNeto = SueldoNeto;
            this.SueldoBruto = SueldoBruto;

        }

    }
}