using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {

        public bool Guardar(string archivo, string datos)
        {

            StreamWriter streamW = null;
            try
            {
               

                streamW = new StreamWriter(archivo);
                streamW.WriteLine(datos);
                return true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                streamW.Close();

            }
        }
       
           
           
        /// <summary>
        /// lee los datos de que se encuentra en el archivo Jornada.txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamR = null;
            bool retorno = false;
            try
            {
                streamR = new StreamReader(archivo);


                datos = streamR.ReadToEnd();
                

                retorno = true;
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                streamR.Close();
            }

            return retorno;


        }
    }
}
