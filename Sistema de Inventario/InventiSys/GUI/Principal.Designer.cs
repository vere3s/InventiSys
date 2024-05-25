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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUsuario = new System.Windows.Forms.ToolStripSplitButton();
            this.editarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesión = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.inicioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.productosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioDeIngredientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPedidosVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPedidosVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPedidosDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUnPedidoDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportesStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeIngredientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(220, 602);
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
            this.accesosMenuItem,
            this.toolStripMenuItem1,
            this.productosMenuItem,
            this.categoriasMenuItem,
            this.inventarioMenuItem,
            this.pedidosMenuItem,
            this.pedidosComprasToolStripMenuItem,
            this.ReportesStripMenuItem1});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.menuStrip2.Size = new System.Drawing.Size(220, 624);
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
            this.accesosMenuItem.MouseEnter += new System.EventHandler(this.accesosMenuItem_MouseEnter);
            this.accesosMenuItem.MouseLeave += new System.EventHandler(this.accesosMenuItem_MouseLeave);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarPermisos,
            this.agregarPermisos});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.DarkGray;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 45);
            this.toolStripMenuItem1.Text = "Permisos";
            this.toolStripMenuItem1.MouseEnter += new System.EventHandler(this.toolStripMenuItem1_MouseEnter);
            this.toolStripMenuItem1.MouseLeave += new System.EventHandler(this.toolStripMenuItem1_MouseLeave);
            // 
            // administrarPermisos
            // 
            this.administrarPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarPermisos.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarPermisos.Name = "administrarPermisos";
            this.administrarPermisos.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.administrarPermisos.Size = new System.Drawing.Size(231, 29);
            this.administrarPermisos.Text = "Administrar Permisos";
            this.administrarPermisos.Click += new System.EventHandler(this.administrarPermisos_Click);
            // 
            // agregarPermisos
            // 
            this.agregarPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarPermisos.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarPermisos.Name = "agregarPermisos";
            this.agregarPermisos.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.agregarPermisos.Size = new System.Drawing.Size(231, 29);
            this.agregarPermisos.Text = "Agregar Permisos";
            this.agregarPermisos.Click += new System.EventHandler(this.agregarPermisos_Click);
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
            // inventarioMenuItem
            // 
            this.inventarioMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioDeProductosToolStripMenuItem,
            this.inventarioDeIngredientesToolStripMenuItem});
            this.inventarioMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventarioMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.inventarioMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inventarioMenuItem.Image")));
            this.inventarioMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventarioMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.inventarioMenuItem.Name = "inventarioMenuItem";
            this.inventarioMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.inventarioMenuItem.Size = new System.Drawing.Size(164, 45);
            this.inventarioMenuItem.Text = "Inventario";
            this.inventarioMenuItem.MouseEnter += new System.EventHandler(this.inventarioMenuItem_MouseEnter);
            this.inventarioMenuItem.MouseLeave += new System.EventHandler(this.inventarioMenuItem_MouseLeave);
            // 
            // inventarioDeProductosToolStripMenuItem
            // 
            this.inventarioDeProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inventarioDeProductosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.inventarioDeProductosToolStripMenuItem.Name = "inventarioDeProductosToolStripMenuItem";
            this.inventarioDeProductosToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.inventarioDeProductosToolStripMenuItem.Text = "Inventario de productos";
            this.inventarioDeProductosToolStripMenuItem.Click += new System.EventHandler(this.inventarioDeProductosToolStripMenuItem_Click);
            // 
            // inventarioDeIngredientesToolStripMenuItem
            // 
            this.inventarioDeIngredientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inventarioDeIngredientesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.inventarioDeIngredientesToolStripMenuItem.Name = "inventarioDeIngredientesToolStripMenuItem";
            this.inventarioDeIngredientesToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.inventarioDeIngredientesToolStripMenuItem.Text = "Inventario de Ingredientes";
            this.inventarioDeIngredientesToolStripMenuItem.Click += new System.EventHandler(this.inventarioDeIngredientesToolStripMenuItem_Click);
            // 
            // pedidosMenuItem
            // 
            this.pedidosMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarPedidosVenta,
            this.agregarPedidosVenta});
            this.pedidosMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidosMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.pedidosMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pedidosMenuItem.Image")));
            this.pedidosMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pedidosMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.pedidosMenuItem.Name = "pedidosMenuItem";
            this.pedidosMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.pedidosMenuItem.Size = new System.Drawing.Size(164, 45);
            this.pedidosMenuItem.Text = "Pedidos Ventas";
            this.pedidosMenuItem.MouseEnter += new System.EventHandler(this.pedidosVentasMenuItem_MouseEnter);
            this.pedidosMenuItem.MouseLeave += new System.EventHandler(this.pedidosVentasMenuItem_MouseLeave);
            // 
            // administrarPedidosVenta
            // 
            this.administrarPedidosVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarPedidosVenta.ForeColor = System.Drawing.Color.DarkGray;
            this.administrarPedidosVenta.Name = "administrarPedidosVenta";
            this.administrarPedidosVenta.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.administrarPedidosVenta.Size = new System.Drawing.Size(293, 29);
            this.administrarPedidosVenta.Text = "Administrar Pedidos de Ventas";
            this.administrarPedidosVenta.Click += new System.EventHandler(this.administrarPedidosVenta_Click);
            // 
            // agregarPedidosVenta
            // 
            this.agregarPedidosVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarPedidosVenta.ForeColor = System.Drawing.Color.DarkGray;
            this.agregarPedidosVenta.Name = "agregarPedidosVenta";
            this.agregarPedidosVenta.Size = new System.Drawing.Size(291, 26);
            this.agregarPedidosVenta.Text = "Agregar un Pedido de Venta";
            this.agregarPedidosVenta.Click += new System.EventHandler(this.agregarPedidosVenta_Click);
            // 
            // pedidosComprasToolStripMenuItem
            // 
            this.pedidosComprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarPedidosDeComprasToolStripMenuItem,
            this.agregarUnPedidoDeCompraToolStripMenuItem});
            this.pedidosComprasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidosComprasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.pedidosComprasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pedidosComprasToolStripMenuItem.Image")));
            this.pedidosComprasToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pedidosComprasToolStripMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.pedidosComprasToolStripMenuItem.Name = "pedidosComprasToolStripMenuItem";
            this.pedidosComprasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.pedidosComprasToolStripMenuItem.Size = new System.Drawing.Size(164, 45);
            this.pedidosComprasToolStripMenuItem.Text = "Pedidos Compras";
            this.pedidosComprasToolStripMenuItem.MouseEnter += new System.EventHandler(this.pedidosComprasToolStripMenuItem_MouseEnter);
            this.pedidosComprasToolStripMenuItem.MouseLeave += new System.EventHandler(this.pedidosComprasToolStripMenuItem_MouseLeave);
            // 
            // administrarPedidosDeComprasToolStripMenuItem
            // 
            this.administrarPedidosDeComprasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarPedidosDeComprasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.administrarPedidosDeComprasToolStripMenuItem.Name = "administrarPedidosDeComprasToolStripMenuItem";
            this.administrarPedidosDeComprasToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.administrarPedidosDeComprasToolStripMenuItem.Text = "Administrar Pedidos de Compras";
            this.administrarPedidosDeComprasToolStripMenuItem.Click += new System.EventHandler(this.administrarPedidosDeComprasToolStripMenuItem_Click);
            // 
            // agregarUnPedidoDeCompraToolStripMenuItem
            // 
            this.agregarUnPedidoDeCompraToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarUnPedidoDeCompraToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.agregarUnPedidoDeCompraToolStripMenuItem.Name = "agregarUnPedidoDeCompraToolStripMenuItem";
            this.agregarUnPedidoDeCompraToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.agregarUnPedidoDeCompraToolStripMenuItem.Text = "Agregar un Pedido de Compra";
            this.agregarUnPedidoDeCompraToolStripMenuItem.Click += new System.EventHandler(this.agregarUnPedidoDeCompraToolStripMenuItem_Click);
            // 
            // ReportesStripMenuItem1
            // 
            this.ReportesStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.reporteDeIngredientesToolStripMenuItem,
            this.reporteDeVentasToolStripMenuItem,
            this.reporteComprasToolStripMenuItem});
            this.ReportesStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportesStripMenuItem1.ForeColor = System.Drawing.Color.DarkGray;
            this.ReportesStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ReportesStripMenuItem1.Image")));
            this.ReportesStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportesStripMenuItem1.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.ReportesStripMenuItem1.Name = "ReportesStripMenuItem1";
            this.ReportesStripMenuItem1.Padding = new System.Windows.Forms.Padding(10);
            this.ReportesStripMenuItem1.Size = new System.Drawing.Size(164, 45);
            this.ReportesStripMenuItem1.Text = "Reportes";
            this.ReportesStripMenuItem1.MouseEnter += new System.EventHandler(this.ReportesStripMenuItem1_MouseEnter);
            this.ReportesStripMenuItem1.MouseLeave += new System.EventHandler(this.ReportesStripMenuItem1_MouseLeave);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(246, 26);
            this.toolStripMenuItem3.Text = "Reporte de productos";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // reporteDeIngredientesToolStripMenuItem
            // 
            this.reporteDeIngredientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reporteDeIngredientesToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.reporteDeIngredientesToolStripMenuItem.Name = "reporteDeIngredientesToolStripMenuItem";
            this.reporteDeIngredientesToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.reporteDeIngredientesToolStripMenuItem.Text = "Reporte de ingredientes";
            this.reporteDeIngredientesToolStripMenuItem.Click += new System.EventHandler(this.reporteDeIngredientesToolStripMenuItem_Click);
            // 
            // reporteDeVentasToolStripMenuItem
            // 
            this.reporteDeVentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reporteDeVentasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.reporteDeVentasToolStripMenuItem.Name = "reporteDeVentasToolStripMenuItem";
            this.reporteDeVentasToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.reporteDeVentasToolStripMenuItem.Text = "Reporte de Ventas";
            this.reporteDeVentasToolStripMenuItem.Click += new System.EventHandler(this.reporteDeVentasToolStripMenuItem_Click);
            // 
            // reporteComprasToolStripMenuItem
            // 
            this.reporteComprasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reporteComprasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.reporteComprasToolStripMenuItem.Name = "reporteComprasToolStripMenuItem";
            this.reporteComprasToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.reporteComprasToolStripMenuItem.Text = "Reporte Compras";
            this.reporteComprasToolStripMenuItem.Click += new System.EventHandler(this.reporteComprasToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 624);
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
        private System.Windows.Forms.ToolStripMenuItem pedidosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPedidosVenta;
        private System.Windows.Forms.ToolStripMenuItem inventarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarProductos;
        private System.Windows.Forms.ToolStripMenuItem agregarProductos;
        private System.Windows.Forms.ToolStripMenuItem categoriasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuario;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoria;
        private System.Windows.Forms.ToolStripMenuItem administrarCategorias;
        private System.Windows.Forms.ToolStripMenuItem ReportesStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administrarPermisos;
        private System.Windows.Forms.ToolStripMenuItem agregarPermisos;
        private System.Windows.Forms.ToolStripMenuItem inventarioDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioDeIngredientesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem agregarPedidosVenta;
        private System.Windows.Forms.ToolStripMenuItem reporteDeIngredientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPedidosDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUnPedidoDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteComprasToolStripMenuItem;
    }
}