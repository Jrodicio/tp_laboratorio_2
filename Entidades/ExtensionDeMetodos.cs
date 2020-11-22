using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionDeMetodos
    {
        /// <summary>
        /// Genera un número entero random entre 5000 y 30000.
        /// </summary>
        /// <param name="randomInt"></param>
        /// <returns></returns>
        public static int Randomizer(this int intRandom)
        {
            Random rnd = new Random();
            return rnd.Next(3000, 20000);
        }
    }
}
