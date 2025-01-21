using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.DAO
{
    public class NominaDAO
    {
        // Método para insertar una nueva nómina
        public static int InsertarNomina(Nomina nomina)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarNomina " +
                    "@id_empleado = " + nomina.idEmpleado + ", " +
                    "@id_PD = " + nomina.idPD + ", " +
                    "@mes = " + nomina.Mes + ", " +
                    "@fecha_pago = '" + nomina.FechaPago.ToString("yyyy-MM-dd") + "', " +
                    "@año = " + nomina.Año + ", " +
                    "@sueldo_neto = " + nomina.SueldoNeto + ", " +
                    "@sueldo_bruto = " + nomina.SueldoBruto + ";";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        // Método para eliminar una nómina por ID
        public static void BorrarNomina(int idNomina)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarNomina @id_nomina = " + idNomina + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();
            }
        }

        // Método para obtener todas las nóminas
        public static List<Nomina> ObtenerNominas()
        {
            List<Nomina> listaNominas = new List<Nomina>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Nomina;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Nomina nomina = new Nomina
                    {
                        idNomina = reader.GetInt32(0),       // id_nomina
                        idEmpleado = reader.GetInt32(1),    // id_empleado
                        idPD = reader.GetInt32(2),         // id_pyd
                        Mes = reader.GetInt32(3),           // Mes
                        FechaPago = reader.GetDateTime(4),  // Fecha_pago
                        Año = reader.GetInt32(5),           // Año
                        SueldoNeto = reader.GetInt32(6),    // sueldo_neto
                        SueldoBruto = reader.GetInt32(7)    // sueldo_bruto
                    };

                    listaNominas.Add(nomina);
                }
            }

            return listaNominas;
        }

        public static List<Nomina> ObtenerNominasSinNeto()
        {
            List<Nomina> listaNominas = new List<Nomina>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT id_nomina, id_empleado, id_pd, Mes, Fecha_pago, Año, sueldo_bruto FROM Nomina;"; // No incluimos el SueldoNeto en la consulta SQL
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Nomina nomina = new Nomina
                    {
                        idNomina = reader.GetInt32(0),       // id_nomina
                        idEmpleado = reader.GetInt32(1),     // id_empleado
                        idPD = reader.GetInt32(2),          // id_pyd
                        Mes = reader.GetInt32(3),            // Mes
                        FechaPago = reader.GetDateTime(4),   // Fecha_pago
                        Año = reader.GetInt32(5),            // Año
                        SueldoBruto = reader.GetInt32(6)     // SueldoBruto
                                                             // No asignamos SueldoNeto
                    };

                    listaNominas.Add(nomina);
                }
            }

            return listaNominas;
        }

        // Método para obtener una nómina específica por ID
        public static Nomina ObtenerNominaPorId(int idNomina)
        {
            Nomina nomina = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Nomina WHERE id_nomina = " + idNomina + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    nomina = new Nomina
                    {
                        idNomina = reader.GetInt32(0),       // id_nomina
                        idEmpleado = reader.GetInt32(1),    // id_empleado
                        idPD = reader.GetInt32(2),         // id_pyd
                        Mes = reader.GetInt32(3),           // Mes
                        FechaPago = reader.GetDateTime(4),  // Fecha_pago
                        Año = reader.GetInt32(5),           // Año
                        SueldoNeto = reader.GetInt32(6),    // sueldo_neto
                        SueldoBruto = reader.GetInt32(7)    // sueldo_bruto
                    };
                }
            }

            return nomina;
        }

        public static DataTable ObtenerReporteNomina()
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                E.id_empleado,
                CONCAT(E.nombre_empleado, ' ', E.apellido_paterno, ' ', E.apellido_materno) AS nombre_completo,
                N.Fecha_pago,
                N.sueldo_neto,
                E.banco,
                E.numero_cuenta
            FROM 
                Nomina N
            JOIN 
                Empleado E ON N.id_empleado = E.id_empleado";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

    }
}