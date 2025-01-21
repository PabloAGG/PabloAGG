namespace PROYECTO_MAD.Ventanas
{
    partial class Form4_RegistroDepartamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NombreDepartamento_RD = new System.Windows.Forms.TextBox();
            this.button_Registrar_RD = new System.Windows.Forms.Button();
            this.dataGridView_RegistroDepartamento = new System.Windows.Forms.DataGridView();
            this.button_FiltrarID_RD = new System.Windows.Forms.Button();
            this.button_Borrar_RD = new System.Windows.Forms.Button();
            this.button_Regresar_RD = new System.Windows.Forms.Button();
            this.textBox_Filtrar_Departamentos = new System.Windows.Forms.TextBox();
            this.button_Actualizar_Departamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegistroDepartamento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del departamento";
            // 
            // textBox_NombreDepartamento_RD
            // 
            this.textBox_NombreDepartamento_RD.Location = new System.Drawing.Point(33, 98);
            this.textBox_NombreDepartamento_RD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_NombreDepartamento_RD.Name = "textBox_NombreDepartamento_RD";
            this.textBox_NombreDepartamento_RD.Size = new System.Drawing.Size(166, 20);
            this.textBox_NombreDepartamento_RD.TabIndex = 2;
            // 
            // button_Registrar_RD
            // 
            this.button_Registrar_RD.Location = new System.Drawing.Point(71, 287);
            this.button_Registrar_RD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Registrar_RD.Name = "button_Registrar_RD";
            this.button_Registrar_RD.Size = new System.Drawing.Size(85, 39);
            this.button_Registrar_RD.TabIndex = 4;
            this.button_Registrar_RD.Text = "Registrar";
            this.button_Registrar_RD.UseVisualStyleBackColor = true;
            this.button_Registrar_RD.Click += new System.EventHandler(this.button_Registrar_RD_Click);
            // 
            // dataGridView_RegistroDepartamento
            // 
            this.dataGridView_RegistroDepartamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RegistroDepartamento.Location = new System.Drawing.Point(230, 79);
            this.dataGridView_RegistroDepartamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_RegistroDepartamento.Name = "dataGridView_RegistroDepartamento";
            this.dataGridView_RegistroDepartamento.RowHeadersWidth = 51;
            this.dataGridView_RegistroDepartamento.RowTemplate.Height = 24;
            this.dataGridView_RegistroDepartamento.Size = new System.Drawing.Size(527, 194);
            this.dataGridView_RegistroDepartamento.TabIndex = 5;
            this.dataGridView_RegistroDepartamento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_FiltrarID_RD
            // 
            this.button_FiltrarID_RD.Location = new System.Drawing.Point(230, 287);
            this.button_FiltrarID_RD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_FiltrarID_RD.Name = "button_FiltrarID_RD";
            this.button_FiltrarID_RD.Size = new System.Drawing.Size(85, 39);
            this.button_FiltrarID_RD.TabIndex = 6;
            this.button_FiltrarID_RD.Text = "Filtrar ID";
            this.button_FiltrarID_RD.UseVisualStyleBackColor = true;
            this.button_FiltrarID_RD.Click += new System.EventHandler(this.button_FiltrarID_RD_Click);
            // 
            // button_Borrar_RD
            // 
            this.button_Borrar_RD.Location = new System.Drawing.Point(586, 287);
            this.button_Borrar_RD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Borrar_RD.Name = "button_Borrar_RD";
            this.button_Borrar_RD.Size = new System.Drawing.Size(85, 39);
            this.button_Borrar_RD.TabIndex = 7;
            this.button_Borrar_RD.Text = "Borrar";
            this.button_Borrar_RD.UseVisualStyleBackColor = true;
            this.button_Borrar_RD.Click += new System.EventHandler(this.button_Borrar_RD_Click);
            // 
            // button_Regresar_RD
            // 
            this.button_Regresar_RD.Location = new System.Drawing.Point(675, 287);
            this.button_Regresar_RD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Regresar_RD.Name = "button_Regresar_RD";
            this.button_Regresar_RD.Size = new System.Drawing.Size(82, 39);
            this.button_Regresar_RD.TabIndex = 8;
            this.button_Regresar_RD.Text = "Regresar";
            this.button_Regresar_RD.UseVisualStyleBackColor = true;
            this.button_Regresar_RD.Click += new System.EventHandler(this.button_Regresar_RD_Click);
            // 
            // textBox_Filtrar_Departamentos
            // 
            this.textBox_Filtrar_Departamentos.Location = new System.Drawing.Point(320, 297);
            this.textBox_Filtrar_Departamentos.Name = "textBox_Filtrar_Departamentos";
            this.textBox_Filtrar_Departamentos.Size = new System.Drawing.Size(100, 20);
            this.textBox_Filtrar_Departamentos.TabIndex = 9;
            // 
            // button_Actualizar_Departamento
            // 
            this.button_Actualizar_Departamento.Location = new System.Drawing.Point(496, 287);
            this.button_Actualizar_Departamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Actualizar_Departamento.Name = "button_Actualizar_Departamento";
            this.button_Actualizar_Departamento.Size = new System.Drawing.Size(85, 39);
            this.button_Actualizar_Departamento.TabIndex = 10;
            this.button_Actualizar_Departamento.Text = "Actualizar";
            this.button_Actualizar_Departamento.UseVisualStyleBackColor = true;
            this.button_Actualizar_Departamento.Click += new System.EventHandler(this.button_Actualizar_Departamento_Click);
            // 
            // Form4_RegistroDepartamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 366);
            this.Controls.Add(this.button_Actualizar_Departamento);
            this.Controls.Add(this.textBox_Filtrar_Departamentos);
            this.Controls.Add(this.button_Regresar_RD);
            this.Controls.Add(this.button_Borrar_RD);
            this.Controls.Add(this.button_FiltrarID_RD);
            this.Controls.Add(this.dataGridView_RegistroDepartamento);
            this.Controls.Add(this.button_Registrar_RD);
            this.Controls.Add(this.textBox_NombreDepartamento_RD);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form4_RegistroDepartamentos";
            this.Text = "Registro de departamentos";
            this.Load += new System.EventHandler(this.Form4_RegistroDepartamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegistroDepartamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NombreDepartamento_RD;
        private System.Windows.Forms.Button button_Registrar_RD;
        private System.Windows.Forms.DataGridView dataGridView_RegistroDepartamento;
        private System.Windows.Forms.Button button_FiltrarID_RD;
        private System.Windows.Forms.Button button_Borrar_RD;
        private System.Windows.Forms.Button button_Regresar_RD;
        private System.Windows.Forms.TextBox textBox_Filtrar_Departamentos;
        private System.Windows.Forms.Button button_Actualizar_Departamento;
    }
}