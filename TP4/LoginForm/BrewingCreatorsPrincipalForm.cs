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
    public partial class BrewingCreatorsPrincipalForm : Form
    {
        private static Form formularioAbierto;
                        
        public BrewingCreatorsPrincipalForm()
        {
            InitializeComponent();
            BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
            this.Opacity = 0.0;
        }

        public static Form FormularioAbierto
        {
            get
            {
                return BrewingCreatorsPrincipalForm.formularioAbierto;
            }
            set
            {
                BrewingCreatorsPrincipalForm.formularioAbierto = value;
            }
        }

        private void PrincipalEmptyForm_Load(object sender, EventArgs e)
        {
            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
        }

        public static void MostrarFormularioAbierto()
        {
            BrewingCreatorsPrincipalForm.FormularioAbierto.Show();
        }

    }
}
