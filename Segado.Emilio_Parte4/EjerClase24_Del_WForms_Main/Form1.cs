using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjerClase24_Delegados_ClassLibrary;

namespace EjerClase24_Del_WForms_Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            #region "Se parsean los atributos necesarios"
            int auxDni = 0;
            int.TryParse(this.txtDni.Text, out auxDni);

            double auxSueldo = 0;
            double.TryParse(this.txtSueldo.Text, out auxSueldo);
            #endregion

            Empleado auxEmpleado = new Empleado(this.txtNombre.Text, this.txtApellido.Text, auxDni); //Se instancia el nuevo empleado
            auxEmpleado.SueldoMaximoMejorado += new DelegadoLimiteSueldoMejorado(this.ManejadorSueldoMaximoForms); //Se agrega el metodo a las lista de invocacion del delegado para el evento de Sueldo Maximo Mejorado

            try { auxEmpleado.Sueldo = auxSueldo; } //Validacion para Sueldo Negativo
            catch (SueldoNegativoException)
            { MessageBox.Show("El sueldo es Negativo", "Aleta de Sueldo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ManejadorSueldoMaximoForms(Empleado empleadoA, EmpleadoEventArgs empEventArgs)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Alerta: El empleado {0} intenta cobrar ${1}", empleadoA, empEventArgs.Sueldo);

            MessageBox.Show(stringBuild.ToString(),"Alerta de Sueldo Maximo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
