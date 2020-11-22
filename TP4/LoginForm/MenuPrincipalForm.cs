using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewingCreators
{
    public partial class MenuPrincipalForm : Form
    {
        #region Métodos

        /// <summary>
        /// Constructor MenuPrincipalForm
        /// </summary>
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Desloguea al usuario de la instancia BrewingCreators y cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesloguear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Solicita confirmación de deslogueo. Setea el usuario instanciado en BrewingCreators como null y abre el formulario de Login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta por desloguearse del sistema, ¿está seguro?", "Deslogueo de Brewing Creators", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
                brewingCreator.UsuarioLogueado = null;
                BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
                BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();

                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Abre ListarVentasForm de forma modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarVentas_Click(object sender, EventArgs e)
        {
            ListaVentasForm listaVentasForm = new ListaVentasForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = listaVentasForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(true);
        }

        /// <summary>
        /// Abre CargarVentaForm de forma modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            CargarVentaForm cargarVentaForm = new CargarVentaForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = cargarVentaForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(true);
        }

        /// <summary>
        /// Abre CrearProductoForm de forma modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarProductos_Click(object sender, EventArgs e)
        {
            CrearProductoForm crearProductoForm = new CrearProductoForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = crearProductoForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(true);
        }

        /// <summary>
        /// Abre ListaProductosForm de forma modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarProductos_Click(object sender, EventArgs e)
        {
            ListaProductosForm listaProductosForm = new ListaProductosForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = listaProductosForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(true);
        }

        /// <summary>
        /// Abre AltaClienteForm de forma modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            AltaClienteForm altaClienteForm = new AltaClienteForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = altaClienteForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(true);
        }
        #endregion


    }
}
