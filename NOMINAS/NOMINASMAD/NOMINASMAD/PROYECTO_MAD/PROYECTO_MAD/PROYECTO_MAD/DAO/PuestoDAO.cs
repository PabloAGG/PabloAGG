using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.DAO
{
    public class PuestoDAO
    {
        // Obtener todos los puestos
        public static List<Puesto> ObtenerPuestos()
        {
            List<Puesto> listaPuestos = new List<Puesto>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Puesto;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Puesto puesto = new Puesto();
                    puesto.idPuesto = reader.GetInt32(0); // id_puesto
                    puesto.nombrePuesto = reader.GetString(1); // nombre_puesto
                    puesto.idDepartamento = reader.GetInt32(2); // id_departamento
                
                    listaPuestos.Add(puesto);
                }
                return listaPuestos;
            }  
        }


        // Obtener un puesto específico por id_puesto
        public static List<Puesto> ObtenerPuestoPorId(int idPuesto)
        {
            List<Puesto> lista = new List<Puesto>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Puesto WHERE id_puesto =" + idPuesto.ToString() + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
             
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Puesto puesto = new Puesto();
                    puesto.idPuesto = reader.GetInt32(0); // id_puesto
                    puesto.nombrePuesto = reader.GetString(1); // nombre_puesto
                    puesto.idDepartamento = reader.GetInt32(2); // id_departamento
                    lista.Add(puesto);

                }
                return lista;
            }

        }



        // Insertar un nuevo puesto utilizando un stored procedure
        public static int InsertarPuesto(Puesto puesto)
        {
            int resultado = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarPuesto " +
                    "@nombre_puesto = '" + puesto.nombrePuesto + "', " +
                    "@id_departamento = '" + puesto.idDepartamento + "'; ";

                SqlCommand comando = new SqlCommand(query, conexion);
                int retorno = comando.ExecuteNonQuery();
            }

            return resultado;
        }


        // Eliminar un puesto
        public static void EliminarPuesto(int idPuesto)
        {

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarPuesto @puesto_id = " + idPuesto + "; ";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();
            }          
        }


        public static int ContarEmpleadoPorPuesto(int PuestoId)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Empleado WHERE id_puesto = @id_puesto";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id_puesto", PuestoId);

                return (int)comando.ExecuteScalar();
            }
        }

        public static int ModificarPuesto(Puesto puesto)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ActualizarPuesto " +
                    "@id_puesto = " + puesto.idPuesto + ", " +
                    "@nombre_puesto = '" + puesto.nombrePuesto + "', " +
                    "@id_departamento = '" + puesto.idDepartamento +  "'; ";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }
    }
}
