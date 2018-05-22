using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase18_Interfaces_Libray;

namespace EjerClase18_Interfaces_Ejecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Carreta c1 = new Carreta(100);
            Deportivo d1 = new Deportivo(100, "Patente Deportivo", 200);
            Familiar f1 = new Familiar(100,"Patente Familiar",4);
            Avion a1 = new Avion(100, 50);
            Privado p1 = new Privado(100, 50, 5);
            Comercial co1 = new Comercial(100, 45, 20);

            c1.MostrarPrecio();

            d1.MostrarPrecio();
            d1.MostrarPatente();
            Console.WriteLine("El impuesto es de ${0:#,##}.\n", ((IAFIP)d1).CalcularImpuesto());

            f1.MostrarPrecio();
            f1.MostrarPatente();

            Console.WriteLine("El impuesto de Deportivo es {0}.", Gestion.MostrarImpuestoNacional(d1));
            Console.WriteLine("El impuesto de Avion es {0}.", Gestion.MostrarImpuestoNacional(a1));
            Console.WriteLine("El impuesto de Privado es {0}.", Gestion.MostrarImpuestoNacional(p1));
            Console.WriteLine("El impuesto de Comercial es {0}.", Gestion.MostrarImpuestoNacional(co1));

            Console.WriteLine("\nEl impuesto de Deportivo es {0}.", Gestion.MostrarImpuestoProvincial(c1));
            Console.WriteLine("El impuesto de Deportivo es {0}.", Gestion.MostrarImpuestoProvincial(d1));
            Console.WriteLine("El impuesto de Avion es {0}.", Gestion.MostrarImpuestoProvincial(a1));
            Console.WriteLine("El impuesto de Privado es {0}.", Gestion.MostrarImpuestoProvincial(p1));
            Console.WriteLine("El impuesto de Comercial es {0}.", Gestion.MostrarImpuestoProvincial(co1));

            Console.ReadLine();
        }
    }
}
