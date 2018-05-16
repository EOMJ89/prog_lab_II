using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio21Classes
{
    /*Crear tres clases: Fahrenheit, Celsius y Kelvin.Realizar un ejercicio similar al anterior, teniendo en cuenta que:
    F = C * (9/5) + 32
    C = (F - 32) * 5/9
    F = K * 9/5 – 459.67
    K = (F + 459.67) * 5/9
    */

    public class Fahrenheit
    {
        public double _temperatura;

        #region Constructores
        private Fahrenheit() : this(0)
        { }

        public Fahrenheit(double temperatura)
        {
            this._temperatura = temperatura;
        }
        #endregion

        #region Conversores
        public static explicit operator Celsius(Fahrenheit f1)
        {
            Celsius c1 = new Celsius(Math.Round((f1._temperatura - 32) * ((double)5) / 9,2));
            return c1;
        }

        public static explicit operator Kelvin(Fahrenheit f1)
        {
            Kelvin k1 = new Kelvin((f1._temperatura + 459.67) * ((double)5) / 9);
            return k1;
        }

        public static implicit operator Fahrenheit(double d)
        {
            Fahrenheit f1 = new Fahrenheit(d);
            return f1;
        }
        #endregion

        #region "Sobrecargas de Operadores"
        #region "Fahrenheit y Celsius"
        public static Fahrenheit operator +(Fahrenheit f1, Celsius c1)
        {
            f1._temperatura += ((Fahrenheit)c1)._temperatura;

            return f1;
        }

        public static Fahrenheit operator -(Fahrenheit f1, Celsius c1)
        {
            f1._temperatura -= ((Fahrenheit)c1)._temperatura;

            return f1;
        }


        public static Boolean operator ==(Fahrenheit f1, Celsius c1)
        {
            Boolean retorno = false;

            if (f1._temperatura == Math.Round(((Fahrenheit)c1)._temperatura, 4))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Fahrenheit f1, Celsius c1)
        { return !(f1 == c1); }
        #endregion

        #region "Fahrenheit y Kelvin"
        public static Fahrenheit operator +(Fahrenheit f1, Kelvin k1)
        {
            f1._temperatura += ((Fahrenheit)k1)._temperatura;

            return f1;
        }

        public static Fahrenheit operator -(Fahrenheit f1, Kelvin k1)
        {
            f1._temperatura -= ((Fahrenheit)k1)._temperatura;

            return f1;
        }


        public static Boolean operator ==(Fahrenheit f1, Kelvin k1)
        {
            Boolean retorno = false;

            if (f1._temperatura == Math.Round(((Fahrenheit)k1)._temperatura, 4))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Fahrenheit f1, Kelvin k1)
        { return !(f1 == k1); }
        #endregion

        #region "Fahrenheit y Fahrenheit"
        public static Fahrenheit operator +(Fahrenheit f1, Fahrenheit f2)
        {
            f1._temperatura += f2._temperatura;

            return f1;
        }

        public static Fahrenheit operator -(Fahrenheit f1, Fahrenheit f2)
        {
            f1._temperatura -= f2._temperatura;

            return f1;
        }


        public static Boolean operator ==(Fahrenheit f1, Fahrenheit f2)
        {
            Boolean retorno = false;
            if (f1._temperatura == f2._temperatura)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Fahrenheit f1, Fahrenheit f2)
        { return !(f1 == f2); }
        #endregion
        #endregion
    }

    public class Celsius
    {
        public double _temperatura;

        #region Constructores
        private Celsius() : this(0)
        { }

        public Celsius(double temperatura)
        {
            this._temperatura = temperatura;
        }
        #endregion

        #region Conversores
        public static explicit operator Fahrenheit(Celsius c1)
        {
            Fahrenheit f1 = new Fahrenheit(c1._temperatura * (((double)9) / 5) + 32);
            return f1;
        }

        public static explicit operator Kelvin(Celsius c1)
        {
            Fahrenheit f1 = (Fahrenheit)c1;
            Kelvin k1 = (Kelvin)f1;
            return k1;
        }

        public static implicit operator Celsius(double d)
        {
            Celsius f1 = new Celsius(d);
            return f1;
        }
        #endregion

        #region "Sobrecargas de Operadores"
        #region "Celcious y Fahrenheit"
        public static Celsius operator +(Celsius c1, Fahrenheit f1)
        {
            c1._temperatura += ((Celsius)f1)._temperatura;

            return c1;
        }

        public static Celsius operator -(Celsius c1, Fahrenheit f1)
        {
            c1._temperatura -= ((Celsius)f1)._temperatura;

            return c1;
        }


        public static Boolean operator ==(Celsius c1, Fahrenheit f1)
        {
            Boolean retorno = false;

            if (c1._temperatura == Math.Round(((Celsius)f1)._temperatura, 2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Celsius c1, Fahrenheit f1)
        { return !(c1 == f1); }
        #endregion

        #region "Celsius y Kelvin"
        public static Celsius operator +(Celsius c1, Kelvin k1)
        {
            c1._temperatura += ((Celsius)k1)._temperatura;

            return c1;
        }

        public static Celsius operator -(Celsius c1, Kelvin k1)
        {
            c1._temperatura -= ((Celsius)k1)._temperatura;

            return c1;
        }


        public static Boolean operator ==(Celsius c1, Kelvin k1)
        {
            Boolean retorno = false;

            if (c1._temperatura == Math.Round(((Celsius)k1)._temperatura, 2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Celsius c1, Kelvin k1)
        { return !(c1 == k1); }
        #endregion

        #region "Celsius y Celsius"
        public static Celsius operator +(Celsius c1, Celsius c2)
        {
            c1._temperatura += c2._temperatura;

            return c1;
        }

        public static Celsius operator -(Celsius c1, Celsius c2)
        {
            c1._temperatura -= c2._temperatura;

            return c1;
        }


        public static Boolean operator ==(Celsius c1, Celsius c2)
        {
            Boolean retorno = false;
            if (c1._temperatura == c2._temperatura)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Celsius c1, Celsius c2)
        { return !(c1 == c2); }
        #endregion
        #endregion
    }

    public class Kelvin
    {
        public double _temperatura;

        #region Constructores
        private Kelvin() : this(0)
        { }

        public Kelvin(double temperatura)
        {
            this._temperatura = temperatura;
        }
        #endregion

        #region Conversores
        public static explicit operator Fahrenheit(Kelvin k1)
        {
            Fahrenheit f1 = new Fahrenheit(k1._temperatura * 9 / 5 - 459.67);
            return f1;
        }

        public static explicit operator Celsius(Kelvin k1)
        {
            Celsius c1 = new Celsius(k1._temperatura - 273.15);
            return c1;
        }

        public static implicit operator Kelvin(double d)
        {
            Kelvin f1 = new Kelvin(d);
            return f1;
        }
        #endregion

        #region "Sobrecargas de Operadores"
        #region "Kelvin y Celsius"
        public static Kelvin operator +(Kelvin k1, Celsius c1)
        {
            k1._temperatura += ((Kelvin)c1)._temperatura;

            return k1;
        }

        public static Kelvin operator -(Kelvin k1, Celsius c1)
        {
            k1._temperatura -= ((Kelvin)c1)._temperatura;

            return k1;
        }


        public static Boolean operator ==(Kelvin k1, Celsius c1)
        {
            Boolean retorno = false;

            if (k1._temperatura == Math.Round(((Kelvin)c1)._temperatura, 2))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Kelvin k1, Celsius c1)
        { return !(k1 == c1); }
        #endregion

        #region "Kelvin y Fahrenheit"
        public static Kelvin operator +(Kelvin k1, Fahrenheit f1)
        {
            k1._temperatura = Math.Round(k1._temperatura += ((Kelvin)f1)._temperatura,2);

            return k1;
        }

        public static Kelvin operator -(Kelvin k1, Fahrenheit f1)
        {
            k1._temperatura = Math.Round(k1._temperatura -= ((Kelvin)f1)._temperatura,2);

            return k1;
        }


        public static Boolean operator ==(Kelvin k1, Fahrenheit f1)
        {
            Boolean retorno = false;

            if (k1._temperatura == Math.Round(((Kelvin)f1)._temperatura, 4))
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Kelvin k1, Fahrenheit f1)
        { return !(k1 == f1); }
        #endregion

        #region "Kelvin y Kelvin"
        public static Kelvin operator +(Kelvin k1, Kelvin k2)
        {
            k1._temperatura += k2._temperatura;

            return k1;
        }

        public static Kelvin operator -(Kelvin k1, Kelvin k2)
        {
            k1._temperatura -= k2._temperatura;

            return k1;
        }


        public static Boolean operator ==(Kelvin k1, Kelvin k2)
        {
            Boolean retorno = false;
            if (k1._temperatura == k2._temperatura)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Kelvin k1, Kelvin k2)
        { return !(k1 == k2); }
        #endregion
        #endregion
    }
}
