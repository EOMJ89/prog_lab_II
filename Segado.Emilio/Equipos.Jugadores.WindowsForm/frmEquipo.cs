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
    public partial class frmEquipo : Form
    {
        private Equipo _equipo;

        public frmEquipo()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string cantidadJugadores = this.txtCantidadJugadores.Text;

            short parsedCantidad = 0;
            short.TryParse(cantidadJugadores, out parsedCantidad);
            _equipo = new Equipo(parsedCantidad, nombre);
            
            this.txtNombre.Enabled = false;
            this.txtCantidadJugadores.Enabled = false;

            this.btnAceptar.Visible = false;
            this.btnCancelar.Visible = false;

            this.ltbLista.Visible = true;
            this.btnMas.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
      
        }
    }
}
