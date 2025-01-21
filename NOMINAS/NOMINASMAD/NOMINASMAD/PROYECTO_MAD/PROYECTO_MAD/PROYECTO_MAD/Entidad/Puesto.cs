using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Puesto
    {
        public int idPuesto { get; set; }
        public string nombrePuesto { get; set; }
    
        public int idDepartamento { get; set; }
       

        public Puesto() { }

        public Puesto(int idPuesto, string nombrePuesto, decimal sueldoEspecificoDiario, int idDepartamento, decimal nivelSalarial)
        {
            this.idPuesto = idPuesto;
            this.nombrePuesto = nombrePuesto;
         
            this.idDepartamento = idDepartamento;
           
        }

    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        // Opcionalmente, puedes sobrescribir ToString() para mostrar un formato más amigable
        public override string ToString()
        {
            return Text;
        }
    }
}
