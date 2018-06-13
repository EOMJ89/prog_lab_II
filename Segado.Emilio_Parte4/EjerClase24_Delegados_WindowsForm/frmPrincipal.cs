using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjerClase24_Delegados_WindowsForm
{
    public delegate void DelegadoLabel(string sender); //Se declara el delegado a nivel de namespace para que los formularios hijos puedan verlo

    public partial class frmPrincipal : Form
    {
        public DelegadoLabel Actualizar; //Se crea instancia del delegado para poder desencadenar el evento que tendrá el metodo para actualizar el Label
        public DelegadoLabel ActualizarImagen; //Se crean instancia del delegado para poder desencadenar el evento que tendrá el metodo para actualizar el PictureBox
        private int childFormNumber = 0;

        public frmPrincipal()
        { InitializeComponent(); }

        private void testDelegadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTestDelegados testDelegados = new formTestDelegados(); //Nueva instancia de formulario
            testDelegados.Show(this); //Pasar como parametro un formulario, hará que este sea el padre del formulario que se va a abrir
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatos testDatos = new frmDatos(); //Nueva instancia de formulario

            Actualizar = new DelegadoLabel(testDatos.ActualizarNombre); //Inizializa el Delegado para que al momento de su ejecución, pueda ejecutar el metodo que se le pasa, en este caso para actualizar el texto del Label
            ActualizarImagen = new DelegadoLabel(testDatos.ActualizarImagenDatos); //Inizializa el Delegado para que al momento de su ejecución, pueda ejecutar el metodo que se le pasa, en este caso para actualizar la imagen del PictureBox

            testDatos.Show(this);//Pasar como parametro un formulario, hará que este sea el padre del formulario que se va a abrir
        }
    }
}
