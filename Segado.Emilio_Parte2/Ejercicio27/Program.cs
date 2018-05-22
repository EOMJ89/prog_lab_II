using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio27
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 27";

            Random r = new Random();
            #region Pilas
            Console.WriteLine("Pilas");
            System.Collections.Stack pila = new System.Collections.Stack();

            for (int i = 0; i < 20; i++)
            {
                pila.Push(r.Next(100, 200));
            }

            Console.WriteLine("Mostrar como se ingresó");
            MostrarPila(pila);

            Console.WriteLine("\nMostrar de forma decreciente");
            pila = SortStack(pila, false);
            MostrarPila(pila);

            Console.WriteLine("\nMostrar de forma creciente");
            pila = SortStack(pila, true);
            MostrarPila(pila);

            Console.ReadLine();
            #endregion
            Console.Clear();

            #region Colas
            Console.WriteLine("Colas");
            System.Collections.Queue cola = new System.Collections.Queue();

            for (int i = 0; i < 20; i++)
            {
                cola.Enqueue(r.Next(100, 200));
            }

            Console.WriteLine("Mostrar como se ingresó");
            MostrarCola(cola);

            Console.WriteLine("\nMostrar de forma decreciente");
            cola = SortQueue(cola, true);
            MostrarCola(cola);

            Console.WriteLine("\nMostrar de forma creciente");
            cola = SortQueue(cola, false);
            MostrarCola(cola);

            Console.ReadLine();
            #endregion
            Console.Clear();

            #region Listas
            Console.WriteLine("Listas");
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            for (int i = 0; i < 20; i++)
            {
                lista.Add(r.Next(100, 200));
            }

            Console.WriteLine("Mostrar como se ingresó");
            MostrarLista(lista);

            Console.WriteLine("\nMostrar de forma decreciente");
            lista.Sort();
            lista.Reverse();
            MostrarLista(lista);

            Console.WriteLine("\nMostrar de forma creciente");
            lista.Reverse();
            MostrarLista(lista);

            Console.ReadLine();
            #endregion
        }

        public static void MostrarPila(System.Collections.Stack pila)
        {
            foreach (int intA in pila)
            { Console.WriteLine(intA); }
        }

        public static System.Collections.Stack SortStack(System.Collections.Stack pila, Boolean Order)
        {
            object[] vectorA = pila.ToArray();

            int aux1;

            if (Order)
            {
                for (int i = 0; i < vectorA.Length - 1; i++)
                {
                    for (int j = i + 1; j < vectorA.Length; j++)
                    {
                        if ((int)vectorA[i] < (int)vectorA[j])
                        {
                            aux1 = (int)vectorA[i];
                            vectorA[i] = vectorA[j];
                            vectorA[j] = aux1;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < vectorA.Length - 1; i++)
                {
                    for (int j = i + 1; j < vectorA.Length; j++)
                    {
                        if ((int)vectorA[i] > (int)vectorA[j])
                        {
                            aux1 = (int)vectorA[i];
                            vectorA[i] = vectorA[j];
                            vectorA[j] = aux1;
                        }
                    }
                }
            }

            System.Collections.Stack pila1 = new System.Collections.Stack();

            for (int i = 0; i < vectorA.Length - 1; i++)
            {
                pila1.Push((int)vectorA[i]);
            }

            return pila1;
        }


        public static void MostrarCola(System.Collections.Queue pila)
        {
            foreach (int intA in pila)
            { Console.WriteLine(intA); }
        }

        public static System.Collections.Queue SortQueue(System.Collections.Queue pila, Boolean Order)
        {
            object[] vectorA = pila.ToArray();

            int aux1;

            if (Order)
            {
                for (int i = 0; i < vectorA.Length - 1; i++)
                {
                    for (int j = i + 1; j < vectorA.Length; j++)
                    {
                        if ((int)vectorA[i] < (int)vectorA[j])
                        {
                            aux1 = (int)vectorA[i];
                            vectorA[i] = vectorA[j];
                            vectorA[j] = aux1;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < vectorA.Length - 1; i++)
                {
                    for (int j = i + 1; j < vectorA.Length; j++)
                    {
                        if ((int)vectorA[i] > (int)vectorA[j])
                        {
                            aux1 = (int)vectorA[i];
                            vectorA[i] = vectorA[j];
                            vectorA[j] = aux1;
                        }
                    }
                }
            }

            System.Collections.Queue pila1 = new System.Collections.Queue();

            for (int i = 0; i < vectorA.Length - 1; i++)
            {
                pila1.Enqueue((int)vectorA[i]);
            }

            return pila1;
        }


        public static void MostrarLista(System.Collections.ArrayList pila)
        {
            foreach (int intA in pila)
            { Console.WriteLine(intA); }
        }
    }
}

