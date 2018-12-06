using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.apellido=ValidarNombreApellido(value);
                
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
                this.dni=this.ValidarDni(this.nacionalidad, value);
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
                this.nombre = ValidarNombreApellido(value);
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
                catch (Exception e)
                {

                    throw new NacionalidadInvalidaException();
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

            cadena.AppendFormat("Nombre: {0} ", this.Nombre);
            cadena.AppendFormat("Apellido: {0} ", this.Apellido);
            cadena.AppendFormat("Nacionalidad: {0} ", this.nacionalidad.ToString());
            cadena.AppendFormat("Dni: {0} ", this.DNI);

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


                    throw new DniInvalidoException();

                }



            }


            return dato;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            int datoAux=0;

            int.TryParse(dato, out datoAux);
            ValidarDni(nacionalidad, datoAux);
            return datoAux;


        }

        private string ValidarNombreApellido(string dato)
        {

            foreach (char letraAux in dato)
            {
                if (!char.IsLetter(letraAux))
                {

                    dato = "";
                    break;
                }

            }
            return dato;

        }





    }
}
