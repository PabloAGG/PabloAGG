using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_MAD.DAO
{
public class PeriodoDao
    {
        public static List<Periodo> ObtenerPeriodo()
        {
            List<Periodo> listaPeriodo = new List<Periodo>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM periodos;";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Periodo periodo = new Periodo();
                    periodo.idPeriodo = reader.GetInt32(0); // id_puesto
                    periodo.mes = reader.GetInt32(1); // nombre_puesto
                    periodo.año = reader.GetInt32(2); // id_departamento

                    listaPeriodo.Add(periodo);
                }
                return listaPeriodo;
            }
        
        }
        public static int InsertarPeriodo(Periodo periodo)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    string query = "EXEC InsertarPeriodo @mes, @año";

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@mes", periodo.mes);
                    comando.Parameters.AddWithValue("@año", periodo.año);

                    resultado = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Si el error proviene del RAISERROR en el procedimiento almacenado
                if (ex.Number == 50000) // 50000 es el código base para RAISERROR
                {
                    MessageBox.Show(ex.Message, "Error de periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otros errores de SQL
                    MessageBox.Show("Ocurrió un error al insertar el periodo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultado;
        }
      
        public static List<Periodo> ObtenerPeriodoPorId(int idPeriodo)
        {
            List<Periodo> listaPeriodo = new List<Periodo>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT * FROM periodos WHERE id_periodo =" + idPeriodo.ToString() + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Periodo periodo = new Periodo();
                    periodo.idPeriodo = reader.GetInt32(0); // id_puesto
                    periodo.mes = reader.GetInt32(1); // nombre_puesto
                    periodo.año = reader.GetInt32(2); // id_departamento

                    listaPeriodo.Add(periodo);

                }
                return listaPeriodo;
            }

        }
        public static Periodo ObtenerUltimoPeriodo()
        {
            Periodo ultimoPeriodo = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT TOP 1 * FROM periodos ORDER BY año DESC, mes DESC"; // Suponiendo que deseas el último por fecha.

                SqlCommand comando = new SqlCommand(query, conexion);
                

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ultimoPeriodo = new Periodo
                        {
                            idPeriodo = reader.GetInt32(reader.GetOrdinal("id_periodo")),
                            mes = reader.GetInt32(reader.GetOrdinal("mes")),
                            año = reader.GetInt32(reader.GetOrdinal("año"))
                        };
                    }
                }
            }

            return ultimoPeriodo;
        }

    }


}
