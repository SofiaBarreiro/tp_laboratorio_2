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
        private Universidad.EClases claseQueToma;

        private Alumno.EEstadoCuenta estadoCuenta;

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

        protected override string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    cadena.AppendLine("ESTADO DE CUENTA: CUOTA AL DIA");
                    break;
                case EEstadoCuenta.Deudor:
                    cadena.AppendLine("ESTADO DE CUENTA: CUOTA CON DEUDA");
                    break;
                case EEstadoCuenta.Becado:
                    cadena.AppendLine("ESTADO DE CUENTA: BECADO");
                    break;
                default:
                    cadena.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta.ToString());
                    break;

            }
            cadena.AppendLine("TOMA CLASES DE: " + this.claseQueToma.ToString());
            return cadena.ToString();

        }


        public static bool operator !=(Alumno a, Universidad.EClases clases)
        {

            
            return (Universidad.EClases)a.claseQueToma != (Universidad.EClases)clases; 
        }

        public static bool operator ==(Alumno a, Universidad.EClases clases)
        {

            if (a.claseQueToma == clases)
            {

                if (a.estadoCuenta != Alumno.EEstadoCuenta.Deudor)
                {
                    return true;
                }
            }
            return false;
        }


        protected override string ParticiparEnClase()
        {

            return "TOMA CLASE DE: " + this.claseQueToma.ToString();

        }

        public override string ToString()
        {
            return this.MostrarDatos();


        }
        public enum EEstadoCuenta
        {

            AlDia,
            Deudor,
            Becado,
        }


    }
}
