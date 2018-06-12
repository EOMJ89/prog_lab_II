using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjerClase23_Eventos_Calculadora_ClassLibrary;

namespace EjerClase23_Eventos_Calculadora
{
    public partial class Form1 : Form
    {
        //Atributos para poder guardar los operandos y la operacion que se hará
        private int primerOperando;
        private int segundoOperando;
        private int operador;

        public Form1()
        {
            InitializeComponent();
            //Inicializa los operandos y el operando (debido a que el 0 sigue siendo usable con los operandos)
            this.primerOperando = -1;
            this.segundoOperando = -1;
            this.operador = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AgregarManejador(this.gboxNumericos); //Agrega los manejadores del Evento Click a los botones numericos
            this.txtBoxPrimerNumero.Enabled = false; //Inhabilita la edición del TextBox
        }

        private void ManejadorCentral(object sender, EventArgs e)
        {
            Button auxButton = (Button)sender; //Ya que todos los disparadores de eventos son botones, usamos una auxiliar con el object casteado a Button para hacer el codigo más legible.

            #region "Numeradores"            
            if (this.gboxNumericos.Controls.Contains(auxButton)) //Si alguno de los controles dentro del Panel gboxNumericos es igual a auxButton.
            {
                this.AgregarManejador(this.gboxOperaciones); //Agrega el manejador a los eventos de los botones de los operadores.

                switch (auxButton.Name) //se guia por el nombre del botón, es más limpio que un if-else con el ==, se utiliza para mostrar por display el numero que se utilizará.
                {
                    case "btnCero":
                        this.txtBoxPrimerNumero.Text += "0";
                        break;
                    case "btnUno":
                        this.txtBoxPrimerNumero.Text += "1";
                        break;
                    case "btnDos":
                        this.txtBoxPrimerNumero.Text += "2";
                        break;
                    case "btnTres":
                        this.txtBoxPrimerNumero.Text += "3";
                        break;
                    case "btnCuatro":
                        this.txtBoxPrimerNumero.Text += "4";
                        break;
                    case "btnCinco":
                        this.txtBoxPrimerNumero.Text += "5";
                        break;
                    case "btnSeis":
                        this.txtBoxPrimerNumero.Text += "6";
                        break;
                    case "btnSiete":
                        this.txtBoxPrimerNumero.Text += "7";
                        break;
                    case "btnOcho":
                        this.txtBoxPrimerNumero.Text += "8";
                        break;
                    case "btnNueve":
                        this.txtBoxPrimerNumero.Text += "9";
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region "Operadores"
            if (this.gboxOperaciones.Controls.Contains(auxButton)) //Si alguno de los controles dentro del Panel gboxOperaciones es igual a auxButton.
            {
                this.EliminarManejador(this.gboxOperaciones); //Elimina los manejadores de los eventos de los botones de operadores para evitar que se dupliquen eventos.
                int.TryParse(this.txtBoxPrimerNumero.Text, out this.primerOperando); //Si el TryParse es exitoso, asigna el primer operando.

                switch (auxButton.Name) //se guia por el nombre del botón, es más limpio que un if-else con el ==, se utiliza para determinar qué operación se ha presionado.
                {
                    case "btnMas":
                        this.operador = 1;
                        break;
                    case "btnMenos":
                        this.operador = 2;
                        break;
                    case "btnPor":
                        this.operador = 3;
                        break;
                    case "btnDividir":
                        this.operador = 4;
                        break;
                    default:
                        break;
                }

                this.txtBoxPrimerNumero.Text = ""; //Elimina el texto presente en el TextBox para que el proximo numero inicie limpio.
                this.btnIgual.Click += new EventHandler(ManejadorCentral); //Agrega el manejador al evento Click del Botón Igual para permitir la operación.
            }
            #endregion

            if (auxButton == btnIgual) //Si el disparador fue el Botón Igual.
            {
                int.TryParse(this.txtBoxPrimerNumero.Text, out this.segundoOperando); //Si el TryParse fue exitoso, asignará el segundo operando para la operación.

                double resultado = Calculadora.Operar(this.primerOperando, this.segundoOperando, this.operador); //El resultado se obtiene mediante un metodo de clase en la libreria de clases.
                MessageBox.Show("El resultado es " + resultado, "Resultado", MessageBoxButtons.OK); //Se muestra el resultado por MessageBox.
                
                this.txtBoxPrimerNumero.Text = ""; //Se reinicia el TextBox.
                this.btnIgual.Click -= new EventHandler(ManejadorCentral); //Elimina el manejador del Evento Click del Botón Igual.
            }
        }

        private void AgregarManejador(Panel gbox) //Agrega el ManejadorCentral a todos los Controles dentro el Panel del parametro.
        {
            this.EliminarManejador(gbox); //Elimina en caso de que el manejador ya estuviera presente.

            foreach (Control controlA in gbox.Controls)
            { controlA.Click += ManejadorCentral; }
        }

        private void EliminarManejador(Panel gbox) //Elimina el ManejadorCentral de todos los Controles dentro el Panel del parametro.
        {
            foreach (Control controlA in gbox.Controls)
            { controlA.Click -= ManejadorCentral; }
        }
    }
}