using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Archivos
{
    /// <summary>
    /// Interfaz con generic para guardar archivos de productos
    /// </summary>
    /// <typeparam name="T">Generic de tipo Producto</typeparam>
    interface IArchivosGuardar<T> where T : Producto
    {
        void Guardar(string nombreArchivo, T objeto);
    }
}
