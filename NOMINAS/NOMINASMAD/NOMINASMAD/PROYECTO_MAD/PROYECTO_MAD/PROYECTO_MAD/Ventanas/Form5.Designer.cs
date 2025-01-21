namespace PROYECTO_MAD.Ventanas
{
    partial class Form5_RegistroPuestos
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Departamento_RP = new System.Windows.Forms.ComboBox();
            this.textBox_NombrePuesto_RP = new System.Windows.Forms.TextBox();
            this.button_Registrar_RP = new System.Windows.Forms.Button();
            this.dataGridView_RegistroPuestos = new System.Windows.Forms.DataGridView();
            this.button_FiltrarID_RP = new System.Windows.Forms.Button();
            this.button_Borrar_RP = new System.Windows.Forms.Button();
            this.button_Regresar_RP = new System.Windows.Forms.Button();
            this.textBox_Filtrar_Puestos = new System.Windows.Forms.TextBox();
            this.button_Actualizar_Puesto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegistroPuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del puesto";
            // 
            // comboBox_Departamento_RP
            // 
            this.comboBox_Departamento_RP.FormattingEnabled = true;
            this.comboBox_Departamento_RP.Location = new System.Drawing.Point(230, 131);
            this.comboBox_Departamento_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Departamento_RP.Name = "comboBox_Departamento_RP";
            this.comboBox_Departamento_RP.Size = new System.Drawing.Size(183, 24);
            this.comboBox_Departamento_RP.TabIndex = 4;
            // 
            // textBox_NombrePuesto_RP
            // 
            this.textBox_NombrePuesto_RP.Location = new System.Drawing.Point(230, 183);
            this.textBox_NombrePuesto_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_NombrePuesto_RP.Name = "textBox_NombrePuesto_RP";
            this.textBox_NombrePuesto_RP.Size = new System.Drawing.Size(183, 22);
            this.textBox_NombrePuesto_RP.TabIndex = 5;
            // 
            // button_Registrar_RP
            // 
            this.button_Registrar_RP.Location = new System.Drawing.Point(173, 278);
            this.button_Registrar_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Registrar_RP.Name = "button_Registrar_RP";
            this.button_Registrar_RP.Size = new System.Drawing.Size(115, 49);
            this.button_Registrar_RP.TabIndex = 8;
            this.button_Registrar_RP.Text = "Registrar";
            this.button_Registrar_RP.UseVisualStyleBackColor = true;
            this.button_Registrar_RP.Click += new System.EventHandler(this.button_Registrar_RP_Click);
            // 
            // dataGridView_RegistroPuestos
            // 
            this.dataGridView_RegistroPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RegistroPuestos.Location = new System.Drawing.Point(468, 64);
            this.dataGridView_RegistroPuestos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_RegistroPuestos.Name = "dataGridView_RegistroPuestos";
            this.dataGridView_RegistroPuestos.RowHeadersWidth = 51;
            this.dataGridView_RegistroPuestos.RowTemplate.Height = 24;
            this.dataGridView_RegistroPuestos.Size = new System.Drawing.Size(820, 246);
            this.dataGridView_RegistroPuestos.TabIndex = 9;
            this.dataGridView_RegistroPuestos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RegistroPuestos_CellContentClick);
            // 
            // button_FiltrarID_RP
            // 
            this.button_FiltrarID_RP.Location = new System.Drawing.Point(468, 331);
            this.button_FiltrarID_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_FiltrarID_RP.Name = "button_FiltrarID_RP";
            this.button_FiltrarID_RP.Size = new System.Drawing.Size(115, 49);
            this.button_FiltrarID_RP.TabIndex = 10;
            this.button_FiltrarID_RP.Text = "Filtrar ID";
            this.button_FiltrarID_RP.UseVisualStyleBackColor = true;
            this.button_FiltrarID_RP.Click += new System.EventHandler(this.button_FiltrarID_RP_Click);
            // 
            // button_Borrar_RP
            // 
            this.button_Borrar_RP.Location = new System.Drawing.Point(1052, 331);
            this.button_Borrar_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Borrar_RP.Name = "button_Borrar_RP";
            this.button_Borrar_RP.Size = new System.Drawing.Size(115, 49);
            this.button_Borrar_RP.TabIndex = 11;
            this.button_Borrar_RP.Text = "Borrar";
            this.button_Borrar_RP.UseVisualStyleBackColor = true;
            this.button_Borrar_RP.Click += new System.EventHandler(this.button_Borrar_RP_Click);
            // 
            // button_Regresar_RP
            // 
            this.button_Regresar_RP.Location = new System.Drawing.Point(1173, 331);
            this.button_Regresar_RP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Regresar_RP.Name = "button_Regresar_RP";
            this.button_Regresar_RP.Size = new System.Drawing.Size(115, 49);
            this.button_Regresar_RP.TabIndex = 12;
            this.button_Regresar_RP.Text = "Regresar";
            this.button_Regresar_RP.UseVisualStyleBackColor = true;
            this.button_Regresar_RP.Click += new System.EventHandler(this.button_Regresar_RP_Click);
            // 
            // textBox_Filtrar_Puestos
            // 
            this.textBox_Filtrar_Puestos.Location = new System.Drawing.Point(607, 344);
            this.textBox_Filtrar_Puestos.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Filtrar_Puestos.Name = "textBox_Filtrar_Puestos";
            this.textBox_Filtrar_Puestos.Size = new System.Drawing.Size(132, 22);
            this.textBox_Filtrar_Puestos.TabIndex = 13;
            // 
            // button_Actualizar_Puesto
            // 
            this.button_Actualizar_Puesto.Location = new System.Drawing.Point(931, 331);
            this.button_Actualizar_Puesto.Name = "button_Actualizar_Puesto";
            this.button_Actualizar_Puesto.Size = new System.Drawing.Size(115, 49);
            this.button_Actualizar_Puesto.TabIndex = 14;
            this.button_Actualizar_Puesto.Text = "Actualizar";
            this.button_Actualizar_Puesto.UseVisualStyleBackColor = true;
            this.button_Actualizar_Puesto.Click += new System.EventHandler(this.button_Actualizar_Puesto_Click);
            // 
            // Form5_RegistroPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 424);
            this.Controls.Add(this.button_Actualizar_Puesto);
            this.Controls.Add(this.textBox_Filtrar_Puestos);
            this.Controls.Add(this.button_Regresar_RP);
            this.Controls.Add(this.button_Borrar_RP);
            this.Controls.Add(this.button_FiltrarID_RP);
            this.Controls.Add(this.dataGridView_RegistroPuestos);
            this.Controls.Add(this.button_Registrar_RP);
            this.Controls.Add(this.textBox_NombrePuesto_RP);
            this.Controls.Add(this.comboBox_Departamento_RP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form5_RegistroPuestos";
            this.Text = "Registro de puestos";
            this.Load += new System.EventHandler(this.Form5_RegistroPuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegistroPuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Departamento_RP;
        private System.Windows.Forms.TextBox textBox_NombrePuesto_RP;
        private System.Windows.Forms.Button button_Registrar_RP;
        private System.Windows.Forms.DataGridView dataGridView_RegistroPuestos;
        private System.Windows.Forms.Button button_FiltrarID_RP;
        private System.Windows.Forms.Button button_Borrar_RP;
        private System.Windows.Forms.Button button_Regresar_RP;
        private System.Windows.Forms.TextBox textBox_Filtrar_Puestos;
        private System.Windows.Forms.Button button_Actualizar_Puesto;
    }
}