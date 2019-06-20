using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = resultado.ToString();

        }

        /// <summary>
        /// Llama al método Operar de la calculadora 
        /// y realiza la operación indicada
        /// </summary>
        /// <param name="numero1">Primer numero con el que se desea operar</param>
        /// <param name="numero2">Segundo numero con el que se desea operar</param>
        /// <param name="operador">Operador a utilizar</param>
        /// <returns>Resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;

            //Creo los objetos para guardar los numeros
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            //Llamo a la función operar que devuelve el resultado
            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            Limpiar();
        }

        /// <summary>
        /// Limpia los datos que muestra la calculadora
        /// </summary>
        private void Limpiar()
        {
            //Limpio todos los valores
            txtNumero1.Clear();
            cmbOperador.Text = "";
            txtNumero2.Clear();
            lblResultado.Text = "";

        }


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
