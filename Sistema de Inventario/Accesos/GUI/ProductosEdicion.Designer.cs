namespace Accesos.GUI
{
    partial class ProductosEdicion
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
            this.components = new System.ComponentModel.Container();
            this.cbIDCategoria = new System.Windows.Forms.ComboBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIDProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCostoUnitario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Notificador = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbPlatillo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIDCategoria
            // 
            this.cbIDCategoria.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cbIDCategoria.FormattingEnabled = true;
            this.cbIDCategoria.Location = new System.Drawing.Point(44, 391);
            this.cbIDCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIDCategoria.Name = "cbIDCategoria";
            this.cbIDCategoria.Size = new System.Drawing.Size(387, 24);
            this.cbIDCategoria.TabIndex = 30;
            // 
            // tbPrecio
            // 
            this.tbPrecio.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrecio.Location = new System.Drawing.Point(309, 289);
            this.tbPrecio.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(122, 30);
            this.tbPrecio.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(302, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 346);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "Categoria";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(283, 550);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 43);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(43, 550);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 43);
            this.btnGuardar.TabIndex = 36;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(44, 182);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(387, 30);
            this.tbNombre.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nombre de Producto";
            // 
            // tbIDProducto
            // 
            this.tbIDProducto.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbIDProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIDProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDProducto.Location = new System.Drawing.Point(44, 70);
            this.tbIDProducto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbIDProducto.Name = "tbIDProducto";
            this.tbIDProducto.ReadOnly = true;
            this.tbIDProducto.Size = new System.Drawing.Size(101, 30);
            this.tbIDProducto.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "ID";
            // 
            // tbCostoUnitario
            // 
            this.tbCostoUnitario.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbCostoUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCostoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCostoUnitario.Location = new System.Drawing.Point(38, 289);
            this.tbCostoUnitario.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbCostoUnitario.Name = "tbCostoUnitario";
            this.tbCostoUnitario.Size = new System.Drawing.Size(122, 30);
            this.tbCostoUnitario.TabIndex = 44;
            this.tbCostoUnitario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 43;
            this.label3.Text = "Costo unitario";
            // 
            // tbCantidad
            // 
            this.tbCantidad.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tbCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCantidad.Location = new System.Drawing.Point(285, 482);
            this.tbCantidad.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(122, 30);
            this.tbCantidad.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(279, 452);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 47;
            this.label6.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 474);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 45;
            this.label7.Text = "Sin Stock?";
            // 
            // Notificador
            // 
            this.Notificador.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Notificador.ContainerControl = this;
            // 
            // cbPlatillo
            // 
            this.cbPlatillo.AutoSize = true;
            this.cbPlatillo.Location = new System.Drawing.Point(187, 482);
            this.cbPlatillo.Name = "cbPlatillo";
            this.cbPlatillo.Size = new System.Drawing.Size(18, 17);
            this.cbPlatillo.TabIndex = 49;
            this.cbPlatillo.UseVisualStyleBackColor = true;
            this.cbPlatillo.CheckedChanged += new System.EventHandler(this.cbPlatillo_CheckedChanged);
            // 
            // ProductosEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(471, 634);
            this.Controls.Add(this.cbPlatillo);
            this.Controls.Add(this.tbCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCostoUnitario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbIDCategoria);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIDProducto);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductosEdicion";
            this.Text = "ProductosEdicion";
            this.Load += new System.EventHandler(this.ProductosEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox cbIDCategoria;
        public System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbIDProducto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbCostoUnitario;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider Notificador;
        public System.Windows.Forms.CheckBox cbPlatillo;
    }
}