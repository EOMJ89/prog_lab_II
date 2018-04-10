using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase07_Ejercicio29_Clases
{
    public class Jugador
    {
        private long _dni;
        private string _nombre;
        private int _partidosJugados;
        private float _promedioGoles;
        private int _totalGoles;

        public Jugador(string nombre, long dni, int partidosJugados, int totalGoles)
            : this(nombre, dni)
        {
            this._partidosJugados = partidosJugados;
            this._totalGoles = totalGoles;
        }

        public Jugador(string nombre, long dni)
            : this()
        {
            this._nombre = nombre;
            this._dni = dni;
        }

        private Jugador()
        {
            this._nombre = "Sin Nombre";
            this._dni = 1;
            this._partidosJugados = 0;
            this._totalGoles = 0;
            this._promedioGoles = this.GetPromedioGoles();
        }

        public float GetPromedioGoles()
        {
            float retorno = 0;

            if (this._partidosJugados != 0)
            {
                retorno = (float)this._totalGoles / (float)this._partidosJugados;
            }

            return retorno;
        }

        public string MostrarDatos()
        {
            string retorno = "";

            retorno += "Nombre: " + this._nombre + " - DNI: " + this._dni + " - Partidos: " + this._partidosJugados + " - Goles: " + this._totalGoles + " - Promedio: ";
            retorno += this.GetPromedioGoles();

            return retorno;
        }

        public static Boolean operator ==(Jugador jugador1, Jugador jugador2)
        {
            Boolean retorno = false;

            if (jugador1._dni == jugador2._dni)
            {
                retorno = true;
            }
            return retorno;
        }

        public static Boolean operator !=(Jugador jugador1, Jugador jugador2)
        {
            return !(jugador1 == jugador2);
        }
    }

    public class Equipo
    {
        private short cantidadJugadores;
        private List<Jugador> jugadores;
        private string nombre;

        private Equipo()
        {
            this.jugadores = new List<Jugador>(5);
        }

        public Equipo(short cantidad, string nombre)
            : this()
        {
            this.cantidadJugadores = cantidad;
            this.nombre = nombre;
        }

        public static Boolean operator +(Equipo equipo1, Jugador jugador1)
        {
            Boolean retorno = false;


            if (equipo1.jugadores.Count() < equipo1.cantidadJugadores)
            {
                Boolean flag = false;

                foreach (Jugador jugadorAux in equipo1.jugadores)
                {
                    if (jugadorAux == jugador1) //Al ser lista generica, siempre habrá un jugador en la lista
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    equipo1.jugadores.Add(jugador1);
                    retorno = true;
                }
            }

            return retorno;
        }

        public List<Jugador> GetJugadores()
        {
            return this.jugadores;
        }
    }
}
