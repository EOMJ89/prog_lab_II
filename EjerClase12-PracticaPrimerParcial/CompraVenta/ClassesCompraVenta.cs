using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta
{
    public class Articulo
    {
        protected int _codigo;
        protected string _nombre;
        protected float _precioCosto;
        protected float _precioVenta;
        protected int _stock;

        public virtual string NombreYCodigo { get { return this._codigo.ToString() + " " + this._nombre; } }

        public virtual float PrecioCosto
        {
            set
            {
                this._precioCosto = value;
                this._precioVenta = value + (value * 30 / 100);
            }
        }

        public float PrecioVenta { get { return this._precioVenta; } }

        public int Stock { set { this._stock = value; } }

        public Articulo(int codigo, string nombre, float precioCosto, int cantidad)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this.PrecioCosto = precioCosto;
            this.Stock = cantidad;
        }

        public Boolean HayStock(int cantidad)
        {
            Boolean retorno = false;

            if (this._stock >= cantidad) { retorno = true; }
            return retorno;
        }

        public static int operator +(Articulo articulo1, Articulo articulo2)
        { return articulo1._stock + articulo2._stock; }

        public static int operator -(Articulo articulo1, int cantidad)
        {
            int retorno = -1;

            if (articulo1.HayStock(cantidad))
            { retorno = articulo1._stock - cantidad; }

            return retorno;
        }

        public static Boolean operator ==(Articulo articulo1, Articulo articulo2)
        {
            Boolean retorno = false;

            if (articulo1.NombreYCodigo == articulo2.NombreYCodigo)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Articulo articulo1, Articulo articulo2)
        { return !(articulo1 == articulo2); }
    }

    public class Venta
    {
        protected Articulo _articulo;
        protected int _cantidad;

        public float RetornarGanancia()
        {
            return this._articulo.PrecioVenta * this._cantidad;
        }

        public Venta(Articulo articuloVendido, int cantidad)
        {
            this._articulo = articuloVendido;
            this._cantidad = cantidad;
        }
    }

    public class Comercio
    {
        protected string _dueño;
        protected List<Articulo> _misArticulos;
        protected List<Venta> _misVentas;

        public Comercio(string dueño)
        {
            this._misArticulos = new List<Articulo>();
            this._misVentas = new List<Venta>();
            this._dueño = dueño;
        }

        public void ComprarArticulo(Articulo articuloComprado)
        {
            Boolean noHayArticulo = true;

            for (int i = 0; i < this._misArticulos.Count; i++)
            {
                if (this._misArticulos[i] == articuloComprado)
                {
                    this._misArticulos[i].Stock = this._misArticulos[i] + articuloComprado;
                    noHayArticulo = false;
                    break;
                }
            }

            if (noHayArticulo == true)
            {
                this._misArticulos.Add(articuloComprado);
            }
        }

        public static void MostrarArticulos(Comercio comercioAMostrar)
        {
            StringBuilder strBuild = new StringBuilder("Lista de Articulos:\n");

            foreach (Articulo articuloA in comercioAMostrar._misArticulos)
            {
                strBuild.AppendLine(articuloA.NombreYCodigo);
            }

            Console.Write(strBuild.ToString());
        }

        public static void MostrarGanancias(Comercio comercioParaResumen)
        {
            float cantGanancias = 0;

            foreach (Venta ventaA in comercioParaResumen._misVentas)
            {
                cantGanancias += ventaA.RetornarGanancia();
            }

            Console.Write("Las ganancias obtenidas son {0}", cantGanancias);
        }

        public void VenderArticulo(Articulo articuloSolicitado, int cantidad)
        {
            Boolean flagExisteArticulo = false;

            for (int i = 0; i < this._misArticulos.Count; i++)
            {
                if (this._misArticulos[i] == articuloSolicitado)
                {
                    if (this._misArticulos[i].HayStock(cantidad))
                    {
                        this._misArticulos[i].Stock = this._misArticulos[i] - cantidad;
                        Venta ventaRealizada = new Venta(this._misArticulos[i], cantidad);
                        this._misVentas.Add(ventaRealizada);
                    }
                    else
                    { Console.WriteLine("No hay stock para \n{0}", this._misArticulos[i].NombreYCodigo); }
                    flagExisteArticulo = true;
                    break;
                }
            }

            if (flagExisteArticulo == false)
            { Console.WriteLine("El siguiente articulo no existe en el comercio\n{0}", articuloSolicitado.NombreYCodigo); }
        }

    }

    public class ArticuloImportado : Articulo
    {
        private string _paisOrigen;
        private double _impuesto;

        public override float PrecioCosto
        {
            set
            {
                base.PrecioCosto = value;
                base._precioVenta = (float)(base.PrecioVenta + (base.PrecioVenta * this._impuesto / 100));
            }
        }

        public ArticuloImportado(int codigo, string nombre, float precioCosto, int cantidad, string pais, double impuesto)
            : base(codigo, nombre, precioCosto, cantidad)
        {
            this._paisOrigen = pais;
            this._impuesto = impuesto;
            this.PrecioCosto = precioCosto;
        }

        public override string NombreYCodigo { get { return base.NombreYCodigo + " " + this._paisOrigen; } }
    }
}
