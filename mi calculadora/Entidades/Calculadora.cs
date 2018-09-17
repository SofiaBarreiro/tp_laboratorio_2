using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        public double Operar(Numero num1, Numero num2, string operador) {
        double retorno= 0;
        string operadorA;
        
            operadorA=ValidarOperador(operador);

            switch (operadorA)
            {

                case "-": retorno=num1 - num2; 
                          break;
                case "+": retorno = num1 + num2;
                          break;
                case "*": retorno = num1 * num2;
                          break;
                case "/": retorno = num1 / num2;
                          break;
                default: 
                        break;
                
            }

            return retorno;
            
        }

        private static string ValidarOperador(string operador) {

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
