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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROYECTO_MAD.Ventanas
{
    public partial class Form4_RegistroDepartamentos : Form
    {
        public Form4_RegistroDepartamentos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refrescar()
        {
            dataGridView_RegistroDepartamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();
        }

        private void Form4_RegistroDepartamentos_Load(object sender, EventArgs e)
        {
            // Cargar departamentos en el DataGridView
            dataGridView_RegistroDepartamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();

            // Obtener la lista de percepciones y deducciones
          
        }

        private void button_Regresar_RD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Registrar_RD_Click(object sender, EventArgs e)
        {
            // Cargar departamentos en el DataGridView

            dataGridView_RegistroDepartamento.DataSource = DepartamentoDAO.ObtenerDepartamentos();

            // Obtener la lista de percepciones y deducciones


          

         


            // Verificar que el campo de nombre del departamento no esté vacío

            if (string.IsNullOrEmpty(textBox_NombreDepartamento_RD.Text))

            {

                MessageBox.Show("Por favor ingrese un nombre para el departamento.");

                return;

            }

            // Verificar que el sueldo base diario sea un valor válido

           
            // Obtener el id de la percepción/deducción seleccionada del ComboBox

            if (textBox_NombreDepartamento_RD.Text != null)

            {

             

                if (textBox_NombreDepartamento_RD.Text != null)

                {

                    // Crear un nuevo objeto departamento

                    Departamento departamento = new Departamento

                    {

                        nombreDepartamento = textBox_NombreDepartamento_RD.Text,

                 

                        idEmpresa = 1,  // Suponiendo que el idEmpresa es constante o se obtiene de algún lado

                      

                    };

                    // Llamar al método para insertar el departamento

                    int resultado = DepartamentoDAO.InsertarDepartamento(departamento);

                    refrescar();  // Suponiendo que este método actualiza la vista después de la inserción

                    // Comprobar el resultado y dar feedback al usuario

                    if (resultado > 0)

                    {

                        MessageBox.Show("Departamento registrado con éxito.");

                    }

                    else

                    {

                        MessageBox.Show("Hubo un error al registrar el departamento.");

                    }

                }

               

            }

           


        }

        private void button_Borrar_RD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Filtrar_Departamentos.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de un Departamento.");
                return;
            }

            // Intentar convertir el valor del TextBox a entero
            int departamentoId;
            if (!int.TryParse(textBox_Filtrar_Departamentos.Text, out departamentoId))
            {
                MessageBox.Show("El ID del Departamento debe ser un número válido.");
                return;
            }

            int puestosRelacionados = DepartamentoDAO.ContarPuestosPorDepartamento(departamentoId);
            if (puestosRelacionados > 0)
            {
                MessageBox.Show($"No se puede eliminar el departamento porque tiene {puestosRelacionados} puesto(s) asociado(s).");
                return;
            }

            // Llamar al método BorrarDepartamento de DepartamentoDAO
            DepartamentoDAO.BorrarDepartamento(departamentoId);

            // Mensaje de éxito
            MessageBox.Show("Departamento borrado con éxito.");

            refrescar();
        }

        private void button_FiltrarID_RD_Click(object sender, EventArgs e)
        {
            // Verificar si el valor ingresado es un número válido
            if (int.TryParse(textBox_Filtrar_Departamentos.Text, out int departamentoId))
            {
                // Comprobar que el ID sea positivo
                if (departamentoId <= 0)
                {
                    MessageBox.Show("Por favor ingrese un ID de Departamento válido (positivo).");
                    return;
                }

                // Obtener los departamentos filtrados por ID
                List<Departamento> departamentos = DepartamentoDAO.ObtenerDepartamentosPorID(departamentoId);

                // Verificar si se encontró algún departamento con el ID proporcionado
                if (departamentos != null && departamentos.Count > 0)
                {
                    // Tomar el primer departamento de la lista (ya que se supone que el ID es único)
                    Departamento departamento = departamentos[0];

                    // Mostrar los datos del departamento en los controles de la interfaz
                    textBox_NombreDepartamento_RD.Text = departamento.nombreDepartamento;

                    // Actualizar el ComboBox con la lista de percepciones/deducciones disponibles
                    

                    // Si quieres seleccionar automáticamente el valor correspondiente (por ejemplo, por ID o nombre):
                    // comboBox_PercepcionDeduccion.SelectedItem = departamento.nombrePercepcionDeduccion; // O algún criterio similar

                }
                else
                {
                    // Si no se encuentra el departamento, mostrar mensaje
                    MessageBox.Show("No se encontró el departamento con el ID proporcionado.");
                }
            }
            else
            {
                // Si el valor ingresado no es un número, mostrar mensaje de error
                MessageBox.Show("Por favor, ingresa un ID de un Departamento válido.");
            }
        }

        private void button_Actualizar_Departamento_Click(object sender, EventArgs e)
        {
            // Verificar que el campo de ID del departamento sea válido
            if (int.TryParse(textBox_Filtrar_Departamentos.Text, out int idDepartamento))
            {
                if (idDepartamento <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de departamento válido (positivo).");
                    return;
                }

                // Verificar que el nombre del departamento no esté vacío
                if (string.IsNullOrEmpty(textBox_NombreDepartamento_RD.Text))
                {
                    MessageBox.Show("Por favor ingrese un nombre para el departamento.");
                    return;
                }

                // Verificar que el sueldo base diario sea un valor válido
              

                // Obtener el id de la percepción/deducción seleccionada del ComboBox
                if (textBox_NombreDepartamento_RD.Text != null)
                {
                    // Buscar la percepción/deducción en la lista para obtener su id
                    

                    if (textBox_NombreDepartamento_RD.Text != null)
                    {
                        // Crear el objeto Departamento con los datos actualizados
                        Departamento departamento = new Departamento
                        {
                            idDepartamento = idDepartamento,  // Asignar el ID del departamento a actualizar
                            nombreDepartamento = textBox_NombreDepartamento_RD.Text,
                        
                            idEmpresa = 1,  // Suponiendo que el idEmpresa es constante o se obtiene de algún lado
                   
                        };

                        // Llamar al método para actualizar el departamento
                        int resultado = DepartamentoDAO.ModificarDepartamento(departamento);

                        // Comprobar el resultado y dar feedback al usuario
                        if (resultado > 0)
                        {
                            MessageBox.Show("Departamento actualizado con éxito.");
                            refrescar();  // Suponiendo que este método actualiza la vista después de la actualización
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error al actualizar el departamento.");
                        }
                    }
                    
                }
              
            }
            else
            {
                // Si el ID no es un número válido, mostrar mensaje de error
                MessageBox.Show("Por favor, ingrese un ID de departamento válido.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
