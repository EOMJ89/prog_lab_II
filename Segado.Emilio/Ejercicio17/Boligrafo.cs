using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBoligrafo
{


    class Boligrafo
    {
        private const short cantidadTintaMaxima = 100;
        private ConsoleColor color;
        private short tinta;

        public ConsoleColor GetColor()
        {
            return this.color;
        }

        public short GetTinta()
        {
            return this.tinta;
        }

        //El método Pintar(int, out string) restará la tinta gastada, sin poder quedar el nivel en negativo,
        //avisando si pudo pintar (nivel de tinta mayor a 0).
        //También informará mediante el out string tantos "*" como haya podido "gastar" del nivel de tinta. O sea,
        //si nivel de tinta es 10 y gasto es 2 valdrá "**" y si nivel de tinta es 3 y gasto es 10 "***". 

        public bool Pintar(int gasto, out string dibujo)
        {
            bool retorno = false;
            dibujo = "";

            if (this.tinta > 0)
            {
                retorno = true;

                for (int i = 0; i < gasto; i++)
                {
                    if (this.tinta - 1 >= 0)
                    {
                        dibujo += "*";
                        this.tinta -= 1;
                    }   
                    else
                    { break; }
                }

                ImprimirDibujo(dibujo);
            }
            return retorno;
        }

        private void ImprimirDibujo(string dibujo)
        {
            Console.ForegroundColor = this.color;
            Console.WriteLine(dibujo);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Recargar()
        {
            this.SetTinta(cantidadTintaMaxima);
        }

        private void SetTinta(short tinta)
        {
            this.tinta = tinta;
        }

        public Boligrafo(short tintaInicial, ConsoleColor color)
        {
            this.SetTinta(tintaInicial);
            this.color = color;
        }
    }
}
