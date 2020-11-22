using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinVentasException : Exception
    {
        public SinVentasException(string mensaje)
            : base(mensaje)
        {
        }

        public SinVentasException()
            :this("No hay ventas en el sistema.")
        {
        }
    }
}