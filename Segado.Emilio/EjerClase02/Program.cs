using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Referencia a la libreria de clases puesta como referencia (DLL)
            EntidadSello.Sello.mensaje = "Test";

            //Cambio de color de letra
            EntidadSello.Sello.color = ConsoleColor.White;
            /*EntidadSello.Sello.Imprimir();
            Console.ReadLine();
            EntidadSello.Sello.Borrar();
            */
            ////Añadir Sello
            //EntidadSello.Sello.mensaje = EntidadSello.Sello.ArmarFormatoMensaje();
            //EntidadSello.Sello.Imprimir();

            
            EntidadSello.Sello.mensaje = "AA";
            EntidadSello.Sello.Imprimir();
            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

            //Referencia a la clase dentro del mismo namespace
            /*
            Sello.mensaje = "Test";

            Sello.Imprimir();
            Console.ReadLine(); 
            Sello.Borrar();
            Console.ReadLine();*/
        }
    }
}
