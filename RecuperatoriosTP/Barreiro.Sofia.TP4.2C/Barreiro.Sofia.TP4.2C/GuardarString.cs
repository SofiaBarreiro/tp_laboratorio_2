using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {

        /// <summary>
        /// Guardar un texto en un documento .txt
        /// </summary>
        /// <param name="texto">nombre del archivo</param>
        /// <param name="archivo">cadena de texto que guarda</param>
        /// <returns>true si se pudo guardar, false si no</returns>
        public static bool Guardar(this string texto, string archivo)
        {

            archivo = (object.Equals(archivo, null)) ? "" : archivo;
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = escritorio + "\\" + archivo;
            bool retorno = false;
            StreamWriter writer = null;
            bool existe = File.Exists(archivo);

            try
            {


                using (writer = new StreamWriter(path, existe))
                {
                    writer.Write(texto);
                    retorno = true;

                }

                        
            }

            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                writer.Close();
                

            }

            return retorno;

        }

    }
}
