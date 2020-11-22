using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace BrewingCreators
{
    public partial class AltaClienteForm : Form
    {
        #region Métodos
        /// <summary>
        /// Constructor AltaClienteForm
        /// </summary>
        public AltaClienteForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Se intentará crear un nuevo cliente dependiendo de si el mismo no se encuentra ya dentro de la lista de clientes instanciada en BrewingCreators.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
            try
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido);
                brewingCreator.ListaClientes = SQL.LeerClientes();
                if (nuevoCliente != brewingCreator.ListaClientes)
                {
                    int idCliente = SQL.InsertCliente(nuevoCliente);
                    nuevoCliente.IdCliente = idCliente;
                    brewingCreator.ListaClientes = SQL.LeerClientes();
                    MessageBox.Show($"Se creo el cliente {nuevoCliente.ToString()}", "Exito!.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    throw new ClienteDuplicadoException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
