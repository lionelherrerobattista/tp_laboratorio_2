using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Crea un objeto del tipo Numero
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Crea un objeto de tipo Numero
        /// </summary>
        /// <param name="numero">valor atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Crea un objeto del tipo número
        /// </summary>
        /// <param name="strNumero">valor atributo numero</param>
        public Numero(string strNumero)
        {
           
            this.SetNumero = strNumero;
        }



        /// <summary>
        /// Propiedad que asigna el valor a número a partir de un string
        /// luego de validarlo
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
            
        }

        
        

        /// <summary>
        /// Convierte un número binario a decimal
        /// </summary>
        /// <param name="binario">número binario a convertir</param>
        /// <returns>número decimal</returns>
        public static string BinarioDecimal(string binario)
        {
            int i;
            int j = 0;
            double numeroDecimal = 0;
            string resultado = "Valor inválido";
            bool esBinario = true;

            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    esBinario = false;
                    break;

                }
            }

            if (esBinario)
            {
                for (i = binario.Length - 1; i >= 0; i--)
                {

                    if (binario[i] == '1')
                    {
                        numeroDecimal += Math.Pow(2, j);
                    }

                    j++;

                }

                resultado = numeroDecimal.ToString();
            }

            return resultado;

        }

        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero">número decimal a convertir</param>
        /// <returns>número binario</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";
            string retorno = "";
            int i;

            numero = (int)Math.Abs(numero);

            if (numero > 1)
            {
                do
                {
                    if (numero % 2 == 0)
                    {
                        binario += "0";
                    }
                    else
                    {
                        binario += "1";
                    }

                    numero = (int)numero / 2;

                } while (numero > 1);

                binario += numero.ToString();


                for (i = binario.Length - 1; i >= 0; i--)
                {
                    retorno += binario[i];
                }

            }
            else if (numero == 0 || numero == 1)
            {
                retorno = numero.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero">número decimal a convertir</param>
        /// <returns>número binario</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroDouble;
            string numeroString;

            if (Double.TryParse(numero, out numeroDouble))
            {
                numeroString = DecimalBinario(numeroDouble);
            }
            else
            {
                numeroString = "Valor inválido";
            }

            return numeroString;

        }

        /// <summary>
        /// Sobrecarga el operador - para realizar operaciones entre 
        /// dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga el operador * para realizar operaciones entre 
        /// dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga el operador / para realizar operaciones entre 
        /// dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero / n2.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga el operador + para realizar operaciones entre 
        /// dos objetos del tipo Numero
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero</param>
        /// <param name="n2">Objeto de tipo Numero</param>
        /// <returns>El resultado de la operación</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }


        /// <summary>
        /// Valida que la cadena ingresada sea un número válido
        /// de lo contrario devuelve 0
        /// </summary>
        /// <param name="strNumero">Número que quiero validar</param>
        /// <returns>Número validado en formato double, en caso contrario devuelve 0</returns>
        private static double ValidarNumero(string strNumero)
        {
            double numero;

            Double.TryParse(strNumero, out numero);

            return numero;
        }
    }
}

