using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Venta
    {
        #region Campos
        private int idVenta;
        private Usuario vendedor;
        private Cliente comprador;
        private Dictionary<Producto, int> coleccionProductosCantidad;
        private EVentaEstado estadoVenta;
        #endregion
        #region Propiedades
        /// <summary>
        /// Setea o retorna el Id Venta
        /// </summary>
        public int IdVenta
        {
            get
            {
                return this.idVenta;
            }

            set
            {
                this.idVenta = value;
            }
        }

        /// <summary>
        /// Retorna el usuario asociado a la venta
        /// </summary>
        public Usuario Vendedor
        {
            get
            {
                return this.vendedor;
            }
        }

        /// <summary>
        /// Retorna el cliente asociado a la venta
        /// </summary>
        public Cliente Comprador
        {
            get
            {
                return this.comprador;
            }
            set
            {
                this.comprador = value;
            }
        }

        /// <summary>
        /// Retorna datos de venta en formato string
        /// </summary>
        public string StrVenta
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("ID: {0}\nVendedor: {1}\nComprador: {2}", this.IdVenta, this.Vendedor, this.Comprador);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Retorna o setea diccionario de "producto, cantidad" asociados a la venta.
        /// </summary>
        public Dictionary<Producto, int> ColeccionProductosCantidad
        {
            get
            {
                return this.coleccionProductosCantidad;
            }

            set
            {
                this.coleccionProductosCantidad = value;
            }
        }

        /// <summary>
        /// Retorna el cálculo del costo total de los productos en la venta
        /// </summary>
        public float CostoTotal
        {
            get
            {
                float costoTotal = 0;

                foreach (Producto p in this.ColeccionProductosCantidad.Keys)
                {
                    costoTotal += p.Precio * this.ColeccionProductosCantidad[p];
                }

                return costoTotal;
            }
        }

        /// <summary>
        /// Setea o retorna el estado actual de la venta
        /// </summary>
        public EVentaEstado EstadoVenta
        {
            get
            {
                return this.estadoVenta;
            }
            set
            {
                this.estadoVenta = value;
            }
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Constructor venta, el vendedor será el usuario logueado en la instancia de BrewingCreators.
        /// </summary>
        /// <param name="comprador">Cliente comprador</param>
        /// <param name="productos">Lista de productos</param>
        public Venta(Cliente comprador, Dictionary<Producto, int> productos)
        {
            BrewingCreator bc = BrewingCreator.GetBrewingCreatorsSystem();
            this.EstadoVenta = EVentaEstado.EnDeposito;
            this.vendedor = bc.UsuarioLogueado;
            this.Comprador = comprador;
            this.ColeccionProductosCantidad = productos;
        }

        /// <summary>
        /// Permite la actualización del estado de la venta en la base de datos.
        /// </summary>
        /// <param name="venta">Venta a actualizar</param>
        public static void ActualizarVenta(Venta venta)
        {
            SQL.ActualizarEstadoVenta(venta);
        }

        /// <summary>
        /// Comparación de ventas
        /// </summary>
        /// <param name="v1">Venta 1</param>
        /// <param name="v2">Venta 2</param>
        /// <returns>True si las ventas tienen el mismo Id Venta, caso contrario false</returns>
        public static bool operator ==(Venta v1, Venta v2)
        {
            if (v1.IdVenta == v2.IdVenta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Comparación de ventas
        /// </summary>
        /// <param name="v1">Venta 1</param>
        /// <param name="v2">Venta 2</param>
        /// <returns>True si las ventas no tienen el mismo Id Venta, caso contrario false</returns>
        public static bool operator !=(Venta v1, Venta v2)
        {
            return !(v1 == v2);
        }
        #endregion
        #region enum
        public enum EVentaEstado
        {
            EnDeposito,
            Retirado
        }

        #endregion
    }
}
