using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Threading;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Profesor : Universitario
    {

        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion






        #region Operadores

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {

            return !(i == clase);

        }

        /// <summary>
        /// comprueba que profesor no este ya asignado a esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases aux in i.clasesDelDia)
            {

                if (aux == clase)
                {
                    retorno= true;
                }
            }
            return retorno;
        }

#endregion
        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor()        
        {
            

        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

            this.clasesDelDia = new Queue<Universidad.EClases>();
            while (this.clasesDelDia.Count < 2)
            {
                this._randomClases();
            }

        }

        #endregion


        #region  Metodos
        /// <summary>
        /// inserta una lista de clases a clasesDeldia de manera aleatoria
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));

        }



        /// <summary>
        /// arma una cadena de texto con las clases del dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nCLASES DEL DIA:\n");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// arma una cadena de texto con los datos de la clase Universitario y con el metodo ParticiparEnClase
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine(this.ParticiparEnClase());
            return cadena.ToString();


        }

        /// <summary>
        /// llama al metodo MostrarDatos que devuelve un string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return this.MostrarDatos();
        }

        #endregion

    }
}
