using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase06_Entidades;

namespace EjerClase06_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Clase 06";

            Tempera tempera1 = new Tempera(ConsoleColor.Cyan, "Test", 5);
            Tempera tempera2 = new Tempera(ConsoleColor.Cyan, "Test", 7);
            Tempera tempera3 = new Tempera(ConsoleColor.Green, "Test", 8);

            //Temperas
            //Console.WriteLine(Tempera.Mostrar(tempera1));
            //Console.WriteLine(tempera1 == tempera2);
            //Console.WriteLine(tempera1 != tempera2);
            //Console.WriteLine(tempera1 != tempera3);

            //Console.WriteLine((string)tempera1);
            string cad = (string)tempera2;
            //Console.WriteLine(cad);

            //Console.WriteLine("Tempera 1 + 2: {0}", ((int)tempera2 + tempera1));

            Paleta paleta1 = 6;
            Paleta paleta2 = 7;

            Console.WriteLine((string)paleta1);
            Console.WriteLine(paleta1 == tempera1);

            paleta1 += tempera2;
            Console.WriteLine((string)paleta1);
            paleta1 += tempera3;
            Console.WriteLine((string)paleta1 + "\n");

            paleta1 -= tempera1;
            Console.WriteLine((string)paleta1);
            paleta1 -= tempera2;
            Console.WriteLine((string)paleta1);

            Console.ReadLine();
        }
    }
}
