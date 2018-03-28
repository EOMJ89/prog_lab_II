using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    class Alumno
    {
        private byte _nota1;
        private byte _nota2;
        private float _notaFinal;
        public string apellido;
        public string nombre;
        public int legajo;

        public void CalcularFinal()
        {
            if (this._nota1 >= 4 && this._nota2 >= 4)
            {
                Random randomN = new Random();
                this._notaFinal = randomN.Next(1, 10);
            }
            else
            {
                this._notaFinal = -1;
            }
        }

        public void Estudiar(byte notaUno, byte notaDos)
        {
            this._nota1 = notaUno;
            this._nota2 = notaDos;
        }

        public void Mostrar()
        {
            Console.WriteLine("Nombre: {0}\nApellido: {1}\nLegajo: {2}\nNota1: {3}\nNota2: {4}", this.nombre, this.apellido, this.legajo, this._nota1, this._nota2);

            if (this._notaFinal != -1)
            {
                Console.WriteLine("Nota Final: {0}", this._notaFinal);
            }
            else
            {
                Console.WriteLine("Alumno Desaprobado");
            }
        }

        public Alumno(string nombre1, string apellido1, int legajo1)
        {
            this.nombre = nombre1;
            this.apellido = apellido1;
            this.legajo = legajo1;
            this._notaFinal = -1;
        }

        public Alumno() : this("","",0)
        {
        }
    }
}
