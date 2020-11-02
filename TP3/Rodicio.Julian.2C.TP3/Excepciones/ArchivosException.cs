using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {

        /// <summary>
        /// Excepción por defecto al no poderse accionar con un archivo.
        /// </summary>
        public ArchivosException()
            :base("Ha ocurrido un error al intentar acceder al archivo.")
        {
        }

        /// <summary>
        /// Excepción producida al no poderse accionar con un archivo. Mensaje por defecto.
        /// </summary>
        /// <param name="innerExcepcion">Excepción que represesenta la causa de esta excepción</param>
        public ArchivosException(Exception innerExcepcion)
           : this("Ha ocurrido un error al intentar acceder al archivo.", innerExcepcion)
        {
        }

        /// <summary>
        /// Excepción producida al no poderse accionar con un archivo. Mensaje por parámetro.
        /// </summary>
        /// <param name="mensaje">Mensaje custom de excepción</param>
        /// <param name="innerExcepcion">Excepción que represesenta la causa de esta excepción</param>
        public ArchivosException(string mensaje, Exception innerExcepcion)
           : base(mensaje, innerExcepcion)
        {
        }
    }
}
