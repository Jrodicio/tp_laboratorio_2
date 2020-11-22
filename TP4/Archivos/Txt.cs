using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase que implementa interfaz. Posee todo lo necesario para guardar un producto o varios en formato txt.
    /// </summary>
    /// <typeparam name="T">Producto</typeparam>
    public class Txt<T> : IArchivosGuardar<Producto>
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
        /// Validará que el nombre del archivo no posea caracteres especiales.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>true si es válido, caso contrario false</returns>
        public bool ValidarNombreArchivo(string nombreArchivo)
        {
            return !(string.IsNullOrWhiteSpace(nombreArchivo) ||
                                  nombreArchivo.Contains("\\")||
                                  nombreArchivo.Contains("/") ||
                                  nombreArchivo.Contains(":") ||
                                  nombreArchivo.Contains("*") ||
                                  nombreArchivo.Contains("?") ||
                                  nombreArchivo.Contains("\"")||
                                  nombreArchivo.Contains("<") ||
                                  nombreArchivo.Contains(">") ||
                                  nombreArchivo.Contains("|"));
        }

        /// <summary>
        /// Implementación de método de interfaz. Guardará un producto con Append a un archivo de tipo texto en el escritorio.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <param name="producto">Producto</param>
        public void Guardar(string nombreArchivo, Producto producto)
        {
            StreamWriter streamWriter = null;
            try
            {
                if (ValidarNombreArchivo(nombreArchivo))
                {
                    streamWriter = new StreamWriter($"{this.GetDirectoryPath}{nombreArchivo}", true);
                    streamWriter.WriteLine("================Producto================");
                    streamWriter.WriteLine(producto);
                    streamWriter.WriteLine("========================================");
                }
                else
                {
                    throw new ErrorArchivoException("El nombre del archivo es inválido.");
                }

            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al guardar archivo", ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
        #endregion
    }
}