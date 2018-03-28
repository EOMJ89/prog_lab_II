using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadSello
{
    public class Sello
    {
        public static string mensaje;
        //ConsoleColor es un enumerado (especie de constante con N valores)
        public static ConsoleColor color;

        public static void Imprimir()
        {
            string auxMensaje = "";
            Console.ForegroundColor = Sello.color;

            if(Sello.TryParse(Sello.mensaje, out auxMensaje))
            {
                Console.WriteLine(auxMensaje);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Borrar()
        {
            Console.Clear();
        }

        private static string ArmarFormatoMensaje()
        {
            string retorno = "";

            for (int i = 0; i < (Sello.mensaje.Length + 2); i++)
            {
                retorno += "*";
            }

            retorno += "\n";
            retorno += "*";
            retorno += Sello.mensaje;
            retorno += "*";
            retorno += "\n";
            for (int i = 0; i < (Sello.mensaje.Length + 2); i++)
            {
                retorno += "*";
            }
            return retorno;
        }

        private static bool TryParse(string entrada, out string salida)
        {
            Boolean retorno = false;
            salida = "";
            if (entrada == "")
            {
                retorno = false;
            }
            else
            {
                salida = Sello.ArmarFormatoMensaje();
                retorno = true;
            }
            
            return retorno;
        }
    }
}
