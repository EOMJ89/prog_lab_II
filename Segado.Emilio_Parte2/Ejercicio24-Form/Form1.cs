using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio21Classes;

namespace Ejercicio24_Form
{
    public partial class Form1 : Form
    {
        public Fahrenheit _euro;
        public Celsius _dolar;
        public Kelvin _peso;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertirEuro_Click(object sender, EventArgs e)
        {            
                double euroParsed = 0;

                if (double.TryParse(this.txtBEuro.Text, out euroParsed))
                {
                    _euro = new Fahrenheit(euroParsed);
                    this.txtBEuroEuro.Text = _euro._temperatura.ToString("#.##");
                    this.txtBEuroEuro.Enabled = false;
                    this.txtBEuroDolar.Text = ((Celsius)_euro)._temperatura.ToString("#.##");
                    this.txtBEuroDolar.Enabled = false;
                    this.txtBEuroPeso.Text = ((Kelvin)_euro)._temperatura.ToString("#.##");
                    this.txtBEuroPeso.Enabled = false;
                }            
        }

        private void btnConvertirDolar_Click(object sender, EventArgs e)
        {
            double dolarParsed = 0;

            if (double.TryParse(this.txtBDolar.Text, out dolarParsed))
            {
                _dolar = new Celsius(dolarParsed);
                this.txtDolarEuro.Text = ((Fahrenheit)_dolar)._temperatura.ToString("#.##");
                this.txtDolarEuro.Enabled = false;
                this.txtDolarDolar.Text = _dolar._temperatura.ToString("#.##");
                this.txtDolarDolar.Enabled = false;
                this.txtDolarPeso.Text = ((Kelvin)_dolar)._temperatura.ToString("#.##");
                this.txtDolarPeso.Enabled = false;
            }
        }

        private void btnConvertirPeso_Click(object sender, EventArgs e)
        {
            double pesoParsed = 0;

            if (double.TryParse(this.txtBPeso.Text, out pesoParsed))
            {
                _peso = new Kelvin(pesoParsed);
                this.txtBPesoEuro.Text = ((Fahrenheit)_peso)._temperatura.ToString("#.##");
                this.txtBPesoEuro.Enabled = false;
                this.txtBPesoDolar.Text = ((Celsius)_peso)._temperatura.ToString("#.##");
                this.txtBPesoDolar.Enabled = false;
                this.txtBPesoPeso.Text = _peso._temperatura.ToString("#.##");
                this.txtBPesoPeso.Enabled = false;
            }
        }
    }
}
