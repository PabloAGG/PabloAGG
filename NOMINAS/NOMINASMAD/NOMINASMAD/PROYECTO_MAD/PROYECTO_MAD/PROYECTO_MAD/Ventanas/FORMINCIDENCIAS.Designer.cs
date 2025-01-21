namespace PROYECTO_MAD.Ventanas
{
    partial class FORMINCIDENCIAS
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
            this.textBox_periodo = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_IDEmpleado_CN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inc_faltas = new System.Windows.Forms.TextBox();
            this.inc_horase = new System.Windows.Forms.TextBox();
            this.inc_aguinaldo = new System.Windows.Forms.TextBox();
            this.inc_vacaciones = new System.Windows.Forms.TextBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_periodo
            // 
            this.textBox_periodo.Location = new System.Drawing.Point(192, 17);
            this.textBox_periodo.Name = "textBox_periodo";
            this.textBox_periodo.ReadOnly = true;
            this.textBox_periodo.Size = new System.Drawing.Size(100, 20);
            this.textBox_periodo.TabIndex = 0;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(192, 97);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.ReadOnly = true;
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 1;
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(192, 59);
            this.txtMes.Name = "txtMes";
            this.txtMes.ReadOnly = true;
            this.txtMes.Size = new System.Drawing.Size(100, 20);
            this.txtMes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Periodo activo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Año";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBox_IDEmpleado_CN
            // 
            this.comboBox_IDEmpleado_CN.FormattingEnabled = true;
            this.comboBox_IDEmpleado_CN.Location = new System.Drawing.Point(192, 137);
            this.comboBox_IDEmpleado_CN.Name = "comboBox_IDEmpleado_CN";
            this.comboBox_IDEmpleado_CN.Size = new System.Drawing.Size(121, 21);
            this.comboBox_IDEmpleado_CN.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empleado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Faltas (Dias)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Vacaciones (Dias)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Horas extra";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Aguinaldo";
            // 
            // inc_faltas
            // 
            this.inc_faltas.Location = new System.Drawing.Point(192, 172);
            this.inc_faltas.Name = "inc_faltas";
            this.inc_faltas.Size = new System.Drawing.Size(121, 20);
            this.inc_faltas.TabIndex = 12;
            // 
            // inc_horase
            // 
            this.inc_horase.Location = new System.Drawing.Point(192, 262);
            this.inc_horase.Name = "inc_horase";
            this.inc_horase.Size = new System.Drawing.Size(121, 20);
            this.inc_horase.TabIndex = 13;
            // 
            // inc_aguinaldo
            // 
            this.inc_aguinaldo.Enabled = false;
            this.inc_aguinaldo.Location = new System.Drawing.Point(192, 232);
            this.inc_aguinaldo.Name = "inc_aguinaldo";
            this.inc_aguinaldo.Size = new System.Drawing.Size(121, 20);
            this.inc_aguinaldo.TabIndex = 14;
            // 
            // inc_vacaciones
            // 
            this.inc_vacaciones.Location = new System.Drawing.Point(192, 203);
            this.inc_vacaciones.Name = "inc_vacaciones";
            this.inc_vacaciones.Size = new System.Drawing.Size(121, 20);
            this.inc_vacaciones.TabIndex = 15;
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(327, 304);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 16;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(45, 304);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 17;
            this.btn_back.Text = "Regresar";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // FORMINCIDENCIAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 357);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.inc_vacaciones);
            this.Controls.Add(this.inc_aguinaldo);
            this.Controls.Add(this.inc_horase);
            this.Controls.Add(this.inc_faltas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_IDEmpleado_CN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.textBox_periodo);
            this.Name = "FORMINCIDENCIAS";
            this.Text = "FORMINCIDENCIAS";
            this.Load += new System.EventHandler(this.FORMINCIDENCIAS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_periodo;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_IDEmpleado_CN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inc_faltas;
        private System.Windows.Forms.TextBox inc_horase;
        private System.Windows.Forms.TextBox inc_aguinaldo;
        private System.Windows.Forms.TextBox inc_vacaciones;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Button btn_back;
    }
}