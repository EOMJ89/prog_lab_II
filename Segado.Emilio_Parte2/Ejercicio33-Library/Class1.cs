using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio33_Library
{
    public class Libro
    {
        private List<string> _paginas;

        public string this[int i]
        {
            get
            {
                if (i > -1 && i < _paginas.Count)
                { return this._paginas[i]; }
                else
                { return ""; }
            }
            set
            {
                if (i > (this._paginas.Count - 1))
                { this._paginas.Add(value); }
                else
                { this._paginas.Insert(i, value); }
            }
        }

        public Libro() : this(new List<string>()) { }

        public Libro(List<string> paginas) { this._paginas = paginas; }
    }
}
