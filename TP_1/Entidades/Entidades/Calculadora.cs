using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 
    public class Calculadora
    {
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
