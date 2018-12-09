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
            
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion
        #region Enumeradores

        public enum ENacionalidad
        {

            Argentino,
            Extranjero,
        }


        #endregion
        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
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

                this.nombre = ValidarNombreApellido(value);

            }
        }

        public string StringToDNI
        {
           
            set
            {
                
              this.dni = ValidarDni(this.nacionalidad, value);
                
            }
        }

        #endregion

        #region Constructores

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
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

        #endregion
        #region Metodos
        /// <summary>
        /// Construye una cadena de texto con los datos de la clase Persona
        /// </summary>
        /// <returns>cadena con los datos de Persona</returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nNombre: {0}", this.Nombre);
            sb.AppendFormat("\nApellido: {0}", this.Apellido);
            sb.AppendFormat("\nDNI: {0}", this.DNI);
            sb.AppendFormat("\nNacionalidad: {0}", this.Nacionalidad);
            return sb.ToString();

        }

        /// <summary>
        /// llama al metodo validar tring y devuelve un string con el nro de dni
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dni</param>
        /// <returns>dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            return this.ValidarDni(nacionalidad, dato.ToString());

        }


        /// <summary>
        /// Valida que la nacionalidad conincida con el dni, de lo contrario lanza la excepcion NacionalidadInvalida
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">nro de dni</param>
        /// <returns>el nro de dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;
            if (dato.Length <= 8 && Int32.TryParse(dato, out dni))
            {
                int dni = Int32.Parse(dato);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:


                        if (dni > 0 && dni < 90000000)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La Nacionalidad no se coincide con el numero de DNI");
                        }

                        break;

                    case ENacionalidad.Extranjero:


                        if (dni > 89999999 && dni <= 99999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La Nacionalidad no se coincide con el numero de DNI");
                        }

                        break;

                    default:
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException("Dni  formato incorrecto");
            }
            return retorno;

        }

        /// <summary>
        /// Valida que se ingrese un tipo de dato char en nombre y apellido
        /// </summary>
        /// <param name="dato">cadena de texto a comparar</param>
        /// <returns>la cadena de texto validada</returns>
        private string ValidarNombreApellido(string dato)
        {

            bool aux = true;
            foreach (char a in dato)
            {
                if (!char.IsLetter(a))
                {
                    aux = false;
                }
            }
            if (aux == true)
                return dato;
            else
                return null;
        }

        #endregion

    }






}
