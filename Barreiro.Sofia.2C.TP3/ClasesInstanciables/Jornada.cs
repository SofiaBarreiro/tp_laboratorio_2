﻿using System;
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
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;




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

        public static bool Guardar(Jornada jornada)
        {


            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());

            //string archivo = "nuevaJornada";
            //Texto<Jornada> aux = new Texto<Jornada>();
            //((IArchivo<Jornada>)aux).Guardar(archivo, jornada);



            ////GuardarTexto<string, int> aux = new GuardarTexto<string, int>();

            //bool palabra = ((IGuardar<string, int>)aux).Guardar("");

            //int nro = ((IGuardar<string, int>)aux).Leer();



        }

        public static string Leer()
        {
            string cadena = " ";
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out cadena);
            return cadena;


        }


        private Jornada()
        {

            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;

        }

        
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == (Universidad.EClases)j.Clase)
            {
                return true;
                
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;
            foreach (Alumno aux in j.alumnos)
            {
                if (aux == a)
                {
                    flag= true;
                    break;
                }
                
            }
            if (flag == false)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }


            return j;
        }

        public override string ToString()
        {
            if (!object.Equals(this, null) && !object.Equals(this.Clase, null) && !object.Equals(this.Instructor, null))
            {

                StringBuilder cadena = new StringBuilder();
                cadena.AppendLine(this.Clase.ToString());
                cadena.AppendLine(this.Instructor.ToString());
                foreach (Alumno aux in this.alumnos)
                {
                    cadena.AppendLine(aux.ToString());
                }

                return cadena.ToString();
            }
            else {

                return "";
            }
            
            

        }
    }
}
