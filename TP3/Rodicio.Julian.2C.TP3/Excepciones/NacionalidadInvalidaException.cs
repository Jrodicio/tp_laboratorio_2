using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepción producida cuando el DNI no corresponde con la nacionalidad.
        /// </summary>
        public NacionalidadInvalidaException()
            :this("La nacionalidad no se condice con el número de DNI")
        {
        }

        /// <summary>
        /// Excepción producida cuando el DNI no corresponde con la nacionalidad. Mensaje custom.
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepción</param>
        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        {
        }
    }
}
