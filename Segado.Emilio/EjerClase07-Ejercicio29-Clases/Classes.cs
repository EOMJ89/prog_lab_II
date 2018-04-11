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

        //Declaracion de propiedad de solo lectura
        public long Dni { get { return this._dni; } }
        //Declaracion de propiedad de lecto-escritura
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }
        public int PartidosJugados { get { return this._partidosJugados; } set { this._partidosJugados = value; } }
        public int TotalGoles { get { return this._totalGoles; } set { this._totalGoles = value; } }

        //Constructor parametrizado que llama al constructor de nombre y dni
        public Jugador(string nombre, long dni, int partidosJugados, int totalGoles)
            : this(nombre, dni)
        {
            this._partidosJugados = partidosJugados;
            this._totalGoles = totalGoles;
        }
        
        //Constructor parametrizado que llama al default privado
        public Jugador(string nombre, long dni)
            : this()
        {
            this._nombre = nombre;
            this._dni = dni;
        }

        //Constructor privado que inicializa los valores en default (aun no valida que las entradas no estén vacias, por lo que se puede llegar a tener nombre con ""
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

            if (this._partidosJugados != 0) //Validación de division porque no se puede divivir por 0
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

            if (jugador1.Dni == jugador2.Dni) //Compara DNI para determianr igualdad
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

        private Equipo() //Inicializa la lista de jugadores, debe ser llamado por ser privado
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(short cantidad, string nombre)
            : this() //Constructor que llama al privado para inicializar la lista y luego inicializa la cantidad y el nombre del equipo (aun no valida entradas vacias de textbox así que puede haber nombre "" y cantidad 0)
        {
            this.cantidadJugadores = cantidad;
            this.nombre = nombre;
        }

        public static Boolean operator +(Equipo equipo1, Jugador jugador1) 
        {
            Boolean retorno = false;

            if (equipo1.jugadores.Count() < equipo1.cantidadJugadores) //Mientras la cantidad de jugadores de la lista sea menos a la cantidad maxima de jugadores...
            {
                Boolean flag = false;

                foreach (Jugador jugadorAux in equipo1.jugadores) //por cada jugador en la lista
                {
                    if (jugadorAux == jugador1) //Al ser lista generica, siempre habrá un jugador en la lista, si el jugador a agregar es igual a un jugador de la lista...
                    {
                        flag = true; //Flag para demostrar que el jugador ya está en el equipo
                        break; //No hace falta seguir buscando
                    }
                }

                if (!flag) //Si el jugador no estaba en la lista...
                {
                    equipo1.jugadores.Add(jugador1); //Añade el jugador con el metodo de la lista
                    retorno = true; 
                }
            }

            return retorno;
        }

        public static Boolean operator -(Equipo equipo1, Jugador jugador1)
        {
            Boolean retorno = false;

            foreach (Jugador jugadorAux in equipo1.jugadores) //Por cada jugador en la lista
            {
                if (jugadorAux == jugador1) //Al ser lista generica, siempre habrá un jugador en la lista, compara jugador de lista con el jugador de parametro
                {
                    //Puede reducirse todo a una linea pero sería más dificil de leer

                    int indexJugador = equipo1.jugadores.IndexOf(jugadorAux); //Obtiene el indice en donde se encuentra el jugador a eliminar
                    equipo1.jugadores.RemoveAt(indexJugador); //Eliminar el jugador ubicado en el indice buscado anteriormente
                    retorno = true;
                    break; //No hace falta buscar más
                }
            }

            return retorno;
        }

        public List<Jugador> GetJugadores()
        {
            return this.jugadores;
        }

        public void SetJugador(Jugador jugador1, int index) //Metodo especial para poder asignar a la lista
        {
            this.jugadores[index] = jugador1; //Reemplaza el item de la lista por el ingresado por parametro (no usar Insert porque lo añade, más no reemplaza ninguno objeto)
        }
    }
}
