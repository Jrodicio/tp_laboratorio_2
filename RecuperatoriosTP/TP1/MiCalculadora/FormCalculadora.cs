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
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load de calculadora. Se comienza con una limpieza de los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        /// <summary>
        /// Acción de cierre de Form al presionar botón "Cerrar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Limpiará los campos txt, cmb y lbl de FormCalculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Nos permite limpiar los campos de la calculadora.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Realizará, en caso de ser posible, el cálculo entre numero1 y numero2.
        /// </summary>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            
            if(!char.TryParse(operador, out char charOperador))
            {
                charOperador = '+';
            }
            
            return Calculadora.Operar(num1, num2, charOperador);
        }

        /// <summary>
        /// Realizá la operación seleccionada en cmbOperador, entre los valores de txtNumero1 y txtNumero2 de FormCalculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            this.lblResultado.Text = Operar(numero1, numero2, operador).ToString("N4");
        }

        /// <summary>
        /// Intentará convertir el valor de lblResultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = Numero.DecimalBinario(this.lblResultado.Text);

            if (resultado == "Valor inválido")
            {
                MessageBox.Show("No se puede convertir a binario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.lblResultado.Text = resultado;
            }
        }

        /// <summary>
        /// Intentará convertir el valor de lblResultado a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertADecimal_Click(object sender, EventArgs e)
        {
            string resultado = Numero.BinarioDecimal(this.lblResultado.Text);
            if (resultado == "Valor inválido")
            {
                MessageBox.Show("No se puede convertir a decimal", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.lblResultado.Text = resultado;
            }
        }

        /// <summary>
        /// Cierre de formulario. Solicita confirmación del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
