using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjerClase07_Ejercicio29_Clases;

namespace Equipos.Jugadores.WindowsForm
{
    public partial class frmJugador : Form
    {
        private Jugador _jugador;

        public frmJugador()
        {
            InitializeComponent();
        }

        //Parametrizado especial que permite "cargar" los datos de un jugador
        public frmJugador(Jugador jugador1)
            : this()
        {

            this.txtDNI.Text = jugador1.Dni.ToString(); //Metodo especial que convierte a string los tipos int,short, etc. Es heredada de Object
            this.txtDNI.Enabled = false; //Deshabilita si el this._jugador ya tiene parametros

            //Asigna los valores del parametro a los Text Box para poder mostrarlos
            this.txtNombre.Text = jugador1.Nombre;
            this.txtPartidosJugados.Text = jugador1.PartidosJugados.ToString();
            this.txtGoles.Text = jugador1.TotalGoles.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Toma de datos de los Text Box para el nuevo jugador
            string dni = this.txtDNI.Text;
            string nombre = this.txtNombre.Text;
            string partidos = this.txtPartidosJugados.Text;
            string goles = this.txtGoles.Text;

            //Parseo de DNI, Goles y Partidos
            long parsedDNI = 0;
            int parsedPartidos = 0;
            int parsedGoles = 0;
            long.TryParse(dni, out parsedDNI);
            int.TryParse(partidos, out parsedPartidos);
            int.TryParse(goles, out parsedGoles);

            if (((object)this._jugador) == null) //Valida si es null para decidir si debe crear un nuevo objeto o actualizar el que llegó como parametro (en caso de modificar o eliminar)
            {
                this._jugador = new Jugador(nombre, parsedDNI, parsedPartidos, parsedGoles);
                //MessageBox.Show(this._jugador.MostrarDatos(), "Info de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            else
            {
                //Asignación de los nuevos valores al objeto jugador (no importa si no se han cambiado, si se presionó aceptar, se actualiza)
                this._jugador.Nombre = this.txtNombre.Text;
                this._jugador.PartidosJugados = parsedPartidos;
                this._jugador.TotalGoles = parsedGoles;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK; //Envia señal de salida para validar el botón oprimido, debe hacerse manual
        }

        public Jugador GetJugador()
        {
            return this._jugador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; //Envia una señal de salida para validar el botón oprimido (puede simplemente no enviarse nada y usar un this.Close(); pero es buena forma de validar la salida en caso de no oprimir aceptar o la cruz de la esquina
        }
    }
}
