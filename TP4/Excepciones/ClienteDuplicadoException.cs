using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ClienteDuplicadoException : Exception
    {
        public ClienteDuplicadoException()
            :base("El cliente se encuentra duplicado")
        {

        }
    }
}
