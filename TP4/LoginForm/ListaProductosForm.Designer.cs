namespace BrewingCreators
{
    partial class ListaProductosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaProductosForm));
            this.btnGuardarTXT = new System.Windows.Forms.Button();
            this.btnGuardarXML = new System.Windows.Forms.Button();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.boxProductos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGuardarTXT
            // 
            this.btnGuardarTXT.Location = new System.Drawing.Point(678, 505);
            this.btnGuardarTXT.Name = "btnGuardarTXT";
            this.btnGuardarTXT.Size = new System.Drawing.Size(164, 53);
            this.btnGuardarTXT.TabIndex = 3;
            this.btnGuardarTXT.Text = "Guardar todos como TXT";
            this.btnGuardarTXT.UseVisualStyleBackColor = true;
            this.btnGuardarTXT.Click += new System.EventHandler(this.btnGuardarTXT_Click);
            // 
            // btnGuardarXML
            // 
            this.btnGuardarXML.Location = new System.Drawing.Point(450, 505);
            this.btnGuardarXML.Name = "btnGuardarXML";
            this.btnGuardarXML.Size = new System.Drawing.Size(164, 53);
            this.btnGuardarXML.TabIndex = 4;
            this.btnGuardarXML.Text = "Guardar seleccionado como XML";
            this.btnGuardarXML.UseVisualStyleBackColor = true;
            this.btnGuardarXML.Click += new System.EventHandler(this.btnGuardarXML_Click);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(446, 471);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(120, 19);
            this.lblNombreArchivo.TabIndex = 4;
            this.lblNombreArchivo.Text = "Nombre archivo:";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(572, 468);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(270, 27);
            this.txtNombreArchivo.TabIndex = 2;
            // 
            // boxProductos
            // 
            this.boxProductos.FormattingEnabled = true;
            this.boxProductos.ItemHeight = 19;
            this.boxProductos.Location = new System.Drawing.Point(450, 140);
            this.boxProductos.Name = "boxProductos";
            this.boxProductos.Size = new System.Drawing.Size(392, 308);
            this.boxProductos.TabIndex = 1;
            // 
            // ListaProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(933, 565);
            this.Controls.Add(this.boxProductos);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.btnGuardarXML);
            this.Controls.Add(this.btnGuardarTXT);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ListaProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.ListaProductosForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardarTXT;
        private System.Windows.Forms.Button btnGuardarXML;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.ListBox boxProductos;
    }
}