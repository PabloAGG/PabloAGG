namespace PROYECTO_MAD.Ventanas
{
    partial class Form_InicioSesion
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
            this.textBox_NombreIS = new System.Windows.Forms.TextBox();
            this.textBox_ContrasenaIs = new System.Windows.Forms.TextBox();
            this.button_Entrar_IS = new System.Windows.Forms.Button();
            this.button_Salir_IS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // textBox_NombreIS
            // 
            this.textBox_NombreIS.Location = new System.Drawing.Point(210, 82);
            this.textBox_NombreIS.Name = "textBox_NombreIS";
            this.textBox_NombreIS.Size = new System.Drawing.Size(227, 22);
            this.textBox_NombreIS.TabIndex = 2;
            this.textBox_NombreIS.TextChanged += new System.EventHandler(this.textBox_NombreIS_TextChanged);
            // 
            // textBox_ContrasenaIs
            // 
            this.textBox_ContrasenaIs.Location = new System.Drawing.Point(210, 179);
            this.textBox_ContrasenaIs.Name = "textBox_ContrasenaIs";
            this.textBox_ContrasenaIs.PasswordChar = '*';
            this.textBox_ContrasenaIs.Size = new System.Drawing.Size(227, 22);
            this.textBox_ContrasenaIs.TabIndex = 3;
            // 
            // button_Entrar_IS
            // 
            this.button_Entrar_IS.Location = new System.Drawing.Point(265, 270);
            this.button_Entrar_IS.Name = "button_Entrar_IS";
            this.button_Entrar_IS.Size = new System.Drawing.Size(110, 45);
            this.button_Entrar_IS.TabIndex = 4;
            this.button_Entrar_IS.Text = "Iniciar Sesión";
            this.button_Entrar_IS.UseVisualStyleBackColor = true;
            this.button_Entrar_IS.Click += new System.EventHandler(this.button_Entrar_IS_Click);
            // 
            // button_Salir_IS
            // 
            this.button_Salir_IS.Location = new System.Drawing.Point(265, 321);
            this.button_Salir_IS.Name = "button_Salir_IS";
            this.button_Salir_IS.Size = new System.Drawing.Size(110, 45);
            this.button_Salir_IS.TabIndex = 5;
            this.button_Salir_IS.Text = "Salir";
            this.button_Salir_IS.UseVisualStyleBackColor = true;
            this.button_Salir_IS.Click += new System.EventHandler(this.button_Salir_IS_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(514, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Salir_IS);
            this.Controls.Add(this.button_Entrar_IS);
            this.Controls.Add(this.textBox_ContrasenaIs);
            this.Controls.Add(this.textBox_NombreIS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_InicioSesion";
            this.Text = "Inicio de sesión";
            this.Load += new System.EventHandler(this.Form_InicioSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_NombreIS;
        private System.Windows.Forms.TextBox textBox_ContrasenaIs;
        private System.Windows.Forms.Button button_Entrar_IS;
        private System.Windows.Forms.Button button_Salir_IS;
        private System.Windows.Forms.Button button1;
    }
}