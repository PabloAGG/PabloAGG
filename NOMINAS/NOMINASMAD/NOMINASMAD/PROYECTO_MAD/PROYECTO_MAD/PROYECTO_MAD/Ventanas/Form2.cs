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
    public partial class Form2_RegistroEmpleados : Form
    {
        public Form2_RegistroEmpleados()
        {
            InitializeComponent();
        }

        
        //------------------------------------------------------------------------------------
        private void button_Registrar_RE_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();

            // Asignar valores a las propiedades de 'empleado'
            empleado.nombreEmpleado = textBox_NombreEmpleado_RegistroEmpleado.Text;
            empleado.apellidoPaterno = textBox_ApellidoPaterno_RE.Text;
            empleado.apellidoMaterno = textBox_ApellidoMaterno_RE.Text;
            empleado.curp = textBox_CURP_RE.Text;
            empleado.nss = textBox_NSS_RE.Text;
            empleado.rfc = textBox_RFC_RE.Text;
            empleado.direccion = textBox_Direccion.Text;
            // Otros datos
            empleado.banco = textBox_Banco_RE.Text;
            empleado.numeroCuenta = textBox_NumeroCuenta_RE.Text;
            empleado.email = textBox_Email_RE.Text;
            empleado.telefono = textBox_Telefono_RE.Text;
            empleado.idPuesto = (int)comboBox_Puesto_RE.SelectedValue;
            empleado.idDepartamento = (int)comboBox_Departamento_RE.SelectedValue;

            empleado.fechaNacimiento = dateTimePicker_FechaNacimiento_RE.Value.Date;

            // Asignar tipo de empleado según selección del radio button
         
                empleado.tipoEmpleado = 0; // Empleado tipo 0
           

            // Establecer las fechas de ingreso y contrato, de acuerdo a los campos de la interfaz
            empleado.fechaIngresoEmpresa = dateTimePicker_FechaIngresoEmpresa_RE.Value.Date;
           

            
            EmpleadoDAO.InsertarEmpleado(empleado);
       
            refrescar();
        }

        //private void Form2_RegistroEmpleados_Load(object sender, EventArgs e)
        //{
        //    dataGridView_RegistroEmpleado.DataSource = EmpleadoDAO.ObtenerEmpleados();
        //}

        private void refrescar()
        {

            dataGridView_RegistroEmpleado.DataSource = EmpleadoDAO.ObtenerEmpleados();

        }

        private void dataGridView_RegistroEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            textBox_NombreEmpleado_RegistroEmpleado.Text = Convert.ToString(dataGridView_RegistroEmpleado.CurrentRow.Cells["id_empleado"].Value);
        }

        private void dataGridView_RegistroEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button_FiltrarID_RE_Click(object sender, EventArgs e)
        //{
            //int idEmpleado = Int32.Parse(txtForm1IDFilter.Text);
            //dataGridView_RegistroEmpleado.DataSource = EmpleadoDAO.ObtenerEmpleados(idEmpleado);
        //}

        private void button_Borrar_RE_Click(object sender, EventArgs e)
        {
            int idEmpleado = Int32.Parse(dataGridView_RegistroEmpleado.SelectedRows[0].Cells[0].Value.ToString());

            EmpleadoDAO.BorrarEmpleado(idEmpleado);
            refrescar();
        }

        //-----------------------------------------------------------------------------------------------lo bueno esta de aca pa abajo
        private void Form2_RegistroEmpleados_Load_1(object sender, EventArgs e)
        {
            dataGridView_RegistroEmpleado.DataSource = EmpleadoDAO.ObtenerEmpleados();

            Random random = new Random();
            int idGenerado = random.Next(100, 1000000);

            // Mostrar el número generado en el TextBox
            txtNumeroEmpleado.Text = idGenerado.ToString();

            List<Puesto> puestos = PuestoDAO.ObtenerPuestos();
            List<Departamento> departamentos = DepartamentoDAO.ObtenerDepartamentos();

            comboBox_Puesto_RE.Items.Clear();
            comboBox_Departamento_RE.Items.Clear();

            // Agregar cada puesto al ComboBox
            for (int i = 0; i < puestos.Count; i++)
            {
                Puesto puesto = puestos[i];  // Obtener el puesto en la posición i

                // Crear un ComboBoxItem para cada puesto
                ComboBoxItem item = new ComboBoxItem
                {
                    Text = puesto.nombrePuesto,  // Nombre del puesto
                    Value = puesto.idPuesto      // ID del puesto
                };

                // Agregar el item al ComboBox
                comboBox_Puesto_RE.Items.Add(item);
            }

            // Establecer qué propiedad se mostrará y qué propiedad se usará como valor
            comboBox_Puesto_RE.DisplayMember = "Text";  // Lo que el usuario ve (nombre del puesto)
            comboBox_Puesto_RE.ValueMember = "Value";  // Lo que se guarda internamente (id_puesto)

            // Agregar cada departamento al ComboBox
            for (int i = 0; i < departamentos.Count; i++)
            {
                Departamento departamento = departamentos[i];  // Obtener el departamento en la posición i

                // Crear un ComboBoxItem para cada departamento
                ComboBoxItem item = new ComboBoxItem
                {
                    Text = departamento.nombreDepartamento,  // Nombre del departamento
                    Value = departamento.idDepartamento      // ID del departamento
                };

                // Agregar el item al ComboBox
                comboBox_Departamento_RE.Items.Add(item);
            }

            // Establecer qué propiedad se mostrará y qué propiedad se usará como valor
            comboBox_Departamento_RE.DisplayMember = "Text";  // Lo que el usuario ve (nombre del departamento)
            comboBox_Departamento_RE.ValueMember = "Value";  // Lo que se guarda internamente (id_departamento)

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_RegistroEmpleado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_Puesto_RE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Registrar_RE_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNumeroEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(textBox_NombreEmpleado_RegistroEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(textBox_ApellidoPaterno_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_ApellidoMaterno_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_CURP_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_NSS_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_RFC_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Direccion.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Banco_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_NumeroCuenta_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Email_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Telefono_RE.Text) ||
                    string.IsNullOrWhiteSpace(textBox_Sueldo.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.",
                                    "Campos incompletos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_Puesto_RE.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un puesto.",
                                    "Puesto requerido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_Departamento_RE.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un departamento.",
                                    "Departamento requerido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Validar que teléfono sea un número entero
                if (!long.TryParse(textBox_Telefono_RE.Text, out long telefono))
                {
                    MessageBox.Show("El teléfono debe ser un número entero.",
                                    "Formato inválido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el número de cuenta sea un número entero
                if (!long.TryParse(textBox_NumeroCuenta_RE.Text, out long numeroCuenta))
                {
                    MessageBox.Show("El número de cuenta debe ser un número entero.",
                                    "Formato inválido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto empleado
                Empleado empleado = new Empleado
                {
                    idEmpleado = int.Parse(txtNumeroEmpleado.Text),
                    nombreEmpleado = textBox_NombreEmpleado_RegistroEmpleado.Text,
                    apellidoPaterno = textBox_ApellidoPaterno_RE.Text,
                    apellidoMaterno = textBox_ApellidoMaterno_RE.Text,
                    curp = textBox_CURP_RE.Text,
                    nss = textBox_NSS_RE.Text,
                    rfc = textBox_RFC_RE.Text,
                    direccion = textBox_Direccion.Text,
                    banco = textBox_Banco_RE.Text,
                    numeroCuenta = textBox_NumeroCuenta_RE.Text,
                    email = textBox_Email_RE.Text,
                    telefono = textBox_Telefono_RE.Text,
                    idPuesto = ((ComboBoxItem)comboBox_Puesto_RE.SelectedItem).Value,
                    idDepartamento = ((ComboBoxItem)comboBox_Departamento_RE.SelectedItem).Value,
                    fechaNacimiento = dateTimePicker_FechaNacimiento_RE.Value.Date,
                    tipoEmpleado = 0, // Asume tipo de empleado 0 (ajusta según lógica de negocio)
                    fechaIngresoEmpresa = dateTimePicker_FechaIngresoEmpresa_RE.Value.Date,
                    sueldo = decimal.Parse(textBox_Sueldo.Text)
                };

                // Insertar el empleado en la base de datos
                EmpleadoDAO.InsertarEmpleado(empleado);

                // Refrescar la vista después del registro
                MessageBox.Show("Empleado registrado con éxito.",
                                "Registro exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                refrescar();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Formato incorrecto en uno de los campos numéricos. Detalles: {ex.Message}",
                                "Error de formato",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar el empleado. Detalles: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }



        private void button_Regresar_RE_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button_FiltrarID_RE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de un Empleado.");
                return;
            }

            if (int.TryParse(textBox1.Text, out int empleadoId))
            {
                if (empleadoId <= 0)
                {
                    MessageBox.Show("Por favor ingrese un ID de empleado válido (positivo).");
                    return;
                }

                // Llamamos a la función ObtenerEmpleados con el ID
                List<Empleado> empleados = EmpleadoDAO.ObtenerEmpleados(empleadoId);

                // Verificamos si se encontró al empleado
                if (empleados != null && empleados.Count > 0)
                {
             
                    Empleado empleado = empleados[0];  // Solo debe haber un resultado, ya que estamos buscando por ID

                    txtNumeroEmpleado.Text = empleado.idEmpleado.ToString();
                    textBox_NombreEmpleado_RegistroEmpleado.Text = empleado.nombreEmpleado;
                    textBox_ApellidoPaterno_RE.Text = empleado.apellidoPaterno;
                    textBox_ApellidoMaterno_RE.Text = empleado.apellidoMaterno;
                    dateTimePicker_FechaNacimiento_RE.Text = empleado.fechaNacimiento.ToShortDateString();
                    textBox_Telefono_RE.Text = empleado.telefono;
                    textBox_CURP_RE.Text = empleado.curp;
                    textBox_NSS_RE.Text = empleado.nss;
                    textBox_RFC_RE.Text = empleado.rfc;
                    textBox_Banco_RE.Text = empleado.banco;
                    textBox_NumeroCuenta_RE.Text = empleado.numeroCuenta;
                    textBox_Email_RE.Text = empleado.email;
                    dateTimePicker_FechaIngresoEmpresa_RE.Text = empleado.fechaIngresoEmpresa.ToShortDateString();
                    textBox_Direccion.Text = empleado.direccion;
                    textBox_Sueldo.Text = empleado.sueldo.ToString (); 


                    List<Puesto> Puestos = PuestoDAO.ObtenerPuestos();

                    comboBox_Puesto_RE.DataSource = Puestos;
                    comboBox_Puesto_RE.DisplayMember = "nombrePuesto";
                    comboBox_Puesto_RE.ValueMember = "idPuesto";

                    // Seleccionar el departamento correcto usando el idDepartamento
                    comboBox_Puesto_RE.SelectedValue = empleado.idPuesto;

                    List<Departamento> departamentos = DepartamentoDAO.ObtenerDepartamentos();

                    comboBox_Departamento_RE.DataSource = departamentos;
                    comboBox_Departamento_RE.DisplayMember = "nombreDepartamento";
                    comboBox_Departamento_RE.ValueMember = "idDepartamento";

                    // Seleccionar el departamento correcto usando el idDepartamento
                    comboBox_Departamento_RE.SelectedValue = empleado.idDepartamento;

                        
                    MessageBox.Show("Empleado encontrado. Informacion Mostrada");
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.");
                }
            }
            else
            {
                // Si no se puede convertir el texto a un número entero, mostrar un mensaje de error
                MessageBox.Show("Por favor ingrese un ID de empleado válido.");
            }
        }

        private void button_Borrar_RE_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingresa un ID de un Empleado.");
                return;
            }

            // Intentar convertir el valor del TextBox a entero
            int empleadoId;
            if (!int.TryParse(textBox1.Text, out empleadoId))
            {
                MessageBox.Show("El ID del Empleado debe ser un número válido.");
                return;
            }

            // Llamar al método BorrarDepartamento de DepartamentoDAO
            EmpleadoDAO.BorrarEmpleado(empleadoId);

            // Mensaje de éxito
            MessageBox.Show("Empleado borrado con éxito.");

            refrescar();
        }

        private void button_Actualizar_RE_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int empleadoId))
            {
                if (empleadoId <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de empleado válido (positivo).");
                    return;
                }

               
                Empleado empleado = new Empleado();

                empleado.idEmpleado = empleadoId;  // El ID lo obtenemos del TextBox
                empleado.nombreEmpleado = textBox_NombreEmpleado_RegistroEmpleado.Text;
                empleado.apellidoPaterno = textBox_ApellidoPaterno_RE.Text;
                empleado.apellidoMaterno = textBox_ApellidoMaterno_RE.Text;
                empleado.fechaNacimiento = DateTime.Parse(dateTimePicker_FechaNacimiento_RE.Text);
           
                empleado.curp = textBox_CURP_RE.Text;
                empleado.rfc = textBox_RFC_RE.Text;
                empleado.nss = textBox_NSS_RE.Text;
                empleado.direccion = textBox_Direccion.Text;
                empleado.banco = textBox_Banco_RE.Text;
                empleado.numeroCuenta = textBox_NumeroCuenta_RE.Text;
                empleado.email = textBox_Email_RE.Text;
                empleado.telefono = textBox_Telefono_RE.Text;
                empleado.fechaIngresoEmpresa = DateTime.Parse(dateTimePicker_FechaIngresoEmpresa_RE.Text);
                
            
                    empleado.tipoEmpleado = 0; // Empleado tipo 0
              empleado.sueldo=decimal.Parse(textBox_Sueldo.Text);


                if (comboBox_Puesto_RE.SelectedItem != null)
                {
                    Puesto selectedPuesto = (Puesto)comboBox_Puesto_RE.SelectedItem;
                    empleado.idPuesto = selectedPuesto.idPuesto;  // Asignar el id_puesto al empleado
                }
                else
                {
                    // Mostrar un mensaje de error si no se seleccionó ningún puesto
                    MessageBox.Show("Por favor, selecciona un puesto.");
                    return; // Salir de la función si no se seleccionó un puesto
                }


                if (comboBox_Departamento_RE.SelectedItem != null)
                {
                    Departamento selectedDepartamento = (Departamento)comboBox_Departamento_RE.SelectedItem;
                    empleado.idDepartamento = selectedDepartamento.idDepartamento;  // Asignar el id_departamento al empleado
                }
                else
                {
                    // Mostrar un mensaje de error si no se seleccionó ningún departamento
                    MessageBox.Show("Por favor, selecciona un departamento.");
                    return; // Salir de la función si no se seleccionó un departamento
                }

                int resultado = EmpleadoDAO.ModificarEmpleado(empleado);

                if (resultado > 0)
                {
                   
                    MessageBox.Show("Empleado actualizado con éxito.");
                    refrescar();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar el empleado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de empleado válido.");
            }
        }

        private void textBox_ApellidoPaterno_RE_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ApellidoMaterno_RE_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox_Direccion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
