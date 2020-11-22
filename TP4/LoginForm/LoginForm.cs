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
    public partial class LoginForm : Form
    {
        #region Métodos
        /// <summary>
        /// Constructor de LoginForm
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Actualiza la lista de usuarios en la instancia de BrewingCreators e intenta loguear al usuario con las credenciales facilitadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
                Usuario usuarioIngresado = new Usuario(this.txtUsuario.Text, this.txtContraseña.Text);
                brewingCreator.ActualizarUsuarios();
                brewingCreator.UsuarioLogueado = usuarioIngresado;

                MenuPrincipalForm menuPrincipalForm = new MenuPrincipalForm();

                BrewingCreatorsPrincipalForm.FormularioAbierto = menuPrincipalForm;

                BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario de creación de usuario y cierra el actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            CrearUsuarioForm crearUsuarioForm = new CrearUsuarioForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = crearUsuarioForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
            this.Close();
        }

        /// <summary>
        /// En caso de cierre de formulario y no haber otro formulario abierto se finalizará la ejecución del aplicativo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BrewingCreatorsPrincipalForm.FormularioAbierto is LoginForm)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}
