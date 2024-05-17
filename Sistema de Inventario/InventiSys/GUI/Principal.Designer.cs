namespace InventiSys.GUI
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUsuario = new System.Windows.Forms.ToolStripSplitButton();
            this.editarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesión = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.inicioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(220, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsuario});
            this.toolStrip1.Location = new System.Drawing.Point(220, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUsuario
            // 
            this.btnUsuario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarUsuario,
            this.cerrarSesión});
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(83, 24);
            this.btnUsuario.Text = "Usuario";
            // 
            // editarUsuario
            // 
            this.editarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("editarUsuario.Image")));
            this.editarUsuario.Name = "editarUsuario";
            this.editarUsuario.Size = new System.Drawing.Size(142, 22);
            this.editarUsuario.Text = "Editar";
            this.editarUsuario.Click += new System.EventHandler(this.editarUsuario_Click);
            // 
            // cerrarSesión
            // 
            this.cerrarSesión.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSesión.Image")));
            this.cerrarSesión.Name = "cerrarSesión";
            this.cerrarSesión.Size = new System.Drawing.Size(142, 22);
            this.cerrarSesión.Text = "Cerrar sesión";
            this.cerrarSesión.Click += new System.EventHandler(this.cerrarSesión_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioMenuItem,
            this.dashboardMenuItem,
            this.accesosMenuItem,
            this.ventasMenuItem,
            this.inventarioMenuItem,
            this.productosMenuItem,
            this.categoriasMenuItem});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.menuStrip2.Size = new System.Drawing.Size(220, 450);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // inicioMenuItem
            // 
            this.inicioMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.inicioMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.inicioMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inicioMenuItem.Image")));
            this.inicioMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inicioMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.inicioMenuItem.Name = "inicioMenuItem";
            this.inicioMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.inicioMenuItem.Size = new System.Drawing.Size(164, 45);
            this.inicioMenuItem.Text = "Inicio";
            this.inicioMenuItem.Click += new System.EventHandler(this.inicioMenuItem_Click);
            this.inicioMenuItem.MouseEnter += new System.EventHandler(this.inicioMenuItem_MouseEnter);
            this.inicioMenuItem.MouseLeave += new System.EventHandler(this.inicioMenuItem_MouseLeave);
            // 
            // dashboardMenuItem
            // 
            this.dashboardMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.dashboardMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardMenuItem.Image")));
            this.dashboardMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.dashboardMenuItem.Name = "dashboardMenuItem";
            this.dashboardMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.dashboardMenuItem.Size = new System.Drawing.Size(164, 45);
            this.dashboardMenuItem.Text = "Dashboard";
            this.dashboardMenuItem.Click += new System.EventHandler(this.dashboardMenuItem_Click);
            this.dashboardMenuItem.MouseEnter += new System.EventHandler(this.dashboardMenuItem_MouseEnter);
            this.dashboardMenuItem.MouseLeave += new System.EventHandler(this.dashboardMenuItem_MouseLeave);
            // 
            // accesosMenuItem
            // 
            this.accesosMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuarios,
            this.agregarUsuario});
            this.accesosMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accesosMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.accesosMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("accesosMenuItem.Image")));
            this.accesosMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accesosMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.accesosMenuItem.Name = "accesosMenuItem";
            this.accesosMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.accesosMenuItem.Size = new System.Drawing.Size(164, 45);
            this.accesosMenuItem.Text = "Accesos";
            // 
            // administrarUsuarios
            // 
            this.administrarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarUsuarios.ForeColor = System.Drawing.Color.DarkGray;
            this.administrarUsuarios.Name = "administrarUsuarios";
            this.administrarUsuarios.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.administrarUsuarios.Size = new System.Drawing.Size(229, 29);
            this.administrarUsuarios.Text = "Administrar Usuarios";
            this.administrarUsuarios.Click += new System.EventHandler(this.administrarUsuarios_Click);
            // 
            // agregarUsuario
            // 
            this.agregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarUsuario.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarUsuario.Name = "agregarUsuario";
            this.agregarUsuario.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.agregarUsuario.Size = new System.Drawing.Size(229, 29);
            this.agregarUsuario.Text = "Agregar Usuario";
            this.agregarUsuario.Click += new System.EventHandler(this.agregarUsuario_Click);
            // 
            // ventasMenuItem
            // 
            this.ventasMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidos});
            this.ventasMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.ventasMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasMenuItem.Image")));
            this.ventasMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ventasMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.ventasMenuItem.Name = "ventasMenuItem";
            this.ventasMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.ventasMenuItem.Size = new System.Drawing.Size(164, 45);
            this.ventasMenuItem.Text = "Ventas";
            this.ventasMenuItem.MouseEnter += new System.EventHandler(this.generalMenuItem_MouseEnter);
            this.ventasMenuItem.MouseLeave += new System.EventHandler(this.generalMenuItem_MouseLeave);
            // 
            // pedidos
            // 
            this.pedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pedidos.ForeColor = System.Drawing.Color.DarkGray;
            this.pedidos.Image = ((System.Drawing.Image)(resources.GetObject("pedidos.Image")));
            this.pedidos.Name = "pedidos";
            this.pedidos.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.pedidos.Size = new System.Drawing.Size(186, 29);
            this.pedidos.Text = "Pedidos";
            this.pedidos.Click += new System.EventHandler(this.pedidos_Click);
            // 
            // inventarioMenuItem
            // 
            this.inventarioMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventarioMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.inventarioMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inventarioMenuItem.Image")));
            this.inventarioMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventarioMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.inventarioMenuItem.Name = "inventarioMenuItem";
            this.inventarioMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.inventarioMenuItem.Size = new System.Drawing.Size(164, 45);
            this.inventarioMenuItem.Text = "Inventario";
            this.inventarioMenuItem.Click += new System.EventHandler(this.inventarioMenuItem_Click);
            this.inventarioMenuItem.MouseEnter += new System.EventHandler(this.inventarioMenuItem_MouseEnter);
            this.inventarioMenuItem.MouseLeave += new System.EventHandler(this.inventarioMenuItem_MouseLeave);
            // 
            // productosMenuItem
            // 
            this.productosMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarProductos,
            this.agregarProductos});
            this.productosMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.productosMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productosMenuItem.Image")));
            this.productosMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.productosMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.productosMenuItem.Name = "productosMenuItem";
            this.productosMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.productosMenuItem.Size = new System.Drawing.Size(164, 45);
            this.productosMenuItem.Text = "Productos";
            this.productosMenuItem.Click += new System.EventHandler(this.productosMenuItem_Click);
            this.productosMenuItem.MouseEnter += new System.EventHandler(this.productosMenuItem_MouseEnter);
            this.productosMenuItem.MouseLeave += new System.EventHandler(this.productosMenuItem_MouseLeave);
            // 
            // administrarProductos
            // 
            this.administrarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarProductos.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarProductos.Name = "administrarProductos";
            this.administrarProductos.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.administrarProductos.Size = new System.Drawing.Size(238, 29);
            this.administrarProductos.Text = "Administrar Productos";
            this.administrarProductos.Click += new System.EventHandler(this.administrarProductos_Click);
            // 
            // agregarProductos
            // 
            this.agregarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarProductos.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarProductos.Name = "agregarProductos";
            this.agregarProductos.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.agregarProductos.Size = new System.Drawing.Size(238, 29);
            this.agregarProductos.Text = "Agregar Productos";
            this.agregarProductos.Click += new System.EventHandler(this.agregarProductos_Click);
            // 
            // categoriasMenuItem
            // 
            this.categoriasMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCategoria,
            this.administrarCategorias});
            this.categoriasMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriasMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.categoriasMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoriasMenuItem.Image")));
            this.categoriasMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoriasMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.categoriasMenuItem.Name = "categoriasMenuItem";
            this.categoriasMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.categoriasMenuItem.Size = new System.Drawing.Size(164, 45);
            this.categoriasMenuItem.Text = "Categorias";
            this.categoriasMenuItem.MouseEnter += new System.EventHandler(this.categoriasMenuItem_MouseEnter);
            this.categoriasMenuItem.MouseLeave += new System.EventHandler(this.categoriasMenuItem_MouseLeave);
            // 
            // agregarCategoria
            // 
            this.agregarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarCategoria.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarCategoria.Name = "agregarCategoria";
            this.agregarCategoria.Size = new System.Drawing.Size(238, 26);
            this.agregarCategoria.Text = "Agregar Categoria";
            this.agregarCategoria.Click += new System.EventHandler(this.agregarCategoria_Click);
            // 
            // administrarCategorias
            // 
            this.administrarCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarCategorias.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarCategorias.Name = "administrarCategorias";
            this.administrarCategorias.Size = new System.Drawing.Size(238, 26);
            this.administrarCategorias.Text = "administrar Categorias";
            this.administrarCategorias.Click += new System.EventHandler(this.administrarCategorias_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton btnUsuario;
        private System.Windows.Forms.ToolStripMenuItem editarUsuario;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesión;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem inicioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidos;
        private System.Windows.Forms.ToolStripMenuItem inventarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarProductos;
        private System.Windows.Forms.ToolStripMenuItem agregarProductos;
        private System.Windows.Forms.ToolStripMenuItem dashboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuario;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoria;
        private System.Windows.Forms.ToolStripMenuItem administrarCategorias;
    }
}