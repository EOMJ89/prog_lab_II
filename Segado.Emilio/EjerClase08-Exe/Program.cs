using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase08;

namespace EjerClase08_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Lavadero lavadero = new Lavadero(1, 2, 3);
            Auto auto1 = new Auto("AB", 4, EMarcas.Fiat, 4);
            Auto auto2 = new Auto("BC", 4, EMarcas.Iveco, 4);
            Camion camion1 = new Camion("JK", 18, EMarcas.Iveco, 30);
            Camion camion2 = new Camion("JK", 8, EMarcas.Iveco, 56); //Es igual a camion1, por lo que no se puede agregar
            Moto moto1 = new Moto("FG", 2, EMarcas.Honda, 50);

            Console.WriteLine(lavadero.LavaderoAll);

            Console.WriteLine("Añadir vehiculo y mostrar");
            lavadero += auto1;
            Console.WriteLine(lavadero.LavaderoAll);

            Console.WriteLine("Intentar añadir vehiculo ya ingresado y mostrar");
            lavadero += auto1;
            Console.WriteLine(lavadero.LavaderoAll);

            Console.WriteLine("Quitar Vehiculo y mostrar");            
            lavadero -= auto1;
            Console.WriteLine(lavadero.LavaderoAll);
            
            Console.WriteLine("Añade todos los demás vehiculos");
            lavadero += auto1;
            lavadero += auto2;
            lavadero += camion1;
            lavadero += camion2;
            lavadero += moto1;
            
            Console.WriteLine("\nMostrar precio total");
            Console.WriteLine(lavadero.MostrarTotalFacturado());

            Console.WriteLine("\nMostrar precio de auto");
            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculo.Auto));

            Console.WriteLine("\nMostrar precio de camion");
            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculo.Camion));
            
            Console.WriteLine("\nMostrar precio de moto");
            Console.WriteLine(lavadero.MostrarTotalFacturado(EVehiculo.Moto));
            
            Console.WriteLine("\nMostrar Ordenar de por patente");
            Console.WriteLine(Lavadero.OrdenarVehiculosPorPatentes(auto1, auto2));
            Console.WriteLine(Lavadero.OrdenarVehiculosPorPatentes(auto2, auto2));
            Console.WriteLine(Lavadero.OrdenarVehiculosPorPatentes(auto2, auto1));

            Console.WriteLine("\nMostrar Ordenar por marca");
            Console.WriteLine(Lavadero.OrdenarVehiculosPorMarca(auto1, auto2));
            Console.WriteLine(Lavadero.OrdenarVehiculosPorMarca(auto2, auto2));
            Console.WriteLine(Lavadero.OrdenarVehiculosPorMarca(auto2, auto1));
            Console.ReadLine();
        }
    }
}
