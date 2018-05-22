using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio31_Library
{
    public class Cliente
    {
        private string _nombre;
        private int _numero;

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public int Numero { get { return this._numero; } }

        public Cliente(int numero)
        { this._numero = numero; }

        public Cliente(int numero, string nombre) : this(numero)
        { this.Nombre = nombre; }

        public static Boolean operator ==(Cliente c1, Cliente c2)
        {
            Boolean retorno = false;

            if (c1.Numero == c2.Numero)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Cliente c1, Cliente c2)
        { return !(c1 == c2); }
    }

    public class Negocio
    {
        private PuestoAtencion _caja;
        private Queue<Cliente> _clientes;
        private string _nombre;

        public Cliente Cliente
        {
            get { return this._clientes.Dequeue(); }
            set
            {
                if (this != value)
                {
                    this._clientes.Enqueue(value);
                }
            }
        }

        private Negocio()
        {
            this._clientes = new Queue<Cliente>();
            this._caja = new PuestoAtencion(PuestoAtencion.Puesto.Caja1);
        }

        public Negocio(string nombre) : this()
        { this._nombre = nombre; }

        public static Boolean operator ==(Negocio n, Cliente c)
        {
            Boolean retorno = false;

            foreach (Cliente clienteA in n._clientes)
            {
                if (clienteA == c)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Negocio n, Cliente c)
        { return !(n == c); }

        public static Boolean operator +(Negocio n, Cliente c)
        {
            Boolean retorno = false;

            if (n != c)
            {
                n._clientes.Enqueue(c);
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator ~(Negocio n)
        {
            Boolean retorno = false;

            if (n._clientes.Count >= 1)
            {
                n._caja.Atender(n.Cliente);
                retorno = true;
            }
            return retorno;
        }
    }

    public class PuestoAtencion
    {
        private static int _numeroActual;
        private Puesto _puesto;

        public static int NumeroActual
        {
            get
            {
                PuestoAtencion._numeroActual += 1;
                return PuestoAtencion._numeroActual;
            }
        }

        public Boolean Atender(Cliente cli)
        {
            System.Threading.Thread.Sleep(500);
            return true;
        }

        static PuestoAtencion()
        { PuestoAtencion._numeroActual = 0; }

        public PuestoAtencion(Puesto puesto)
        { this._puesto = puesto; }

        public enum Puesto
        { Caja1, Caja2 }
    }
}
