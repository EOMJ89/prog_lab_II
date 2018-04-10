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
            Equipo equipoTest = new Equipo(4,"Test Equipo");


            Console.WriteLine("Sumar jugadores");
            Console.WriteLine((Boolean)(equipoTest + jugadorUno));
            Console.WriteLine((Boolean)(equipoTest + jugadorDos));
            Console.WriteLine((Boolean)(equipoTest + jugadorTres));

            List<Jugador> lista2;

            lista2 = equipoTest.GetJugadores();
            Console.WriteLine(lista2.Count());
            Console.ReadLine();
        }
    }
}
