using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        ///Atributos

        private double numero;

        //Métodos

        /// <summary>
        /// Asigna al atributo numero el parámetro que se le pasa al método
        /// </summary>
        /// <param name="numero">valor que se va a asignar al atributo número</param>
        private void SetNumero(string numero)
        {      
            //valido el numero y lo seteo
            this.numero = ValidarNumero(numero);
        }

        //Constructores
        //
        /// <summary>
        /// Constructor por defecto. Crea un objeto del tipo Numero,
        /// asigna valor 0 al atributo numero
        /// </summary>
        public Numero()
        {
            new Numero(0);
        }

        /// <summary>
        /// Construye un objeto de tipo Numero con el atributo asignado
        ///  a partir del valor del parámetro double que se le pasa
        /// </summary>
        /// <param name="numero">valor que se le va a asignar al atributo numero</param>
        public Numero(double numero)
        {
            new Numero(numero.ToString());
        }

        /// <summary>
        /// Construye un objeto del tipo número
        /// </summary>
        /// <param name="strNumero">valor que se le va a asignar al parámetro numero</param>
        public Numero(string strNumero)
        {    
            this.SetNumero(strNumero);  
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

            //Busco si hay algún número que no sea 0 ni 1
            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')//no es binario
                {
                    esBinario = false;
                    break;

                }
            }

            if (esBinario)
            {
                for (i = binario.Length - 1; i >= 0; i--)
                {

                    if (binario[i] == '1')//si es 1 en binario
                    {
                        //lo multiplico por 2 ^ a la posición y los sumo
                        numeroDecimal += Math.Pow(2, j);
                    }

                    //Aumento la potencia
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
            //bool esBinario = true;
            int i;

            
            //Tomo el valor absoluto y la parte entera
            numero = (int) Math.Abs(numero);

            if (numero > 1)//valor binario tiene más de una cifra
            {
                do
                {
                    //Si es par
                    if (numero % 2 == 0)
                    {
                        binario += "0";
                    }
                    else
                    {
                        binario += "1";
                    }

                    //divido (tomo la parte entera)
                    numero = (int)numero / 2;

                } while (numero > 1);

                //Agrego el último número
                if (numero == 0)
                {
                    binario += "0";
                }
                else
                {
                    binario += "1";
                }

                //doy vuelta el número para que quede con el formato correcto
                for (i = binario.Length - 1; i >= 0; i--)
                {
                    retorno += binario[i];
                }

            }
            else if(numero == 0 || numero == 1)//si es 0 o 1
            {
                retorno = numero.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }

            /*
            //Compruebo que haya quedado un número binario:
            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')//no es binario
                {
                    esBinario = false;
                    break;

                }
            }

            if(esBinario == false)
            {
                retorno = "Valor inválido";
            }*/

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



            if(Double.TryParse(numero, out numeroDouble))
            {
                numeroString = DecimalBinario(numeroDouble);
            }
            else
            {
                numeroString = "Valor inválido";
            }

            return numeroString;

        }

        //Sobrecarga de operadores
        //

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

        //Validaciones
        //

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
