using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerClase21_Library;
using System.Data;

namespace EjerClase21_Exe
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region "Traer registros desde la base a una DataTable independiente"
            DataTable tabla1 = Persona.TraerTodosTabla();
            
            for (int i = 0; i < tabla1.Rows.Count; i++)
            { Console.WriteLine("{0}-{1}-{2}-{3}", tabla1.Rows[i]["id"], tabla1.Rows[i]["apellido"], tabla1.Rows[i][2], tabla1.Rows[i]["edad"]); }
            #endregion

            #region "Agregar un registro"
            Persona persona1 = new Persona("Add", "Persona", 1);
            if (persona1.Agregar())
            { Console.WriteLine("Añadido exitosamente"); }
            else { Console.WriteLine("No se ha añadido"); }
            #endregion

            #region "Borrar Registro - Usa el ID de la persona del parametro como condicion"
            Persona.Borrar(new Persona(0, "", "", 0)); //Pude instanciarse una nueva persona solo para obtener el ID
            #endregion

            #region "Traer un registro que corresponda con el ID pasado por parametro"
            Persona persona2 = Persona.TraerTodos(2);
            if (persona2 != null)
            { Console.WriteLine(persona2); }
            #endregion

            #region "Trae todos los registros y los muestra"
            foreach (Persona itemPersona in Persona.TraerTodos())
            { Console.WriteLine(itemPersona); }
            #endregion

            #region "Modificar registro - La instancia actual es la que contiene la nueva informacion"
            Console.WriteLine("Se intenta modificar la persona");
            if (persona2.Modificar()) //Usa como condición el ID del registro a modificar, por lo que si no hay registros coincidentes
            { Console.WriteLine("Modificado exitosamente"); }
            else { Console.WriteLine("No se ha Modificado"); }
            Console.ReadLine();
        }
    }
}
