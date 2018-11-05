using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona 
    {


        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;



        public enum ENacionalidad
        {

            Argentino,
            Extranjero,
        }


       

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {

                    this.apellido = this.ValidarNombreApellido(value);
                }


            }
        }



        

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        


        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = this.ValidarNombreApellido(value);
                }
            }
        }

        public string StringToDNI
        {
           
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);
                }
                catch (Exception)
                {

                    throw new NacionalidadInvalidaException("La nacionalidad no coincide con el DNI");
                }
            }
        }



        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            
            this.DNI = dni;

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            
            this.StringToDNI = dni;
           

        }

        public override string ToString()
        {

            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            cadena.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            

            return cadena.ToString();

        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {


            if (dato >= 90000000 && dato <= 99999999)
            {
                this.nacionalidad = ENacionalidad.Extranjero;

            }
            else {

                if (dato <= 89999999 && dato >= 1)
                {
                    this.nacionalidad = ENacionalidad.Extranjero;

                }
                else {


                    throw new DniInvalidoException("el dni no coincide");

                }



            }


            return dato;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));

        }

        private string ValidarNombreApellido(string dato)
        {

            Regex rg = new Regex(@"^[a-zA-Z]$");
            if (rg.IsMatch(dato))
            {

                return dato;
            }
            else
            {
                return null;
            }

        }





    }
}
