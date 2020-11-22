using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excepciones;
using System.Data;

namespace Entidades
{
    public delegate void VentaActualizadaDB();

    /// <summary>
    /// Clase estática creada con el fin de mantener ordenadas las ejecuciones de SQL.
    /// </summary>
    public static class SQL
    {
        #region Campos y eventos
        public static event VentaActualizadaDB InformarVentaActualizada;
        private static SqlConnection connection = new SqlConnection("Server=.;Database=BrewingCreators;Trusted_Connection=True;");
        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene conexión a base de datos
        /// </summary>
        public static SqlConnection GetConnection
        {
            get
            {
                return SQL.connection;
            }
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Lectura de productos a base de datos
        /// </summary>
        /// <returns>Lista de productos leídos</returns>
        public static List<Producto> LeerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            int idProducto;
            string descripcion;
            string marca;
            float precio;
            string tamaño;
            string tipo;

            try
            {
                string textCommand = @"SELECT id_producto, tipo, descripcion, marca, precio, tamaño FROM dbo.Productos ORDER BY id_producto";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);

                SQL.GetConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    idProducto = reader.GetInt32(0);
                    tipo = reader.GetString(1);
                    descripcion = reader.GetString(2);
                    marca = reader.GetString(3);
                    precio = (float)reader.GetDecimal(4);
                    tamaño = reader.GetString(5);

                    if (tipo == "Barril")
                    {
                        listaProductos.Add(new Barril(idProducto, descripcion, marca, precio, tamaño));
                    }
                    else
                    {
                        listaProductos.Add(new MateriaPrima(idProducto, descripcion, tipo, marca, precio, float.Parse(tamaño)));
                    }
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
            return listaProductos;
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos y configura el id del nuevo producto en nuestro producto instanciado
        /// </summary>
        /// <param name="tipo">Tipo</param>
        /// <param name="descripcion">Descripcion</param>
        /// <param name="marca">Marca</param>
        /// <param name="precio">Precio</param>
        /// <param name="tamañoPeso">Tamaño o peso</param>
        /// <param name="nuevoProducto">Producto instanciado</param>
        public static void InsertProducto(string tipo, string descripcion, string marca, float precio, string tamañoPeso, out Producto nuevoProducto)
        {
            int idProducto;
            try
            {
                if (tipo == "Barril")
                {
                    nuevoProducto = new Barril(0, descripcion, marca, precio, tamañoPeso);
                }
                else
                {
                    nuevoProducto = new MateriaPrima(0, descripcion, tipo, marca, precio, float.Parse(tamañoPeso));
                }

                if (nuevoProducto == BrewingCreator.GetBrewingCreatorsSystem().ListaProductos)
                {
                    throw new ProductoInvalidoException("El producto se encuentra duplicado");
                }

                string textCommand = @" INSERT INTO dbo.Productos (tipo, descripcion, marca, precio, tamaño)
                                        VALUES (@tipo, @descripcion, @marca, @precio, @tamañoPeso)
                                        
                                        SELECT @@IDENTITY";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);

                sqlCommand.Parameters.AddWithValue("tipo", tipo);
                sqlCommand.Parameters.AddWithValue("descripcion", descripcion);
                sqlCommand.Parameters.AddWithValue("marca", marca);
                sqlCommand.Parameters.AddWithValue("precio", precio);
                sqlCommand.Parameters.AddWithValue("tamañoPeso", tamañoPeso);

                SQL.GetConnection.Open();
                idProducto = int.Parse(sqlCommand.ExecuteScalar().ToString());

                nuevoProducto.IdProducto = idProducto;
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
        }

        /// <summary>
        /// Lee los usuarios desde la base de datos
        /// </summary>
        /// <returns>Lista de usuarios leídos</returns>
        public static List<Usuario> LeerUsuarios()
        {
            SqlDataReader reader;
            SqlCommand sqlCommand;
            string textCommand;
            string nombre;
            string apellido;
            string usuario;
            string contraseña;
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                textCommand = @"SELECT   
                                    [Nombre] = name, [Apellido] = lastname, [Usuario] = username, [Contrasena] = password 
                               FROM dbo.Usuarios";

                SQL.GetConnection.Open();
                sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    nombre = reader.GetString(0);
                    apellido = reader.GetString(1);
                    usuario = reader.GetString(2);
                    contraseña = reader.GetString(3);

                    Usuario nuevoUsuario = new Usuario(nombre, apellido, usuario, contraseña);
                    nuevoUsuario.AddUsuario(listaUsuarios);
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }

            return listaUsuarios;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="nuevoUsuario">Usuario nuevo a insertar</param>
        public static void InsertUsuario(Usuario nuevoUsuario)
        {
            try
            {
                string textCommand = @" INSERT INTO dbo.Usuarios (username, password, name, lastname)
                                        VALUES (@usuario, @clave, @nombre, @apellido)";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                sqlCommand.Parameters.AddWithValue("usuario", nuevoUsuario.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("clave", nuevoUsuario.Contraseña);
                sqlCommand.Parameters.AddWithValue("nombre", nuevoUsuario.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", nuevoUsuario.Apellido);

                SQL.GetConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
        }

        /// <summary>
        /// Lee lista de clientes desde la base de datos
        /// </summary>
        /// <returns>Lista de clientes leída</returns>
        public static List<Cliente> LeerClientes()
        {
            SqlDataReader reader;
            SqlCommand sqlCommand;
            string textCommand;
            int idCliente;
            string nombre;
            string apellido;

            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                textCommand = @"SELECT   
                                    [IdCliente] = id_cliente, [Nombre] = name, [Apellido] = apellido
                               FROM dbo.Clientes
                               ORDER BY 1";

                SQL.GetConnection.Open();
                sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);

                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    idCliente = reader.GetInt32(0);
                    nombre = reader.GetString(1);
                    apellido = reader.GetString(2);

                    Cliente nuevoCliente = new Cliente(nombre, apellido, idCliente);
                    listaClientes.Add(nuevoCliente);
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }

            return listaClientes;
        }

        /// <summary>
        /// Inserta un nuevo cliente en la base de datos
        /// </summary>
        /// <param name="nuevoCliente">Cliente instanciado</param>
        /// <returns>Retorna el id del cliente insertado</returns>
        public static int InsertCliente(Cliente nuevoCliente)
        {
            int retorno;
            try
            {
                string textCommand = @" INSERT INTO dbo.Clientes
                                        VALUES (@nombre, @apellido)
                                        
                                        SELECT @@IDENTITY";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                sqlCommand.Parameters.AddWithValue("nombre", nuevoCliente.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", nuevoCliente.Apellido);

                SQL.GetConnection.Open();
                retorno = int.Parse(sqlCommand.ExecuteScalar().ToString());
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Lee las ventas desde la base de datos
        /// </summary>
        /// <returns>DataTable con las ventas leídas</returns>
        public static DataTable LeerVentas()
        {
            string query = @"SELECT	[IDVenta] = v.id_venta, 
                                    [TS] = v.TS, 
                                    [EstadoVenta] = v.estado,
                                    [Vendedor] = U.username + ' - ' + U.lastname + ', ' + U.name,
                                    [idCliente] = C.id_cliente, 
                                    [NombreCliente] = C.name, 
                                    [ApellidoCliente] = C.apellido,
                                    [IDProducto] = P.id_producto, 
                                    [Descripcion] = P.tipo + ' - ' + P.descripcion, 
                                    [Unidades] = VD.unidades,
                                    [PrecioUnitario] = P.precio, 
                                    [Subtotal] = P.precio * VD.unidades
                            FROM dbo.Clientes AS C
                            INNER JOIN dbo.Ventas AS V
                                ON C.id_cliente = V.id_cliente
                            INNER JOIN dbo.Usuarios AS U
                                ON V.usuario = U.username
                            INNER JOIN dbo.Ventas_detalle AS VD
                                ON V.id_venta = VD.id_venta
                            INNER JOIN dbo.Productos AS P
                                ON VD.id_producto = P.id_producto";

            DataTable dataTable = new DataTable();

            try
            {
                if (SQL.GetConnection == null || SQL.GetConnection.State == System.Data.ConnectionState.Closed)
                {
                    SQL.GetConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand(query, SQL.GetConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                    return dataTable;
                }
                else
                {
                    throw new SinVentasException();
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
            
        }
        /// <summary>
        /// Inserta una venta en la base de datos
        /// </summary>
        /// <param name="nuevaVenta">Venta a insertar</param>
        public static void InsertVenta(Venta nuevaVenta)
        {
            int idVenta;
            try
            {
                string textCommand = @" INSERT INTO Ventas (usuario, id_cliente, TS, estado)
                                        VALUES (@usuario, @idCliente, GETDATE(), 'EnDeposito')
                                        
                                        SELECT @@IDENTITY";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                sqlCommand.Parameters.AddWithValue("usuario", nuevaVenta.Vendedor.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("idCliente", nuevaVenta.Comprador.IdCliente);

                SQL.GetConnection.Open();
                idVenta = int.Parse(sqlCommand.ExecuteScalar().ToString());

                nuevaVenta.IdVenta = idVenta;

                textCommand = @" INSERT INTO Ventas_detalle(id_venta, id_producto, unidades)
                                 VALUES(@idVenta, @idProducto, @unidades)";

                foreach (Producto p in nuevaVenta.ColeccionProductosCantidad.Keys)
                {
                    sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                    sqlCommand.Parameters.AddWithValue("idVenta", idVenta);
                    sqlCommand.Parameters.AddWithValue("idProducto", p.IdProducto);
                    sqlCommand.Parameters.AddWithValue("unidades", nuevaVenta.ColeccionProductosCantidad[p]);

                    sqlCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
        }

        /// <summary>
        /// Actualiza el estado de una venta en la base de datos
        /// </summary>
        /// <param name="venta">Venta a actualizar</param>
        public static void ActualizarEstadoVenta(Venta venta)
        {
            try
            {
                string textCommand = @" UPDATE Ventas
                                        SET estado = @estado
                                        WHERE id_venta = @idVenta";

                SqlCommand sqlCommand = new SqlCommand(textCommand, SQL.GetConnection);
                sqlCommand.Parameters.AddWithValue("estado", venta.EstadoVenta.ToString());
                sqlCommand.Parameters.AddWithValue("idVenta", venta.IdVenta);

                SQL.GetConnection.Open();
                sqlCommand.ExecuteNonQuery();

                if (SQL.InformarVentaActualizada != null)
                {
                    SQL.InformarVentaActualizada.Invoke();
                }
            }
            finally
            {
                if (SQL.GetConnection != null && SQL.GetConnection.State == System.Data.ConnectionState.Open)
                {
                    SQL.GetConnection.Close();
                }
            }
        }
        #endregion
    }
}
