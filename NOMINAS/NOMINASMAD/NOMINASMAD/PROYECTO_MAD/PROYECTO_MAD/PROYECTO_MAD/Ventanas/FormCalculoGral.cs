using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_MAD.Ventanas
{
    public partial class FormCalculoGral : Form
    {
        public FormCalculoGral()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene los valores ingresados.
                int mes = int.Parse(txtMes.Text);
                int año = int.Parse(txtAño.Text);

                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    // Ejecuta el procedimiento almacenado InsertarPeriodo.
                    string insertarPeriodoQuery = "EXEC InsertarPeriodo @mes, @año";
                    using (SqlCommand insertarPeriodoCmd = new SqlCommand(insertarPeriodoQuery, conexion))
                    {
                        insertarPeriodoCmd.Parameters.AddWithValue("@mes", mes);
                        insertarPeriodoCmd.Parameters.AddWithValue("@año", año);

                        try
                        {
                            insertarPeriodoCmd.ExecuteNonQuery();
                            MessageBox.Show("Periodo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            // Maneja el error del procedimiento almacenado (por ejemplo, periodo duplicado).
                            MessageBox.Show($"Error al registrar el periodo: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Detiene la ejecución si ocurre un error.
                        }
                    }

                    // Llama a la función ObtenerNominasPorMesYAño y llena el DataGridView.
                    string obtenerNominasQuery = "SELECT * FROM ObtenerNominasPorMesYAño(@Mes, @Año)";
                    using (SqlCommand obtenerNominasCmd = new SqlCommand(obtenerNominasQuery, conexion))
                    {
                        obtenerNominasCmd.Parameters.AddWithValue("@Mes", mes);
                        obtenerNominasCmd.Parameters.AddWithValue("@Año", año);

                        SqlDataAdapter adapter = new SqlDataAdapter(obtenerNominasCmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Muestra los datos en el DataGridView.
                        dataGridViewNominas.DataSource = dataTable;
                        MessageBox.Show("Nóminas obtenidas y mostradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Limpia los campos después de registrar y consultar.
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores válidos en los campos de Mes y Año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada.
        private void LimpiarCampos()
        {
            txtMes.Clear();
            txtAño.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPasadosVW form7 = new FormPasadosVW();

            form7.Show();
        }

        private void FormCalculoGral_Load(object sender, EventArgs e)
        {

        }
    }
}
