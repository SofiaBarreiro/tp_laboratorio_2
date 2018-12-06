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
        /// realiza operaciones matematicas con dos numneros y devuelve el resultado
        /// </summary>
        /// <param name="num1">primer numero</param>
        /// <param name="num2">segundo numero</param>
        /// <param name="operador">cuenta que debe realizar</param>
        /// <returns>retorno, resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            string operadorA;

            operadorA = ValidarOperador(operador);

            switch (operadorA)
            {

                case "-":
                    retorno = num1 - num2;
                    break;
                case "+":
                    retorno = num1 + num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
                default:
                    break;

            }

            return retorno;

        }

        /// <summary>
        /// Valida que el operador elegido sea valido, caso contrario devuelve el operador de suma
        /// </summary>
        /// <param name="operador">cadena de texto con el operador</param>
        /// <returns>operador elegido</returns>
        private static string ValidarOperador(string operador)
        {

            switch (operador)
            {

                case "-": break;
                case "+": break;
                case "*": break;
                case "/": break;
                default: operador = "+";
                    break;
            }
        
            return operador;
        }

        

    }
}
