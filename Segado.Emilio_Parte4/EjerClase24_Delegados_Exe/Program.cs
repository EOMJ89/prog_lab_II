using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase24_Delegados_ClassLibrary;

namespace EjerClase24_Delegados_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado empleadoA = new Empleado("Test", "Empleado", 12345678);
            //Se añaden los Metodos a las respectivas listas de invocacion de sus Delegados para cada evento
            empleadoA.SueldoCero += new DelegadoSueldoCero(Empleado.ManejarEventoSueldoCero); 
            empleadoA.SueldoMaximo += new DelegadoLimiteSueldo(Empleado.ManejarEventoSueldoMaximo);
            empleadoA.SueldoMaximoMejorado += new DelegadoLimiteSueldoMejorado(Empleado.ManejarEventoSueldoMaximoMejorado);
            
            try //Validación para la excepcion de Sueldo Negativo.
            { empleadoA.Sueldo = 22000; }
            catch (SueldoNegativoException excep)
            { Console.WriteLine("El sueldo que se intenta ingresar es Negativo"); }

            Console.ReadLine();
        }
    }
}
