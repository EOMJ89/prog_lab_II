using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjerClase23_Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Este foreach recorre todos los controles dentro de un GroupBox (aunque tambien se puede usar un Panel si no se quiere el recuadro y el texto que le acompaña).
            foreach (Control controlA in this.gBoxBilletes.Controls) //Por cada control dentro de la lista de controles del groupbox.
            {
                if (controlA is TextBox) //Si el control es un texbox.
                { controlA.Enabled = false; } //Inhabilitalo.
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Este evento sucede justo antes de hacer visible el Formulario
        {
            this.btnAceptar.Click += new EventHandler(Calcular); //Agrega el manejador en el evento click del botón aceptar
        }

        private void Calcular(Object sender, EventArgs e)
        {
            int dinero = 0;
            int[] contadores = new int[6];
            int.TryParse(this.txtARetirar.Text, out dinero);

            while (dinero >= 2)
            {
                if ((dinero - 100) >= 0)
                {
                    contadores[0]++;
                    dinero -= 100;
                }
                else if ((dinero - 50) >= 0)
                {
                    contadores[1]++;
                    dinero -= 50;
                }
                else if ((dinero - 20) >= 0)
                {
                    contadores[2]++;
                    dinero -= 20;
                }
                else if ((dinero - 10) >= 0)
                {
                    contadores[3]++;
                    dinero -= 10;
                }
                else if ((dinero - 5) >= 0)
                {
                    contadores[4]++;
                    dinero -= 5;
                }
                else if ((dinero - 2) >= 0)
                {
                    contadores[5]++;
                    dinero -= 2;
                }
            }

            #region "Asigna los valores a los TextBox"
            this.txtBilletes2.Text = contadores[5].ToString();
            this.txtBilletes5.Text = contadores[4].ToString();
            this.txtBilletes10.Text = contadores[3].ToString();
            this.txtBilletes20.Text = contadores[2].ToString();
            this.txtBilletes50.Text = contadores[1].ToString();
            this.txtBilletes100.Text = contadores[0].ToString();
            #endregion

            if (dinero < 2 && dinero > 0)
            {
                string aux = "Le quedan $" + dinero + " Pesos";
                MessageBox.Show(aux, "Vuelto", MessageBoxButtons.OK);
            }
        }

        private void Informar(Object sender, EventArgs e) //Al hacer click en Aceptar cuando este manejador fue cargado
        {
            this.btnAceptar.Click -= new EventHandler(Informar);//Elimina el manejador del evento click de aceptar para evitar que se acumulen al oprimir varias veces.
            MessageBox.Show("Debe limpiar la pantalla para seguir operando.", "Informacion", MessageBoxButtons.OK); //Informa que se debe limpiar
        }

        private void Limpiar(Object sender, EventArgs e) //Al hacer click en Limpiar
        {
            this.btnAceptar.Click -= new EventHandler(Informar); //Elimina el manejador para informar del evento Click del botón Aceptar porque ahora es cuando limpiará el formulario.
            this.btnLimpiar.Click -= new EventHandler(Limpiar); //Elimina el manejador para limpiar del evento Click del botón Limpiar porque no queremos que se repita.
            this.btnAceptar.Click -= new EventHandler(Calcular); //Elimina el manejador para calcular del evento Click del botón Aceptar para evitar repeticiones en caso de que ya tenga asignado el manejador.

            foreach (Control controlA in this.gBoxBilletes.Controls) //Por cada control dentro de la lista de controles del groupbox.
            {
                if (controlA is TextBox) //Si el control es un texbox.
                { controlA.Text = ""; } //Regresalo a vacio.
            }

            this.btnAceptar.Click += new EventHandler(Calcular); //Agrega el manejador para Calcular nuevamente al evento Click del botón Aceptar porque ya ha terminado de limpiar el formulario.
        }

        private void btnAceptar_Click(object sender, EventArgs e) //Al hacer click en aceptar
        {
            this.btnAceptar.Click -= new EventHandler(Calcular); //Elimina el manejador de Calcular para que no pueda hacerlo de nuevo.
            this.btnLimpiar.Click += new EventHandler(Limpiar); //Agrega el manejador para limpiar al boton al evento Click del botón Limpiar.
            this.btnAceptar.Click += new EventHandler(Informar); //Agrega el manejador para informar que se debe limpiar el formulario antes de seguir al evento Click del botón Aceptar.
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir?", "Terminar la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) //Si ha oprimido Okay en el MessageBox.
            { this.Close(); } //Cerrar el formulario.
        }
    }
}
