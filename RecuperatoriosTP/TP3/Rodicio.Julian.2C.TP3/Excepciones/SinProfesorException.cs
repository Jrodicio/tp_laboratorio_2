using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepcion generada para la falta de profesor para una clase. Mensaje por default.
        /// </summary>
        public SinProfesorException()
            : this("No hay profesor para la clase.")
        {
        }

        /// <summary>
        /// Excepcion generada para la falta de profesor para una clase. Mensaje por parámetro.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        public SinProfesorException(string mensaje)
            : base(mensaje)
        {
        }

    }
}
