using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesPersonas
{
    public abstract class Persona
    {
        private string _nombre;
        private string _apellido;

        public string Nombre
        { get { return this._nombre; } }

        public string Apellido
        { get { return this._apellido; } }

        protected abstract String FichaTecnica();

        protected string NombreCompleto()
        { return string.Format("{0} {1}", this.Nombre, this.Apellido); }

        public Persona(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }
    }

    public class DirectorTecnico : Persona
    {
        public DirectorTecnico(string nombre, string apellido) : base(nombre, apellido)
        { }

        protected override string FichaTecnica()
        {
            return string.Format("{0,-25}",base.NombreCompleto());
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }
    }

    public class Jugador : Persona
    {
        private Boolean _esCapitan;
        private Int32 _numero;

        public Boolean EsCapitan
        { get { return this._esCapitan; } set { this._esCapitan = value; } }

        public Int32 Numero
        { get { return this._numero; } set { this._numero = value; } }

        public override bool Equals(object obj)
        {
            Boolean retorno = false;

            if (obj is Jugador)
            {
                if ((Jugador)obj == this)
                { retorno = true; }
            }
            return retorno;
        }

        public static explicit operator Int32(Jugador jugador)
        { return jugador.Numero; }

        protected override string FichaTecnica()
        {
            string retorno = string.Format("{0,-25}", base.NombreCompleto());

            if (this.EsCapitan)
            { string.Format("{0}, Capitan del Equipo,", retorno); }

            return string.Format("{0} Camiseta N°{1:00}", retorno, this.Numero);
        }

        public Jugador(string nombre, string apellido) : this(nombre, apellido, 0, false)
        { }

        public Jugador(string nombre, string apellido, Int32 numero, Boolean esCapitan) : base(nombre, apellido)
        {
            this.Numero = numero;
            this.EsCapitan = esCapitan;
        }

        public static Boolean operator ==(Jugador jugador1, Jugador jugador2)
        {
            Boolean retorno = false;

            if (jugador1.NombreCompleto() == jugador2.NombreCompleto() && jugador1.Numero == jugador2.Numero)
            {
                retorno = true;
            }

            return retorno;
        }

        public static Boolean operator !=(Jugador jugador1, Jugador jugador2)
        {
            return !(jugador1 == jugador2);
        }

        public override string ToString()
        {
            return this.FichaTecnica();
        }
    }

    public class Equipo
    {
        private EDeporte _deporte;
        private DirectorTecnico _dt;
        private List<Jugador> _jugadores;
        private string _nombre;

        public EDeporte Deporte
        { set { this._deporte = value; } }

        private Equipo()
        {
            this._jugadores = new List<Jugador>();
        }

        public Equipo(string nombre, DirectorTecnico dt) : this(nombre, dt, EDeporte.Futbol)
        { }

        public Equipo(string nombre, DirectorTecnico dt, EDeporte deporte) : this()
        {
            this._nombre = nombre;
            this._dt = dt;
            this.Deporte = deporte;
        }

        public static explicit operator String(Equipo equipo)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("**{0} {1}**\nNomina de Jugadores:\n", equipo._nombre,equipo._deporte.ToString());

            foreach (Jugador jugadorA in equipo._jugadores)
            {
                if (jugadorA is Jugador)
                {
                    stringBuild.AppendLine(jugadorA.ToString());
                }
            }

            stringBuild.AppendLine("Dirigido por: " + equipo._dt.ToString());

            return stringBuild.ToString();
        }

        public static Equipo operator +(Equipo equipo1, Jugador jugador1)
        {
            if (equipo1 != jugador1)
            { equipo1._jugadores.Add(jugador1); }

            return equipo1;
        }

        public static Equipo operator -(Equipo equipo1, Jugador jugador1)
        {
            if (equipo1 == jugador1)
            { equipo1._jugadores.Remove(jugador1); }

            return equipo1;
        }

        public static Boolean operator ==(Equipo equipo, Jugador jugador1)
        {
            Boolean retorno = false;

            foreach (Jugador jugadorA in equipo._jugadores)
            {
                if (jugadorA == jugador1)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static Boolean operator !=(Equipo equipo, Jugador jugador1)
        { return !(equipo == jugador1); }
    }
}
