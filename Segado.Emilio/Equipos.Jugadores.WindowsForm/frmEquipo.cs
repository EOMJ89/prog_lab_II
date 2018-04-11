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
            //Toma el nombre de los TextBox
            string nombre = this.txtNombre.Text;
            string cantidadJugadores = this.txtCantidadJugadores.Text;

            //Parse de los TextBox
            short parsedCantidad = 0;
            short.TryParse(cantidadJugadores, out parsedCantidad);

            //Creacion del Objeto Equipo
            _equipo = new Equipo(parsedCantidad, nombre);

            //Inhabilitar TextBox una vez aceptar
            this.txtNombre.Enabled = false;
            this.txtCantidadJugadores.Enabled = false;

            //Oculta botones Aceptar/Cancelar
            this.btnAceptar.Visible = false;
            this.btnCancelar.Visible = false;

            //Habilitar Lista de Jugadores y botones +,-,(Mod)ificar
            this.ltbLista.Visible = true;
            this.btnMas.Visible = true;
            this.btnMenos.Visible = true;
            this.btnModificar.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar Forma
            this.Close();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            //Creacion de la instancia form para jugadores
            frmJugador windowJugador = new frmJugador();
            windowJugador.ShowDialog();

            
            if (windowJugador.DialogResult == System.Windows.Forms.DialogResult.OK) //Valida si el ususario oprimio "Aceptar"
            {
                if (this._equipo + windowJugador.GetJugador() == true) //Valida tomando en cuenta si la suma fue posible
                {
                    this.ActualizarListBox(); //Actualiza la ListBox y Envia un mensaje de exito
                    MessageBox.Show("Exitoso", "Alerta de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    MessageBox.Show("Falido", "Alerta de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); //Mensaje de error
                }
            }
        }

        private void ActualizarListBox()
        {
            this.ltbLista.Items.Clear(); // Limpia la lista para evitar repeticiones

            //Por cada jugadorA en la lista de jugadores
            //Puede reemplazarse por un List<Jugador> auxLista = this._equipo.GetJugadores(); y usar la auxLista en el foreach
            foreach (Jugador jugadorA in this._equipo.GetJugadores()) 
            {
                this.ltbLista.Items.Add(jugadorA.MostrarDatos()); //Escribe los datos en la lista, a modo de cadena de caracteres
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this._equipo.GetJugadores()[this.ltbLista.SelectedIndex].MostrarDatos(), "Alerta de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (this.ltbLista.SelectedIndex != -1) //Valida que haya un item seleccionado para no crear cosas en vano
            {
                //Creacion de ls instancia utilizando el parametrizado que permitirá usar los datos como si se estuvieran cargando
                frmJugador windowJugador = new frmJugador(this._equipo.GetJugadores()[this.ltbLista.SelectedIndex]);
                windowJugador.ShowDialog();

                if (windowJugador.DialogResult == System.Windows.Forms.DialogResult.OK) //Valida si se presiona "Aceptar"
                {
                    DialogResult rta = MessageBox.Show("Está por eliminar:\n" + windowJugador.GetJugador().MostrarDatos() + "\n\nDesea continuar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); //Pregunta de confirmación Sí/No

                    if (rta == System.Windows.Forms.DialogResult.Yes) //Si el usuario presaiona "Sí"
                    {
                        if (this._equipo - windowJugador.GetJugador() == true) //Ejecuta la resta y verifica que se haya hecho correctamente
                        {
                            this.ActualizarListBox(); //Actualizacion y mensaje de exito en la lista
                            MessageBox.Show("Exitoso", "Alerta de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        }
                        else
                        {
                            MessageBox.Show("Falido", "Alerta de Jugador", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); //Mensaje de error
                        }
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.ltbLista.SelectedIndex != -1) //Valida que haya un item seleccionado
            {
                //Creacion de instancia con parametrizado para "cargar" los datos del jugador
                frmJugador windowJugador = new frmJugador(this._equipo.GetJugadores()[this.ltbLista.SelectedIndex]);
                windowJugador.ShowDialog();

                if (windowJugador.DialogResult == System.Windows.Forms.DialogResult.OK) //Valida que se presione "Aceptar"
                {
                    this._equipo.SetJugador(windowJugador.GetJugador(), this.ltbLista.SelectedIndex); //Funcion especial para reemplazar el jugador por su version actualizada, recibe como parametros el jugador a reemplazar y el index
                    this.ActualizarListBox(); //Actualizar List Box
                }
            }
        }
    }
}
