using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PrecioInvalidoException : Exception
    {
        public PrecioInvalidoException()
            :base("El precio debe ser mayor a $0.00")
        {

        }
    }
}
