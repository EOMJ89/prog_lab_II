using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CosaSpace;

namespace EjerClase04_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numero = this.textBoxNumero.Text;
            string cadena = this.textBoxCadena.Text;
            string fecha = this.textBoxFecha.Text;
            int numeroParsed = 0;
            DateTime fechaParsed = new DateTime();
            int.TryParse(numero, out numeroParsed);
            DateTime.TryParse(fecha, out fechaParsed);

            Cosa cosa1 = new Cosa(numeroParsed, cadena,fechaParsed);
            //string salida = ;

            MessageBox.Show(cosa1.Mostrar(),"Info",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }
    }
}
