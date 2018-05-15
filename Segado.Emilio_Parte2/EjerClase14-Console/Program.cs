using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase14_Library;

namespace EjerClase14_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba de Parse con Exception
            Numero nuevoNumero;
            bool retornoFuncion = Numero.Parse("44", out nuevoNumero);
            
            Console.WriteLine("Se usa una cadena que puede convertirse:");
            if (retornoFuncion)
            { Console.WriteLine("El valor de número es {0}.", nuevoNumero.MiNumero); }
            else
            { Console.WriteLine("Error. El número no ha podido convertirse."); }

            Console.WriteLine("\nSe usa una cadena que da error:");
            retornoFuncion = Numero.Parse("4-4", out nuevoNumero); //Se cambia el parametro del Parse para crear un nuevo numero que no puede ser parseado

            if (retornoFuncion)
            { Console.WriteLine("El valor de número es {0}.", nuevoNumero.MiNumero); }
            else
            { Console.WriteLine("Error. El número no ha podido convertirse."); }

            //Creacion de los Numeros con el metodo regular
            Numero nuevoNumero2 = new Numero(8);
            Numero nuevoNumero3 = new Numero(2);
            Numero nuevoNumero4 = new Numero(10);
            Numero nuevoNumero5 = new Numero(2);

            ColectoraDeNumeros coleccion = new ColectoraDeNumeros(ETipoNumero.Par); //Creacion de la coleccion            

            //Prueba de la excepcion al agregar a la lista
            try
            { coleccion += nuevoNumero; } //Intentar -> añadir el Numero a la lista...
            catch (Exception e)
            { Console.WriteLine(e.Message); } //Si se atrapó una excepcion, mostrar el mensaje almacenado en esta

            coleccion += nuevoNumero2; //Añade más Numero a la lista de la forma regular
            coleccion += nuevoNumero3;
            coleccion += nuevoNumero4;
            coleccion += nuevoNumero5;

            try
            { coleccion -= new Numero(12); } //Intentar -> restar el Numero de la lista...
            catch (Exception e)
            { Console.WriteLine(e.Message); } //Si se atrapó una excepcion, mostrar el mensaje almacenado en esta

            Console.ReadLine();
        }
    }
}
