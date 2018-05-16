using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio47_Library;

namespace Ejercicio47_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Factura f1 = new Factura(3);
            Factura f2 = new Factura(5);
            Factura f3 = new Factura(2);

            Recibo r1 = new Recibo();
            Recibo r2 = new Recibo(2);
            Recibo r3 = new Recibo();

            //Compilan perfectamente
            Contabilidad<Factura, Recibo> contaduria = new Contabilidad<Factura, Recibo>();
            Contabilidad<Documento, Recibo> contaduria2 = new Contabilidad<Documento, Recibo>();
            /* 
             * Contabilidad<Recibo,Factura> contaduria = new Contabilidad<Recibo,Factura>();
             * Contabilidad<Factura, Documento> contaduria = new Contabilidad<Factura, Documento>();
             * //Esto no compilaria porque Factura no tiene un constructor Default
            */

            contaduria += f1;
            contaduria += r1;
            contaduria += f2;
            contaduria += r2;
            contaduria += f3;
            contaduria += r3;

            contaduria2 += f1;
            contaduria2 += r1;
            contaduria2 += f2;
            contaduria2 += r2;
            contaduria2 += f3;
            contaduria2 += r3;

            Console.WriteLine(contaduria.ToString("Factura", "Recibo"));

            Console.WriteLine(contaduria2.ToString("Documento", "Recibo"));

            Console.ReadLine();
        }
    }
}
