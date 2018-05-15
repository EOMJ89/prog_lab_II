using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase14_Library
{
    public class Numero
    {
        protected Int32 _numero;

        #region Propiedades
        public Int32 MiNumero { get { return this._numero; } }
        #endregion

        #region Constructor
        public Numero(Int32 numero)
        { this._numero = numero; }
        #endregion

        #region Sobrecargas
        public static Int32 operator +(Numero n1, Numero n2)
        { return (n1.MiNumero + n2.MiNumero); }

        public static Int32 operator -(Numero n1, Numero n2)
        { return (n1.MiNumero - n2.MiNumero); }

        public static Double operator /(Numero n1, Numero n2)
        {
            Double retorno = 0f;

            if (n2.MiNumero != 0)
            { retorno = n1.MiNumero / n2.MiNumero; }

            return retorno;
        }

        public static Int32 operator *(Numero n1, Numero n2)
        { return (n1.MiNumero * n2.MiNumero); }
        #endregion

        #region Metodos
        public static Boolean Parse(string cadena, out Numero numeroSalida)
        {
            Boolean retorno = false;
            numeroSalida = null; //Asigna nulo debido a que en caso de fallar el try, se utilizará este valor.

            try //Intentar...
            {
                int numeroParsed = int.Parse(cadena); //... convertir la cadena a int, ...
                numeroSalida = new Numero(numeroParsed); // ... instanciar el nuevo Numero con el parametro resultado del Parse anterior y...
                retorno = true; // ... retornar "true".
            }
            catch (Exception e)
            { /*Si atrapá una excepción (en la mayoria de los casos debido a no ser posible parsear) de cualquier tipo...*/ }

            return retorno;
        }
        #endregion
    }

    public class ColectoraDeNumeros
    {
        protected List<Numero> _numeros;

        #region Propiedades
        public ETipoNumero Tipo { get; set; } //Propiedad Autodefinida, no requiere del atributo (todo se almacena en el stack)
        #endregion

        #region Constructores
        private ColectoraDeNumeros()
        {
            this._numeros = new List<Numero>();
        }

        public ColectoraDeNumeros(ETipoNumero tipoNumero) : this()
        {
            this.Tipo = tipoNumero;
        }
        #endregion

        #region Sobrecargas
        public static Boolean operator ==(ColectoraDeNumeros a, Numero b)
        {
            Boolean retorno = false;

            foreach (Numero numeroA in a._numeros)
            {
                if (numeroA.MiNumero == b.MiNumero)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Boolean operator !=(ColectoraDeNumeros a, Numero b)
        {
            return !(a == b);
        }

        public static ColectoraDeNumeros operator +(ColectoraDeNumeros a, Numero b)
        {
            if (Verificadora.VerificarNumero(a.Tipo, b)) //Si b es del tipo de numero que a permite...
            { a._numeros.Add(b); } //... se añade a la lista
            else
            { throw new Exception("La contenedora no admite Numero de este tipo"); } //En caso contrario, tira una excepción de forma manual con un mensaje especifico.

            return a;
        }

        public static ColectoraDeNumeros operator -(ColectoraDeNumeros a, Numero b)
        {
            if (a == b) //Si el numero está en la lista...
            { a._numeros.Remove(b); } //... se remueve la primera instancia encontrada.
            else
            { throw new Exception("El numero no esta en esta colectora\n" + a.ToString()); } //En caso contrario, se tira una excepción de forma manual con el mensaje de error y los datos de la colección.

            return a;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Tipo de Numero: {0}", this.Tipo);

            foreach (Numero numeroA in this._numeros) //Por cada Numero en la lista...
            {
                stringBuild.AppendLine(""); //... coloca un \n...
                stringBuild.AppendFormat("Valor: {0}", numeroA.MiNumero); // ... y muestra los datos del Numero.
            }

            return stringBuild.ToString();
        }
        #endregion
    }

    public enum ETipoNumero
    { Par, Impar, Positivo, Negativo, Cero } //Tipo de Numero

    public static class Verificadora
    {
        public static Boolean VerificarNumero(ETipoNumero tipo, Numero numero)
        {
            Boolean retorno = false;

            switch (tipo)
            {
                case ETipoNumero.Par:
                    if (numero.MiNumero % 2 == 0)
                    { retorno = true; }
                    break;
                case ETipoNumero.Impar:
                    if (numero.MiNumero % 2 != 0)
                    { retorno = true; }
                    break;
                case ETipoNumero.Positivo:
                    if (numero.MiNumero > 0)
                    { retorno = true; }
                    break;
                case ETipoNumero.Negativo:
                    if (numero.MiNumero < 0)
                    { retorno = true; }
                    break;
                case ETipoNumero.Cero:
                    if (numero.MiNumero == 0)
                    { retorno = true; }
                    break;
                default:
                    break;

            }
            return retorno;
        }
    }
}
