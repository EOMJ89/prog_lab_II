using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio08
{
    class Program
    {
        static void Main(string[] args)
        {
            //Por teclado se ingresa el valor hora, el nombre, la antigüedad(en años) y la cantidad de horas
            //trabajadas en el mes de ‗n‘ empleados de una fábrica.
            //Se pide calcular el importe a cobrar teniendo en cuenta que el total(que resulta de multiplicar el
            //valor hora por la cantidad de horas trabajadas), hay que sumarle la cantidad de años trabajados
            //multiplicados por $ 150, y al total de todas esas operaciones restarle el 13 % en concepto de
            //descuentos.
            //Mostrar el recibo correspondiente con el nombre, la antigüedad, el valor hora, el total a cobrar en
            //bruto, el total de descuentos y el valor neto a cobrar de todos los empleados ingresados.
            //Nota: Utilizar estructuras repetitivas y selectivas.
            Console.Title = "Ejercicio Nro 08";

            int aniosAntiguedad = 0, cantidadHorasTrabajadas = 0;
            float valorHora = 0, totalACobrar = 0;
            string nombre = "";

            //Flag
            bool flagAntiguedad = false, flagValorHora = false, flagHorasTrabajadas = false, flagNombre = false;


            do
            {
                if (flagNombre == true && nombre == "")
                {
                    Console.WriteLine("ERROR. Reingresar Nombre.");
                }
                Console.Write("Ingrese nombre: ");
                nombre = Console.ReadLine();
                flagNombre = true;
            } while (nombre == "");
            
            
            do
            {
                if (flagValorHora == true && valorHora < 0)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Valor Hora: ");
                valorHora = float.Parse(Console.ReadLine());
                flagValorHora = true;
            } while (valorHora < 0);

            do
            {
                if (flagAntiguedad == true && aniosAntiguedad < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Antiguedad: ");
                aniosAntiguedad = int.Parse(Console.ReadLine());
                flagAntiguedad = true;
            } while (aniosAntiguedad < 1);
            
            do
            {
                if (flagHorasTrabajadas == true && cantidadHorasTrabajadas < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Cantidad de Horas Trabajadas: ");
                cantidadHorasTrabajadas = int.Parse(Console.ReadLine());
                flagHorasTrabajadas = true;
            } while (cantidadHorasTrabajadas < 1);

            totalACobrar = (cantidadHorasTrabajadas * valorHora) + (aniosAntiguedad * 150);
            Console.WriteLine("El total a cobrar neto de {1} es {0}", totalACobrar,nombre);

            totalACobrar =  totalACobrar - (totalACobrar * 13 / 100);
            Console.WriteLine("El total a cobrar de {1} es {0}", totalACobrar,nombre);

            Console.ReadLine();
        }
    }
}
