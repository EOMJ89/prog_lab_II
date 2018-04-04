using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase05_Library;

namespace EjerClase05_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Tinta tintaEjemplo = new Tinta();
            Tinta tintaEjemplo2 = new Tinta(ConsoleColor.Magenta);
            Tinta tintaEjemplo3 = new Tinta(ETipoTinta.ConBrillito);
            Tinta tintaEjemplo4 = new Tinta(ConsoleColor.DarkRed, ETipoTinta.China);
            Tinta tintaEjemplo5 = new Tinta();

            Console.WriteLine(Tinta.Mostrar(tintaEjemplo));
            Console.WriteLine(Tinta.Mostrar(tintaEjemplo2));
            Console.WriteLine(Tinta.Mostrar(tintaEjemplo3));
            Console.WriteLine(Tinta.Mostrar(tintaEjemplo4));

            Console.WriteLine("La comparacion entre T1 y T2 es {0}\n",tintaEjemplo == tintaEjemplo2);
            Console.WriteLine("La comparacion entre T1 y T4 es {0}\n",tintaEjemplo != tintaEjemplo4);
            Console.WriteLine("La comparacion entre T1 y T5 es {0}\n",tintaEjemplo == tintaEjemplo5);
            Console.ReadLine();

            Pluma pluma1 = new Pluma(); //Da error por el null de la tinta
            Pluma pluma2 = new Pluma("A", tintaEjemplo4, 5);
            Console.WriteLine(pluma2 + "\n");
            Console.WriteLine("La tinta en P2 y T4 son iguales: {0}",pluma2 == tintaEjemplo4);
            Console.WriteLine("La tinta en P2 y T3 son iguales: {0}\n",pluma2 == tintaEjemplo3);

            pluma2 += tintaEjemplo4;
            Console.WriteLine(pluma2 + "\n");

            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4;
            pluma2 -= tintaEjemplo4; // A partir de aquí ya no los toma en cuennta
            pluma2 -= tintaEjemplo4;
            Console.WriteLine(pluma2);
            Console.ReadLine();
        }
    }
}
