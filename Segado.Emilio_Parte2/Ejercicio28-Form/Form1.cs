using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio28_Form
{
    public partial class Form1 : Form
    {
        public Dictionary<string, int> dictionaryA = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string[] palabras = this.tBoxDictionary.Text.Split(' ');


            for (int j = 0; j < palabras.Length; j++)
            {
                int contador = 0;
                for (int i = 0; i < palabras.Length; i++)
                {
                    if (palabras[j].Equals(palabras[i]))
                    { contador++; }
                }

                if (dictionaryA.ContainsKey(palabras[j]) == false)
                { dictionaryA.Add(palabras[j], contador); }                
            }

            dictionaryA.OrderBy(key => key.Value);

            string retorno = string.Join(";", dictionaryA);
            MessageBox.Show(retorno);
        }
    }
}
