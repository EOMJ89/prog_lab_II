namespace EjerClase24_Delegados_WindowsForm
{
    partial class formTestDelegados
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
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.Imagen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(12, 12);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(268, 20);
            this.txtTexto.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(12, 62);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(268, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(12, 33);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(268, 23);
            this.Imagen.TabIndex = 2;
            this.Imagen.Text = "Imagen";
            this.Imagen.UseVisualStyleBackColor = true;
            this.Imagen.Click += new System.EventHandler(this.Imagen_Click);
            // 
            // formTestDelegados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 97);
            this.Controls.Add(this.Imagen);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtTexto);
            this.Name = "formTestDelegados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formTestDelegados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button Imagen;
    }
}