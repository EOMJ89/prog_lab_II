namespace EjerClase19_Forms
{
    partial class Form1
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.cboPuesto = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnTraer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(62, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(62, 34);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(12, 37);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(12, 67);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(40, 13);
            this.lblPuesto.TabIndex = 4;
            this.lblPuesto.Text = "Puesto";
            // 
            // cboPuesto
            // 
            this.cboPuesto.FormattingEnabled = true;
            this.cboPuesto.Location = new System.Drawing.Point(62, 64);
            this.cboPuesto.Name = "cboPuesto";
            this.cboPuesto.Size = new System.Drawing.Size(121, 21);
            this.cboPuesto.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 114);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnTraer
            // 
            this.btnTraer.Location = new System.Drawing.Point(108, 114);
            this.btnTraer.Name = "btnTraer";
            this.btnTraer.Size = new System.Drawing.Size(75, 23);
            this.btnTraer.TabIndex = 7;
            this.btnTraer.Text = "&Traer";
            this.btnTraer.UseVisualStyleBackColor = true;
            this.btnTraer.Click += new System.EventHandler(this.btnTraer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 145);
            this.Controls.Add(this.btnTraer);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboPuesto);
            this.Controls.Add(this.lblPuesto);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "Form1";
            this.Text = "FrmJugador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cboPuesto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnTraer;
    }
}

