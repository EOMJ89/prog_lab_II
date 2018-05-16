namespace Ejercicio25_Form
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
            this.txtDolarEuro = new System.Windows.Forms.TextBox();
            this.txtBEuroEuro = new System.Windows.Forms.TextBox();
            this.btnConvertirDolar = new System.Windows.Forms.Button();
            this.btnConvertirEuro = new System.Windows.Forms.Button();
            this.txtBDolar = new System.Windows.Forms.TextBox();
            this.txtBEuro = new System.Windows.Forms.TextBox();
            this.lblDolarLeft = new System.Windows.Forms.Label();
            this.lblEuroLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDolarEuro
            // 
            this.txtDolarEuro.Location = new System.Drawing.Point(295, 39);
            this.txtDolarEuro.Name = "txtDolarEuro";
            this.txtDolarEuro.Size = new System.Drawing.Size(100, 20);
            this.txtDolarEuro.TabIndex = 45;
            // 
            // txtBEuroEuro
            // 
            this.txtBEuroEuro.Location = new System.Drawing.Point(295, 6);
            this.txtBEuroEuro.Name = "txtBEuroEuro";
            this.txtBEuroEuro.Size = new System.Drawing.Size(100, 20);
            this.txtBEuroEuro.TabIndex = 44;
            // 
            // btnConvertirDolar
            // 
            this.btnConvertirDolar.Location = new System.Drawing.Point(214, 37);
            this.btnConvertirDolar.Name = "btnConvertirDolar";
            this.btnConvertirDolar.Size = new System.Drawing.Size(75, 23);
            this.btnConvertirDolar.TabIndex = 43;
            this.btnConvertirDolar.Text = "->";
            this.btnConvertirDolar.UseVisualStyleBackColor = true;
            this.btnConvertirDolar.Click += new System.EventHandler(this.btnConvertirDolar_Click);
            // 
            // btnConvertirEuro
            // 
            this.btnConvertirEuro.Location = new System.Drawing.Point(214, 4);
            this.btnConvertirEuro.Name = "btnConvertirEuro";
            this.btnConvertirEuro.Size = new System.Drawing.Size(75, 23);
            this.btnConvertirEuro.TabIndex = 42;
            this.btnConvertirEuro.Text = "->";
            this.btnConvertirEuro.UseVisualStyleBackColor = true;
            this.btnConvertirEuro.Click += new System.EventHandler(this.btnConvertirEuro_Click);
            // 
            // txtBDolar
            // 
            this.txtBDolar.Location = new System.Drawing.Point(108, 39);
            this.txtBDolar.Name = "txtBDolar";
            this.txtBDolar.Size = new System.Drawing.Size(100, 20);
            this.txtBDolar.TabIndex = 41;
            // 
            // txtBEuro
            // 
            this.txtBEuro.Location = new System.Drawing.Point(108, 6);
            this.txtBEuro.Name = "txtBEuro";
            this.txtBEuro.Size = new System.Drawing.Size(100, 20);
            this.txtBEuro.TabIndex = 40;
            // 
            // lblDolarLeft
            // 
            this.lblDolarLeft.AutoSize = true;
            this.lblDolarLeft.Location = new System.Drawing.Point(12, 42);
            this.lblDolarLeft.Name = "lblDolarLeft";
            this.lblDolarLeft.Size = new System.Drawing.Size(89, 13);
            this.lblDolarLeft.TabIndex = 38;
            this.lblDolarLeft.Text = "Decimal a Binario";
            // 
            // lblEuroLeft
            // 
            this.lblEuroLeft.AutoSize = true;
            this.lblEuroLeft.Location = new System.Drawing.Point(12, 9);
            this.lblEuroLeft.Name = "lblEuroLeft";
            this.lblEuroLeft.Size = new System.Drawing.Size(89, 13);
            this.lblEuroLeft.TabIndex = 37;
            this.lblEuroLeft.Text = "Binario a Decimal";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 67);
            this.Controls.Add(this.txtDolarEuro);
            this.Controls.Add(this.txtBEuroEuro);
            this.Controls.Add(this.btnConvertirDolar);
            this.Controls.Add(this.btnConvertirEuro);
            this.Controls.Add(this.txtBDolar);
            this.Controls.Add(this.txtBEuro);
            this.Controls.Add(this.lblDolarLeft);
            this.Controls.Add(this.lblEuroLeft);
            this.Name = "Form1";
            this.Text = "Conversor Numero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDolarEuro;
        private System.Windows.Forms.TextBox txtBEuroEuro;
        private System.Windows.Forms.Button btnConvertirDolar;
        private System.Windows.Forms.Button btnConvertirEuro;
        private System.Windows.Forms.TextBox txtBDolar;
        private System.Windows.Forms.TextBox txtBEuro;
        private System.Windows.Forms.Label lblDolarLeft;
        private System.Windows.Forms.Label lblEuroLeft;
    }
}

