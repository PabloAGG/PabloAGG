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
    public partial class Form_InicioSesion : Form
    {
        public Form_InicioSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void button_Entrar_IS_Click(object sender, EventArgs e)
        {
            string nombreEmpleado = textBox_NombreIS.Text; 
            string contrasena = textBox_ContrasenaIs.Text; 

            if (string.IsNullOrWhiteSpace(nombreEmpleado) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                try
                {
                    string query = "SELECT COUNT(1) FROM Usuario WHERE nombre = @NombreEmpleado AND contraseña = @Contrasena";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@NombreEmpleado", nombreEmpleado);
                        command.Parameters.AddWithValue("@Contrasena", contrasena);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Inicio de sesión exitoso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Abre la ventana principal o redirige al usuario
                            this.Hide();
                            Form1 formPrincipal = new Form1();
                            formPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox_NombreIS_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Salir_IS_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
          "¿Estás seguro de que deseas salir?",
          "Confirmar salida",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 form12 = new Form12();
            form12.Show();  
        }
    }
}
