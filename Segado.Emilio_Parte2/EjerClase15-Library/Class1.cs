using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase15_Library
{
    public class Auto
    {
        protected string _color;
        protected string _marca;

        public string Color { get { return this._color; } }

        public string Marca { get { return this._marca; } }

        public Auto(string color, string marca)
        {
            this._color = color;
            this._marca = marca;
        }

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Auto)
            {
                if (this == ((Auto)obj))
                { retorno = true; }
            }
            return retorno;
        }

        public static Boolean operator ==(Auto a, Auto b)
        {
            Boolean retorno = false;

            if (a.Color == b.Color && a.Marca == b.Marca)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Auto a, Auto b)
        { return !(a == b); }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Marca: {0} - ", this.Marca);
            stringBuild.AppendFormat("Color: {0}\n", this.Color);

            return stringBuild.ToString();
        }
        #endregion
    }

    public class DepositoDeAutos
    {
        protected Int32 _capacidadMaxima;
        protected List<Auto> _lista;

        public DepositoDeAutos(int capacidad)
        {
            this._lista = new List<Auto>();
            this._capacidadMaxima = capacidad;
        }

        private Int32 GetIndice(Auto a)
        { return this._lista.IndexOf(a); }

        public Boolean Agregar(Auto a)
        {
            Boolean retorno = false;

            if (this._capacidadMaxima > this._lista.Count)
            {
                this._lista.Add(a);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator +(DepositoDeAutos d, Auto a)
        {
            Boolean retorno = false;
            retorno = d.Agregar(a);
            return retorno;
        }

        public Boolean Remover(Auto a)
        {
            Boolean retorno = false;
            Int32 indexAuto = this.GetIndice(a);

            if (indexAuto != -1)
            {
                this._lista.RemoveAt(indexAuto);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator -(DepositoDeAutos d, Auto a)
        {
            Boolean retorno = false;
            retorno = d.Remover(a);

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad máxima: {0}\n", this._capacidadMaxima);
            stringBuild.AppendLine("Listado de Autos:");

            foreach (Auto autoA in this._lista)
            {
                stringBuild.AppendFormat("{0}", autoA.ToString());
            }

            return stringBuild.ToString();
        }
    }

    public class Cocina
    {
        protected Int32 _codigo;
        protected Boolean _esIndustrial;
        protected Double _precio;

        public Int32 Codigo { get { return this._codigo; } }

        public Boolean EsIndustrial { get { return this._esIndustrial; } }

        public Double Precio { get { return Math.Round(this._precio, 2); } }

        public Cocina(int codigo, double precio, bool esIndustrial)
        {
            this._codigo = codigo;
            this._precio = precio;
            this._esIndustrial = esIndustrial;
        }

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Cocina)
            {
                if (this == ((Cocina)obj))
                { retorno = true; }
            }
            return retorno;
        }

        public static Boolean operator ==(Cocina a, Cocina b)
        {
            Boolean retorno = false;

            if (a.Codigo == b.Codigo)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Cocina a, Cocina b)
        { return !(a == b); }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Codigo: {0} - ", this.Codigo);
            stringBuild.AppendFormat("Precio: {0} - ", this.Precio);
            stringBuild.AppendFormat("Es industrial: {0}\n", this.EsIndustrial);

            return stringBuild.ToString();
        }
        #endregion
    }

    public class DepositoDeCocinas
    {
        protected Int32 _capacidadMaxima;
        protected List<Cocina> _lista;

        public DepositoDeCocinas(int capacidad)
        {
            this._lista = new List<Cocina>();
            this._capacidadMaxima = capacidad;
        }

        private Int32 GetIndice(Cocina a)
        { return this._lista.IndexOf(a); }

        public Boolean Agregar(Cocina a)
        {
            Boolean retorno = false;

            if (this._capacidadMaxima > this._lista.Count)
            {
                this._lista.Add(a);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator +(DepositoDeCocinas d, Cocina a)
        {
            Boolean retorno = false;
            retorno = d.Agregar(a);
            return retorno;
        }

        public Boolean Remover(Cocina a)
        {
            Boolean retorno = false;
            Int32 indexCocina = this.GetIndice(a);

            if (indexCocina != -1)
            {
                this._lista.RemoveAt(indexCocina);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator -(DepositoDeCocinas d, Cocina a)
        {
            Boolean retorno = false;
            retorno = d.Remover(a);

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad máxima: {0}\n", this._capacidadMaxima);
            stringBuild.AppendLine("Listado de Cocinas:");

            foreach (Cocina cocinaA in this._lista)
            {
                stringBuild.AppendFormat("{0}", cocinaA.ToString());
            }

            return stringBuild.ToString();
        }
    }

    public class Deposito<T>
    { 
        protected Int32 _capacidadMaxima;
        protected List<T> _lista;

        public Deposito(int capacidad)
        {
            this._lista = new List<T>();
            this._capacidadMaxima = capacidad;
        }

        private Int32 GetIndice(T a)
        { return this._lista.IndexOf(a); }

        public Boolean Agregar(T a)
        {
            Boolean retorno = false;

            if (this._capacidadMaxima > this._lista.Count)
            {
                this._lista.Add(a);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator +(Deposito<T> d, T a)
        {
            Boolean retorno = false;
            retorno = d.Agregar(a);
            return retorno;
        }

        public Boolean Remover(T a)
        {
            Boolean retorno = false;
            Int32 indexT = this.GetIndice(a);

            if (indexT != -1)
            {
                this._lista.RemoveAt(indexT);
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator -(Deposito<T> d, T a)
        {
            Boolean retorno = false;
            retorno = d.Remover(a);

            return retorno;
        }

        public override string ToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad máxima: {0}\n", this._capacidadMaxima);
            stringBuild.AppendLine("Listado:");

            foreach (T tA in this._lista)
            {
                stringBuild.AppendFormat("{0}", tA.ToString());
            }

            return stringBuild.ToString();
        }
    }
}
