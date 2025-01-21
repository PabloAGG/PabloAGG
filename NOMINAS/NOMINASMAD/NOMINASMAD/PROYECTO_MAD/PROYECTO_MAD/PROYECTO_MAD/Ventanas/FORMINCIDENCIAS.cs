using PROYECTO_MAD.DAO;
using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_MAD.Ventanas
{
    public partial class FORMINCIDENCIAS : Form
    {
        public FORMINCIDENCIAS()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void CargarComboBoxEmpleados(int mes, int año)
        {
            List<Empleado> empleados = EmpleadoDAO.ObtenerEmpleadosFecha(mes, año);

            comboBox_IDEmpleado_CN.DataSource = empleados;
            comboBox_IDEmpleado_CN.DisplayMember = "NombreCompleto";
            comboBox_IDEmpleado_CN.ValueMember = "idEmpleado";
        }

   

        private void FORMINCIDENCIAS_Load(object sender, EventArgs e)
        {
            
            Periodo ultimoPeriodo =PeriodoDao.ObtenerUltimoPeriodo();

            if (ultimoPeriodo != null)
            {
                textBox_periodo.Text = ultimoPeriodo.idPeriodo.ToString();
                txtMes.Text = ultimoPeriodo.mes.ToString();
                txtAnio.Text = ultimoPeriodo.año.ToString();
                CargarComboBoxEmpleados(ultimoPeriodo.mes, ultimoPeriodo.año);
                if (ultimoPeriodo.mes == 12)
                {
                    inc_aguinaldo.Enabled = true;
                   
                    
                }
                else
                {
                    inc_aguinaldo.Text = 0.00.ToString();

                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "No se encontró ningún período registrado. ¿Desea regresar al menú principal?",
                    "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Asumiendo que estás en un formulario llamado 'IncidenciasForm'
                    this.Hide(); // Oculta la pantalla actual
                    Form1 menu = new Form1(); // Instancia de la pantalla principal
                    menu.Show(); // Muestra la pantalla principal
                }
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            try
            {
                int idperiodo = int.Parse(textBox_periodo.Text);
                int faltas = int.Parse(inc_faltas.Text);
                int vacaciones = int.Parse(inc_vacaciones.Text);
                decimal aguinaldo = decimal.Parse(inc_aguinaldo.Text);
                int horasextra = int.Parse(inc_horase.Text);
                int idempleado = 0;
                decimal vacacionesfinal = 0;
                decimal horasextrafinal = 0;
                decimal aguinaldofinal = 0;
                decimal horas = 0;

                if (comboBox_IDEmpleado_CN.SelectedItem != null)
                {
                    Empleado selectedEmpleado = (Empleado)comboBox_IDEmpleado_CN.SelectedItem;
                    idempleado = selectedEmpleado.idEmpleado; // Asigna el ID del empleado seleccionado.
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Empleado empleado = EmpleadoDAO.ObtenerEmpleadoPorId(idempleado);
                if (empleado != null)
                {
                    const decimal DIAS_PROMEDIO_MES = 30.41m;
                    decimal sueldodiario = empleado.sueldo / DIAS_PROMEDIO_MES;
                    vacacionesfinal = vacaciones * sueldodiario;
                    horas = sueldodiario / 8;
                    aguinaldofinal = aguinaldo * sueldodiario;
                    horasextrafinal = horasextra * horas;

                    using (SqlConnection conexion = BDConexion.ObtenerConexion())
                    {
                        // Define la consulta con parámetros.
                        string query = "EXEC AgregarIncidencias " +
                                       "@id_empleado, " +
                                       "@id_periodo, " +
                                       "@vacaciones, " +
                                       "@aguinaldo, " +
                                       "@horas_extras, " +
                                       "@faltas";

                        // Crea el comando con la consulta.
                        SqlCommand comando = new SqlCommand(query, conexion);

                        // Agrega los parámetros con sus valores.
                        comando.Parameters.AddWithValue("@id_empleado", idempleado);
                        comando.Parameters.AddWithValue("@id_periodo", idperiodo);
                        comando.Parameters.AddWithValue("@vacaciones", vacacionesfinal);
                        comando.Parameters.AddWithValue("@aguinaldo", aguinaldofinal);
                        comando.Parameters.AddWithValue("@horas_extras", horasextrafinal);
                        comando.Parameters.AddWithValue("@faltas", faltas);

                        // Ejecuta el comando.
                        comando.ExecuteNonQuery();

                        // Muestra un mensaje de confirmación.
                        MessageBox.Show("Incidencias registradas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpia los campos después de registrar.
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado. Verifica la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void LimpiarCampos()
        {
            
            inc_faltas.Clear();
            inc_vacaciones.Clear();
            inc_aguinaldo.Clear();
            inc_horase.Clear();
            comboBox_IDEmpleado_CN.SelectedIndex = -1; // Deselecciona cualquier elemento en el comboBox.
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
           this.Hide();
        }
    }
}
