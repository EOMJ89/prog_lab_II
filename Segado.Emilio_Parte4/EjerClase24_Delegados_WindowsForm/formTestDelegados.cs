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
    public partial class formTestDelegados : Form
    {
        private OpenFileDialog openImage; //Se intancia un OpenFileDialog para que su atributo FileName pueda verse en todo el formulario
        private Boolean imageUpdated; //Boolean extra como validación para que no se actualize el PictureBox si no se cambió el FileName del OpenFileDialog

        public formTestDelegados()
        { InitializeComponent(); }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ((frmPrincipal)this.Owner).Actualizar(this.txtTexto.Text); //Se castea el this.Owner debido a que esta propiedad retorna un Formulario, mientras que el formulario padre es de clase FrmPrincipal, de esta forma se puede acceder al Delegado e invocar al metodo para actualizar.

            if (this.imageUpdated) //Si el OpenFileDialog fue abierto y se eligio una imagen...
            { ((frmPrincipal)this.Owner).ActualizarImagen(this.openImage.FileName); }
            //Se castea el this.Owner debido a que esta propiedad retorna un Formulario, mientras que el formulario padre es de clase FrmPrincipal, de esta forma se puede acceder al Delegado e invocar al metodo para actualizar.
        }

        private void Imagen_Click(object sender, EventArgs e)
        {
            this.openImage = new OpenFileDialog(); //Se instancia el OpenFileDialog para no gastar memoria inicializandolo en el inicio, siendo que tal vez nunca se quiera actualizar la imagen.

            if (this.openImage.ShowDialog() == DialogResult.OK) //Si el OpenFileDialog fue abierto y se eligio una imagen exitosamente...
            { this.imageUpdated = true; } //Coloca el Boolean en true, para permitir que se actualice.
        }
    }
}
