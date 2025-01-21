using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PROYECTO_MAD.Ventanas
{
    public partial class ReporteGeneralNomina : Form
    {
        public ReporteGeneralNomina()
        {
            InitializeComponent();
        }

        private void button_Regresar_RGN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteGeneralNomina_Load(object sender, EventArgs e)
        {
            // Cargar años dinámicamente
            int añoActual = DateTime.Now.Year;
            for (int i = añoActual - 24; i <= añoActual; i++) // Últimos 10 años
            {
                comboBoxAño.Items.Add(i);
            }

            comboBoxMes.Items.AddRange(new string[]
            {
        "1", "2", "3", "4",
        "5", "6", "7", "8",
        "9", "10", "11", "12"
            });

            comboBoxAño.SelectedIndex = 0;
            comboBoxMes.SelectedIndex = 0;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void button_Filtrar_RGN_Click(object sender, EventArgs e)
        {
            if (comboBoxAño.SelectedIndex == -1 || comboBoxMes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un año y un mes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int año = int.Parse(comboBoxAño.SelectedItem.ToString());
            int mes = int.Parse(comboBoxMes.SelectedItem.ToString().Split(' ')[0]); 

            string query = @"
        SELECT 
            d.nombre_departamento AS Departamento,
            p.nombre_puesto AS Puesto,
            CONCAT(e.apellido_paterno, ' ', e.apellido_materno, ' ', e.nombre_empleado) AS NombreEmpleado,
            e.fecha_ingreso_empresa AS FechaIngreso,
            DATEDIFF(YEAR, e.fecha_nacimiento, GETDATE()) AS Edad,
            e.sueldo AS Salario
        FROM 
            Empleado e
            INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
            INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
        WHERE 
            YEAR(e.fecha_ingreso_empresa) = @Año AND
            MONTH(e.fecha_ingreso_empresa) = @Mes
        ORDER BY 
            d.nombre_departamento,
            p.nombre_puesto,
            e.apellido_paterno, 
            e.apellido_materno, 
            e.nombre_empleado;";

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("@Año", año);
                    command.Parameters.AddWithValue("@Mes", mes);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_GenerarReporte_RGN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = "ReporteGeneralNomina.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            writer.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    string value = row.Cells[i].Value.ToString();
                                    // Escapar comas y caracteres especiales en el CSV
                                    value = value.Replace(",", ";").Replace("\n", " ").Replace("\r", " ");
                                    writer.Write(value);
                                }

                                if (i < dataGridView1.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show("Reporte generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
