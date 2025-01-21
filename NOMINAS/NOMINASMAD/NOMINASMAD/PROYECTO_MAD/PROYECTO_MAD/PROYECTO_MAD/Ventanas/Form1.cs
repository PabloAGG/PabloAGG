using System;
using System.Windows.Forms;

namespace PROYECTO_MAD.Ventanas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insertarUsuarioBtn_Click(object sender, EventArgs e)
        {
            // Verifica que Form2 esté correctamente creado
            Form2_RegistroEmpleados form2 = new Form2_RegistroEmpleados();

            // Muestra Form2
            form2.Show();

            // Cierra Form1 si es necesario
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica que Form5 esté correctamente creado
            Form5_RegistroPuestos form5 = new Form5_RegistroPuestos();

            // Muestra Form5
            form5.Show();

            // Cierra Form1 si es necesario
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4_RegistroDepartamentos form4 = new Form4_RegistroDepartamentos();

            // Muestra Form4
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FORMINCIDENCIAS form = new FORMINCIDENCIAS();  
            form.Show();
          
        }

        private void button_SalirMenuPrincipal_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                 "¿Estás seguro de cerrar tu sesión?",
                 "Confirmar salida",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Nominas_Click(object sender, EventArgs e)
        {
            FormCalculoGral form7 = new FormCalculoGral();

            form7.Show();
        }

        private void button_ReporteGeneralNomina_Click(object sender, EventArgs e)
        {
            ReporteGeneralNomina form12 = new ReporteGeneralNomina();

            form12.Show();
        }

        private void button_ReporteHeadcounter_Click(object sender, EventArgs e)
        {
            ReporteHeadcounter form13 = new ReporteHeadcounter();

            form13.Show();
        }
    }
}
