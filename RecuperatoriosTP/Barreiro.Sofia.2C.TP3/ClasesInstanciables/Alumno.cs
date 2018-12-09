using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    
    sealed public class Alumno : Universitario
    {

        #region Atributos
        private Universidad.EClases claseQueToma;

        private EEstadoCuenta estadoCuenta;

        #endregion


        #region Enumeradores
        public enum EEstadoCuenta
        {

            AlDia,
            Deudor,
            Becado,
        }
        #endregion
        #region Constructores
        public Alumno()
            :base()      
        {
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, Alumno.EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna los datos de Universitario y de Alumno
        /// </summary>
        /// <returns>cadena con los datos</returns>
        protected override string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat(base.MostrarDatos());
            cadena.AppendFormat("\nEstado de Cuenta: {0}", this.estadoCuenta);
            cadena.AppendFormat(this.ParticiparEnClase());
            return cadena.ToString();



        }


        /// <summary>
        /// llama al metodo mostrarDatos de la clase Alumno
        /// </summary>
        /// <returns>cadena de MostraDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();

            


        }


        /// <summary>
        /// retorna una cadena de texto con el nombre de la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("\nTOMA CLASES DE :{0}", this.claseQueToma.ToString());
            return cadena.ToString();

        }
        #endregion

        #region Operadores
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {

            if (!(a == null) && (a.claseQueToma != clase))
            {
                return true;
            }
               
            return false;
        }

        /// <summary>
        /// Compara si un alumno se encuentra tomando esa clase, y que no este en estado deudor
        /// </summary>
        /// <param name="a">objeto de la clase Alumno</param>
        /// <param name="clase"></param>
        /// <returns>si cunple con los requisitos</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if ((!(a != clase)) && (a.estadoCuenta != EEstadoCuenta.Deudor))
            {
                retorno = true;
            }
            return retorno;
        }


        #endregion

        
        

     
    }
}
