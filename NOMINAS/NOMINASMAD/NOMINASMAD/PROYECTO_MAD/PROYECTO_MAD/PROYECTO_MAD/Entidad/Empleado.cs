using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaIngresoEmpresa { get; set; }
        public Decimal sueldo { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public string nss { get; set; }
        public string direccion { get; set; }
        public string banco { get; set; }
        public string numeroCuenta { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public int tipoEmpleado { get; set; }
        public int idPuesto { get; set; }
        public int idDepartamento { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{nombreEmpleado} {apellidoPaterno} {apellidoMaterno}";
            }
        }

        public Empleado() { }

        public Empleado(int idEmpleado, string nombreEmpleado, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, DateTime fechaIngresoEmpresa, DateTime fechaContrato, Decimal sueldo, string curp, string rfc, string nss, string direccion, string banco, string numeroCuenta, string email, string telefono, int tipoEmpleado, int idPuesto, int idDepartamento)
        {
            this.idEmpleado = idEmpleado;
            this.nombreEmpleado = nombreEmpleado;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            
            this.fechaNacimiento = fechaNacimiento;
            this.fechaIngresoEmpresa = fechaIngresoEmpresa;
            this.sueldo = sueldo;
            this.curp = curp;
            this.rfc = rfc;
            this.nss = nss;
            this.direccion = direccion;
            this.banco = banco;
            this.numeroCuenta = numeroCuenta;
            this.email = email;
            this.telefono = telefono;
            this.tipoEmpleado = tipoEmpleado;
            this.idPuesto = idPuesto;
            this.idDepartamento = idDepartamento;
        }
    }
}
