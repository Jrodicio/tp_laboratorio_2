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
using Archivos;
using Excepciones;

namespace BrewingCreators
{
    public partial class ListaProductosForm : Form
    {
        #region Métodos
        /// <summary>
        /// Constructor ListaProductosForm
        /// </summary>
        public ListaProductosForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga box de productos con los instanciados en BrewingCreator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListaProductosForm_Load(object sender, EventArgs e)
        {
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();

            foreach (Producto producto in brewingCreator.ListaProductos)
            {
                this.boxProductos.Items.Add(producto);
                this.boxProductos.DisplayMember = "StrProducto";
            }
            if(this.boxProductos.Items.Count < 1)
            {
                this.btnGuardarTXT.Enabled = false;
                this.btnGuardarXML.Enabled = false;
            }
        }
            
        /// <summary>
        /// Guarda en un archivo TXT en el escritorio todos los productos listados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarTXT_Click(object sender, EventArgs e)
        {
            Txt<Producto> textDesigner = new Txt<Producto>();
            string nombreArchivo = this.txtNombreArchivo.Text;

            try
            {
                foreach (Producto producto in this.boxProductos.Items)
                {
                    textDesigner.Guardar(nombreArchivo, producto);
                }
                MessageBox.Show($"Se ha generado el archivo {nombreArchivo} con todos los productos", "Éxito al guardar producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "No se guardó archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda en un archivo XML el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarXML_Click(object sender, EventArgs e)
        {
            string nombreArchivo = this.txtNombreArchivo.Text;
            Producto producto;
            try
            {
                if (this.boxProductos.SelectedItem != null)
                {
                    int index = this.boxProductos.SelectedIndex;


                    if (this.boxProductos.Items[index] is MateriaPrima)
                    {
                        Xml<MateriaPrima> xmlProducto = new Xml<MateriaPrima>();
                        producto = (MateriaPrima)this.boxProductos.Items[index];
                        xmlProducto.Guardar(nombreArchivo, producto);
                    }
                    else
                    {
                        Xml<Barril> xmlProducto = new Xml<Barril>();
                        producto = (Barril)this.boxProductos.Items[index];
                        xmlProducto.Guardar(nombreArchivo, producto);
                    }
                    MessageBox.Show($"El producto [{producto.StrProducto}] se ha guardado correctamente", "Éxito al guardar producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    throw new ErrorArchivoException("Debe seleccionar un producto para guardarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se guardó archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
