using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Cliente : Persona
    {
        #region Campos
        private int idCliente;
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea o retorna el idCliente
        /// </summary>
        public int IdCliente
        {
            get
            {
                return this.idCliente;
            }
            set
            {
                this.idCliente = value;
            }
        }

        /// <summary>
        /// Retorna los datos del cliente como string.
        /// </summary>
        public string StrCliente
        {
            get
            {
                return this.ToString();
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor de cliente completo
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="idCliente">Id cliente</param>
        public Cliente(string nombre, string apellido, int idCliente)
            : this(nombre, apellido)
        {
            this.idCliente = idCliente;
        }

        public Cliente(string nombre, string apellido)
            : base(nombre, apellido)
        {
        }

        /// <summary>
        /// Compara dos clientes
        /// </summary>
        /// <param name="c1">Cliente 1</param>
        /// <param name="c2">Cliente 2</param>
        /// <returns>true si ambos clientes tienen el mismo nombre y apellido, caso contrario false</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            if (c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compara dos clientes
        /// </summary>
        /// <param name="c1">Cliente 1</param>
        /// <param name="c2">Cliente 2</param>
        /// <returns>false si ambos clientes tienen el mismo nombre y apellido, caso contrario true</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Verifica si un cliente se encuentra en una lista de clientes
        /// </summary>
        /// <param name="c1">Cliente 1</param>
        /// <param name="c2">Cliente 2</param>
        /// <returns>true si ambos clientes tienen el mismo nombre y apellido, caso contrario false</returns>
        public static bool operator ==(Cliente cliente, List<Cliente> listaClientes)
        {
            foreach(Cliente c in listaClientes)
            {
                if(c == cliente)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Compara dos clientes
        /// </summary>
        /// <param name="c1">Cliente 1</param>
        /// <param name="c2">Cliente 2</param>
        /// <returns>false si ambos clientes tienen el mismo nombre y apellido, caso contrario true</returns>
        public static bool operator !=(Cliente cliente, List<Cliente> listaClientes)
        {
            return !(cliente == listaClientes);
        }

        /// <summary>
        /// Pasa a string los datos del cliente
        /// </summary>
        /// <returns>String de cliente</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - {1}, {2}", this.IdCliente, base.Apellido, base.Nombre);

            return sb.ToString();
        }
        #endregion
    }
}
