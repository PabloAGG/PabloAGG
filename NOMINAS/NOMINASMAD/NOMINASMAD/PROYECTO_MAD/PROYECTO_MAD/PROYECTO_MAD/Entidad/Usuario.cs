using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.Entidad
{
    public class Usuario
    {

        public int id { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }

        public Usuario() { }

        public Usuario(int id, string contrasena, string nombre)
        {
            this.id = id;
         
            this.contrasena = contrasena;
            this.nombre = nombre;
        }
    }
}
