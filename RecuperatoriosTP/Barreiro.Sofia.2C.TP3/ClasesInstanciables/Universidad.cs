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

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
                if ( i < 0 || i >= this.Jornadas.Count)
                {
                    return null;
                }
                else
                {
                    return this.Jornadas[i];
                }
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }


        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> datos = new Xml<Universidad>();
            bool retorno =datos.Guardar("NuevaUniversidad.xml", uni);
            return retorno;
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder cadena = new StringBuilder();
            if (uni.Jornadas != null)
            {

                cadena.AppendLine("Jornadas: ");
                foreach (Jornada aux in uni.Jornadas)
                {

                    cadena.AppendLine(aux.ToString());
                }
            }

            return cadena.ToString();

            
        }

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
        public static bool operator ==(Universidad g, Profesor i)
        {

            foreach (Profesor aux in g.Instructores)
            {
                if (aux == i)
                {
                    return true;
                }

            }
            return false;


        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g.profesores)
            {
                if (aux != clase)
                {
                    return aux;
                }
            }
            throw new SinProfesorException();

            
        }
        public static Profesor operator ==(Universidad g, EClases clases)
        {
            try
            {

                foreach (Profesor aux in g.Instructores)
                {
                    if (aux == (Universidad.EClases)clases)
                    {
                        return aux;
                    }
                }

                throw new SinProfesorException();
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }




        public static Universidad operator +(Universidad g, EClases clases)
        {

            Jornada jAux = new Jornada(clases, g == clases);
            foreach (Alumno aux in g.alumnos)
            {
                if (aux == clases)
                {
                    jAux += aux;
                }
            }

            g.jornada.Add(jAux);
            return g;

        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            bool flag = true;
            foreach (Alumno aux in g.alumnos)
            {

                if (aux == a)
                {
                    flag = false;
                }
            }
            if (flag == false)
            {

                throw new AlumnoRepetidoException();
            }
            else
            {
                g.alumnos.Add(a);
            }

            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g.profesores)
            {

                if (aux == i)
                {
                    return g;
                }
            }
            g.profesores.Add(i);
            return g;
        }

        public override string ToString()
        {


            return Universidad.MostrarDatos(this);

        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }


        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }

    }
}
