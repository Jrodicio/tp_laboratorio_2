using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaludar_OnClick(object sender, EventArgs e)
        {
            string nombreIngresado = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(nombreIngresado))
            {
                MessageBox.Show("DEBE INGRESAR SU NOMBRE!", "ERROR #247", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Hola {nombreIngresado.Trim()}!", "Saludo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }
    }
}
