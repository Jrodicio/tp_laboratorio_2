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

namespace BrewingCreators
{
    public partial class CrearProductoForm : Form
    {
        #region Métodos
        /// <summary>
        /// Constructor CrearProductoForm.
        /// </summary>
        public CrearProductoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al cambiar el tipo de producto, se oculta o muestran campos correspondientes a Barril o Materia Prima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstTipo.Text == "Barril")
            {
                this.lstTamaño.Visible = true;
                this.decPesoKG.Visible = false;
            }
            else
            {
                this.lstTamaño.Visible = false;
                this.decPesoKG.Visible = true;
            }
        }

        /// <summary>
        /// Al aceptar, se crea un nuevo producto tanto en base de datos como en la instancia de BrewingCreators.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string tipo = this.lstTipo.Text;
            string descripcion = this.txtDescripcion.Text;
            string marca = this.txtMarca.Text;
            float precio = (float)this.decPrecio.Value;
            float peso = (float)this.decPesoKG.Value;
            string tamaño = this.lstTamaño.Text;

            Producto nuevoProducto;
            try
            {
                if (tipo == "Barril")
                {
                    SQL.InsertProducto(tipo, descripcion, marca, precio, tamaño, out nuevoProducto);
                }
                else
                {
                    SQL.InsertProducto(tipo, descripcion, marca, precio, peso.ToString(), out nuevoProducto);
                }
                BrewingCreator.GetBrewingCreatorsSystem().ActualizarProductos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
