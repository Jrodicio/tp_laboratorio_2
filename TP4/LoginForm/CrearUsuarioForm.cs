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
    public partial class CrearUsuarioForm : Form
    {
        #region Métodos
        /// <summary>
        /// Constructor de CrearUsuarioForm
        /// </summary>
        public CrearUsuarioForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cancela la creación de usuario solicitando confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar la creación de un nuevo usuario?", "Cancelar alta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Al cerrar formulario, se configura como formulario abierto el LoginForm y se abre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrearUsuarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
        }

        /// <summary>
        /// Crea un nuevo usuario en la instancia de BrewingCreators y en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            string cuenta = this.txtUsuario.Text;
            string contraseña = this.txtContraseña.Text;
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();

            try
            {
                Usuario nuevoUsuario = new Usuario(nombre, apellido, cuenta, contraseña);
                brewingCreator.ListaUsuarios = SQL.LeerUsuarios();
                if (nuevoUsuario != brewingCreator.ListaUsuarios)
                {
                    SQL.InsertUsuario(nuevoUsuario);
                    brewingCreator.ListaUsuarios = SQL.LeerUsuarios();
                    this.Close();
                }
                else
                {
                    throw new UsuarioDuplicadoException("El nombre de usuario <{0}> ya está en uso.", nuevoUsuario.NombreUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear usuario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
