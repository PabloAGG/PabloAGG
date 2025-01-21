using PROYECTO_MAD.DAO;
using PROYECTO_MAD.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_MAD.Ventanas
{
    public partial class Form5_RegistroPuestos : Form
    {
        public Form5_RegistroPuestos()
        {
            InitializeComponent();
        }

        private void refrescar()
        {

            dataGridView_RegistroPuestos.DataSource = PuestoDAO.ObtenerPuestos();

        }

        private void Form5_RegistroPuestos_Load(object sender, EventArgs e)
        {
            dataGridView_RegistroPuestos.DataSource = PuestoDAO.ObtenerPuestos();

            List<Departamento> departamentos = DepartamentoDAO.ObtenerDepartamentos();

            comboBox_Departamento_RP.Items.Clear();

            // Agregar cada puesto al ComboBox
            for (int i = 0; i < departamentos.Count; i++)
            {
                Departamento departamento = departamentos[i];  // Obtener el puesto en la posición i

                // Crear un ComboBoxItem para cada puesto
                ComboBoxItem item = new ComboBoxItem
                {
                    Text = departamento.nombreDepartamento,  // Nombre del puesto
                    Value = departamento.idDepartamento      // ID del puesto
                };

                // Agregar el item al ComboBox
                comboBox_Departamento_RP.Items.Add(item);
            }

            // Establecer qué propiedad se mostrará y qué propiedad se usará como valor
            comboBox_Departamento_RP.DisplayMember = "Text";  // Lo que el usuario ve (nombre del puesto)
            comboBox_Departamento_RP.ValueMember = "Value";  // Lo que se guarda internamente (id_puesto)

        }

        private void dataGridView_RegistroPuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Regresar_RP_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button_FiltrarID_RP_Click(object sender, EventArgs e)
        {

            // Obtener el ID del puesto desde el TextBox
            if (int.TryParse(textBox_Filtrar_Puestos.Text, out int idPuesto))
            {

                if (idPuesto <= 0)
                {
                    MessageBox.Show("Por favor ingrese un ID de un Puesto válido (positivo).");
                    return;
                }

           
                List<Puesto> puestos = PuestoDAO.ObtenerPuestoPorId(idPuesto);

                if (puestos != null && puestos.Count>0)
                {
                    Puesto puesto = puestos[0];
                    // Mostrar los datos del puesto en los controles
                    textBox_NombrePuesto_RP.Text = puesto.nombrePuesto;
                 


                    List<Departamento> departamentos = DepartamentoDAO.ObtenerDepartamentos(); 

                    comboBox_Departamento_RP.DataSource = departamentos;
                    comboBox_Departamento_RP.DisplayMember = "nombreDepartamento";
                    comboBox_Departamento_RP.ValueMember = "idDepartamento";

                    // Seleccionar el departamento correcto usando el idDepartamento
                    comboBox_Departamento_RP.SelectedValue = puesto.idDepartamento; 
                }
                else
                {
                    // Si no se encuentra el puesto, mostrar mensaje
                    MessageBox.Show("No se encontró un puesto con el ID proporcionado.");
                }
            }
            else
            {
                // Si el valor no es un número válido, mostrar mensaje de error
                MessageBox.Show("Por favor, ingresa un ID de puesto válido.");
            }
        }

        private void button_Registrar_RP_Click(object sender, EventArgs e)
        {
            Puesto puesto = new Puesto();

            puesto.nombrePuesto = textBox_NombrePuesto_RP.Text;

            if (comboBox_Departamento_RP.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox_Departamento_RP.SelectedItem;
                puesto.idDepartamento = selectedItem.Value;

                // Obtener el sueldo base diario del departamento
                Departamento departamento = DepartamentoDAO.ObtenerDepartamentoPorId(puesto.idDepartamento);
                
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un departamento.");
                return;
            }

            int resultado = PuestoDAO.InsertarPuesto(puesto);

            if (resultado > 0)
            {
                MessageBox.Show("Puesto registrado con éxito.");
                refrescar();
            }
            else
            {
                MessageBox.Show("Puesto registrado con éxito.");
                refrescar();
            }
        }


        private void button_Borrar_RP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Filtrar_Puestos.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de un Puesto.");
                return;
            }

            // Intentar convertir el valor del TextBox a entero
            int idPuesto;
            if (!int.TryParse(textBox_Filtrar_Puestos.Text, out idPuesto))
            {
                MessageBox.Show("El ID del Puesto debe ser un número válido.");
                return;
            }

            int empleadosRelacionados = PuestoDAO.ContarEmpleadoPorPuesto(idPuesto);
            if (empleadosRelacionados > 0)
            {
                MessageBox.Show($"No se puede eliminar el Puesto porque tiene {empleadosRelacionados} empleado(s) asigando(s).");
                return;
            }

            // Llamar al método BorrarDepartamento de DepartamentoDAO
            PuestoDAO.EliminarPuesto(idPuesto);

            // Mensaje de éxito
            MessageBox.Show("Puesto borrado con éxito.");

            refrescar();
        }

        private void button_Actualizar_Puesto_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Filtrar_Puestos.Text, out int idPuesto))
            {
                if (idPuesto <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de puesto válido (positivo).");
                    return;
                }

                Puesto puesto = new Puesto();
                puesto.idPuesto = idPuesto;
                puesto.nombrePuesto = textBox_NombrePuesto_RP.Text;
             

                if (comboBox_Departamento_RP.SelectedItem != null)
                {
                    Departamento selectedDepartamento = (Departamento)comboBox_Departamento_RP.SelectedItem;
                    puesto.idDepartamento = selectedDepartamento.idDepartamento;

                    // Obtener el sueldo base diario del departamento
                    Departamento departamento = DepartamentoDAO.ObtenerDepartamentoPorId(puesto.idDepartamento);

                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un departamento.");
                    return;
                }

                int resultado = PuestoDAO.ModificarPuesto(puesto);

                if (resultado > 0)
                {
                    MessageBox.Show("Puesto actualizado con éxito.");
                    refrescar();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar el puesto.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de puesto válido.");
            }
        }


        private void textBox_NivelSalarial_RP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SueldoEspecífico_RP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
