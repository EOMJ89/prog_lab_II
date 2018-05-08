namespace WindowsFormsApp1
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
            this.btnPrueba = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.richTextLista = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPrueba
            // 
            this.btnPrueba.Location = new System.Drawing.Point(182, 12);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(150, 46);
            this.btnPrueba.TabIndex = 0;
            this.btnPrueba.Text = "Prueba Clases";
            this.btnPrueba.UseVisualStyleBackColor = true;
            this.btnPrueba.Click += new System.EventHandler(this.btnPrueba_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(182, 64);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(150, 46);
            this.btnMostrar.TabIndex = 1;
            this.btnMostrar.Text = "Mostrar Salida Por Pantalla";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // richTextLista
            // 
            this.richTextLista.Location = new System.Drawing.Point(12, 116);
            this.richTextLista.Name = "richTextLista";
            this.richTextLista.Size = new System.Drawing.Size(485, 96);
            this.richTextLista.TabIndex = 2;
            this.richTextLista.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 231);
            this.Controls.Add(this.richTextLista);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnPrueba);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrueba;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.RichTextBox richTextLista;
    }
}

