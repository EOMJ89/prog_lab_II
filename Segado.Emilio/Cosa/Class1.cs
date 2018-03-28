using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosaSpace
{
    public class Cosa
    {
        public int entero;
        public string cadena;
        public DateTime fecha;

        /// <summary>
        /// Establece un valor a el atributo entero de la clase.
        /// </summary>
        /// <param name="valor"> Paramatro que inicializara el abributo de clase entero </param>
        public void EstablecerValor(int valor)
        {
            this.entero = valor;
        }

        /// <summary>
        /// Establece un valor a el atributo cadena de la clase.
        /// </summary>
        /// <param name="cadena1"> Paramatro que inicializara el abributo de clase cadena </param>
        public void EstablecerValor(string cadena1)
        {
            this.cadena = cadena1;
        }

        /// <summary>
        /// Establece un valor a el atributo fecha de la clase
        /// </summary>
        /// <param name="date"> Parametro que inicializara el atributo de clase fecha </param>
        public void EstablecerValor(DateTime date)
        {
            this.fecha = date;
        }

        /// <summary>
        /// Se utiliza para dar formato a los tres datos de la clase para devolverlos en un solo string con tres renglones
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            string cadena1 = "";
            cadena1 += this.fecha;
            cadena1 += "\n";
            cadena1 += this.entero;
            cadena1 += "\n";
            cadena1 += this.cadena;
            cadena1 += "\n";

            return cadena1;
        }


        /// <summary>
        /// Crea un objeto donde se establecen valores ingresados para la clase
        /// </summary>
        /// <param name="entero1">Parametro que inicializara el atributo de clase entero</param>
        /// <param name="cadena1">Parametro que inicializara el atributo de clase cadena</param>
        /// <param name="fecha1">Parametro que inicializara el atributo de clase fecha</param>
        public Cosa(int entero1, string cadena1, DateTime fecha1)
        {
            this.entero = entero1;
            this.cadena = cadena1;
            this.fecha = fecha1;
        }

        /// <summary>
        /// Crea un objeto donde se establecen valores predeterminados para la clase
        /// </summary>
        public Cosa()
        {
            this.entero = 10;
            this.cadena = "Sin valor";
            this.fecha = DateTime.Now;
        }

        /*
        Peon sacrificado para optimizar codigo
        /// <summary>
        /// Crea un objeto donde se establecen valores predeterminados para la clase
        /// </summary>
        public Cosa():this(10,"Sin valor", DateTime.Now)
        {
        }*/
        
        /*
        Mismo constructor pero de la forma "normal"
        /// <summary>
        /// Crea un objeto donde se establecen valores predeterminados para la clase
        /// </summary>
        public Cosa()
        {
            this.entero = 10;
            this.cadena = "Sin valor";
            this.fecha = DateTime.Now;
        }*/

        /// <summary>
        /// Crea un objeto donde se establecen valores ingresados para la clase (solo en entero)
        /// </summary>
        /// <param name="entero1">Parametro que inicializara el atributo de clase entero</param>
        public Cosa(int entero1):this()
        {
            this.entero = entero1;
        }

        /*
        Mismo constructor pero de la forma "normal"
        /// <summary>
        /// Crea un objeto donde se establecen valores ingresados para la clase (solo en entero)
        /// </summary>
        /// <param name="entero1">Parametro que inicializara el atributo de clase entero</param>
        public Cosa(int entero1)
        {
            this.entero = entero1;
            this.cadena = "Sin valor";
            this.fecha = DateTime.Now;
        }*/

        /// <summary>
        /// Crea un objeto donde se establecen valores ingresados para la clase (solo en entero y cadena)
        /// </summary>
        /// <param name="entero1">Parametro que inicializara el atributo de clase entero</param>
        /// <param name="cadena1">Parametro que inicializara el atributo de clase cadena</param>
        public Cosa(int entero1, string cadena):this(entero1)
        {
            this.cadena = cadena;
        }

        /*
         * Mismo constructor de forma "normal"
        /// <summary>
        /// Crea un objeto donde se establecen valores ingresados para la clase (solo en entero y cadena)
        /// </summary>
        /// <param name="entero1">Parametro que inicializara el atributo de clase entero</param>
        /// <param name="cadena1">Parametro que inicializara el atributo de clase cadena</param>
        public Cosa(int entero1, string cadena):this(entero1)
        {
            this.entero = entero1;
            this.cadena = cadena;
        }*/
    }
}
