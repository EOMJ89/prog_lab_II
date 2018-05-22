using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompraVenta;

namespace EjerClase12_PracticaPrimerParcial_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            Comercio ElBolicheDeToni = new Comercio("TONI");
            Articulo articuloUno = new Articulo(100, "Sprite", (float)2.5, 10);
            Articulo articuloDos = new Articulo(101, "Fanta", (float)2.5, 10);
            Articulo articuloTres = new Articulo(100, "Sprite", (float)2.5, 25);
            Articulo articuloCuatro = new Articulo(103, "Quattro", (float)2.5, 10);
            Articulo articuloCinco = new Articulo(103, "Pepsi", (float)2.5, 10);
            ArticuloImportado articuloSeis = new ArticuloImportado(103, "Apple", (float)10, 10,"EUA",21);
            ElBolicheDeToni.ComprarArticulo(articuloUno);
            ElBolicheDeToni.ComprarArticulo(articuloDos);
            ElBolicheDeToni.ComprarArticulo(articuloTres);
            ElBolicheDeToni.ComprarArticulo(articuloCuatro);
            ElBolicheDeToni.ComprarArticulo(articuloSeis);

            Console.WriteLine("El Boliche De Tony");
            Console.WriteLine("Vender:");
            ElBolicheDeToni.VenderArticulo(articuloUno, 1);
            ElBolicheDeToni.VenderArticulo(articuloDos, 1);
            ElBolicheDeToni.VenderArticulo(articuloTres, 1);
            ElBolicheDeToni.VenderArticulo(articuloDos, 1);
            ElBolicheDeToni.VenderArticulo(articuloTres, 20);
            ElBolicheDeToni.VenderArticulo(articuloTres, 50);
            ElBolicheDeToni.VenderArticulo(articuloCuatro, 1);
            ElBolicheDeToni.VenderArticulo(articuloCinco, 1);
            ElBolicheDeToni.VenderArticulo(articuloSeis, 1);
            Console.WriteLine();
            Comercio.MostrarArticulos(ElBolicheDeToni);
            Console.WriteLine();
            Comercio.MostrarGanancias(ElBolicheDeToni);
            Console.ReadLine();
        }
    }
}
