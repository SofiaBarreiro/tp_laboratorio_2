using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        private int legajo;
        public override bool Equals(object obj)
        {

            if (obj is Universitario)
            {

                return true;
            }

            return false;
        }


        protected virtual string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("LEGAJO: {0}\n{1}", this.legajo, base.ToString());
            return cadena.ToString();

        }


        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (!(Equals(pg1,null)) && !(Equals(pg2,null)))
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


        protected abstract string ParticiparEnClase();


        public Universitario()
            :base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }




    }
}
