namespace EjerClase24_Delegados_WindowsForm
{
    partial class frmDatos
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
            this.lblActualizado = new System.Windows.Forms.Label();
            this.pboxImagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lblActualizado
            // 
            this.lblActualizado.Location = new System.Drawing.Point(12, 240);
            this.lblActualizado.Name = "lblActualizado";
            this.lblActualizado.Size = new System.Drawing.Size(260, 13);
            this.lblActualizado.TabIndex = 0;
            this.lblActualizado.Text = "Label";
            this.lblActualizado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pboxImagen
            // 
            this.pboxImagen.Location = new System.Drawing.Point(12, 12);
            this.pboxImagen.Name = "pboxImagen";
            this.pboxImagen.Size = new System.Drawing.Size(260, 225);
            this.pboxImagen.TabIndex = 1;
            this.pboxImagen.TabStop = false;
            // 
            // frmDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pboxImagen);
            this.Controls.Add(this.lblActualizado);
            this.Name = "frmDatos";
            this.Text = "frmDatos";
            ((System.ComponentModel.ISupportInitialize)(this.pboxImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblActualizado;
        private System.Windows.Forms.PictureBox pboxImagen;
    }
}