using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjerClase19_Library;
using System.IO;

namespace EjerClase19_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (Jugador.EPuesto itemA in Enum.GetValues(typeof(Jugador.EPuesto))) /*Añade los items del enumerado a la lista sin necesidad de hardcodear, facilitando la creacion -- La linea seria "Por cada "itemA" de tipo "Epuesto" dentro del Array "de strings que tiene los valores del enumerado"...*/
            { this.cboPuesto.Items.Add(itemA); /*Agrega ese "Epuesto" al Combo Box*/ }

            this.cboPuesto.DropDownStyle = ComboBoxStyle.DropDownList; //Evita que la lista sea editada, ya que solo permite opciones ingresadas mediante el foreach anterior
            this.cboPuesto.SelectedItem = Jugador.EPuesto.Arquero; //Selecciona un elemento como default, tambien puede hacerse por indice con "cboPuesto.SelectedIndex = index;"
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Jugador auxJugador = new Jugador(this.txtNombre.Text, this.txtApellido.Text, ((Jugador.EPuesto)this.cboPuesto.SelectedItem)); /*Se castea el tercer parametro ya que lo que se toma del ComboBox es un string.*/

            #region "Manejo de archivos con StreamWriter y Stream Writter
            /*StreamWriter tambien cuenta con varios constructores...
            * StreamWriter auxGuardado = new StreamWriter(@"D:\jugadores.txt"); //En este constructor solo recibe la ruta del archivo
            * 
            * StreamWriter auxGuardado = new StreamWriter(@"D:\jugadores.txt", true); el boolean es para el modo append, permitiendo añadir contenido en lugar de sobreescribirlo, en este caso requeiria estructura repetitiva
            * 
            * Para las rutas de archivo hay ciertos aspectos importantes...
            * "\" dará error porque es un caracter de escape, se puede arreglar con "\\"(no recomendado), "/"(no recomendado) o anteponiendo el "@" previo a la comilla de apertura (recomendado).
            * 
            * auxGuardado.WriteLine(auxJugador.ToString()); //Se escribe la linea dentro del archivo (tambien hay .Write()).
            * auxGuardado.Close(); //Siempre se cierra el archivo al terminar de escribir Ó leer, para evitar errores. 
           
            * StreamReader, tiene varios constructores...
            * 
            * StreamReader auxLectura = new StreamReader(@"D:\jugadores.txt"); //En este constructor solo recibe la ruta del archivo
            * MessageBox.Show("Jugador Abierto\n" + auxLectura.ReadToEnd()); //Mostrar el contenido de la linea.
            * 
            * while ((linea = auxLectura.ReadLine()) != null) //Si el metodo de Leer una linea y asignarla a la variable fue diferente de Null (lo cual da error)...
            * { MessageBox.Show("Jugador Abierto\n" + linea); } //Mostrar el contenido de la linea.
            * 
            * auxLectura.Close(); //Siempre se cierra el archivo al terminar de escribir Ó leer, para evitar errores. */
            #endregion

            #region "Metodo estatico con rutas hardcodeadas"
            /* Una forma de escribir y leer archivo es hardcodear una ruta especifica
             * Usar cualquiera de estas funciona, pero provoca fallos ya que nunca se sabe si la pc que ejecutará el programa cuenta con un disco D, por ejemplo, o si el nombre de usuario es "alumno".
             * 
             * Esto escribirá un texto en la ruta especificada, ademas de decir si se añadira a lo escrito anterior mente o se sobreescribirá por completo.
             * AdministradorDeArchivos.Escribir(@"D:\jugadores.txt", auxJugador.ToString(), true);
             * Admin istradorDeArchivos.Escribir(@"C:\Users\alumno\Desktop\jugador.txt", auxJugador.ToString(), true);   
             * 
             * Esto leera la el archivo de principio a fin y lo almacenará en la variable auxLinea
             * string auxLinea = "";
             * AdministradorDeArchivos.Leer(@"D:\jugadores.txt", out auxLinea); */
            #endregion

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK) //Sí el usuario seleccionó un archivo y opimió "abrir" dentro de la instancia de SaveFileDialog...
            {
                try
                {
                    string path = "";

                    #region "Carpeta Generica"
                    /*Otra forma es hardcodear una carpeta especifica dentro de las carpetas genericas de windows
                     * path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\jugador.txt"; //Enviroment.SpecialFolder obtiene la ruta del la carpeta elegida en el enumerado, luego se le agrega el nombre del archivo*/
                    #endregion

                    /*Pero la mejor, regularmente, es permitir al propio usuario elegir un archivo cualquiera del directorio que prefiera, utilizando el SaveDialogFile y su atributo de FileNames[0] o FileName. */
                    path = this.saveFileDialog1.FileNames[0];
                    if (AdministradorDeArchivos.Escribir(path, auxJugador.ToString(), true) == true) //Si se pudo escribir en el archivo correctamente...
                    {
                        try //Intentar...
                        {
                            string linea = ""; //Auxiliar que se usará como "out" del AdministradorDeArchivos.Leer(), si funciona correctamente, se almacenará todo lo leido del archivo de principio a fin.

                            if (AdministradorDeArchivos.Leer(path, out linea)) /*Si se pudo leer el archivo correctamente (tomará el true o false que devuelve el metodo)...*/
                            { MessageBox.Show("Jugador Abierto\n" + linea); /*Muestra el contenido de la variable dentro de un MessageBox*/ }

                        }
                        catch (Exception exception) /*Si capta una excepción de cualquier tipo...*/
                        { throw exception; } /* La vuelve a lanzar ya que no será tratada aquí */
                    }
                }
                catch (Exception exception) /*Si capta una excepción de cualquier tipo...*/
                { MessageBox.Show("Se ha producido un error\n" + exception.Message); /*Avisa que se ha producido un error y da detalles del mismo */ }
            }
            else
            { MessageBox.Show("Se ha producido un error al seleccionar archivo. Intente de nuevo"); }
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            Jugador auxJugador = new Jugador(this.txtNombre.Text, this.txtApellido.Text, ((Jugador.EPuesto)this.cboPuesto.SelectedItem));
            Jugador jugadorRetorno = null;

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Buscando..."); //Esto es meramente visual, para mostrar que los datos cambian
                this.txtNombre.Text = "";
                this.txtApellido.Text = "";
                this.cboPuesto.SelectedItem = "";
                
                string path = this.saveFileDialog1.FileNames[0];

                if (Jugador.TraerUno(path, auxJugador, out jugadorRetorno)) //Si el jugador se encontraba dentro de la lista y jugadorRetorno ahora es diferente de null...
                {
                    MessageBox.Show("Jugador encontrado!");
                    this.txtNombre.Text = jugadorRetorno.Nombre;
                    this.txtApellido.Text = jugadorRetorno.Apellido;
                    this.cboPuesto.SelectedItem = jugadorRetorno.Puesto;
                }
                else
                { MessageBox.Show("Jugador no encontrado!"); }
            }
        }
    }
}
