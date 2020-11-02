using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepción causada cuando el DNI no es válido con mensaje por defecto.
        /// </summary>
        public DniInvalidoException()
            :this("El DNI no es válido.")
        {
        }

        /// <summary>
        /// Excepción causada cuando el DNI no es válido con mensaje custom.
        /// </summary>
        /// <param name="mensaje">Mensaje de excepción</param>
        public DniInvalidoException(string mensaje)
            :base(mensaje)
        {
        }

        /// <summary>
        /// Excepción causada cuando el DNI no es válido con innerException. Mensaje por defecto.
        /// </summary>
        /// <param name="e">Referencia al innerExcepcion</param>
        public DniInvalidoException(Exception e)
            :this("El DNI no es válido.", e)
        {
        }

        /// <summary>
        /// Excepción causada cuando el DNI no es válido con innerException. Mensaje custom.
        /// </summary>
        /// <param name="mensaje">Mensaje de excepción</param>
        /// <param name="e">Referencia al innerExcepcion</param>
        public DniInvalidoException(string mensaje, Exception e)
            : base(mensaje, e)
        {
        }
    }
}
