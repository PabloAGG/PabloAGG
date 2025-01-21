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
using System.IO;

namespace PROYECTO_MAD.Ventanas
{
    public partial class ReporteHeadcounter : Form
    {
        public ReporteHeadcounter()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReporteHeadcounter_Load(object sender, EventArgs e)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                try
                {
                    // Cargar departamentos
                    SqlCommand cmdDepartamentos = new SqlCommand("SELECT id_departamento, nombre_departamento FROM Departamento", conexion);
                    SqlDataReader reader = cmdDepartamentos.ExecuteReader();
                    comboBoxDepartamento.Items.Add("Todos");
                    while (reader.Read())
                    {
                        comboBoxDepartamento.Items.Add(new { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                    reader.Close();
                    comboBoxDepartamento.DisplayMember = "Nombre";
                    comboBoxDepartamento.ValueMember = "Id";
                    comboBoxDepartamento.SelectedIndex = 0;

                    // Cargar años
                    int añoActual = DateTime.Now.Year;
                    for (int i = añoActual - 24; i <= añoActual; i++)
                    {
                        comboBoxAño.Items.Add(i);
                    }
                    comboBoxAño.SelectedIndex = 0;

                    // Cargar meses
                    comboBoxMes.Items.AddRange(new string[]
                    {
                "1", "2", "3", "4",
                "5", "6", "7", "8",
                "9", "10", "11", "12"
                    });
                    comboBoxMes.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAño.SelectedIndex == -1 || comboBoxMes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecciona un año y un mes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int año = int.Parse(comboBoxAño.SelectedItem.ToString());
            int mes = int.Parse(comboBoxMes.SelectedItem.ToString().Split(' ')[0]);
            int? departamentoId = comboBoxDepartamento.SelectedIndex > 0 ?
                                  (comboBoxDepartamento.SelectedItem as dynamic).Id :
                                  (int?)null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                try
                {
                    // Cargar Parte 1
                    string queryParte1 = @"
                 SELECT 
                     d.nombre_departamento AS Departamento,
                     p.nombre_puesto AS Puesto,
                     COUNT(e.id_empleado) AS Cantidad_Empleados
                 FROM 
                     Empleado e
                     INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
                     INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
                 WHERE 
                     (@Departamento IS NULL OR d.id_departamento = @Departamento) AND
                     YEAR(e.fecha_ingreso_empresa) = @Año AND
                     MONTH(e.fecha_ingreso_empresa) = @Mes
                 GROUP BY 
                     d.nombre_departamento, p.nombre_puesto
                 ORDER BY 
                     d.nombre_departamento, p.nombre_puesto;";
                    SqlCommand cmd1 = new SqlCommand(queryParte1, conexion);
                    cmd1.Parameters.AddWithValue("@Departamento", (object)departamentoId ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@Año", año);
                    cmd1.Parameters.AddWithValue("@Mes", mes);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    dataGridView1.DataSource = table1;

                    // Cargar Parte 2
                    string queryParte2 = @"
                 SELECT 
                     d.nombre_departamento AS Departamento,
                 COUNT(e.id_empleado) AS Cantidad_Empleados
                 FROM 
                     Empleado e
                     INNER JOIN Puesto p ON e.id_puesto = p.id_puesto
                     INNER JOIN Departamento d ON p.id_departamento = d.id_departamento
                 WHERE 
                     (@Departamento IS NULL OR d.id_departamento = @Departamento) AND
                 YEAR(e.fecha_ingreso_empresa) = @Año AND
                 MONTH(e.fecha_ingreso_empresa) = @Mes
                 GROUP BY 
                     d.nombre_departamento
                 ORDER BY 
                     d.nombre_departamento;";
                    SqlCommand cmd2 = new SqlCommand(queryParte2, conexion);
                    cmd2.Parameters.AddWithValue("@Departamento", (object)departamentoId ?? DBNull.Value);
                    cmd2.Parameters.AddWithValue("@Año", año);
                    cmd2.Parameters.AddWithValue("@Mes", mes);

                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    dataGridView2.DataSource = table2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        private void button_GenerarReporteRH_Click(object sender, EventArgs e)
        {
            // Abrir un diálogo para que el usuario elija la ubicación del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            saveFileDialog.FileName = "Reporte_Headcounter.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Crear un nuevo archivo CSV en la ubicación seleccionada
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Escribir los encabezados de las columnas (se asume que el DataGridView tiene los encabezados)
                        string[] columnas = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                  .Select(col => col.HeaderText)
                                                  .ToArray();
                        sw.WriteLine(string.Join(",", columnas)); // Escribir encabezados

                        // Escribir las filas de datos de la primera parte (dataGridView1)
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Verificar que la fila no esté vacía
                            if (!row.IsNewRow)
                            {
                                string[] fila = row.Cells.Cast<DataGridViewCell>()
                                                        .Select(cell => cell.Value?.ToString() ?? "")
                                                        .ToArray();
                                sw.WriteLine(string.Join(",", fila)); // Escribir los datos de la fila
                            }
                        }

                        // Si necesitas incluir la segunda parte (dataGridView2), repetir el proceso
                        sw.WriteLine(); // Añadir una línea vacía entre los dos reportes
                        columnas = dataGridView2.Columns.Cast<DataGridViewColumn>()
                                                        .Select(col => col.HeaderText)
                                                        .ToArray();
                        sw.WriteLine(string.Join(",", columnas)); // Escribir encabezados de la segunda parte

                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string[] fila = row.Cells.Cast<DataGridViewCell>()
                                                        .Select(cell => cell.Value?.ToString() ?? "")
                                                        .ToArray();
                                sw.WriteLine(string.Join(",", fila)); // Escribir los datos de la fila
                            }
                        }
                    }

                    MessageBox.Show("Reporte generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
