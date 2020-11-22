using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace BrewingCreators
{
    public partial class CargarVentaForm : Form
    {
        #region Campos
        private Producto productoSeleccionado;
        private Cliente clienteSeleccionado;
        private Venta venta;
        #endregion
        #region Propiedades

        /// <summary>
        /// Retorna el producto seleccionado en pantalla.
        /// </summary>
        public Producto GetProducto
        {
            get
            {
                this.productoSeleccionado = (Producto)this.lstProducto.SelectedItem;
                return this.productoSeleccionado;
            }
        }

        /// <summary>
        /// Retorna el cliente seleccionado en pantalla.
        /// </summary>
        public Cliente GetCliente
        {
            get
            {
                this.clienteSeleccionado = (Cliente)this.lstCliente.SelectedItem;
                return this.clienteSeleccionado;
            }
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Constructor de CargarVentaForm.
        /// </summary>
        public CargarVentaForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de formulario. Se precargan desplegables y vendedor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarVentaForm_Load(object sender, EventArgs e)
        {
            BrewingCreator bc = BrewingCreator.GetBrewingCreatorsSystem();
            string vendedor = bc.UsuarioLogueado.ToString();

            if (bc.ListaClientes.Count > 0 && bc.ListaProductos.Count > 0)
            {
                this.txtVendedor.Text = vendedor;

                this.lstCliente.DataSource = bc.ListaClientes;
                this.lstCliente.DisplayMember = "StrCliente";

                this.lstProducto.DataSource = bc.ListaProductos;
                this.lstProducto.DisplayMember = "StrProducto";
            }
            else
            {
                MessageBox.Show("No hay productos para vender o no hay clientes cargados", "No se puede cargar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Al cambiarse el index del producto se deberán realizar los cálculos de precios nuevamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtDescripcion.Text = this.GetProducto.ToString();

            this.intCantidad.Value = 1;

            float precio = productoSeleccionado.Precio;

            this.txtSubtotal.Text = precio.ToString();
        }

        /// <summary>
        /// Cuando la cantidad se ve modificada, se actualizan el subtotal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intCantidad_ValueChanged(object sender, EventArgs e)
        {
            int cantidad = (int)this.intCantidad.Value;
            float precio = this.GetProducto.Precio;

            this.txtSubtotal.Text = (precio * cantidad).ToString();
        }

        /// <summary>
        /// Añade el producto seleccionado a la lista de productos de la venta actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            int cantidad = (int)this.intCantidad.Value;
            if (this.venta is null)
            {
                this.venta = new Venta(GetCliente, new Dictionary<Producto, int>());
            }
            try
            {
                if (!this.venta.ColeccionProductosCantidad.ContainsKey(this.GetProducto))
                {
                    this.venta.ColeccionProductosCantidad.Add(this.GetProducto, cantidad);
                    this.txtTotal.Text = this.venta.CostoTotal.ToString();
                    this.boxProductos.Items.Add(this.GetProducto.StrProducto);
                }
                else
                {
                    throw new ProductoInvalidoException("Producto duplicado, cargue otro producto o cancele la gestión y vuelva a intentarlo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se puede agregar el producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Acepta y genera la venta. Cierra formulario actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BrewingCreator bc = BrewingCreator.GetBrewingCreatorsSystem();
            bc.AppendVenta = this.venta;

            this.Close();
        }
        #endregion
    }
}
