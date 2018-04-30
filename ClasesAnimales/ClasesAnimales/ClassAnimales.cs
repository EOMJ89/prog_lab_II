using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesAnimales
{
    public class Grupo
    {
        private List<Mascota> _manada;
        private string _nombre;
        private ETipoManada _tipo;

        public ETipoManada TipoManada
        { set { this._tipo = value; } }

        private Grupo()
        { this._manada = new List<Mascota>(); }

        public Grupo(string nombre) : this(nombre,ETipoManada.Única)
        { }

        public Grupo(string nombre, ETipoManada tipo) : this()
        {
            this._nombre = nombre;
            this.TipoManada = tipo;
        }

        public static explicit operator string(Grupo e)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("**{0}**\nIntegrantes:\n", e._nombre);

            foreach (Mascota mascotaA in e._manada)
            {
                if (mascotaA is Perro)
                {
                    stringBuild.AppendLine(((Perro)mascotaA).ToString());
                }
                if (mascotaA is Gato)
                {
                    stringBuild.AppendLine(((Gato)mascotaA).ToString());
                }
            }

            return stringBuild.ToString();
        }

        public static Boolean operator ==(Grupo e, Mascota j)
        {
            Boolean retorno = false;

            foreach (Mascota mascotaA in e._manada)
            {
                if (j is Perro)
                {
                    if (((Perro)j).Equals(mascotaA))
                    {
                        retorno = true;
                        break;
                    }
                }
                else if (j is Gato)
                {
                    if (((Gato)j).Equals(mascotaA))
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Grupo e, Mascota j)
        { return !(e == j); }

        public static Grupo operator +(Grupo e, Mascota j)
        {
            if (e != j)
            { e._manada.Add(j); }

            return e;
        }

        public static Grupo operator -(Grupo e, Mascota j)
        {
            if (e == j)
            { e._manada.Remove(j); }

            return e;
        }
    }

    public abstract class Mascota
    {
        private string _nombre;
        private string _raza;

        public string Nombre
        { get { return this._nombre; } }

        public string Raza
        { get { return this._raza; } }

        protected virtual string DatosCompletos()
        { return string.Format("{0} {1}", this._nombre, this._raza); }

        protected abstract string Ficha();

        public Mascota(string nombre, string raza)
        {
            this._nombre = nombre;
            this._raza = raza;
        }
    }

    public class Perro : Mascota
    {
        protected int _edad;
        protected Boolean _esAlfa;

        public int Edad
        {
            get { return this._edad; }
            set { this._edad = value; }
        }

        public Boolean EsAlfa
        {
            get { return this._esAlfa; }
            set { this._esAlfa = value; }
        }

        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Perro)
            {
                if ((Perro)obj == this)
                { retorno = true; }
            }

            return retorno;
        }

        public static explicit operator int(Perro perro)
        { return perro.Edad; }

        protected override string Ficha()
        {
            string s = string.Format("{0}", base.DatosCompletos());

            if (EsAlfa)
            {
                s = string.Format("{0}, alfa de la manada,", s);
            }

            s = string.Format("{0} Edad {1}", s, this.Edad);

            return s;
        }

        public static Boolean operator ==(Perro j1, Perro j2)
        {
            Boolean retorno = false;

            if (j1.Edad == j2.Edad && j1.Nombre == j2.Nombre && j1.Raza == j2.Raza)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Perro j1, Perro j2)
        { return !(j1 == j2); }

        public Perro(string nombre, string raza) : this(nombre, raza, 0, false)
        { }

        public Perro(string nombre, string raza, int edad, bool esAlfa) : base(nombre, raza)
        {
            this._edad = edad;
            this._esAlfa = esAlfa;
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }

    public class Gato : Mascota
    {
        public override bool Equals(object obj)
        {
            Boolean retorno = false;
            if (obj is Gato)
            {
                if ((Gato)obj == this)
                { retorno = true; }
            }

            return retorno;
        }

        protected override string Ficha()
        {
            return string.Format("{0}", base.DatosCompletos());
        }

        public Gato(string nombre, string raza) : base(nombre, raza)
        { }

        public static Boolean operator ==(Gato g1, Gato g2)
        {
            Boolean retorno = false;

            if (g1.Nombre == g2.Nombre && g1.Raza == g2.Raza)
            { retorno = true; }

            return retorno;
        }

        public static Boolean operator !=(Gato g1, Gato g2)
        { return !(g1 == g2); }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}