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



        public string DecimalBinario(Double numero)
        {
            int entero = (int)numero;
            

            string retorno;
                
            retorno = Convert.ToString(entero, 2);



            return retorno;
        }

        public  Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }



        public string BinarioDecimal(string binario)
        {


            string retorno2 = "Numero invalido";



            char[] array = binario.ToCharArray();

            Array.Reverse(array);
            int retorno = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {

                    retorno += (int)Math.Pow(2, i);
                }
            }


        

            if (retorno == 0)
            {

                return retorno2;

            }
            else {
            
            return retorno.ToString();
            
            }

           
        
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
