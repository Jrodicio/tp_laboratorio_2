using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    [Serializable]
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un archivo en XML
        /// </summary>
        /// <param name="archivo">PATH</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>True si se guardó, caso contrario false</returns>
        bool IArchivo<T>.Guardar(string archivo, T datos)
        {
            bool retorno = false;
            TextWriter xml = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                xml = new StreamWriter(archivo);
                serializer.Serialize(xml, datos);
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (xml != null)
                {
                    xml.Close();
                }   
            }
            return retorno;
        }

        /// <summary>
        /// Lee un archivo XML
        /// </summary>
        /// <param name="archivo">PATH</param>
        /// <param name="datos">Información leída</param>
        /// <returns>True si se pudo leer el archivo, caso contrario false</returns>
        bool IArchivo<T>.Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader texto = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(texto);
                texto.Close();

                retorno = true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
