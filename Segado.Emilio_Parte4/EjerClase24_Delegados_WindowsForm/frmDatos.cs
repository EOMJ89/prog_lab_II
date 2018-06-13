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
    public partial class frmDatos : Form
    {
        public frmDatos()
        { InitializeComponent(); }

        public void ActualizarNombre(string texto)
        { this.lblActualizado.Text = texto; } //Esto es un metodo simple, correspondiente a la firma del delegado principal, para que pueda ser utilizado por este. Cambia el texto que se muestra por el Label

        public void ActualizarImagenDatos(string path)
        {
            this.pboxImagen.ImageLocation = path; //Esto es un metodo simple, correspondiente a la firma del delegado principal, para que pueda ser utilizado por este. Cambia la imagen que se muestra por el PictureBox, guiandose por el directorio en donde se encuentra.
            this.pboxImagen.SizeMode = PictureBoxSizeMode.Zoom; //Esto es para que la imagen se re-escale para encajar en el PictureBox, de otra forma, si la imagen es muy grande, se mostrará una pequeña parte de la imagen.
        }
    }
}
