using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {

        /// <summary>
        /// Excepción producida cuando un alumno se encuentra repetido con mensaje por defecto.
        /// </summary>
        public AlumnoRepetidoException()
            : this("Alumno repetido.")
        {
        }

        /// <summary>
        /// Excepción producida cuando un alumno se encuentra repetido con mensaje por parámetro.
        /// </summary>
        /// <param name="mensaje">Mensaje de excepción.</param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
