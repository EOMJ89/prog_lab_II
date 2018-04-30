using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesPersonas;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico direcTec = new DirectorTecnico("Jorge", "Habbeger");
            Equipo equipo = new Equipo("Huracán de San Rafael Unica", direcTec);
            Jugador fernando = new Jugador("Fernando", "Pandolfi", 11, false);
            Jugador julio = new Jugador("Julio", "Merchant", 8, false);
            Jugador ezequiel = new Jugador("Ezequiel", "Medran", 12, false);
            Jugador jose = new Jugador("José", "Pereda", 24, false);
            Jugador hernan = new Jugador("Hernán", "Florentin", 6, false);
            Jugador fernandoN = new Jugador("Fernando", "Navas", 11, true);

            equipo += fernando;
            equipo += julio;
            equipo += ezequiel;
            equipo += jose;
            equipo += hernan;
            equipo += fernandoN;

            Console.WriteLine((string)equipo);
            Console.ReadLine();
        }
    }
}
