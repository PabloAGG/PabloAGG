using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
  
        public decimal idEmpresa { get; set; }
     


        public Departamento() { }

        public Departamento(int idDepartamento, string nombreDepartamento, decimal sueldoBaseDiario, int idEmpresa, int idPd)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
       
            this.idEmpresa = idEmpresa;
      
        }
    }
}