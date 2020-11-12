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
        public CrearUsuarioForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cancelar la creación de un nuevo usuario?", "Cancelar alta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void CrearUsuarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido =  this.txtApellido.Text;
            string cuenta = this.txtUsuario.Text;
            string contraseña = this.txtContraseña.Text;
            BrewingCreator brewingCreator = BrewingCreator.GetBrewingCreatorsSystem();
            try
            {
                Usuario nuevoUsuario = new Usuario(nombre, apellido, cuenta, contraseña);
                if (nuevoUsuario != brewingCreator.ListaUsuarios)
                {
                    brewingCreator.InsertUsuarioDB(nuevoUsuario);
                    brewingCreator.ListaUsuarios = brewingCreator.LeerUsuariosDB();
                    this.Close();
                }
                else
                {
                    throw new UsuarioDuplicadoException("El usuario <{0}> ya existe en la instancia.", nuevoUsuario.NombreUsuario);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear usuario.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
