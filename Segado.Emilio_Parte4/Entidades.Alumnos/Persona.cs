using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Alumnos
{
    public class Persona
    {
        protected string _nombre;
        protected string _apellido;
        protected int _edad;
        protected ESexo _sexo;

        //¿Cómo obtener acceso a los datos de una clase cuando esta posee atributos privados o protegidos?
        //Opción 1:
        #region "Propiedades de Solo Lectura"
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int Edad
        {
            get { return this._edad; }
            set { this._edad = value; }
        }

        public ESexo Sexo
        {
            get { return this._sexo; }
            set { this._sexo = value; }
        }
        #endregion

        public Persona(string nombre, string apellido, int edad, ESexo sexo)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._edad = edad;
            this._sexo = sexo;
        }

        //Opción 2:
        #region "Metodo regular o sobrecarga de metodo to String"
        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}-{2}-{3}", this._nombre, this._apellido, this._edad, this._sexo);

            return stringBuild.ToString();
        }
        #endregion
    }
}
