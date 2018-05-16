using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio23_Moneda;


namespace Ejercicio23_Form
{
    public partial class ConversorForm : Form
    {

        public Dolar _dolar;
        public Euro _euro;
        public Peso _peso;

        public ConversorForm()
        {
            InitializeComponent();
        }

        private void btnConvertirEuro_Click(object sender, EventArgs e)
        {
            double euroParsed = 0;

            if (double.TryParse(this.txtBEuro.Text, out euroParsed))
            {
                _euro = new Euro(euroParsed);
                this.txtBEuroEuro.Text = _euro._cantidad.ToString("#.##");
                this.txtBEuroEuro.Enabled = false;
                this.txtBEuroDolar.Text = ((Dolar)_euro)._cantidad.ToString("#.##");
                this.txtBEuroDolar.Enabled = false;
                this.txtBEuroPeso.Text = ((Peso)_euro)._cantidad.ToString("#.##");
                this.txtBEuroPeso.Enabled = false;
            }
        }

        private void btnConvertirDolar_Click(object sender, EventArgs e)
        {
            double dolarParsed = 0;

            if (double.TryParse(this.txtBDolar.Text, out dolarParsed))
            {
                _dolar = new Dolar(dolarParsed);
                this.txtDolarEuro.Text = ((Euro)_dolar)._cantidad.ToString("#.##");
                this.txtDolarEuro.Enabled = false;
                this.txtDolarDolar.Text = _dolar._cantidad.ToString("#.##");
                this.txtDolarDolar.Enabled = false;
                this.txtDolarPeso.Text = ((Peso)_dolar)._cantidad.ToString("#.##");
                this.txtDolarPeso.Enabled = false;
            }
        }

        private void btnConvertirPeso_Click(object sender, EventArgs e)
        {
            double pesoParsed = 0;

            if (double.TryParse(this.txtBPeso.Text, out pesoParsed))
            {
                _peso = new Peso(pesoParsed);
                this.txtBPesoEuro.Text = ((Euro)_peso)._cantidad.ToString("#.##");
                this.txtBPesoEuro.Enabled = false;
                this.txtBPesoDolar.Text = ((Dolar)_peso)._cantidad.ToString("#.##");
                this.txtBPesoDolar.Enabled = false;
                this.txtBPesoPeso.Text = _peso._cantidad.ToString("#.##");
                this.txtBPesoPeso.Enabled = false;
            }
        }
    }
}
