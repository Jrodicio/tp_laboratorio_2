namespace BrewingCreators
{
    partial class CrearProductoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearProductoForm));
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblTamañoPeso = new System.Windows.Forms.Label();
            this.lstTipo = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lstTamaño = new System.Windows.Forms.ComboBox();
            this.decPrecio = new System.Windows.Forms.NumericUpDown();
            this.decPesoKG = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.decPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decPesoKG)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(81, 187);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(44, 19);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(34, 225);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 19);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(71, 262);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(54, 19);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "Marca:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(70, 300);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(55, 19);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblTamañoPeso
            // 
            this.lblTamañoPeso.AutoSize = true;
            this.lblTamañoPeso.Location = new System.Drawing.Point(23, 338);
            this.lblTamañoPeso.Name = "lblTamañoPeso";
            this.lblTamañoPeso.Size = new System.Drawing.Size(102, 19);
            this.lblTamañoPeso.TabIndex = 4;
            this.lblTamañoPeso.Text = "Tamaño/Peso:";
            // 
            // lstTipo
            // 
            this.lstTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstTipo.Items.AddRange(new object[] {
            "Barril",
            "Cebada",
            "Levadura",
            "Lúpulo",
            "Malta",
            "Trigo"});
            this.lstTipo.Location = new System.Drawing.Point(131, 184);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.Size = new System.Drawing.Size(136, 27);
            this.lstTipo.TabIndex = 1;
            this.lstTipo.SelectedIndexChanged += new System.EventHandler(this.lstTipo_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(131, 222);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(385, 27);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(131, 259);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(136, 27);
            this.txtMarca.TabIndex = 3;
            // 
            // lstTamaño
            // 
            this.lstTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstTamaño.FormattingEnabled = true;
            this.lstTamaño.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstTamaño.Items.AddRange(new object[] {
            "Pequeño",
            "Mediano",
            "Grande"});
            this.lstTamaño.Location = new System.Drawing.Point(131, 335);
            this.lstTamaño.Name = "lstTamaño";
            this.lstTamaño.Size = new System.Drawing.Size(136, 27);
            this.lstTamaño.TabIndex = 5;
            // 
            // decPrecio
            // 
            this.decPrecio.DecimalPlaces = 2;
            this.decPrecio.Location = new System.Drawing.Point(131, 298);
            this.decPrecio.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.decPrecio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.decPrecio.Name = "decPrecio";
            this.decPrecio.Size = new System.Drawing.Size(83, 27);
            this.decPrecio.TabIndex = 4;
            this.decPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // decPesoKG
            // 
            this.decPesoKG.DecimalPlaces = 3;
            this.decPesoKG.Location = new System.Drawing.Point(131, 335);
            this.decPesoKG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.decPesoKG.Name = "decPesoKG";
            this.decPesoKG.Size = new System.Drawing.Size(72, 27);
            this.decPesoKG.TabIndex = 6;
            this.decPesoKG.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(586, 225);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(159, 109);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // CrearProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrewingCreators.Properties.Resources.Logo___Claro;
            this.ClientSize = new System.Drawing.Size(779, 642);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.decPesoKG);
            this.Controls.Add(this.decPrecio);
            this.Controls.Add(this.lstTamaño);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lstTipo);
            this.Controls.Add(this.lblTamañoPeso);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTipo);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CrearProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de producto";
            ((System.ComponentModel.ISupportInitialize)(this.decPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decPesoKG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblTamañoPeso;
        private System.Windows.Forms.ComboBox lstTipo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.ComboBox lstTamaño;
        private System.Windows.Forms.NumericUpDown decPrecio;
        private System.Windows.Forms.NumericUpDown decPesoKG;
        private System.Windows.Forms.Button btnAceptar;
    }
}