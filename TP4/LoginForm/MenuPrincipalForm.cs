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
        public MenuPrincipalForm()
        {
            InitializeComponent();
        }

        private void btnDesloguear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Esta por desloguearse del sistema, ¿está seguro?", "Deslogueo de Brewing Creators",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
                BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
             
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
