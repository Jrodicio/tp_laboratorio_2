using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase barril heredada de Producto
    /// </summary>
    public sealed class Barril : Producto
    {
        #region Campos
        private ETamaño tamaño;
        #endregion

        #region Propiedades
        /// <summary>
        /// Devuelve o setea el tamaño del barril
        /// </summary>
        public ETamaño Tamaño
        {
            get
            {
                return this.tamaño;
            }

            set
            {
                this.tamaño = value;
            }
        }

        /// <summary>
        /// Devuelve o setea el tamaño del barril en string
        /// </summary>
        public string StringTamaño
        {
            get
            {
                return this.tamaño.ToString();
            }

            set
            {
                switch (value)
                {
                    case "Pequeño":
                        this.Tamaño = ETamaño.Pequeño;
                        break;
                    case "Mediano":
                        this.Tamaño = ETamaño.Mediano;
                        break;
                    case "Grande":
                        this.Tamaño = ETamaño.Grande;
                        break;
                    default:
                        throw new InvalidCastException();
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor necesario para serializar
        /// </summary>
        public Barril()
        {
        }

        /// <summary>
        /// Constructor de barril
        /// </summary>
        /// <param name="idProducto">Id Producto</param>
        /// <param name="descripcion">Descripcionh</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        /// <param name="tamaño">Tamaño</param>
        public Barril(int idProducto, string descripcion, string marca, float precio, ETamaño tamaño)
            : base(idProducto, descripcion, marca, precio)
        {
            this.Tamaño = tamaño;
        }

        /// <summary>
        /// Constructor de barril
        /// </summary>
        /// <param name="idProducto">Id Producto</param>
        /// <param name="descripcion">Descripcionh</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        /// <param name="tamaño">string Tamaño</param>
        public Barril(int idProducto, string descripcion, string marca, float precio, string tamaño)
            : base(idProducto, descripcion, marca, precio)
        {
            this.StringTamaño = tamaño;
        }

        /// <summary>
        /// Convierte a string los datos del barril.
        /// </summary>
        /// <returns>String de barril</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Tipo: Barril");
            sb.AppendLine();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Tamaño: {0}", this.StringTamaño);

            return sb.ToString();
        }
        #endregion

        #region Enums
        /// <summary>
        /// Posibles tamaño de barril
        /// </summary>
        public enum ETamaño
        {
            Pequeño,
            Mediano,
            Grande
        }

        #endregion
    }
}