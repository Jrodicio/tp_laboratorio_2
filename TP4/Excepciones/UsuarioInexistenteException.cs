using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class UsuarioInexistenteException : Exception
    {
        public UsuarioInexistenteException()
            :this("El usuario no existe.")
        {

        }

        public UsuarioInexistenteException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
