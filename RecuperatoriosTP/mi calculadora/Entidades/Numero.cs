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

        public Numero()
        {

        }
        public Numero(double numero)
        {
            this.numero = numero;

        }
        public Numero(string strNumero)
            : this()
        {

            SetNumero = strNumero;
        }



        /// <summary>
        /// Valida que el string insertado sea un numero valido
        /// </summary>
        /// <param name="strNumero">cadena de texto</param>
        /// <returns>0, si no es valido, si es valido retono un numero</returns>
        private double ValidarNumero(String strNumero)
        {

            double resultado;

            if (double.TryParse(strNumero, out resultado))
            {
                return resultado;

            }

            return 0;
        }

        private string SetNumero
        {

            set
            {

                this.numero = ValidarNumero(value);

            }

        }



        /// <summary>
        /// Convierte un numero entero a un numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>retorno, cadena de texto con el numero binario</returns>
        public string DecimalBinario(Double numero)
        {
            int entero = (int)numero;


            string retorno;


            retorno = Convert.ToString(entero, 2);



            return retorno;

        }

        /// <summary>
        /// Valida que una cadena de texto sea un numero entero
        /// </summary>
        /// <param name="valor">valor numerico</param>
        /// <returns>true, si es valido y false si es invalido</returns>
        public bool IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }



        /// <summary>
        /// convierte una cadena de texto en un numero decimal y lo devuelve como string
        /// </summary>
        /// <param name="binario">cadena de texto con un numero binario</param>
        /// <returns>una cadena texto con un numero decimal o "Numero invalido" si no se pudo convertir</returns>
        public string BinarioDecimal(string binario)
        {

            int resultado;
            string rta;
            bool retorno = int.TryParse(binario, out resultado);
            if (retorno)
            {

                rta = Convert.ToInt32(binario, 2).ToString();
            }
            else
            {

                rta = "Numero invalido";
            }

            return rta;
        }


        public static double operator -(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero - n2.numero;
            return retorno;

        }
        public static double operator *(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero * n2.numero;
            return retorno;

        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero / n2.numero;
            return retorno;

        }
        public static double operator +(Numero n1, Numero n2)
        {
            double retorno;

            retorno = n1.numero + n2.numero;
            return retorno;

        }




    }


}
