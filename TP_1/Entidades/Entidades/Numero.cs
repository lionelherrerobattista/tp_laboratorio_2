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

        ///Propiedades

        private string SetNumero
        {
            set
            {
                //valido el numero y lo seteo
                this.numero = Numero.ValidarNumero(value);        
            }
        }

        ///Métodos
        
        //Constructores
        //
        public Numero()
        {
            new Numero(0);
        }

        public Numero(double numero)
        {
            new Numero(numero.ToString());
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;  
        }



        public static string BinarioDecimal(string binario)
        {
            int i;
            int j = 0;
            double numeroDecimal = 0;

            for (i = binario.Length - 1; i >= 0; i--)
            {

                if (binario[i] == '1')//si es 1 en binario
                {
                    //lo multiplico por 2 ^ a la posición y los sumo
                    numeroDecimal += Math.Pow(2, j);
                }

                //Aumento la potencia
                j++;

            }//fin del for

            return numeroDecimal.ToString();

        }

        public static string DecimalBinario(double numero)
        {
            string binario = "";
            string retorno = "";
            int i;

            //Tomo el valor absoluto
            numero = Math.Abs(numero);

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

            //doy vuelta el número
            for (i = binario.Length - 1; i >= 0; i--)
            {
                retorno += binario[i];
            }

            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            double numeroDouble;
            string numeroString;

            if(Double.TryParse(numero, out numeroDouble))
            {
                numeroString = Numero.DecimalBinario(numeroDouble);
            }
            else
            {
                numeroString = "Valor inválido";
            }

            return numeroString;

        }

        //Sobrecarga de operadores
        //
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero / n2.numero;

            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        //Validaciones
        //
        private static double ValidarNumero(string strNumero)
        {
            double numero;

            Double.TryParse(strNumero, out numero);

            return numero;
        }
    }
}
