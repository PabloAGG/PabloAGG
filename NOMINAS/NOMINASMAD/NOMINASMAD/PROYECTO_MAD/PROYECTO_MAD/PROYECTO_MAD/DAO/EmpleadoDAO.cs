using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.DAO
{
    public class EmpleadoDAO
    {
        public static int InsertarEmpleado(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarEmpleado " +
                    "@id_empleado = '" + empleado.idEmpleado + "', " +
                    "@nombre_empleado = '" + empleado.nombreEmpleado + "', " +
                    "@apellido_paterno = '" + empleado.apellidoPaterno + "', " +
                    "@apellido_materno = '" + empleado.apellidoMaterno + "', " +
                    "@fecha_nacimiento = '" + empleado.fechaNacimiento.Date.ToString("yyyy-MM-dd") + "', " +
                  
                    "@curp = '" + empleado.curp + "', " +
                    "@rfc = '" + empleado.rfc + "', " +
                    "@nss = '" + empleado.nss + "', " +
                    "@direccion = '" + empleado.direccion + "', " +
                    "@banco = '" + empleado.banco + "', " +
                    "@numero_cuenta = '" + empleado.numeroCuenta + "', " +
                    "@email = '" + empleado.email + "', " +
                    "@telefono = '" + empleado.telefono + "', " +
                    "@fecha_ingreso_empresa = '" + empleado.fechaIngresoEmpresa.Date.ToString("yyyy-MM-dd") + "', " +
          
                    "@sueldo = '" + empleado.sueldo + "', " +
                    "@tipo_empleado = '" + empleado.tipoEmpleado + "', " +
                    "@id_puesto = '" + empleado.idPuesto + "', " +
                    "@id_departamento = '" + empleado.idDepartamento + "'; ";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();

            }

            return retorno;
        }

        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Empleado;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.idEmpleado = reader.GetInt32(0);               // id_empleado
                    empleado.nombreEmpleado = reader.GetString(1);          // nombre_empleado
                    empleado.apellidoPaterno = reader.GetString(2);         // apellido_paterno
                    empleado.apellidoMaterno = reader.GetString(3);         // apellido_materno
                    empleado.fechaNacimiento = reader.GetDateTime(4);       // fecha_nacimiento
           
                    empleado.curp = reader.GetString(5);                    // curp
                    empleado.rfc = reader.GetString(6);                     // rfc
                    empleado.nss = reader.GetString(7);                     // nss
                    empleado.direccion = reader.GetString(8);               // direccion
                    empleado.banco = reader.GetString(9);                  // banco
                    empleado.numeroCuenta = reader.GetString(10);           // numero_cuenta
                    empleado.email = reader.GetString(11);                 // email
                    empleado.telefono = reader.GetString(12);               // telefono
                    empleado.fechaIngresoEmpresa = reader.GetDateTime(13);  // fecha_ingreso_empresa
                    empleado.sueldo = reader.GetDecimal(14);                // sueldo
                    empleado.tipoEmpleado = reader.GetInt32(15);            // tipo_empleado
                    empleado.idPuesto = reader.GetInt32(16);                // id_puesto
                    empleado.idDepartamento = reader.GetInt32(17);          // id_departamento

                    lista.Add(empleado);
                }
                return lista;

            }

        }

        public static List<Empleado> ObtenerEmpleados(int empleadoId)
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Empleado WHERE id_empleado = " + empleadoId.ToString() + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.idEmpleado = reader.GetInt32(0);               // id_empleado
                    empleado.nombreEmpleado = reader.GetString(1);          // nombre_empleado
                    empleado.apellidoPaterno = reader.GetString(2);         // apellido_paterno
                    empleado.apellidoMaterno = reader.GetString(3);         // apellido_materno
                    empleado.fechaNacimiento = reader.GetDateTime(4);       // fecha_nacimiento
                    empleado.curp = reader.GetString(5);                    // curp
                    empleado.rfc = reader.GetString(6);                     // rfc
                    empleado.nss = reader.GetString(7);                     // nss
                    empleado.direccion = reader.GetString(8);               // direccion
                    empleado.banco = reader.GetString(9);                  // banco
                    empleado.numeroCuenta = reader.GetString(10);           // numero_cuenta
                    empleado.email = reader.GetString(11);                 // email
                    empleado.telefono = reader.GetString(12);               // telefono
                    empleado.fechaIngresoEmpresa = reader.GetDateTime(13);  // fecha_ingreso_empresa
                    empleado.sueldo = reader.GetDecimal(14);                // sueldo
                    empleado.tipoEmpleado = reader.GetInt32(15);            // tipo_empleado
                    empleado.idPuesto = reader.GetInt32(16);                // id_puesto
                    empleado.idDepartamento = reader.GetInt32(17);          // id_departamento

                    lista.Add(empleado);
                }
                return lista;

            }

        }



        public static List<Empleado> ObtenerEmpleadosFecha(int mes, int año)
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"
SELECT *
FROM Empleado e
WHERE YEAR(e.fecha_ingreso_empresa) < @año
   OR (YEAR(e.fecha_ingreso_empresa) = @año AND MONTH(e.fecha_ingreso_empresa) <= @mes)";

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@mes", mes);

                //SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();
                    empleado.idEmpleado = reader.GetInt32(0);               // id_empleado
                    empleado.nombreEmpleado = reader.GetString(1);          // nombre_empleado
                    empleado.apellidoPaterno = reader.GetString(2);         // apellido_paterno
                    empleado.apellidoMaterno = reader.GetString(3);         // apellido_materno
                    empleado.fechaNacimiento = reader.GetDateTime(4);       // fecha_nacimiento
                    empleado.curp = reader.GetString(5);                    // curp
                    empleado.rfc = reader.GetString(6);                     // rfc
                    empleado.nss = reader.GetString(7);                     // nss
                    empleado.direccion = reader.GetString(8);               // direccion
                    empleado.banco = reader.GetString(9);                  // banco
                    empleado.numeroCuenta = reader.GetString(10);           // numero_cuenta
                    empleado.email = reader.GetString(11);                 // email
                    empleado.telefono = reader.GetString(12);               // telefono
                    empleado.fechaIngresoEmpresa = reader.GetDateTime(13);  // fecha_ingreso_empresa
                    empleado.sueldo = reader.GetDecimal(14);                // sueldo
                    empleado.tipoEmpleado = reader.GetInt32(15);            // tipo_empleado
                    empleado.idPuesto = reader.GetInt32(16);                // id_puesto
                    empleado.idDepartamento = reader.GetInt32(17);          // id_departamento

                    lista.Add(empleado);
                }
                return lista;

            }

        }

        public static void BorrarEmpleado(int empleadoId)
        {

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarEmpleado @id_empleado = " + empleadoId + "; ";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();
            }

        }


        public static int ModificarEmpleado(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ActualizarEmpleado " +
                    "@id_empleado = " + empleado.idEmpleado + ", " +
                    "@nombre_empleado = '" + empleado.nombreEmpleado + "', " +
                    "@apellido_paterno = '" + empleado.apellidoPaterno + "', " +
                    "@apellido_materno = '" + empleado.apellidoMaterno + "', " +
                    "@fecha_nacimiento = '" + empleado.fechaNacimiento.Date.ToString("yyyy-MM-dd") + "', " +
                  
                    "@curp = '" + empleado.curp + "', " +
                    "@rfc = '" + empleado.rfc + "', " +
                    "@nss = '" + empleado.nss + "', " +
                    "@direccion = '" + empleado.direccion + "', " +
                    "@banco = '" + empleado.banco + "', " +
                    "@numero_cuenta = '" + empleado.numeroCuenta + "', " +
                    "@email = '" + empleado.email + "', " +
                    "@telefono = '" + empleado.telefono + "', " +
                    "@fecha_ingreso_empresa = '" + empleado.fechaIngresoEmpresa.Date.ToString("yyyy-MM-dd") + "', " +
        
                    "@sueldo = '" + empleado.sueldo + "', " +
                    "@tipo_empleado = '" + empleado.tipoEmpleado + "', " +
                    "@id_puesto = '" + empleado.idPuesto + "', " +
                    "@id_departamento = '" + empleado.idDepartamento + "'; ";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        //public static void ActualizarSueldos()
        //{
        //    int retorno = 0;

        //    using (SqlConnection conexion = BDConexion.ObtenerConexion())
        //    {
        //        string query = @"
        //    UPDATE Empleado
        //    SET sueldo = (
        //        SELECT sueldo_especifico_diario
        //        FROM Puesto
        //        WHERE Puesto.id_puesto = Empleado.id_puesto
        //    )";

        //        SqlCommand comando = new SqlCommand(query, conexion);
        //        retorno = comando.ExecuteNonQuery();
        //    }
        //}

        public static decimal ObtenerSueldoPorId(int idEmpleado)
        {
            decimal sueldo = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT sueldo FROM Empleado WHERE id_empleado = @idEmpleado;";
                SqlCommand comando = new SqlCommand(query, conexion);

                // Parámetro para evitar inyecciones SQL
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                object resultado = comando.ExecuteScalar();
                if (resultado != null)
                {
                    sueldo = Convert.ToDecimal(resultado);
                }
            }

            return sueldo;
        }

        public static Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            Empleado empleado = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT fecha_ingreso_empresa, sueldo FROM Empleado WHERE id_empleado = @idEmpleado;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    empleado = new Empleado
                    {
                        fechaIngresoEmpresa = reader.GetDateTime(0),
                        sueldo = reader.GetDecimal(1)
                    };
                }
            }

            return empleado;
        }

        public static Empleado ObtenerEmpleadoPorIdD(int empleadoId)
        {
            Empleado empleado = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                // Consulta SQL para obtener los datos del empleado
                string query = "SELECT id_empleado, nombre_empleado, fecha_ingreso_empresa, sueldo, id_departamento FROM Empleado WHERE id_empleado = @idEmpleado";

                SqlCommand comando = new SqlCommand(query, conexion);

                // Parametrizamos la consulta para evitar SQL Injection
                comando.Parameters.AddWithValue("@idEmpleado", empleadoId);

                // Ejecutamos la consulta y obtenemos el resultado
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read()) // Si hay resultados
                    {
                        // Mapeamos los resultados a un objeto Empleado
                        empleado = new Empleado
                        {
                            idEmpleado = (int)reader["id_empleado"],
                            nombreEmpleado = reader["nombre_empleado"].ToString(),
                            fechaIngresoEmpresa = (DateTime)reader["fecha_ingreso_empresa"],
                            sueldo = (decimal)reader["sueldo"],
                            idDepartamento = (int)reader["id_departamento"]
                        };
                    }
                }
            }

            return empleado; // Retornamos el objeto empleado o null si no se encontró
        }


    }
}
