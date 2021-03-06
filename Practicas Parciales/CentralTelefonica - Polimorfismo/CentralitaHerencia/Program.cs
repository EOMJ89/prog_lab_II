﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesCentralita;

namespace CentralitaHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Centralita telefonica = new Centralita("Telefonica");

            Local llamada1 = new Local("A", "Z", 30, 2.65);
            Provincial llamada2 = new Provincial("B", "Y", 21, EFranja.Franja_1);
            Local llamada3 = new Local("C", "X", 45, 1.99);
            Provincial llamada4 = new Provincial("D", "T", 21, EFranja.Franja_3);

            Provincial llamada5 = new Provincial("J", "g", 22, EFranja.Franja_2);

            telefonica._listaDeLlamadas.Add(llamada1);
            telefonica._listaDeLlamadas.Add(llamada2);
            telefonica._listaDeLlamadas.Add(llamada3);
            telefonica._listaDeLlamadas.Add(llamada4);

            Console.WriteLine(telefonica == llamada1);
            Console.WriteLine(telefonica == llamada5);
            telefonica += ((Llamada)llamada5);
            Console.WriteLine(telefonica == llamada5);
            Console.Write(telefonica);
            Console.ReadLine();
            telefonica._listaDeLlamadas.Sort(Llamada.OrdernarPorDuracion);

            Console.Clear();
            Console.Write(telefonica);
            Console.ReadLine();

        }
    }
}
