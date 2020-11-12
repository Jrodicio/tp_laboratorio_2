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
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
                Usuario usuarioIngresado = new Usuario(this.txtUsuario.Text, this.txtContraseña.Text);

                brewingCreator.UsuarioLogueado = usuarioIngresado;

                MenuPrincipalForm menuPrincipalForm = new MenuPrincipalForm();

                BrewingCreatorsPrincipalForm.FormularioAbierto = menuPrincipalForm;

                BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BrewingCreatorsPrincipalForm.FormularioAbierto is LoginForm)
            {
                Application.Exit();
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            CrearUsuarioForm crearUsuarioForm = new CrearUsuarioForm();

            BrewingCreatorsPrincipalForm.FormularioAbierto = crearUsuarioForm;

            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
            this.Close();
        }

    }
}
