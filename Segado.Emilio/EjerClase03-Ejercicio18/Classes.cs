using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Punto
    {
        private int x;
        private int y;

        public int GetX() { return this.x; }
        public int GetY() { return this.y; }

        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Rectangulo
    {
        public int area;
        public int perimetro;
        public Punto vertice1;
        public Punto vertice2;
        public Punto vertice3;
        public Punto vertice4;

        public int Area()
        {
            int retorno = -1;
            int xAux = ObtenerDiferenciaEnX(this.vertice1, this.vertice3);
            int yAux = ObtenerDiferenciaEnY(this.vertice1, this.vertice3);

            retorno = xAux * yAux;

            return retorno;
        }

        public int Perimetro()
        {
            int retorno = -1;
            int xAux = ObtenerDiferenciaEnX(this.vertice1, this.vertice3);
            int yAux = ObtenerDiferenciaEnY(this.vertice1, this.vertice3);

            retorno = (xAux + yAux) * 2;
            return retorno;
        }

        public Rectangulo(Punto verticeN1, Punto verticeN3)
        {
            this.vertice1 = new Punto(verticeN1.GetX(), verticeN1.GetY());
            this.vertice2 = new Punto(verticeN1.GetX(), verticeN3.GetY());
            this.vertice3 = new Punto(verticeN3.GetX(), verticeN3.GetY());
            this.vertice4 = new Punto(verticeN3.GetX(), verticeN1.GetY());

            this.area = -1;
            this.perimetro = -1;
        }

        public int GetArea()
        {
            int retorno = 0;

            if (area == -1)
            {
                retorno = this.Area();
            }
            else
            {
                retorno = this.area;
            }
            return retorno;
        }

        public int GetPerimetro()
        {
            int retorno = 0;

            if (perimetro == -1)
            {
                retorno = this.Perimetro();
            }
            else
            {
                retorno = this.perimetro;
            }
            return retorno;
        }

        private int ObtenerDiferenciaEnX(Punto v1, Punto v2)
        {
            //Console.WriteLine("X: " + Math.Abs(v1.GetX() - v2.GetX()));
            return Math.Abs(v1.GetX() - v2.GetX());
        }

        private int ObtenerDiferenciaEnY(Punto v1, Punto v2)
        {
            //Console.WriteLine("Y: " + Math.Abs(v1.GetY() - v2.GetY()));
            return Math.Abs(v1.GetY() - v2.GetY());
        }

        public void Mostrar()
        {
            Console.WriteLine("Los valores que recibe como parametro son:\nV1:{0},{1}\nV2:{2},{3}", this.vertice1.GetX(), this.vertice1.GetY(), this.vertice3.GetX(), this.vertice3.GetY());
        }
    }
}
