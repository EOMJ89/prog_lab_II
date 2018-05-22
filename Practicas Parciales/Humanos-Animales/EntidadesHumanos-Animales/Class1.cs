using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesHumanos_Animales
{
    public abstract class Animal
    {
        protected int _cantidadPatas;
        protected static Random _distanciaRecorrida;
        protected int _velocidadMaxima;

        public int CantidadPatas
        {
            get { return this._cantidadPatas; }
            set
            {
                if (value > 4)
                { this._cantidadPatas = 4; }
                else
                { this._cantidadPatas = value; }
            }
        }

        public int DistanciaRecorrida
        { get { return Animal._distanciaRecorrida.Next(10, this.VelocidadMaxima); } }

        public int VelocidadMaxima
        {
            get { return this._velocidadMaxima; }
            set
            {
                if (value > 60)
                { this._velocidadMaxima = 60; }
                else
                { this._velocidadMaxima = value; }
            }
        }

        static Animal()
        { Animal._distanciaRecorrida = new Random(); }

        public Animal(int cantidadPatas, int velocidadMaxima)
        {
            this.CantidadPatas = cantidadPatas;
            this.VelocidadMaxima = velocidadMaxima;
        }

        public string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("CantidadPatas: {0}\nDistanciaRecorrida: {1}\nVelocidadMaxima: {2}\n", this.CantidadPatas, this.DistanciaRecorrida, this.VelocidadMaxima);

            return retorno.ToString();
        }
    }

    public class Humano : Animal
    {
        protected string _apellido;
        protected string _nombre;
        protected static int _piernas;

        #region "Constructores"
        static Humano()
        { Humano._piernas = 2; }

        public Humano(int velocidadMaxima) : base(Humano._piernas, velocidadMaxima)
        { }

        public Humano(string nombre, string apellido, int velocidadMaxima) : this(velocidadMaxima)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }
        #endregion

        #region "Metodos"
        public string MostrarHumano()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre: {0}\nApellido: {1}\n{2}", this._nombre, this._apellido, base.MostrarDatos());

            return retorno.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Humano h1, Humano h2)
        {
            Boolean retorno = false;

            if (h1._nombre == h2._nombre && h1._apellido == h2._apellido)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Humano h1, Humano h2)
        { return !(h1 == h2); }
        #endregion
    }

    public class Perro : Animal
    {
        protected static int _patas;
        protected Razas _razas;

        #region "Constructores"
        static Perro()
        { Perro._patas = 4; }

        public Perro(int velocidadMaxima) : base(Perro._patas, velocidadMaxima)
        { }

        public Perro(Razas raza, int velocidadMaxima) : this(velocidadMaxima)
        { this._razas = raza; }
        #endregion

        #region "Metodos"
        public string MostrarPerro()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("{0}Raza: {1}\n", base.MostrarDatos(), this._razas);

            return retorno.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Perro p1, Perro p2)
        {
            Boolean retorno = false;

            if (p1._razas == p2._razas && p1.VelocidadMaxima == p2.VelocidadMaxima)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Perro p1, Perro p2)
        { return !(p1 == p2); }
        #endregion

        #region "Enumerado"
        public enum Razas
        { Galgo, OvejeroAleman }
        #endregion
    }

    public class Caballo : Animal
    {
        protected static int _patas;
        protected string _nombre;

        #region "Constructores"
        static Caballo()
        { Caballo._patas = 4; }

        public Caballo(string nombre, int velocidadMaxima) : base(Caballo._patas, velocidadMaxima)
        { this._nombre = nombre; }
        #endregion

        #region "Metodos"
        public string MostrarCaballo()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("Nombre: {0}\n{1}", this._nombre, base.MostrarDatos());

            return retorno.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Caballo c1, Caballo c2)
        {
            Boolean retorno = false;

            if (c1._nombre == c2._nombre)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Caballo c1, Caballo c2)
        { return !(c1 == c2); }
        #endregion
    }

    public class Carrera
    {
        protected int _corredoresMax;
        protected List<Animal> _animales;

        #region "Constructores"
        private Carrera()
        { this._animales = new List<Animal>(); }

        public Carrera(int corredoresMax) : this()
        { this._corredoresMax = corredoresMax; }
        #endregion

        #region "Metodos"
        public string MostrarCarrera()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad de Carrera: {0}", this._corredoresMax);

            foreach (Animal animalA in this._animales)
            {
                stringBuild.AppendLine("");
                if (animalA is Humano)
                { stringBuild.AppendLine(((Humano)animalA).MostrarHumano()); }
                else if (animalA is Perro)
                { stringBuild.AppendLine(((Perro)animalA).MostrarPerro()); }
                else if (animalA is Caballo)
                { stringBuild.AppendLine(((Caballo)animalA).MostrarCaballo()); }
            }

            return stringBuild.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Carrera c, Animal a)
        {
            Boolean retorno = false;

            foreach (Animal animalA in c._animales)
            {
                if (a is Humano && animalA is Humano)
                {
                    if (((Humano)animalA) == ((Humano)a))
                    { retorno = true; }
                }
                else if (a is Perro && animalA is Perro)
                {
                    if (((Perro)animalA) == ((Perro)a))
                    { retorno = true; }
                }
                if (a is Caballo && animalA is Caballo)
                {
                    if (((Caballo)animalA) == ((Caballo)a))
                    { retorno = true; }
                }
            }
            return retorno;
        }

        public static Boolean operator !=(Carrera c, Animal a)
        { return !(c == a); }

        public static Carrera operator +(Carrera c, Animal a)
        {
            if (c._animales.Count < c._corredoresMax)
            {
                if (c != a)
                {
                    c._animales.Add(a);
                }
            }

            return c;
        }
        #endregion
    }
}
