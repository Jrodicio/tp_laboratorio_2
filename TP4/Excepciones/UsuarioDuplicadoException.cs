using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    public class UsuarioDuplicadoException : Exception
    {
        public UsuarioDuplicadoException(string mensaje)
            : base(mensaje)
        {
        }

        public UsuarioDuplicadoException(string formatMessage, string usuario)
            : this(string.Format(formatMessage,usuario))
        {
        }

    }
}
