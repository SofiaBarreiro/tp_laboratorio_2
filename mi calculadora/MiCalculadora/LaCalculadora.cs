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
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        

        public void limpiar()
        {
            txtNumero1.Clear(); ;
            txtNumero2.Clear();
            lblResultado.Text = "";
            CmbOperador.Text = null;
        }





        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            Numero aux = new Numero();
            string retorno = null;
            double nro;


            if (aux.IsNumeric(txtNumero1.Text))
            {

                nro = Convert.ToDouble(txtNumero1.Text);
                retorno = aux.DecimalBinario(nro);
            }
            else {
                retorno = "Numero invalido";
                txtNumero1.Clear();

            
            }

           lblResultado.Text = retorno;
          
        
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
           
            Numero Numero1 = new Numero();
            string retorno;



            retorno = Numero1.BinarioDecimal(txtNumero1.Text);

            if(retorno == "Numero invalido"){

                
                txtNumero1.Clear();
            
            }
           
              lblResultado.Text = retorno;
             

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

         private static double Operar(string numero1, string numero2, string operador){

             Calculadora calculadora1 = new Calculadora();
             Numero num1 = new Numero(numero1);
             Numero num2 = new Numero(numero2);
             double retorno;
             retorno=calculadora1.Operar(num1, num2, operador);

             return retorno;
         }

         private void btnOperar_Click(object sender, EventArgs e)
         {

             Numero nro = new Numero();

            
             double resultado;
             string retorno = "Error";
             if (nro.IsNumeric(txtNumero1.Text) && nro.IsNumeric(txtNumero2.Text))
             {

                 resultado = Operar(txtNumero1.Text, txtNumero2.Text, CmbOperador.Text);

                 retorno=Convert.ToString(resultado);

                 lblResultado.Text = retorno;
                 
             }
             else {


                 lblResultado.Text = retorno;
                
             
             }



         }
 
        
        


    }
}
