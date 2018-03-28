using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 16";

            Alumno alumno1 = new Alumno("Manuel", "Rodriguez", 100);
            Alumno alumno2 = new Alumno("Alex", "Strada", 101);
            Alumno alumno3 = new Alumno("Martin", "Laurence", 103);

            alumno1.Mostrar();
            Console.WriteLine();
            alumno2.Estudiar(2, 6);
            alumno2.CalcularFinal();
            alumno2.Mostrar();
            Console.WriteLine();
            alumno3.Estudiar(5, 7);
            alumno3.CalcularFinal();
            alumno3.Mostrar();
            Console.ReadLine();
        }
    }
}
