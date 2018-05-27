using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio52
{
    public class EscrituraWrapper
    {
        public ConsoleColor color;
        public string texto;

        public EscrituraWrapper(string texto, ConsoleColor color)
        {
            this.texto = texto;
            this.color = color;
        }
    }

    public interface IAcciones
    {
        ConsoleColor Color { get; set; }
        Single UnidadesDeEscritura { get; set; }

        EscrituraWrapper Escribir(string texto);

        bool Recargar(int unidades);
    }

    public class Lapiz : IAcciones
    {
        private float _tamanioMina;
        
        public float UnidadesDeEscritura
        {
            get { return this._tamanioMina; }
            set { this._tamanioMina = value; }
        }

        public ConsoleColor Color
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EscrituraWrapper Escribir(string texto)
        {
            foreach (char charA in texto)
            { this._tamanioMina -= 0.1f; }

            return new EscrituraWrapper(texto, ConsoleColor.White);
        }

        public bool Recargar(int unidades)
        {
            throw new NotImplementedException();
        }

        public Lapiz(int unidades)
        { this._tamanioMina = unidades; }

        public override string ToString()
        {
            return "Lapiz: " + this._tamanioMina;
        }
    }

    public class Boligrafo : IAcciones
    {
        private ConsoleColor _colorTinta;
        private float _tinta;

        public ConsoleColor Color
        {
            get { return this._colorTinta; }
            set { this._colorTinta = value; }
        }

        public float UnidadesDeEscritura
        {
            get { return this._tinta; }
            set { this._tinta = value; }
        }

        public EscrituraWrapper Escribir(string texto)
        {
            foreach (char charA in texto)
            { this._tinta -= 0.3f; }

            return new EscrituraWrapper(texto, this._colorTinta);
        }

        public bool Recargar(int unidades)
        {
            this._tinta += unidades;
            return true;
        }

        public Boligrafo(int unidades, ConsoleColor color)
        {
            this._tinta = unidades;
            this._colorTinta = color;
        }

        public override string ToString()
        {
            return "Boligrafo: " + this._colorTinta + "—" + this._tinta;
        }
    }
}
