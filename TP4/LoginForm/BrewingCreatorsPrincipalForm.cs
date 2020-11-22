using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewingCreators
{
    public partial class BrewingCreatorsPrincipalForm : Form
    {
        #region Campos
        private static Form formularioAbierto;
        #endregion
        #region Propiedades
        /// <summary>
        /// Setea o retorna el formulario abierto actualmente.
        /// </summary>
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
        #endregion
        #region Métodos
        /// <summary>
        /// Constructor de formulario principal. Configura la opacidad en 0 ya que es solo auxiliar.
        /// </summary>
        public BrewingCreatorsPrincipalForm()
        {
            InitializeComponent();
            BrewingCreatorsPrincipalForm.FormularioAbierto = new LoginForm();
            this.Opacity = 0.0;
        }

        /// <summary>
        /// En la carga de este formulario se mostrará el formulario abierto (LoginForm).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrincipalEmptyForm_Load(object sender, EventArgs e)
        {
            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto();
        }

        /// <summary>
        /// Muestra el formulario abierto en forma no modal.
        /// </summary>
        public static void MostrarFormularioAbierto()
        {
            BrewingCreatorsPrincipalForm.MostrarFormularioAbierto(false);
        }

        /// <summary>
        /// Muestra el formulario abierto en forma modal o no modal
        /// </summary>
        /// <param name="dialog">True para modal, false para no modal</param>
        public static void MostrarFormularioAbierto(bool dialog)
        {
            if (dialog)
            {
                BrewingCreatorsPrincipalForm.FormularioAbierto.ShowDialog();
            }
            else
            {
                BrewingCreatorsPrincipalForm.FormularioAbierto.Show();
            }
        }

        /// <summary>
        /// Espera que se terminen de ejecutar todos los hilos antes de cerrar por completo el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrewingCreatorsPrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BrewingCreator bc = BrewingCreator.GetBrewingCreatorsSystem();
            foreach (Thread thread in bc.Threads)
            {
                while (thread.IsAlive)
                {
                    MessageBox.Show("Se están finalizando algunos procesos internos, aguarde unos segundos", "Finalizando procesos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Application.Exit();
        }
        #endregion
    }
}
