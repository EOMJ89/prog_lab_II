using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio09
{
    class Program
    {
        static void Main(string[] args)
        {
            //Escribir un programa que imprima por pantalla una pirámide como la siguiente:
            //*
            //***
            //*****
            //*******
            //*********
            //El usuario indicará cuál será la altura de la pirámide ingresando un número entero positivo. Para el ejemplo anterior la altura ingresada fue de 5.
            //Nota: Utilizar estructuras repetitivas y selectivas.
            Console.Title = "Ejercicio Nro 09";
            int cantLineas = 0;
            Boolean flag = false;
            do
            {
                if (flag == true && cantLineas < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Nro: ");
                cantLineas = int.Parse(Console.ReadLine());

                flag = true;
            } while (cantLineas < 1);

            for (int i = 0; i <=cantLineas; i++)
            {
                for(int j = 0; j <=2*i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
