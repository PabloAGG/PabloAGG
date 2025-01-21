namespace PROYECTO_MAD.Ventanas
{
    partial class ReporteGeneralNomina
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Regresar_RGN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Filtrar_RGN = new System.Windows.Forms.Button();
            this.comboBoxAño = new System.Windows.Forms.ComboBox();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.button_GenerarReporte_RGN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1084, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_Regresar_RGN
            // 
            this.button_Regresar_RGN.Location = new System.Drawing.Point(990, 615);
            this.button_Regresar_RGN.Name = "button_Regresar_RGN";
            this.button_Regresar_RGN.Size = new System.Drawing.Size(151, 55);
            this.button_Regresar_RGN.TabIndex = 1;
            this.button_Regresar_RGN.Text = "Regresar";
            this.button_Regresar_RGN.UseVisualStyleBackColor = true;
            this.button_Regresar_RGN.Click += new System.EventHandler(this.button_Regresar_RGN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mes";
            // 
            // button_Filtrar_RGN
            // 
            this.button_Filtrar_RGN.Location = new System.Drawing.Point(515, 162);
            this.button_Filtrar_RGN.Name = "button_Filtrar_RGN";
            this.button_Filtrar_RGN.Size = new System.Drawing.Size(151, 55);
            this.button_Filtrar_RGN.TabIndex = 6;
            this.button_Filtrar_RGN.Text = "Filtrar";
            this.button_Filtrar_RGN.UseVisualStyleBackColor = true;
            this.button_Filtrar_RGN.Click += new System.EventHandler(this.button_Filtrar_RGN_Click);
            // 
            // comboBoxAño
            // 
            this.comboBoxAño.FormattingEnabled = true;
            this.comboBoxAño.Location = new System.Drawing.Point(541, 60);
            this.comboBoxAño.Name = "comboBoxAño";
            this.comboBoxAño.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAño.TabIndex = 7;
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(543, 109);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMes.TabIndex = 8;
            // 
            // button_GenerarReporte_RGN
            // 
            this.button_GenerarReporte_RGN.Location = new System.Drawing.Point(515, 615);
            this.button_GenerarReporte_RGN.Name = "button_GenerarReporte_RGN";
            this.button_GenerarReporte_RGN.Size = new System.Drawing.Size(151, 55);
            this.button_GenerarReporte_RGN.TabIndex = 9;
            this.button_GenerarReporte_RGN.Text = "Generar Reporte";
            this.button_GenerarReporte_RGN.UseVisualStyleBackColor = true;
            this.button_GenerarReporte_RGN.Click += new System.EventHandler(this.button_GenerarReporte_RGN_Click);
            // 
            // ReporteGeneralNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 711);
            this.Controls.Add(this.button_GenerarReporte_RGN);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.comboBoxAño);
            this.Controls.Add(this.button_Filtrar_RGN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Regresar_RGN);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ReporteGeneralNomina";
            this.Text = "Reporte General de Nomina";
            this.Load += new System.EventHandler(this.ReporteGeneralNomina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Regresar_RGN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Filtrar_RGN;
        private System.Windows.Forms.ComboBox comboBoxAño;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.Button button_GenerarReporte_RGN;
    }
}