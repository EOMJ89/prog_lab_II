using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        private string apellido;
        private string nombre;

        #region "Constructores"
        public Autor(string nombre, string apellido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }
        #endregion

        #region "Conversores"
        public static implicit operator String(Autor autor)
        {
            return autor.nombre + " — " + autor.apellido;
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Autor a, Autor b)
        {
            Boolean retorno = false;

            if (a.nombre == b.nombre && a.apellido == b.apellido)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }
        #endregion
    }

    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        #region "Propiedades"
        public int CantidadDePaginas
        {
            get
            {
                if (this._cantidadDePaginas == 0)
                { this._cantidadDePaginas = Libro._generadorDePaginas.Next(10, 580); }

                return this._cantidadDePaginas;
            }
        }
        #endregion

        #region "Constructores"
        static Libro()
        {
            Libro._generadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, string nombre, string apellido)
            : this(titulo, new Autor(nombre, apellido), precio)
        { }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._autor = autor;
            this._titulo = titulo;
            this._precio = precio;
        }
        #endregion

        #region "Metodos"
        private static string Mostrar(Libro l)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("TITULO: {0}\nCANTIDAD DE PÁGINAS: {1}\nAutor: ", l._titulo, l.CantidadDePaginas);
            stringBuild.AppendLine(l._autor);
            stringBuild.AppendFormat("PRECIO: {0:#.##}", l._precio);

            return stringBuild.ToString();
        }
        #endregion

        #region "Conversores"
        public static explicit operator String(Libro l)
        {
            return Libro.Mostrar(l);
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Libro a, Libro b)
        {
            Boolean retorno = false;

            if (a._autor == b._autor && a._titulo == b._titulo)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
        #endregion
    }

    public class Manual : Libro
    {
        protected ETipo _tipo;

        #region "Constructores"
        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo)
            : base(precio, titulo, nombre, apellido)
        { this._tipo = tipo; }
        #endregion

        #region "Metodos"
        public string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(((string)this));
            stringBuild.AppendFormat("Tipo: {0}", this._tipo);

            return stringBuild.ToString();
        }
        #endregion

        #region "Conversores"
        public static implicit operator double(Manual m)
        {
            return m._precio;
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Manual a, Manual b)
        {
            Boolean retorno = false;

            if (((Libro)a) == ((Libro)b) && a._tipo == b._tipo)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }
        #endregion
    }

    public class Novela : Libro
    {
        protected EGenero _genero;

        #region "Constructores"
        public Novela(string titulo, float precio, Autor autor, EGenero genero)
            : base(titulo, autor, precio)
        { this._genero = genero; }
        #endregion

        #region "Metodos"
        public string Mostrar()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendLine(((string)this));
            stringBuild.AppendFormat("Genero: {0}", this._genero);

            return stringBuild.ToString();
        }
        #endregion

        #region "Conversores"
        public static implicit operator double(Novela n)
        {
            return n._precio;
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Novela a, Novela b)
        {
            Boolean retorno = false;

            if (((Libro)a) == ((Libro)b) && a._genero == b._genero)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }
        #endregion
    }

    public class Biblioteca
    {
        private int _capacidad;
        private List<Libro> _libros;

        #region "Propiedades"
        public double PrecioDeManuales
        { get { return this.ObtenerPrecio(ELibro.Manual); } }

        public double PrecioDeNovelas
        { get { return this.ObtenerPrecio(ELibro.Novela); } }

        public double PrecioTotal
        { get { return (this.ObtenerPrecio(ELibro.Novela) + this.ObtenerPrecio(ELibro.Manual)); } }
        #endregion

        #region "Constructores"
        private Biblioteca()
        { this._libros = new List<Libro>(); }

        private Biblioteca(int capacidad)
            : this()
        { this._capacidad = capacidad; }
        #endregion

        #region "Metodos"
        public static string Mostrar(Biblioteca e)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad de la biblioteca: {0}\n", e._capacidad);
            stringBuild.AppendFormat("Total por Manuales: $ {0:#.##}\n", e.PrecioDeManuales);
            stringBuild.AppendFormat("Total por Novelas: $ {0:#.##}\n", e.PrecioDeNovelas);
            stringBuild.AppendFormat("Total: $ {0:#.##}\n", e.PrecioTotal);
            stringBuild.AppendLine("****************************************");
            stringBuild.AppendLine("Listado de Libros");
            stringBuild.AppendFormat("****************************************");

            foreach (Libro libroA in e._libros)
            {
                stringBuild.AppendLine("");
                if (libroA is Manual)
                { stringBuild.AppendLine(((Manual)libroA).Mostrar()); }
                else if (libroA is Novela)
                { stringBuild.AppendLine(((Novela)libroA).Mostrar()); }
            }

            return stringBuild.ToString();
        }

        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double retorno = 0;

            foreach (Libro libroA in this._libros)
            {
                switch (tipoLibro)
                {
                    case ELibro.Manual:
                        if (libroA is Manual)
                        { retorno += ((Manual)libroA); }
                        break;
                    case ELibro.Novela:
                        if (libroA is Novela)
                        { retorno += ((Novela)libroA); }
                        break;
                    default:
                        break;
                }
            }

            return retorno;
        }
        #endregion

        #region "Conversores"
        public static implicit operator Biblioteca(int capacidad)
        { return (new Biblioteca(capacidad)); }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Biblioteca e, Libro l)
        {
            Boolean retorno = false;

            foreach (Libro libroA in e._libros)
            {
                if (l is Novela && libroA is Novela)
                {
                    if (((Novela)libroA) == ((Novela)l))
                    {
                        retorno = true;
                        break;
                    }
                }
                else if (l is Manual && libroA is Manual)
                {
                    if (((Manual)libroA) == ((Manual)l))
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Biblioteca e, Libro l)
        {
            return !(e == l);
        }

        public static Biblioteca operator +(Biblioteca e, Libro l)
        {
            if (e._libros.Count < e._capacidad)
            {
                if (e != l)
                { e._libros.Add(l); }
                else
                { Console.WriteLine("El libro ya está en la biblioteca!!!"); }
            }
            else
            { Console.WriteLine("No hay más lugar en la biblioteca!!!"); }
            return e;
        }
        #endregion
    }
}
