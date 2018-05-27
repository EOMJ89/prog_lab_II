using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio42_Library;

namespace Ejercicio42
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                N2 num = new N2(2,0);
            }
            catch (MiExcepcion e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}