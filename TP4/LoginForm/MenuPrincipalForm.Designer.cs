namespace BrewingCreators
{
    partial class MenuPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipalForm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCargarProductos = new System.Windows.Forms.Button();
            this.btnListarVentas = new System.Windows.Forms.Button();
            this.btnCargarVenta = new System.Windows.Forms.Button();
            this.btnListarProductos = new System.Windows.Forms.Button();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(740, 394);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 33);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Desloguear";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnDesloguear_Click);
            // 
            // btnCargarProductos
            // 
            this.btnCargarProductos.BackColor = System.Drawing.SystemColors.Control;
            this.btnCargarProductos.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarProductos.Location = new System.Drawing.Point(243, 174);
            this.btnCargarProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargarProductos.Name = "btnCargarProductos";
            this.btnCargarProductos.Size = new System.Drawing.Size(95, 54);
            this.btnCargarProductos.TabIndex = 1;
            this.btnCargarProductos.Text = "Cargar Productos";
            this.btnCargarProductos.UseVisualStyleBackColor = false;
            this.btnCargarProductos.Click += new System.EventHandler(this.btnCargarProductos_Click);
            // 
            // btnListarVentas
            // 
            this.btnListarVentas.BackColor = System.Drawing.SystemColors.Control;
            this.btnListarVentas.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarVentas.Location = new System.Drawing.Point(639, 238);
            this.btnListarVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnListarVentas.Name = "btnListarVentas";
            this.btnListarVentas.Size = new System.Drawing.Size(95, 54);
            this.btnListarVentas.TabIndex = 5;
            this.btnListarVentas.Text = "Listar Ventas";
            this.btnListarVentas.UseVisualStyleBackColor = false;
            this.btnListarVentas.Click += new System.EventHandler(this.btnListarVentas_Click);
            // 
            // btnCargarVenta
            // 
            this.btnCargarVenta.BackColor = System.Drawing.SystemColors.Control;
            this.btnCargarVenta.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarVenta.Location = new System.Drawing.Point(639, 174);
            this.btnCargarVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargarVenta.Name = "btnCargarVenta";
            this.btnCargarVenta.Size = new System.Drawing.Size(95, 54);
            this.btnCargarVenta.TabIndex = 4;
            this.btnCargarVenta.Text = "Cargar Venta";
            this.btnCargarVenta.UseVisualStyleBackColor = false;
            this.btnCargarVenta.Click += new System.EventHandler(this.btnCargarVenta_Click);
            // 
            // btnListarProductos
            // 
            this.btnListarProductos.BackColor = System.Drawing.SystemColors.Control;
            this.btnListarProductos.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarProductos.Location = new System.Drawing.Point(243, 238);
            this.btnListarProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnListarProductos.Name = "btnListarProductos";
            this.btnListarProductos.Size = new System.Drawing.Size(95, 54);
            this.btnListarProductos.TabIndex = 2;
            this.btnListarProductos.Text = "Listar Productos";
            this.btnListarProductos.UseVisualStyleBackColor = false;
            this.btnListarProductos.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnAltaCliente.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaCliente.Location = new System.Drawing.Point(357, 217);
            this.btnAltaCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(259, 30);
            this.btnAltaCliente.TabIndex = 3;
            this.btnAltaCliente.Text = "Alta de nuevo cliente";
            this.btnAltaCliente.UseVisualStyleBackColor = false;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(864, 441);
            this.Controls.Add(this.btnAltaCliente);
            this.Controls.Add(this.btnListarProductos);
            this.Controls.Add(this.btnCargarVenta);
            this.Controls.Add(this.btnListarVentas);
            this.Controls.Add(this.btnCargarProductos);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brewing Creators";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipalForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCargarProductos;
        private System.Windows.Forms.Button btnListarVentas;
        private System.Windows.Forms.Button btnCargarVenta;
        private System.Windows.Forms.Button btnListarProductos;
        private System.Windows.Forms.Button btnAltaCliente;
    }
}