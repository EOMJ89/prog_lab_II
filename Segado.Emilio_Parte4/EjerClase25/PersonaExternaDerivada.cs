using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Externa;

namespace EjerClase25
{
    //A veces, no tendremos acceso al codigo fuente para poder ver los atributos y poder utilizar las opciones anteriores, así que puede hacerse un paso extra
    //Opción 3:

    #region "Clase Derivada de la clase inaccesible"
    public class PersonaExternaDerivada : PersonaExterna
    {
        public PersonaExternaDerivada(string nombre, string apellido, int edad, ESexo sexo) : base(nombre, apellido, edad, sexo) { }

        //Se retuliza una de las opciones anteriores
        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{1}-{2}-{3}", this._nombre, this._apellido, this._edad, this._sexo);

            return stringBuild.ToString();
        }
    }
    #endregion
}
