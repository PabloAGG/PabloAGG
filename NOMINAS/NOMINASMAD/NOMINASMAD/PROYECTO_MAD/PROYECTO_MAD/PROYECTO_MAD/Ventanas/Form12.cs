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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUs = textBox1.Text;
            string contrasena = textBox2.Text;

            if (string.IsNullOrWhiteSpace(nombreUs) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                try
                {
                    string query = "INSERT INTO Usuario(nombre,contraseña) values(@Nombre,@Contrasena);";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreUs);
                        command.Parameters.AddWithValue("@Contrasena", contrasena);

                        int count = Convert.ToInt32(command.ExecuteNonQuery());

                        if (count == 1)
                        {
                            MessageBox.Show("Registro exitoso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Abre la ventana principal o redirige al usuario
                            this.Hide();
                            Form1 formPrincipal = new Form1();
                            formPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_InicioSesion formini = new Form_InicioSesion();
            formini.Show();
        }
    }
}
