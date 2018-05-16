using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio22;

namespace Ejercicio25_Form
{
    public partial class Form1 : Form
    {
        public NumeroBinario _dolar;
        public NumeroDecimal _euro;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertirEuro_Click(object sender, EventArgs e)
        {
            _euro = Conversor.BinarioDecimal(this.txtBEuro.Text);
            this.txtBEuroEuro.Text = _euro._numero.ToString();
            this.txtBEuroEuro.Enabled = false;
        }

        private void btnConvertirDolar_Click(object sender, EventArgs e)
        {
            double numeroParsed = 0;

            if (double.TryParse(this.txtBDolar.Text, out numeroParsed))
            {
                _dolar = new NumeroBinario(this.txtBDolar.Text);
                this.txtDolarEuro.Text = Conversor.DecimalBinario(numeroParsed);
                this.txtDolarEuro.Enabled = false;
            }
        }
    }
}

