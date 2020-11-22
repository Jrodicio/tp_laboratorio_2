using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;

namespace Entidades
{
    public abstract class Producto
    {
        #region Campos
        private string descripcion;
        private string marca;
        private float precio;
        private int idProducto;
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna o setea la descripción de un producto.
        /// </summary>
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ProductoInvalidoException("Descripción del producto inválida");
                }

                this.descripcion = value;
            }
        }

        /// <summary>
        /// Retorna o setea la marca de un producto.
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ProductoInvalidoException("Marca del producto inválida");
                }
                this.marca = value;
            }
        }

        /// <summary>
        /// Retorna o setea el precio de un producto.
        /// </summary>
        public float Precio
        {
            get
            {
                return precio;
            }

            set
            {
                if (value > 0)
                {
                    this.precio = value;
                }
                else
                {
                    throw new PrecioInvalidoException();
                }
            }
        }

        /// <summary>
        /// Retorna o setea el id de un producto
        /// </summary>
        public int IdProducto
        {
            get
            {
                return this.idProducto;
            }
            set
            {
                this.idProducto = value;
            }
        }

        /// <summary>
        /// Retorna datos de producto como string.
        /// </summary>
        public string StrProducto
        {
            get
            {
                return string.Format("{0} - {1} - {2}", this.IdProducto, this.Descripcion, this.Marca);
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor por defecto utilizado para serializar productos
        /// </summary>
        public Producto()
        {
        }

        /// <summary>
        /// Constructor de productos
        /// </summary>
        /// <param name="idProducto">Id producto</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        protected Producto(int idProducto, string descripcion, string marca, float precio)
        {
            this.IdProducto = idProducto;
            this.Descripcion = descripcion;
            this.Marca = marca;
            this.Precio = precio;
        }

        /// <summary>
        /// Comparación de dos productos, son iguales si comparten el mismo ID Producto
        /// </summary>
        /// <param name="p1">Producto 1</param>
        /// <param name="p2">Producto 2</param>
        /// <returns>true si son iguales, caso contrario false</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            if (p1.IdProducto == p2.IdProducto || (p1.Descripcion == p2.Descripcion && p1.Marca == p2.Marca && p1.Precio == p2.Precio && p1.GetType() == p2.GetType()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comparación de dos productos, son iguales si comparten el mismo ID Producto
        /// </summary>
        /// <param name="p1">Producto 1</param>
        /// <param name="p2">Producto 2</param>
        /// <returns>true si son distintos, caso contrario false</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }


        /// <summary>
        /// Verifica si el producto se encuentra dentro de una lista de productos
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="listaProductos"></param>
        /// <returns></returns>
        public static bool operator ==(Producto producto, List<Producto> listaProductos)
        {
            foreach(Producto p in listaProductos)
            {
                if(p == producto)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el producto no se encuentra dentro de una lista de productos
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="listaProductos"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto, List<Producto> listaProductos)
        {
            return !(producto == listaProductos);
        }

        /// <summary>
        /// Convierte a string los datos de un producto.
        /// </summary>
        /// <returns>String de producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id producto: {0}", this.IdProducto);
            sb.AppendLine();
            sb.AppendFormat("Descripcion: {0}", this.Descripcion);
            sb.AppendLine();
            sb.AppendFormat("Marca: {0}", this.Marca);
            sb.AppendLine();
            sb.AppendFormat("Precio: ${0}", this.Precio);

            return sb.ToString();
        }
        #endregion
    }
}
