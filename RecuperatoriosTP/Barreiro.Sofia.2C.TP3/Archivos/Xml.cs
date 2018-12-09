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

        /// <summary>
        /// serliaza datos y los guarda en un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {

            TextWriter writer = null;
            try
            {
                 writer= new StreamWriter(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                return true;
            }
            catch (Exception e)
            {

                return false;
                throw new ArchivosException(e);


            }
            finally
            {
                writer.Close();

            }


           
        }

        /// <summary>
        /// deserializa datos y los guadar en un archivo xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            TextReader reader = null;
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(T));
                 reader= new StreamReader(archivo);
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
            finally
            {
                reader.Close();

            }
        }


    }
}
