using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operación indicada entre los datos de tipo Numero
        /// que se le pasan como parámetro
        /// </summary>
        /// <param name="num1">Dato de tipo Numero</param>
        /// <param name="num2">Dato de tipo Numero</param>
        /// <param name="operador">Operador de la operación a realizar</param>
        /// <returns>Resultado de la operación</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            //valido el operador
            operador = Calculadora.ValidarOperador(operador);

            //Hago la operación indicada
            switch(operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    
                    if(Double.IsInfinity(resultado))
                    {
                      
                        resultado = double.MinValue;
                    }
                    break;
            }

            return resultado;


        }

        /// <summary>
        /// Valida el operador seleccionado por el usuario.
        /// Si no es válido el operador, se asignara + por defecto.
        /// </summary>
        /// <param name="operador">Operador de la cuenta a realizar</param>
        /// <returns>Operador validado, de no ser posible devuelve el operador +</returns>
        private static string ValidarOperador(string operador)
        {
            string operadorValidado = "+";//valor por defecto

            //Si es otro operador, cambio
            if(operador == "-" || operador == "*" || operador == "/" )
            {
                operadorValidado = operador;
            }

            return operadorValidado;
        }
    }

    
}
