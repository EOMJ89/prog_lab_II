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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string dni = this.txtDNI.Text;
            string nombre = this.txtNombre.Text;
            string partidos = this.txtPartidosJugados.Text;
            string goles = this.txtGoles.Text;

            long parsedDNI = 0;
            int parsedPartidos = 0;
            int parsedGoles = 0;
            long.TryParse(dni, out parsedDNI);
            int.TryParse(partidos, out parsedPartidos);
            int.TryParse(goles, out parsedGoles);

            this._jugador = new Jugador(nombre, parsedDNI, parsedPartidos, parsedGoles);

            MessageBox.Show(this._jugador.MostrarDatos(), "Info de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

        public Jugador GetJugador()
        {
            return this._jugador;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
