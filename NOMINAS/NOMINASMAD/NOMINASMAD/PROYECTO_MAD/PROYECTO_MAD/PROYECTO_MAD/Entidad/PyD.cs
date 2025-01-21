using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class PercepcionesDeducciones
    {
        public int idPD { get; set; }
        public string nombrePD { get; set; }
     
        public decimal cantidad { get; set; }
        public bool EsPercepcion { get; set; }
        public bool EsPorcentaje { get; set; }

        public PercepcionesDeducciones() { }

        public PercepcionesDeducciones(int idPD, string nombrePD, int mesPD, int añoPD, decimal cantidad, bool EsPercepcion, bool EsPorcentaje)
        {
            this.idPD = idPD;
            this.nombrePD = nombrePD;
            
            this.cantidad = cantidad;
            this.EsPercepcion = EsPercepcion;
            this.EsPorcentaje = EsPorcentaje;
        }
    }
}
