using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;
using System.IO;


namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {

        public bool Guardar(string archivo, T datos)
        {

            try
            {
                TextWriter writer = new StreamWriter(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                return true;
            }
            catch (Exception e)
            {
                
                return false;
                throw new ArchivosException(e);


            }
           
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);
                datos = (T)ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (ArchivosException e)
            {

                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }


    }
}
