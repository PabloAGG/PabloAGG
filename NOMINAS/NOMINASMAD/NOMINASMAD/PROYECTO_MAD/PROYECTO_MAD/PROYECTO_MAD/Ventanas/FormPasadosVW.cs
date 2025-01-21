using PdfSharp.Drawing;
using PROYECTO_MAD.DAO;
using PROYECTO_MAD.Entidad;
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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;

namespace PROYECTO_MAD.Ventanas
{
    public partial class FormPasadosVW : Form
    {
        public FormPasadosVW()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene los valores ingresados para mes y año.
                int mes = int.Parse(txtMes.Text);
                int año = int.Parse(txtAño.Text);

                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    // Consulta SQL para obtener las nóminas por mes y año.
                    string obtenerNominasQuery = "SELECT * FROM ObtenerNominasPorMesYAño(@Mes, @Año)";

                    using (SqlCommand obtenerNominasCmd = new SqlCommand(obtenerNominasQuery, conexion))
                    {
                        obtenerNominasCmd.Parameters.AddWithValue("@Mes", mes);
                        obtenerNominasCmd.Parameters.AddWithValue("@Año", año);

                        // Crea un SqlDataAdapter para llenar un DataTable con los resultados.
                        SqlDataAdapter adapter = new SqlDataAdapter(obtenerNominasCmd);
                        DataTable dataTable = new DataTable();

                        // Llenar el DataTable con los datos de la consulta.
                        adapter.Fill(dataTable);

                        // Asigna el DataTable al DataGridView para mostrar los resultados.
                        dataGridView1.DataSource = dataTable;

                        // Verifica si se encontraron registros.
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron registros para el mes y año proporcionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores.
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                string obtenerNominasQuery = "SELECT * FROM ObtenerNominasPorMesYAño(@Mes, @Año)";

                // Validar que los campos no estén vacíos
                if (!string.IsNullOrWhiteSpace(txtidempleado.Text) &&
                    !string.IsNullOrWhiteSpace(txtMes.Text) &&
                    !string.IsNullOrWhiteSpace(txtAño.Text))
                {
                    int empleadoID = int.Parse(txtidempleado.Text);
                    int mes = int.Parse(txtMes.Text);
                    int año = int.Parse(txtAño.Text);

                    using (SqlConnection conexion = BDConexion.ObtenerConexion())
                    {
                        using (SqlCommand obtenerNominasCmd = new SqlCommand(obtenerNominasQuery, conexion))
                        {
                            obtenerNominasCmd.Parameters.AddWithValue("@Mes", mes);
                            obtenerNominasCmd.Parameters.AddWithValue("@Año", año);

                            // Crea un SqlDataAdapter para llenar un DataTable con los resultados
                            SqlDataAdapter adapter = new SqlDataAdapter(obtenerNominasCmd);
                            DataTable dataTable = new DataTable();

                            // Llenar el DataTable con los datos de la consulta
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;

                                SaveFileDialog saveFileDialog = new SaveFileDialog
                                {
                                    Filter = "Archivo PDF (.pdf)|.pdf",
                                    FileName = "NominaEmpleado.pdf"
                                };

                                // Ruta temporal para generar el PDF
                                string rutaArchivoTemporal = Path.Combine(Path.GetTempPath(), $"Nomina_Empleado{empleadoID}.pdf");

                                // Llamar a la función que genera el PDF
                                GenerarPDFNomina(empleadoID, mes, año, rutaArchivoTemporal);

                                // Mostrar el PDF en el WebBrowser
                                webBrowser1.Navigate(rutaArchivoTemporal);

                                MessageBox.Show("Previsualización de la nómina generada.");
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron registros para los datos proporcionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos para generar el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarACSV(DataTable dataTable, string rutaArchivo)
        {
            StringBuilder sb = new StringBuilder();

            string[] columnNames = dataTable.Columns.Cast<DataColumn>()
                                        .Select(column => column.ColumnName)
                                        .ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            // Escribir filas
            foreach (DataRow row in dataTable.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            // Guardar archivo
            System.IO.File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    int mes = int.Parse(txtMes.Text);
                    int año = int.Parse(txtAño.Text);
                    // Consulta SQL para obtener las nóminas por mes y año.
                    string obtenerNominasQuery = "SELECT * FROM ObtenerNominasPorMesYAño(@Mes, @Año)";
                  

                    using (SqlCommand obtenerNominasCmd = new SqlCommand(obtenerNominasQuery, conexion))
                    {
                        obtenerNominasCmd.Parameters.AddWithValue("@Mes", mes);
                        obtenerNominasCmd.Parameters.AddWithValue("@Año", año);

                        // Crea un SqlDataAdapter para llenar un DataTable con los resultados.
                        SqlDataAdapter adapter = new SqlDataAdapter(obtenerNominasCmd);
                        DataTable dataTable = new DataTable();
                        // Llenar el DataTable con los datos de la consulta.
                        adapter.Fill(dataTable);

                        // Asigna el DataTable al DataGridView para mostrar los resultados.
                  


                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;

                            SaveFileDialog saveFileDialog = new SaveFileDialog
                            {
                                Filter = "Archivo CSV (.csv)|.csv",
                                FileName = "ReporteCálculoNomina.csv"
                            };

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string rutaArchivo = saveFileDialog.FileName;
                                ExportarACSV(dataTable, rutaArchivo);
                                MessageBox.Show("Reporte generado exitosamente en: " + rutaArchivo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay datos para generar el reporte.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }

        }

        public static void GenerarPDFNomina(int empleadoID, int mes, int año, string rutaArchivo)
        {
    

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {


                // Consulta SQL para obtener los datos necesarios
                string query = @"
    SELECT 
        n.Nombre_Empleado,
        n.Sueldo_Bruto,
        n.SalarioDiario,
        n.BonoAsistencia,
        n.Despensa,
        n.Puntualidad,
        n.IMSS,
        n.ISR,
        n.PrestamoINF,
        n.FondoAhorro,
        n.Vacaciones,
        n.Aguinaldo,
        n.HorasExtras,
        n.Faltas,
        n.Sueldo_Final,
        e.numero_cuenta,
        em.nombre_empresa,
        em.rfc_empresa,
        em.dominio_fiscal
    FROM ObtenerNominasPorMesYAño(@mes, @año) AS n
    INNER JOIN Empleado e ON e.id_empleado = n.ID_Empleado
    INNER JOIN Empresa em ON em.id_empresa = 1 -- Empresa fija con ID 1
    WHERE n.ID_Empleado = @EmpleadoId;";// Solo mostrar conceptos aplicables

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@EmpleadoId", empleadoID);
                command.Parameters.AddWithValue("@Mes", mes);
                command.Parameters.AddWithValue("@Año", año);

                SqlDataReader reader = command.ExecuteReader();

                PdfSharp.Pdf.PdfDocument pdfDocument = new PdfSharp.Pdf.PdfDocument();
                PdfSharp.Pdf.PdfPage pdfPage = pdfDocument.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Arial", 12, XFontStyleEx.Regular);
                XFont fontBold = new XFont("Arial", 12, XFontStyleEx.Bold);

                int yPoint = 40;

                // Encabezado de la empresa y empleado
                if (reader.HasRows && reader.Read())
                {
                    gfx.DrawString($"Empresa: {reader["nombre_empresa"]}", fontBold, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                    gfx.DrawString($"RFC: {reader["rfc_empresa"]}", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                    gfx.DrawString($"Direccion: {reader["dominio_fiscal"]}", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 40;

                    string nombreCompleto = $"{reader["Nombre_Empleado"]}";
                    gfx.DrawString($"Empleado: {nombreCompleto}", fontBold, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                    gfx.DrawString($"Cuenta Bancaria: {reader["numero_cuenta"]}", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 40;

                    gfx.DrawString($"Sueldo Bruto: {reader["Sueldo_Bruto"]}", font, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 20;
                    gfx.DrawString($"Sueldo Neto: {reader["Sueldo_Final"]}", fontBold, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                    yPoint += 40;
                }

                // Tablas de percepciones y deducciones
                gfx.DrawString("Percepciones:", fontBold, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                yPoint += 20;

                int startX = 20;
                int rowHeight = 20;
                int cellWidth = 200;

                // Percepciones
                string[] percepciones = { "BonoAsistencia", "Despensa", "Puntualidad", "Vacaciones", "Aguinaldo", "HorasExtras" };
                foreach (var percepcion in percepciones)
                {
                    if (Convert.ToDecimal(reader[percepcion]) > 0)
                    {
                        gfx.DrawRectangle(XPens.Black, startX, yPoint, cellWidth, rowHeight);
                        gfx.DrawString(percepcion, font, XBrushes.Black, new XRect(startX + 5, yPoint + 5, cellWidth, rowHeight), XStringFormats.TopLeft);

                        gfx.DrawRectangle(XPens.Black, startX + cellWidth, yPoint, cellWidth, rowHeight);
                        gfx.DrawString(reader[percepcion].ToString(), font, XBrushes.Black, new XRect(startX + cellWidth + 5, yPoint + 5, cellWidth, rowHeight), XStringFormats.TopLeft);

                        yPoint += rowHeight;
                    }
                }

                yPoint += 20;
                gfx.DrawString("Deducciones:", fontBold, XBrushes.Black, new XRect(20, yPoint, pdfPage.Width, pdfPage.Height), XStringFormats.TopLeft);
                yPoint += 20;

                // Deducciones
                string[] deducciones = { "IMSS", "ISR", "PrestamoINF", "FondoAhorro", "Faltas" };
                foreach (var deduccion in deducciones)
                {
                    if (Convert.ToDecimal(reader[deduccion]) > 0)
                    {
                        gfx.DrawRectangle(XPens.Black, startX, yPoint, cellWidth, rowHeight);
                        gfx.DrawString(deduccion, font, XBrushes.Black, new XRect(startX + 5, yPoint + 5, cellWidth, rowHeight), XStringFormats.TopLeft);

                        gfx.DrawRectangle(XPens.Black, startX + cellWidth, yPoint, cellWidth, rowHeight);
                        gfx.DrawString(reader[deduccion].ToString(), font, XBrushes.Black, new XRect(startX + cellWidth + 5, yPoint + 5, cellWidth, rowHeight), XStringFormats.TopLeft);

                        yPoint += rowHeight;
                    }
                }

                reader.Close();
                pdfDocument.Save(rutaArchivo);
            }

        }

    }

}
