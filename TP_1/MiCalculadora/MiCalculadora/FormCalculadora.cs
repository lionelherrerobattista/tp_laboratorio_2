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

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            //Llamo a la función Operar
            resultado = Operar(txtNumero1.Text,
                  txtNumero2.Text, cmbOperador.Text);

            //Lo muestro en el label
            lblResultado.Text = resultado.ToString();

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;

            //Creo los objetos para guardar los numeros
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            //Llamo a la función operar
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
