namespace EjerClase23_Eventos_Calculadora
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
            this.txtBoxPrimerNumero = new System.Windows.Forms.TextBox();
            this.btnDividir = new System.Windows.Forms.Button();
            this.btnPor = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnIgual = new System.Windows.Forms.Button();
            this.gboxOperaciones = new System.Windows.Forms.Panel();
            this.gboxNumericos = new System.Windows.Forms.Panel();
            this.btnUno = new System.Windows.Forms.Button();
            this.btnDos = new System.Windows.Forms.Button();
            this.btnTres = new System.Windows.Forms.Button();
            this.btnCuatro = new System.Windows.Forms.Button();
            this.btnCinco = new System.Windows.Forms.Button();
            this.btnSeis = new System.Windows.Forms.Button();
            this.btnSiete = new System.Windows.Forms.Button();
            this.btnOcho = new System.Windows.Forms.Button();
            this.btnNueve = new System.Windows.Forms.Button();
            this.btnCero = new System.Windows.Forms.Button();
            this.gboxOperaciones.SuspendLayout();
            this.gboxNumericos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxPrimerNumero
            // 
            this.txtBoxPrimerNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPrimerNumero.Location = new System.Drawing.Point(12, 12);
            this.txtBoxPrimerNumero.Name = "txtBoxPrimerNumero";
            this.txtBoxPrimerNumero.Size = new System.Drawing.Size(229, 26);
            this.txtBoxPrimerNumero.TabIndex = 0;
            // 
            // btnDividir
            // 
            this.btnDividir.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDividir.Location = new System.Drawing.Point(171, 3);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(50, 50);
            this.btnDividir.TabIndex = 8;
            this.btnDividir.Text = "\\";
            this.btnDividir.UseVisualStyleBackColor = true;
            // 
            // btnPor
            // 
            this.btnPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPor.Location = new System.Drawing.Point(115, 3);
            this.btnPor.Name = "btnPor";
            this.btnPor.Size = new System.Drawing.Size(50, 50);
            this.btnPor.TabIndex = 7;
            this.btnPor.Text = "*";
            this.btnPor.UseVisualStyleBackColor = true;
            // 
            // btnMenos
            // 
            this.btnMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenos.Location = new System.Drawing.Point(59, 3);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(50, 50);
            this.btnMenos.TabIndex = 6;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = true;
            // 
            // btnMas
            // 
            this.btnMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMas.Location = new System.Drawing.Point(3, 3);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(50, 50);
            this.btnMas.TabIndex = 5;
            this.btnMas.Text = "+";
            this.btnMas.UseVisualStyleBackColor = true;
            // 
            // btnIgual
            // 
            this.btnIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgual.Location = new System.Drawing.Point(15, 280);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(218, 50);
            this.btnIgual.TabIndex = 26;
            this.btnIgual.Text = "=";
            this.btnIgual.UseVisualStyleBackColor = true;
            // 
            // gboxOperaciones
            // 
            this.gboxOperaciones.Controls.Add(this.btnDividir);
            this.gboxOperaciones.Controls.Add(this.btnPor);
            this.gboxOperaciones.Controls.Add(this.btnMas);
            this.gboxOperaciones.Controls.Add(this.btnMenos);
            this.gboxOperaciones.Location = new System.Drawing.Point(12, 44);
            this.gboxOperaciones.Name = "gboxOperaciones";
            this.gboxOperaciones.Size = new System.Drawing.Size(228, 56);
            this.gboxOperaciones.TabIndex = 27;
            // 
            // gboxNumericos
            // 
            this.gboxNumericos.Controls.Add(this.btnCero);
            this.gboxNumericos.Controls.Add(this.btnUno);
            this.gboxNumericos.Controls.Add(this.btnNueve);
            this.gboxNumericos.Controls.Add(this.btnDos);
            this.gboxNumericos.Controls.Add(this.btnOcho);
            this.gboxNumericos.Controls.Add(this.btnTres);
            this.gboxNumericos.Controls.Add(this.btnSiete);
            this.gboxNumericos.Controls.Add(this.btnCuatro);
            this.gboxNumericos.Controls.Add(this.btnSeis);
            this.gboxNumericos.Controls.Add(this.btnCinco);
            this.gboxNumericos.Location = new System.Drawing.Point(12, 106);
            this.gboxNumericos.Name = "gboxNumericos";
            this.gboxNumericos.Size = new System.Drawing.Size(228, 168);
            this.gboxNumericos.TabIndex = 28;
            // 
            // btnUno
            // 
            this.btnUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUno.Location = new System.Drawing.Point(3, 3);
            this.btnUno.Name = "btnUno";
            this.btnUno.Size = new System.Drawing.Size(50, 50);
            this.btnUno.TabIndex = 16;
            this.btnUno.Text = "1";
            this.btnUno.UseVisualStyleBackColor = true;
            // 
            // btnDos
            // 
            this.btnDos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDos.Location = new System.Drawing.Point(59, 3);
            this.btnDos.Name = "btnDos";
            this.btnDos.Size = new System.Drawing.Size(50, 50);
            this.btnDos.TabIndex = 17;
            this.btnDos.Text = "2";
            this.btnDos.UseVisualStyleBackColor = true;
            // 
            // btnTres
            // 
            this.btnTres.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTres.Location = new System.Drawing.Point(115, 3);
            this.btnTres.Name = "btnTres";
            this.btnTres.Size = new System.Drawing.Size(50, 50);
            this.btnTres.TabIndex = 18;
            this.btnTres.Text = "3";
            this.btnTres.UseVisualStyleBackColor = true;
            // 
            // btnCuatro
            // 
            this.btnCuatro.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuatro.Location = new System.Drawing.Point(171, 3);
            this.btnCuatro.Name = "btnCuatro";
            this.btnCuatro.Size = new System.Drawing.Size(50, 50);
            this.btnCuatro.TabIndex = 19;
            this.btnCuatro.Text = "4";
            this.btnCuatro.UseVisualStyleBackColor = true;
            // 
            // btnCinco
            // 
            this.btnCinco.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCinco.Location = new System.Drawing.Point(3, 59);
            this.btnCinco.Name = "btnCinco";
            this.btnCinco.Size = new System.Drawing.Size(50, 50);
            this.btnCinco.TabIndex = 20;
            this.btnCinco.Text = "5";
            this.btnCinco.UseVisualStyleBackColor = true;
            // 
            // btnSeis
            // 
            this.btnSeis.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeis.Location = new System.Drawing.Point(59, 59);
            this.btnSeis.Name = "btnSeis";
            this.btnSeis.Size = new System.Drawing.Size(50, 50);
            this.btnSeis.TabIndex = 21;
            this.btnSeis.Text = "6";
            this.btnSeis.UseVisualStyleBackColor = true;
            // 
            // btnSiete
            // 
            this.btnSiete.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiete.Location = new System.Drawing.Point(115, 59);
            this.btnSiete.Name = "btnSiete";
            this.btnSiete.Size = new System.Drawing.Size(50, 50);
            this.btnSiete.TabIndex = 22;
            this.btnSiete.Text = "7";
            this.btnSiete.UseVisualStyleBackColor = true;
            // 
            // btnOcho
            // 
            this.btnOcho.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcho.Location = new System.Drawing.Point(171, 59);
            this.btnOcho.Name = "btnOcho";
            this.btnOcho.Size = new System.Drawing.Size(50, 50);
            this.btnOcho.TabIndex = 23;
            this.btnOcho.Text = "8";
            this.btnOcho.UseVisualStyleBackColor = true;
            // 
            // btnNueve
            // 
            this.btnNueve.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNueve.Location = new System.Drawing.Point(3, 115);
            this.btnNueve.Name = "btnNueve";
            this.btnNueve.Size = new System.Drawing.Size(50, 50);
            this.btnNueve.TabIndex = 24;
            this.btnNueve.Text = "9";
            this.btnNueve.UseVisualStyleBackColor = true;
            // 
            // btnCero
            // 
            this.btnCero.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCero.Location = new System.Drawing.Point(59, 115);
            this.btnCero.Name = "btnCero";
            this.btnCero.Size = new System.Drawing.Size(50, 50);
            this.btnCero.TabIndex = 25;
            this.btnCero.Text = "0";
            this.btnCero.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 336);
            this.Controls.Add(this.gboxNumericos);
            this.Controls.Add(this.gboxOperaciones);
            this.Controls.Add(this.btnIgual);
            this.Controls.Add(this.txtBoxPrimerNumero);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboxOperaciones.ResumeLayout(false);
            this.gboxNumericos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPrimerNumero;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Button btnPor;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Panel gboxOperaciones;
        private System.Windows.Forms.Panel gboxNumericos;
        private System.Windows.Forms.Button btnCero;
        private System.Windows.Forms.Button btnUno;
        private System.Windows.Forms.Button btnNueve;
        private System.Windows.Forms.Button btnDos;
        private System.Windows.Forms.Button btnOcho;
        private System.Windows.Forms.Button btnTres;
        private System.Windows.Forms.Button btnSiete;
        private System.Windows.Forms.Button btnCuatro;
        private System.Windows.Forms.Button btnSeis;
        private System.Windows.Forms.Button btnCinco;
    }
}

