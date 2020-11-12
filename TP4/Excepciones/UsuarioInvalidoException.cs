using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException()
            : this("El usuario ingresado es inválido")
        {
        }

        public UsuarioInvalidoException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
