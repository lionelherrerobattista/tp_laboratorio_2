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

            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = resultado.ToString();

        }

        /// <summary>
        /// Llama al método Operar de Calculadora 
        /// y realiza la operación indicada
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operador a utilizar</param>
        /// <returns>Resultado de la operación</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
           
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            this.Limpiar();
        }

        /// <summary>
        /// Limpia los datos que muestra la calculadora
        /// </summary>
        private void Limpiar()
        {
            
            txtNumero1.Clear();
            cmbOperador.Text = "";
            txtNumero2.Clear();
            lblResultado.Text = "";

        }


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text != "")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text != "")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
            
        }
    }
}
