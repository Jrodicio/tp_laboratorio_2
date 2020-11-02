using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Guarda el archivo de texto haciendo un append de su información.
        /// </summary>
        /// <param name="archivo">Path completo del archivo</param>
        /// <param name="datos">Texto a añadir al archivo</param>
        /// <returns>True si pudo guardarlo. False si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            bool retorno = false;

            try
            {
                streamWriter = new StreamWriter(archivo, true);
                streamWriter.WriteLine(datos);
                retorno = true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">Path completo del archivo</param>
        /// <param name="datos">Variable donde se alojara el texto del archivo</param>
        /// <returns>True si pudo leerlo. False si no pudo</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            bool retorno = true;
            try
            {
                streamReader = new StreamReader(archivo);

                datos = string.Empty;
                string newLine = streamReader.ReadLine();

                while (newLine != null)
                {
                    datos += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }

            }
            catch (Exception ex)
            {
                retorno = false;
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }

            return retorno;
        }
    }        
}

