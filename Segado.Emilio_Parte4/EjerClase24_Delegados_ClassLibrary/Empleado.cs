using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase24_Delegados_ClassLibrary
{
    #region "Delegados"
    public delegate void DelegadoSueldoCero(); //Este delagado va a admitir cualquier metodo que tenga Void como retorno sin parametros

    public delegate void DelegadoLimiteSueldo(double sueldo, Empleado empleadoA); //Este delagado va a admitir cualquier metodo que tenga Void como retorno y dos paremetros, un double y un Empleado respectivamente.

    public delegate void DelegadoLimiteSueldoMejorado(Empleado empleadoSender, EmpleadoEventArgs empEventArgs); //Este delagado va a admitir cualquier metodo que tenga Void como retorno y dos paremetros, un Empleado y un EmpleadoEvenArgs respectivamente.
    #endregion

    public class Empleado
    {
        public string _nombre;
        public string _apellido;
        public int _dni;
        private double _sueldo;

        #region "Propiedades"
        public double Sueldo
        {
            get { return this._sueldo; }
            set
            {
                if (value > 20000)
                {
                    EmpleadoEventArgs empleadoEventArgsAux = new EmpleadoEventArgs(); //Se instancia el EmpleadoEventArgs para que contenga la informacion extra necesaria.
                    empleadoEventArgsAux.Sueldo = value; //Se establece la propiedad necesaria
                    this.SueldoMaximoMejorado.Invoke(this, empleadoEventArgsAux); //Se invocan los metodos del delegado para este evento.
                }
                else if (value > 10000 && value <= 20000) { this.SueldoMaximo.Invoke(value, this); } //Se invocan los metodos del delegado para este evento.
                else if (value == 0) { this.SueldoCero.Invoke(); } //Se invocan los metodos del delegado para este evento.
                else if (value < 0) { throw new SueldoNegativoException(); } //Se lanza una SueldoNegativoExceptio.
                else { this._sueldo = value; }
            }
        }
        #endregion

        #region "Constructures"
        public Empleado(string nombre, string apellido, int dni)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._dni = dni;
        }
        #endregion

        #region "Metodos"

        #region "Sobrecargas"
        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}-{2}", this._nombre, this._apellido, this._dni);
            return stringBuild.ToString();
        }
        #endregion
        #endregion

        #region "Eventos"
        //Declaran los eventos como variables0, toman el nombre del delegado para como tipo de delegado y un nombre de variable para el evento que sucede
        public event DelegadoSueldoCero SueldoCero;

        public event DelegadoLimiteSueldo SueldoMaximo;

        public event DelegadoLimiteSueldoMejorado SueldoMaximoMejorado;
        #endregion

        #region "Menajadores de Eventos"
        //Por convención, el primer elemento deberia ser el disparador del evento, y el segundo deberia ser un EventArgs o derivado, aunque se pueden hacer delegados con cualquier firma, siempre y cuando que los metodos que se agreguen a la lista de invocaciones compartan dicha firma.
        public static void ManejarEventoSueldoCero() { Console.WriteLine("El sueldo que intenta ingresar es Cero."); }

        public static void ManejarEventoSueldoMaximo(double sueldo, Empleado empleadoA)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("El empleado {0} intenta cobrar ${1}", empleadoA, sueldo);

            Console.WriteLine(stringBuild.ToString());
        }

        public static void ManejarEventoSueldoMaximoMejorado(Empleado empleadoA, EmpleadoEventArgs empEventArgs)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Alerta: El empleado {0} intenta cobrar ${1}", empleadoA, empEventArgs.Sueldo);

            Console.WriteLine(stringBuild.ToString());
        }
        #endregion
    }
}
