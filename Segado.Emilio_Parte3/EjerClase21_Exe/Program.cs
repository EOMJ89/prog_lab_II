using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase21_Library;

namespace EjerClase21_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Persona.TraerTodos(); 

            foreach (Persona itemPersona in Persona.TraerTodos())
            { Console.WriteLine(itemPersona); }
            Console.ReadLine();
        }
    }
}
