using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 07";
            int diaIngreso = 0, mesIngreso = 0, anioIngreso = 0;
            //Flag
            bool flagDia = false, flagMes = false, flagAnio = false;

            do
            {
                if (flagDia == true && diaIngreso < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Dia: ");
                diaIngreso = int.Parse(Console.ReadLine());

                flagDia = true;
            } while (diaIngreso < 1 && diaIngreso > 31);

            do
            {
                if (flagMes == true && mesIngreso < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Mes: ");
                mesIngreso = int.Parse(Console.ReadLine());

                flagMes = true;
            } while (mesIngreso < 1 && mesIngreso > 12);

            do
            {
                if (flagAnio == true && anioIngreso < 1)
                {
                    Console.WriteLine("ERROR. Reingresar Numero.");
                }
                Console.Write("Ingrese Anio: ");
                anioIngreso = int.Parse(Console.ReadLine());

                flagAnio = true;
            } while (anioIngreso < 1 && anioIngreso > 3000);

            Console.Write("La fecha ingresada es: {0}", diaIngreso);
            switch (mesIngreso-1)
            {
                case 0:
                    {
                        Console.Write(" de Enero de ");
                        break;
                    }
                case 1:
                    {
                        Console.Write(" de Febrero de ");
                        break;
                    }
                case 2:
                    {
                        Console.Write(" de Marzo de ");
                        break;
                    }
                case 3:
                    {
                        Console.Write(" de Abril de ");
                        break;
                    }
                case 4:
                    {
                        Console.Write(" de Mayo de ");
                        break;
                    }
                case 5:
                    {
                        Console.Write(" de Junio de ");
                        break;
                    }
                case 6:
                    {
                        Console.Write(" de Julio de ");
                        break;
                    }
                case 7:
                    {
                        Console.Write(" de Agosto de ");
                        break;
                    }
                case 8:
                    {
                        Console.Write(" de Septiembre de ");
                        break;
                    }
                case 9:
                    {
                        Console.Write(" de Octubre de ");
                        break;
                    }
                case 10:
                    {
                        Console.Write(" de Noviembre de ");
                        break;
                    }
                default:
                    {
                        Console.Write(" de Diciembre de ");
                        break;
                    }
            }
            Console.WriteLine(anioIngreso);
            
            DateTime ingresed = new DateTime (anioIngreso, mesIngreso, diaIngreso);
            //Console.WriteLine(ingresed.ToString("dd/MM/yyyy"));

            int anio = DateTime.Now.Year - ingresed.Year;
            int mes = DateTime.Now.Month - ingresed.Month;
            int dia = DateTime.Now.Day - ingresed.Day;
            Console.WriteLine("La edad es de {0} anios, {1} meses y {2} dias",anio,mes,dia);
            Console.ReadLine();

        }
    }
}
