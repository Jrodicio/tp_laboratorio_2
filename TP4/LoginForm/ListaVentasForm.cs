using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entidades;
using Excepciones;

namespace BrewingCreators
{
    public partial class ListaVentasForm : Form
    {
        private delegate void Callback();

        #region Métodos
        /// <summary>
        /// Constructor ListaVentasForm
        /// </summary>
        public ListaVentasForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga la lista de ventas y suscribimos el método CargarListaVentas al evento SQL.InformarVentaActualizada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaVentas_Load(object sender, EventArgs e)
        {
            SQL.InformarVentaActualizada += this.CargarListaVentas;
            try
            {
                this.CargarListaVentas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al listar ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Lee las ventas desde la base de datos y las carga en la grilla del formulario.
        /// </summary>
        public void CargarListaVentas()
        {
            DataTable dataTable = SQL.LeerVentas();
            if (this.grdListaVentas.InvokeRequired)
            {
                Callback callback = new Callback(CargarListaVentas);
                this.Invoke(callback);
            }
            else
            {
                this.grdListaVentas.DataSource = dataTable;
            }
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
