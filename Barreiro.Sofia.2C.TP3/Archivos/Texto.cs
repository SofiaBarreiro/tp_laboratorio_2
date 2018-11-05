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
            try
            {

                StreamWriter streamW = new StreamWriter(archivo, true);
                streamW.WriteLine(datos);
                return true;
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
       
           
           
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                StreamReader streamR = new StreamReader(archivo);
                datos=streamR.ReadToEnd();
                retorno= true;
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
                retorno = false;
            }

            return retorno;


        }
    }
}
