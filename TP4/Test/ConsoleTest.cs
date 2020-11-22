using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;
using System.Threading;

namespace Test
{
    class ConsoleTest
    {
        static void Main(string[] args)
        {
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
            //Suscribimos el método VentaActualizada al evento InformaEstadoVenta.
            brewingCreator.InformaEstadoVenta += VentaActualizada;
            
            Console.WriteLine("***Prueba de login***");

            Usuario usuario1 = new Usuario("Pablo", "Olbap", "noExisto", "Contraseña");
            Console.WriteLine(usuario1.ToString());
            
            try
            {
                brewingCreator.UsuarioLogueado = usuario1;
                Console.WriteLine(brewingCreator.UsuarioLogueado.ToString());
                Console.WriteLine("Login correcto");
            }
            catch(UsuarioInexistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Usuario usuario2 = new Usuario("jrodicio", "Contraseña");
            try
            {
                brewingCreator.UsuarioLogueado = usuario2;
                Console.WriteLine(brewingCreator.UsuarioLogueado.ToString());
                Console.WriteLine("Login correcto");
            }
            catch (UsuarioInexistenteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

            Console.WriteLine("\n\n***Prueba de alta de cliente***");
            Cliente cliente = new Cliente("Leo", "Man");
            try
            {
                brewingCreator.ListaClientes = SQL.LeerClientes();
                if (cliente != brewingCreator.ListaClientes)
                {
                    int idCliente = SQL.InsertCliente(cliente);
                    cliente.IdCliente = idCliente;
                    brewingCreator.ListaClientes = SQL.LeerClientes();
                }
                else
                {
                    throw new ClienteDuplicadoException();
                }
                Console.WriteLine($"Se dió de alta correctamente al cliente {cliente.StrCliente}");
            }
            catch(Exception)
            {
                Console.WriteLine($"El cliente {cliente.StrCliente} ya existe en el sistema.");
            }
            Console.ReadKey();

            Console.WriteLine("\n\n***Prueba de alta producto***");

            Producto nuevoProducto;
            try
            {
                SQL.InsertProducto("Barril", "Oro con logo personalizado", "BeerLife", 25000, "Mediano", out nuevoProducto);
                Console.WriteLine($"Producto insertado correctamente: {nuevoProducto.StrProducto}");
            }
            catch(ProductoInvalidoException)
            {
                Console.WriteLine($"El producto ya existe en el sistema.");
            }
            Console.ReadKey();

            Console.WriteLine("\n\n***Generación de 5 ventas***");
            for(int i = 0; i<5;i++)
            {
                Thread threadVenta = new Thread(new ThreadStart(GeneradorDeVentasRandom));
                brewingCreator.Threads.Add(threadVenta);
                threadVenta.Start();

                Thread.Sleep(5000);
            }

            foreach (Thread t in brewingCreator.Threads)
            {
                while (t.IsAlive)
                {
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Informa que se retiró una venta.
        /// </summary>
        /// <param name="ventaActualizada"></param>
        public static void VentaActualizada(Venta ventaActualizada)
        {
            Console.WriteLine($"\nSe ha retirado la siguiente venta:\n {ventaActualizada.StrVenta}\nCosto total: ${ventaActualizada.CostoTotal}\n");
        }

        /// <summary>
        /// Genera ventas con parámetros aleatorios
        /// </summary>
        public static void GeneradorDeVentasRandom()
        {
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
            Dictionary<Producto, int> productosVendidos = new Dictionary<Producto, int>();

            while(productosVendidos.Count<3)
            {
                try
                {
                    productosVendidos.Add(brewingCreator.ListaProductos[new Random().Next(0, brewingCreator.ListaProductos.Count - 1)], new Random().Next(1, 10));
                }
                catch (Exception)
                {
                }
            }
            
            Cliente comprador = brewingCreator.ListaClientes[new Random().Next(0, brewingCreator.ListaClientes.Count - 1)];
            Venta venta = new Venta(comprador, productosVendidos);

            brewingCreator.AppendVenta = venta;
            Console.WriteLine("**Se generó una nueva venta**");
        }
    }
}
