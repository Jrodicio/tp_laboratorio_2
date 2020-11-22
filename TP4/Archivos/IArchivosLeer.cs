using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    /// <summary>
    /// Interfaz con generic para leer archivos de productos
    /// </summary>
    /// <typeparam name="T">Generic de tipo Producto</typeparam>
    interface IArchivosLeer<T> where T : Producto
    {
        bool Leer(string nombreArchivo, out T objeto);
    }
}
