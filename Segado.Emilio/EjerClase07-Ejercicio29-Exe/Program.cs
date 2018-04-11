using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase07_Ejercicio29_Clases;

namespace EjerClase07_Ejercicio29_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Jugador jugadorUno = new Jugador("Jorge", 354366, 5, 8);
            Jugador jugadorDos = new Jugador("Mario", 654646, 7, 1);
            Jugador jugadorTres = new Jugador("Manuel", 76576576, 45, 38);
            Jugador jugadorCuatro = new Jugador("Andres", 4897, 2, 0);
            Jugador jugadorCinco = new Jugador("Angel", 7894, 43, 54);
            Equipo equipoTest = new Equipo(4, "Test Equipo");

            Console.WriteLine("Sumar jugadores Uno, Dos, y Tres");
            Console.WriteLine(equipoTest + jugadorUno);
            Console.WriteLine(equipoTest + jugadorDos);
            Console.WriteLine(equipoTest + jugadorTres);

            Console.WriteLine("Sumar jugador Tres Nuevamente");
            Console.WriteLine(equipoTest + jugadorTres);
           
            Console.WriteLine("Sumar jugador Cuatro");
            Console.WriteLine(equipoTest + jugadorCuatro);

            Console.WriteLine("Sumar jugador Cinco con todos los jugares ocupados");
            Console.WriteLine(equipoTest + jugadorCinco);

            Console.Clear();
            Console.WriteLine("Resta jugador Cuatro");
            Console.WriteLine(equipoTest - jugadorCuatro);

            List<Jugador> lista2;

            lista2 = equipoTest.GetJugadores();
            Console.WriteLine(lista2.Count());
            Console.ReadLine();
        }
    }
}
