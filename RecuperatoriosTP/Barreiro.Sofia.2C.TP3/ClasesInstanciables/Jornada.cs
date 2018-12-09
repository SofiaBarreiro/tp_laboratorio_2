using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.Xml; 
using System.Xml.Serialization;
using Excepciones;





namespace ClasesInstanciables
{

    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    public class Jornada
    {

        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }


        #endregion



        #region Constructores
        private Jornada()
        {

            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;

        }

        #endregion

        #region Metodos
        /// <summary>
        /// guarda los datos de jornada en un archivo txt, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si no lanzo la excepcion</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto nuevo = new Texto();
            try
            {
                nuevo.Guardar("Jornada.txt", jornada.ToString());
                retorno = true;
                
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return retorno;


        }

        /// <summary>
        /// lee el archivo Jornada.txt
        /// </summary>
        /// <returns>cadena de texto con los datos del archivo</returns>
        public static string Leer()
        {
            Texto nuevo = new Texto();
            string texto = null;
            try
            {
                nuevo.Leer("Jornada.txt", out texto);
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            return texto;


        }



        /// <summary>
        /// retorna los datos de la clase Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendFormat("\nTOMA CLASES DE: {0}", this.Clase);
            cadena.AppendFormat("\nPOR: {0} ", this.Instructor);
            cadena.AppendFormat("\nALUMNOS: ");
            foreach (Alumno aux in this.Alumnos)
            {
                cadena.AppendLine(aux.ToString());
            }
            cadena.AppendFormat("-------------------------------------->");
            return cadena.ToString();
        }

            #endregion

            #region Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno i in j.alumnos)
            {
                if (i == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// comprueba que un alumno no se encuentre ya dentro de la misma jornada, caso contrario agrega un nuevo alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a))
            {
                j.alumnos.Add(a);
                return j;
            }

            return j;
        }

        #endregion


    

    }
}
