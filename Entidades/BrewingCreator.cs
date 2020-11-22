using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using Excepciones;

namespace Entidades
{
    /// <summary>
    /// Delegado CambiaEstadoVenta
    /// </summary>
    /// <param name="venta">Venta que cambia de estado</param>
    public delegate void CambiaEstadoVenta(Venta venta);

    public sealed class BrewingCreator
    {
        /// <summary>
        /// Evento utilizado para informar cuando una venta ha cambiado su estado
        /// </summary>
        public event CambiaEstadoVenta InformaEstadoVenta;

        #region Campos
        private static BrewingCreator singleton;
        private Usuario usuarioLogueado;
        private List<Usuario> listaUsuarios;
        private List<Cliente> listaClientes;
        private List<Producto> listaProductos;
        private List<Venta> listaVentas;
        private List<Thread> threads;
        #endregion


        #region Propiedades
        /// <summary>
        /// Setea o retorna el usuario que se encuentra logueado previa validación de credenciales.
        /// </summary>
        public Usuario UsuarioLogueado
        {
            get
            {
                return this.usuarioLogueado;
            }
            set
            {
                if (value is null || this.ComprobarCredenciales(value))
                {
                    this.usuarioLogueado = value;
                }
                else
                {
                    throw new UsuarioInexistenteException("El usuario o la clave son incorrectos.");
                }
            }
        }

        /// <summary>
        /// Setea o retorna lista de ventas
        /// </summary>
        public List<Venta> ListaVentas
        {
            get
            {
                return this.listaVentas;
            }

            set
            {
                this.listaVentas = value;
            }
        }

        /// <summary>
        /// Agrega una venta nueva a la lista de ventas.
        /// </summary>
        public Venta AppendVenta
        {
            set
            {
                SQL.InsertVenta(value);
                this.listaVentas.Add(value);


                Thread thread = new Thread(new ParameterizedThreadStart(this.RetiroDeVenta));
                thread.Start(value);
                this.Threads.Add(thread);
            }
        }

        /// <summary>
        /// Setea o retorna lista de usuarios
        /// </summary>
        public List<Usuario> ListaUsuarios
        {
            get
            {
                return this.listaUsuarios;
            }
            set
            {
                this.listaUsuarios = value;
            }
        }

        /// <summary>
        /// Setea o retorna lista de productos
        /// </summary>
        public List<Producto> ListaProductos
        {
            get
            {
                return this.listaProductos;
            }
            set
            {
                this.listaProductos = value;
            }
        }

        /// <summary>
        /// Setea o retorna lista de productos
        /// </summary>
        public List<Cliente> ListaClientes
        {
            get
            {
                return this.listaClientes;
            }
            set
            {
                this.listaClientes = value;
            }
        }

        /// <summary>
        /// Setea o retorna lista de threads utilizados
        /// </summary>
        public List<Thread> Threads
        {
            get
            {
                return this.threads;
            }
            set
            {
                this.threads = value;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Constructor privado utilizado para BrewingCreator.
        /// </summary>
        private BrewingCreator()
        {
            this.InformaEstadoVenta += new CambiaEstadoVenta(Venta.ActualizarVenta);
            this.Threads = new List<Thread>();
            this.ListaClientes = new List<Cliente>();
            this.ListaProductos = new List<Producto>();
            this.ListaUsuarios = new List<Usuario>();
            this.ListaVentas = new List<Venta>();

            this.ActualizarClientes();
            this.ActualizarProductos();
            this.ActualizarUsuarios();
        }

        /// <summary>
        /// Método encargado de crear un nuevo BrewingCreator en caso de que esté no haya sido creado previamente.
        /// El método nos asegura que no se instancie más de un objeto BrewingCreator.
        /// </summary>
        /// <returns>BrewingCreator utilizado en todo el sistema</returns>
        public static BrewingCreator GetBrewingCreatorsSystem()
        {
            if (BrewingCreator.singleton is null)
            {
                BrewingCreator.singleton = new BrewingCreator();
            }
            return BrewingCreator.singleton;
        }

        /// <summary>
        /// Toma la lista de usuarios de la base de datos y la actualiza en la instancia actual.
        /// </summary>
        public void ActualizarUsuarios()
        {
            this.ListaUsuarios = SQL.LeerUsuarios();
        }

        /// <summary>
        /// Toma la lista de productos de la base de datos y la actualiza en la instancia actual.
        /// </summary>
        public void ActualizarProductos()
        {
            this.ListaProductos = SQL.LeerProductos();
        }

        /// <summary>
        /// Toma la lista de clientes de la base de datos y la actualiza en la instancia actual.
        /// </summary>
        public void ActualizarClientes()
        {
            this.ListaClientes = SQL.LeerClientes();
        }

        /// <summary>
        /// Comprueba las credenciales de un usuario contra los usuarios instanciados en ListaUsuarios.
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <returns>true si es válido, caso contrario false</returns>
        public bool ComprobarCredenciales(Usuario usuario)
        {
            foreach (Usuario user in this.listaUsuarios)
            {
                if (usuario == user && usuario.Contraseña == user.Contraseña)
                {
                    usuario.Nombre = user.Nombre;
                    usuario.Apellido = user.Apellido;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Realiza el retiro de una nueva venta entre 10 seg. y 30 seg de forma aleatoria.
        /// </summary>
        /// <param name="venta">Venta</param>
        public void RetiroDeVenta(object venta)
        {
            Venta miVenta = (Venta)venta;
            int tiempo = 0;
            tiempo = tiempo.Randomizer();

            Thread.Sleep(tiempo);

            miVenta.EstadoVenta = Venta.EVentaEstado.Retirado;

            if (!object.ReferenceEquals(this.InformaEstadoVenta, null))
            {
                this.InformaEstadoVenta.Invoke(miVenta);
            }
        }
        #endregion
    }
}