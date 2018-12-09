using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using EntidadesAbstractas;
using Excepciones;
using Archivos;


namespace ClasesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion
        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {

                return this.alumnos;
            }
            set
            {
                this.alumnos = value;

            }
        }
       
        public List<Profesor> Instructores
        {
            get
            {

                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }

           
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }

         
        }
        #endregion
        #region Metodos
        /// <summary>
        /// guarda los datos de la universidad en una archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si se pudo guardar sin lanzar una excepcion</returns>
        public static bool Guardar(Universidad uni)
        {
           
            bool retorno = false;
            IArchivo<Universidad> archivosXml = new Xml<Universidad>();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";

            try
            {
                retorno = archivosXml.Guardar(ruta, uni);
                
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            return retorno;
        }
        /// <summary>
        /// Muestra los datos de la clase universidad y de la lista de Jornadas
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("JORNADA: ");
            foreach (Jornada j in uni.Jornadas)
            {
                cadena.AppendFormat("{0}",j.ToString());
            }
            return cadena.ToString();
        }


        /// <summary>
        /// llama al metodo MostrarDatos que devuelve un string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return MostrarDatos(this);

        }

        #endregion

        #region Operadores
        /// <summary>
        /// comprueba si un alumno se encuentra o no cursando esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {

            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    return true;
                }

            }
            return false;




        }
        public static bool operator !=(Universidad g, Alumno a)
        {

            return !(g == a);

        }

        public static bool operator !=(Universidad g, Profesor i)
        {

            return !(g == i);

        }
        /// <summary>
        /// comprueba si un profesor se encuentra o no dictando esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            if (g.Instructores.Contains(i))
            {
                retorno = true;
            }

            return retorno;


        }

        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
           
            Profesor profAux = null;
            foreach (Profesor p in g.Instructores)
            {
                if (!(p == clase))
                {
                    profAux = p;
                }
            }
            return profAux;


        }
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {

            
                foreach (Profesor aux in g.profesores)
                {
                    if (aux == clase)
                    {
                        return aux;
                    }
                }

                throw new SinProfesorException();

            


        }




        /// <summary>
        /// inserta los todos los alumnos que se encuentran tomando esa clase dentro de la lista de alumnos de una misma jornada
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {


            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a);
                }
            }

            g.Jornadas.Add(j);

            return g;




        }

        /// <summary>
        /// inserta un alumno a la lista de alumnos
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }

            else
            {
                throw new AlumnoRepetidoException();

            }
               
            return g;


            

        }
        /// <summary>
        /// agrega un profesor a la lista de Instructores
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

         

        #endregion
        #region Constructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion 

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }

    }
}
