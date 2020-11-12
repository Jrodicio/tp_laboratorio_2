using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NombreApellidoPersonaException : Exception
    {
        public NombreApellidoPersonaException(string mensaje)
            :base(mensaje)
        {
        }

        public NombreApellidoPersonaException()
            : this("El nombre o apellido de la persona posee caracteres inválidos")
        {
        }
    }
}
