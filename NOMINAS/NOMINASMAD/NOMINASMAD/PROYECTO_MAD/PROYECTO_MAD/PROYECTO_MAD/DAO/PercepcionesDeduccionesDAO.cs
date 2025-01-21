using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_MAD.DAO
{
    public class PercepcionesDeduccionesDAO
    {
        // Obtener todas las percepciones y deducciones
        public static List<PercepcionesDeducciones> ObtenerPyD()
        {
            List<PercepcionesDeducciones> listaPyD = new List<PercepcionesDeducciones>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM PD;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PercepcionesDeducciones pyd = new PercepcionesDeducciones
                    {
                        idPD = reader.GetInt32(0), // id_pd
                        nombrePD = reader.GetString(1), // nombre_pd
                      
                        cantidad = reader.GetDecimal(4), // monto
                        EsPercepcion = reader.GetBoolean(5), // EsPercepcion
                        EsPorcentaje = reader.GetBoolean(6), // EsPorcentaje
                    };
                    listaPyD.Add(pyd);
                }
                return listaPyD;
            }
        }

        // Obtener una percepción o deducción específica por ID
        public static List<PercepcionesDeducciones> ObtenerPyDPorId(int idPyD)
        {
            List<PercepcionesDeducciones> lista = new List<PercepcionesDeducciones>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM PD WHERE id_pd = " + idPyD + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    PercepcionesDeducciones pyd = new PercepcionesDeducciones
                    {
                        idPD = reader.GetInt32(0), // id_pd
                        nombrePD = reader.GetString(1), // nombre_pd
                    
                        cantidad = reader.GetDecimal(4), // monto
                        EsPercepcion = reader.GetBoolean(5), // EsPercepcion
                        EsPorcentaje = reader.GetBoolean(6), // EsPorcentaje
                    };
                    lista.Add(pyd);
                }
                return lista;
            }
        }

        public static PercepcionesDeducciones ObtenerPorId(int idPyD)
        {
            PercepcionesDeducciones pyd = null;  // Inicializamos en null por si no encontramos el registro.

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM PD WHERE id_pd = @idPD;";  // Usamos un parámetro para la consulta.
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idPD", idPyD);  // Agregamos el parámetro para evitar SQL Injection.

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())  // Si se encuentra el registro, lo leemos.
                {
                    pyd = new PercepcionesDeducciones
                    {
                        idPD = reader.GetInt32(0),         // id_pd
                        nombrePD = reader.GetString(1),       // nombre_pd
                     
                        cantidad = reader.GetDecimal(4),       // cantidad
                        EsPercepcion = reader.GetBoolean(5), // EsPercepcion
                        EsPorcentaje = reader.GetBoolean(6) // EsPorcentaje
                    };
                }
            }

            return pyd;  // Retornamos el objeto o null si no se encontró.
        }

        // Insertar una nueva percepción o deducción
        public static int InsertarPD(PercepcionesDeducciones pyd)
        {
            int resultado = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarPD " +
                               "@nombre_pd = '" + pyd.nombrePD + "', " +
              
                               "@cantidad = " + pyd.cantidad.ToString("F2") + ", " +
                               "@EsPercepcion = " + (pyd.EsPercepcion ? 1 : 0) + ", " +
                               "@EsPorcentaje = " + (pyd.EsPorcentaje ? 1 : 0) + "; ";
                SqlCommand comando = new SqlCommand(query, conexion);
                int retorno = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        // Actualizar una percepción o deducción existente
        public static int ActualizarPD(PercepcionesDeducciones pyd)
        {
            int resultado = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ActualizarPD " +
                               "@id_pd = " + pyd.idPD + ", " +
                               "@nombre_pd = '" + pyd.nombrePD + "', " +
                            
                               "@cantidad = " + pyd.cantidad.ToString("F2") + ", " +
                               "@EsPercepcion = " + (pyd.EsPercepcion ? 1 : 0) + ", " +
                               "@EsPorcentaje = " + (pyd.EsPorcentaje ? 1 : 0) + "; ";
                SqlCommand comando = new SqlCommand(query, conexion);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        // Eliminar una percepción o deducción
        public static void EliminarPD(int idPyD)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarPD @id_pd = " + idPyD + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();
            }
        }
    }
}