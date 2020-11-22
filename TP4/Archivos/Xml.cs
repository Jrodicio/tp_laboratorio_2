using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using Entidades;

namespace Archivos
{
    /// <summary>
    /// Clase que implementa interfaces. Posee todo lo necesario para guardar un producto en formato xml.
    /// </summary>
    /// <typeparam name="T">Producto</typeparam>
    public class Xml<T> : IArchivosGuardar<Producto>, IArchivosLeer<Producto>
    {
        #region Propiedades
        /// <summary>
        /// Obtiene el directorio principal (Desktop) donde se guardarán los archivos generados.
        /// </summary>
        public string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Comprueba que el archivo exista.
        /// </summary>
        /// <param name="nombreArchivo">Archivo a buscar</param>
        /// <returns>true si existe, caso contrario false</returns>
        public bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{this.GetDirectoryPath}{nombreArchivo}");
        }

        /// <summary>
        /// Guarda el producto especificado en un archivo XML en el escritorio.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <param name="producto">Producto</param>
        public void Guardar(string nombreArchivo, Producto producto)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter($"{this.GetDirectoryPath}{nombreArchivo}", Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    serializer.Serialize(writer, producto);
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("No se pudo guardar el archivo", ex);
            }
        }

        /// <summary>
        /// Si existe, lee el archivo XML y devuelve el producto deserealizado.
        /// </summary>
        /// <param name="nombreArchivo">Archivo</param>
        /// <param name="producto">Producto</param>
        /// <returns>true si pudo deserealizar el archivo, caso contrario false</returns>
        public bool Leer(string nombreArchivo, out Producto producto)
        {
            try
            {
                if (!this.FileExists(nombreArchivo) || nombreArchivo.Contains("\\"))
                {
                    throw new ErrorArchivoException("Ruta inválida.");
                }
                using (XmlTextReader reader = new XmlTextReader($"{this.GetDirectoryPath}{nombreArchivo}"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    producto = (Producto)serializer.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al leer archivo.", ex);
            }
        }
        #endregion
    }
}
