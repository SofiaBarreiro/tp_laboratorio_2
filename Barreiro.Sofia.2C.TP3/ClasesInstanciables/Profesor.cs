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

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        private void _randomClases()
        {

            int nroAleatorio = random.Next();
            switch (nroAleatorio)
            {
                case 0:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 1:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 2:
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 3:
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
                default:
                    break;
            }


        }


        protected override string MostrarDatos()
        {

            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(base.MostrarDatos());
            cadena.AppendLine(this.ParticiparEnClase());
            return cadena.ToString();


        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {

            return !(i == clase);

        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases aux in i.clasesDelDia)
            {

                if ((Universidad.EClases)clase == (Universidad.EClases)aux)
                {
                    retorno= true;
                }
            }
            return retorno;
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()        
        {
            

        }
        protected override string ParticiparEnClase()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("CLASES DEL DIA: ");
            foreach (Universidad.EClases aux in this.clasesDelDia) {

                cadena.AppendLine(aux.ToString());
            }

            return cadena.ToString();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            
            this.clasesDelDia = new Queue<Universidad.EClases>(2);
            this._randomClases();
            Thread.Sleep(1000);
            this._randomClases();

        }

        public override string ToString()
        {

            return this.MostrarDatos();
        }

    }
}
