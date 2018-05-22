using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JugosClases
{
    public abstract class Producto
    {
        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        #region "Propiedades"
        public abstract float CalcularCostoDeProducto { get; }

        public EMarcaProducto Marca
        { get { return this._marca; } }

        public float Precio
        { get { return this._precio; } }
        #endregion

        #region "Constructores"
        public Producto(int codigoDeBarra, EMarcaProducto marca, float precio)
        {
            this._codigoDeBarra = codigoDeBarra;
            this._marca = marca;
            this._precio = precio;
        }
        #endregion

        #region "Metodos"
        public virtual string Consumir()
        { return "Parte de una mezcla."; }

        private static string MostrarProducto(Producto producto)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Marca: {0}\nCodigo de Barras: {1}\nPrecio: {2}\n", producto.Marca.ToString(), producto._codigoDeBarra, producto.Precio);

            return stringBuild.ToString();
        }

        public static Boolean MismoTipo(Producto productoA, ETipoProducto tipo)
        {
            Boolean retorno = false;

            switch (tipo)
            {
                case Producto.ETipoProducto.Galletita:
                    {
                        if (productoA is Galletita)
                        { retorno = true; }
                    }
                    break;
                case Producto.ETipoProducto.Gaseosa:
                    {
                        if (productoA is Gaseosa)
                        { retorno = true; }
                    }
                    break;
                case Producto.ETipoProducto.Jugo:
                    {
                        if (productoA is Jugo)
                        { retorno = true; }
                    }
                    break;
                case Producto.ETipoProducto.Harina:
                    {
                        if (productoA is Harina)
                        { retorno = true; }
                    }
                    break;
                case Producto.ETipoProducto.Todos:
                    { retorno = true; }
                    break;
                default:
                    break;
            }

            return retorno;
        }
        #endregion

        #region "Sobrecargas"
        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (this.GetType() == obj.GetType())
            { retorno = true; }

            return retorno;
        }

        public static explicit operator int(Producto producto)
        { return producto._codigoDeBarra; }

        public static implicit operator String(Producto producto)
        { return Producto.MostrarProducto(producto); }

        public override string ToString()
        {
            return this;
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Producto producto1, Producto producto2)
        {
            Boolean retorno = false;

            if (producto1.Equals(producto2) && producto1.Marca == producto2.Marca && producto1._codigoDeBarra == producto2._codigoDeBarra)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Producto producto1, Producto producto2)
        { return !(producto1 == producto2); }

        public static Boolean operator ==(Producto producto1, EMarcaProducto marca)
        {
            Boolean retorno = true;

            if (producto1.Marca == marca)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Producto producto1, EMarcaProducto marca)
        { return !(producto1 == marca); }
        #endregion

        #region "Enumerados"
        public enum EMarcaProducto
        {
            Manaos,
            Pitusas,
            Naranjú,
            Diversión,
            Swift,
            Favorita
        }

        public enum ETipoProducto
        {
            Galletita,
            Gaseosa,
            Jugo,
            Harina,
            Todos
        }
        #endregion
    }

    public class Jugo : Producto
    {
        protected ESaborJugo _sabor;
        protected static Boolean _DeConsumo;

        #region "Propiedades"
        public override float CalcularCostoDeProducto { get { return (this.Precio * 40 / 100); } }
        #endregion

        #region "Constructores"
        static Jugo()
        { Jugo._DeConsumo = true; }

        public Jugo(int codigoDeBarra, float precio, EMarcaProducto marca, ESaborJugo sabor) : base(codigoDeBarra, marca, precio)
        {
            this._sabor = sabor;
        }
        #endregion

        #region "Metodos"
        public override string Consumir()
        { return base.Consumir() + "Bebible"; }

        private string MostrarJugo()
        {
            return base.ToString() + "Sabor: " + this._sabor.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            return this.MostrarJugo();
        }
        #endregion

        #region "Enumerados"
        public enum ESaborJugo
        {
            Asqueroso,
            Pasable,
            Rico
        }
        #endregion
    }

    public class Galletita : Producto
    {
        protected float _peso;
        protected static Boolean _DeConsumo;

        #region "Propiedades"
        public override float CalcularCostoDeProducto { get { return (this._precio * 33 / 100); } }
        #endregion

        #region "Constructores"
        static Galletita()
        { Galletita._DeConsumo = false; }

        public Galletita(int codigoDeBarra, float precio, EMarcaProducto marca, float peso) : base(codigoDeBarra, marca, precio)
        {
            this._peso = peso;
        }
        #endregion

        #region "Metodos"
        public override string Consumir()
        { return base.Consumir() + "Comestible"; }

        private static string MostrarGalletita(Galletita g)
        { return g; }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            return base.ToString() + "Peso: " + this._peso; ;
        }
        #endregion
    }

    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static Boolean _DeConsumo;

        #region "Propiedades"
        public override float CalcularCostoDeProducto { get { return (this.Precio * 42 / 100); } }
        #endregion

        #region "Constructores"
        static Gaseosa()
        { Gaseosa._DeConsumo = true; }

        public Gaseosa(int codigoDeBarra, float precio, EMarcaProducto marca, float litros) : base(codigoDeBarra, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto p, float litros) : this(((int)p), p.Precio, p.Marca, litros)
        { }
        #endregion

        #region "Metodos"
        public override string Consumir()
        { return base.Consumir() + "Bebible"; }

        private string MostrarGaseosa()
        { return base.ToString() + "Litros: " + this._litros; }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            return this.MostrarGaseosa();
        }
        #endregion
    }

    public class Harina : Producto
    {
        protected ETipoHarina _tipo;
        protected static Boolean _DeConsumo;

        #region "Propiedades"
        public override float CalcularCostoDeProducto { get { return (this.Precio * 60 / 100); } }
        #endregion

        #region "Constructores"
        static Harina()
        { Harina._DeConsumo = false; }

        public Harina(int codigoDeBarra, float precio, EMarcaProducto marca, ETipoHarina tipo) : base(codigoDeBarra, marca, precio)
        {
            this._tipo = tipo;
        }
        #endregion

        #region "Metodos"
        private string MostrarHarina()
        { return base.ToString() + "Tipo: " + this._tipo; }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        {
            return this.MostrarHarina();
        }
        #endregion

        #region "Enumerados"
        public enum ETipoHarina
        {
            CuatroCeros,
            TresCeros,
            Integral
        }
        #endregion
    }

    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        #region "Propiedades"
        public float ValorEstanteTotal { get { return this.GetValorEstante(); } }
        #endregion

        #region "Constructores"
        private Estante()
        { this._productos = new List<Producto>(); }

        public Estante(sbyte capacidad) : this()
        { this._capacidad = capacidad; }
        #endregion

        #region "Metodos"
        public List<Producto> GetProductos()
        { return this._productos; }

        public float GetValorEstante()
        { return this.GetValorEstante(Producto.ETipoProducto.Todos); }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float retorno = 0;

            foreach (Producto productoA in this._productos)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (productoA is Galletita)
                        { retorno += productoA.Precio; }
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (productoA is Gaseosa)
                        { retorno += productoA.Precio; }
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (productoA is Jugo)
                        { retorno += productoA.Precio; }
                        break;
                    case Producto.ETipoProducto.Harina:
                        if (productoA is Harina)
                        { retorno += productoA.Precio; }
                        break;
                    case Producto.ETipoProducto.Todos:
                        retorno += productoA.Precio;
                        break;
                    default:
                        break;
                }
            }

            return retorno;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("Capacidad: {0}", e._capacidad);

            foreach (Producto productoA in e.GetProductos())
            {
                stringBuild.AppendLine("");
                if (productoA is Galletita)
                { stringBuild.AppendLine(((Galletita)productoA).ToString()); }
                else if (productoA is Gaseosa)
                { stringBuild.AppendLine(((Gaseosa)productoA).ToString()); }
                else if (productoA is Jugo)
                { stringBuild.AppendLine(((Jugo)productoA).ToString()); }
                else if (productoA is Harina)
                { stringBuild.AppendLine(((Harina)productoA).ToString()); }
            }

            return stringBuild.ToString();
        }
        #endregion

        #region "Operadores"
        public static Boolean operator ==(Estante e, Producto producto2)
        {
            Boolean retorno = false;

            foreach (Producto productoA in e.GetProductos())
            {
                if (productoA == producto2)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static Boolean operator !=(Estante e, Producto producto2)
        { return !(e == producto2); }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            e._productos.RemoveAll(Producto => Producto.MismoTipo(Producto, tipo) == true);
            return e;
        }

        public static Estante operator -(Estante e, Producto producto)
        {
            if (e == producto)
            { e._productos.Remove(producto); }

            return e;
        }

        public static bool operator +(Estante e, Producto producto)
        {
            Boolean retorno = false;
            if (e._productos.Count < e._capacidad)
            {
                if (e != producto)
                {
                    e._productos.Add(producto);
                    retorno = true;
                }
            }

            return retorno;
        }
        #endregion
    }
}



