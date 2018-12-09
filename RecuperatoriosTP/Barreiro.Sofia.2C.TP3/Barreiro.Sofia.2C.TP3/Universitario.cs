using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        protected int legajo;
        #endregion
        #region Operadores
        public override bool Equals(object obj)
        {

            if (obj is Universitario)
            {

                return true;
            }

            return false;
        }



        


       
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (!(Equals(pg1, null)) && !(Equals(pg2, null)))
            {

                if (pg1.legajo == pg2.legajo)
                {
                    return true;

                }
                else
                {
                    if (pg1.DNI == pg2.DNI)
                    {
                        return true;
                    }

                }

              }
            

            return false;

        }

    

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {

            return !(pg1 == pg2);

        }

        #endregion
        #region Constructores


        public Universitario()
            :base()          
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Retorna una cadena con los datos de Universitario y Persona
        /// </summary>
        /// <returns>Los datos de Univesitario</returns>
        protected virtual string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat(base.ToString());
            cadena.AppendFormat("\nLegajo: {0}", this.legajo);
            return cadena.ToString(); ;

        }

        /// <summary>
        /// Metodo abstracto 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


        #endregion
    }
}
