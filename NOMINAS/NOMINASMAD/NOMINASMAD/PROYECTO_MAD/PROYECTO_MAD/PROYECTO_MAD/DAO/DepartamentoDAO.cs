using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.DAO
{
    public class DepartamentoDAO
    {
        public static int InsertarDepartamento(Departamento departamento)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarDepartamento " +
                    "@nombre_departamento = '" + departamento.nombreDepartamento + "', " +
                    "@id_empresa = '" + departamento.idEmpresa +  "';";
                    

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static List<Departamento> ObtenerDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Departamento;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Departamento departamento = new Departamento
                    {
                        idDepartamento = reader.GetInt32(0),               // id_departamento
                        nombreDepartamento = reader.GetString(1),          // nombre_departamento
                        idEmpresa = reader.GetInt32(2)                // id_empresa
                        
                    };

                    lista.Add(departamento);
                }
                return lista;
            }
        }

        public static Departamento ObtenerDepartamentoPorId(int idDepartamento)
        {
            Departamento departamento = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Departamento WHERE id_departamento = @id_departamento;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id_departamento", idDepartamento);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    departamento = new Departamento
                    {
                        idDepartamento = (int)reader["id_departamento"],
                        nombreDepartamento = reader["nombre_departamento"].ToString(),
                     
                        idEmpresa = (int)reader["id_empresa"]
                        
                    };
                }
            }

            return departamento;
        }

        public static List<Departamento> ObtenerDepartamentosPorID(int idDepa)
        {
            List<Departamento> departamentos = new List<Departamento>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Departamento WHERE id_departamento = @id_departamento;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id_departamento", idDepa);  // Parámetro para filtrar

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Departamento departamento = new Departamento
                    {
                        idDepartamento = (int)reader["id_departamento"],
                        nombreDepartamento = reader["nombre_departamento"].ToString(),
               
                        idEmpresa = (int)reader["id_empresa"]
                        
                    };

                    departamentos.Add(departamento);
                }
            }

            return departamentos;
        }

        public static int ModificarDepartamento(Departamento departamento)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ActualizarDepartamento " +
                    "@id_departamento = " + departamento.idDepartamento + ", " +
                    "@nombre_departamento = '" + departamento.nombreDepartamento + "', " +

                    "@id_empresa = '" + departamento.idEmpresa + "'; " 
                    ;

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static void BorrarDepartamento(int idDepartamento)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarDepartamento @id_departamento = " + idDepartamento + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();
            }
        }

        public static int ContarPuestosPorDepartamento(int departamentoId)
        {
            int cantidad = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                // Consulta SQL para contar los puestos relacionados con el departamento
                string query = "SELECT COUNT(*) FROM Puesto WHERE id_departamento = @id_departamento;";
                SqlCommand comando = new SqlCommand(query, conexion);

                // Parametrizamos la consulta para evitar SQL Injection
                comando.Parameters.AddWithValue("@id_departamento", departamentoId);

                // Ejecutamos la consulta y obtenemos el resultado
                cantidad = (int)comando.ExecuteScalar(); // Devuelve el número de filas encontradas
            }

            return cantidad;
        }

        public static int ObtenerIdPercepcionDeduccionPorDepartamento(int idDepartamento)
        {
            int idPercepcionDeduccion = 0; // Valor predeterminado en caso de no encontrar el id

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                // Consulta SQL para obtener el idPercepcionDeduccion del departamento
                string query = "SELECT id_Pd FROM Departamento WHERE id_departamento = @idDepartamento";

                // Crear el comando SQL
                SqlCommand comando = new SqlCommand(query, conexion);

                // Parametrizamos la consulta para evitar SQL Injection
                comando.Parameters.AddWithValue("@idDepartamento", idDepartamento);

                // Ejecutamos la consulta y obtenemos el resultado
                var resultado = comando.ExecuteScalar();

                // Si el resultado no es null, asignamos el valor de la consulta a idPercepcionDeduccion
                if (resultado != DBNull.Value)
                {
                    idPercepcionDeduccion = (int)resultado;
                }
            }

            return idPercepcionDeduccion; // Regresa el idPercepcionDeduccion encontrado, o 0 si no se encontró
        }
    }
}