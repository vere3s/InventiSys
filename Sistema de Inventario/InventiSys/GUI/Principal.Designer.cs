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
            this.generalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administarProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPedidosVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.generalMenuItem,
            this.inventarioMenuItem,
            this.productosMenuItem,
            this.accesosMenuItem,
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
            this.dashboardMenuItem.MouseEnter += new System.EventHandler(this.dashboardMenuItem_MouseEnter);
            this.dashboardMenuItem.MouseLeave += new System.EventHandler(this.dashboardMenuItem_MouseLeave);
            // 
            // generalMenuItem
            // 
            this.generalMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.movimientosToolStripMenuItem});
            this.generalMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generalMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.generalMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generalMenuItem.Image")));
            this.generalMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.generalMenuItem.Margin = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.generalMenuItem.Name = "generalMenuItem";
            this.generalMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.generalMenuItem.Size = new System.Drawing.Size(164, 45);
            this.generalMenuItem.Text = "General";
            this.generalMenuItem.MouseEnter += new System.EventHandler(this.generalMenuItem_MouseEnter);
            this.generalMenuItem.MouseLeave += new System.EventHandler(this.generalMenuItem_MouseLeave);
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuentasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.cuentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentasToolStripMenuItem.Image")));
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.cuentasToolStripMenuItem.Text = "Tabla";
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.movimientosToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.movimientosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("movimientosToolStripMenuItem.Image")));
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.movimientosToolStripMenuItem.Text = "Tabla";
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
            this.inventarioMenuItem.MouseEnter += new System.EventHandler(this.inventarioMenuItem_MouseEnter);
            this.inventarioMenuItem.MouseLeave += new System.EventHandler(this.inventarioMenuItem_MouseLeave);
            // 
            // productosMenuItem
            // 
            this.productosMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarProductosToolStripMenuItem,
            this.agregarProductosToolStripMenuItem});
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
            // administrarProductosToolStripMenuItem
            // 
            this.administrarProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarProductosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarProductosToolStripMenuItem.Name = "administrarProductosToolStripMenuItem";
            this.administrarProductosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.administrarProductosToolStripMenuItem.Size = new System.Drawing.Size(238, 29);
            this.administrarProductosToolStripMenuItem.Text = "Administrar Productos";
            // 
            // agregarProductosToolStripMenuItem
            // 
            this.agregarProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarProductosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarProductosToolStripMenuItem.Name = "agregarProductosToolStripMenuItem";
            this.agregarProductosToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.agregarProductosToolStripMenuItem.Size = new System.Drawing.Size(238, 29);
            this.agregarProductosToolStripMenuItem.Text = "Agregar Productos";
            // 
            // accesosMenuItem
            // 
            this.accesosMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuarios,
            this.agregarUsuarioToolStripMenuItem,
            this.administarProveedoresToolStripMenuItem,
            this.administrarPedidosVentasToolStripMenuItem,
            this.administrarEmpleadoToolStripMenuItem});
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
            this.administrarUsuarios.Size = new System.Drawing.Size(272, 29);
            this.administrarUsuarios.Text = "Administrar Usuarios";
            this.administrarUsuarios.Click += new System.EventHandler(this.administrarUsuarios_Click_1);
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarUsuarioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1, 5, 1, 0);
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(272, 29);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            // 
            // administarProveedoresToolStripMenuItem
            // 
            this.administarProveedoresToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administarProveedoresToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administarProveedoresToolStripMenuItem.Name = "administarProveedoresToolStripMenuItem";
            this.administarProveedoresToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.administarProveedoresToolStripMenuItem.Text = "Administar Proveedores";
            // 
            // administrarPedidosVentasToolStripMenuItem
            // 
            this.administrarPedidosVentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarPedidosVentasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarPedidosVentasToolStripMenuItem.Name = "administrarPedidosVentasToolStripMenuItem";
            this.administrarPedidosVentasToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.administrarPedidosVentasToolStripMenuItem.Text = "Administrar Pedidos Ventas";
            // 
            // administrarEmpleadoToolStripMenuItem
            // 
            this.administrarEmpleadoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarEmpleadoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarEmpleadoToolStripMenuItem.Name = "administrarEmpleadoToolStripMenuItem";
            this.administrarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.administrarEmpleadoToolStripMenuItem.Text = "Administrar Empleado";
            this.administrarEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.administrarEmpleadoToolStripMenuItem_Click);
            // 
            // categoriasMenuItem
            // 
            this.categoriasMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCategoriaToolStripMenuItem,
            this.administrarCategoriasToolStripMenuItem,
            this.aToolStripMenuItem});
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
            // agregarCategoriaToolStripMenuItem
            // 
            this.agregarCategoriaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.agregarCategoriaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.agregarCategoriaToolStripMenuItem.Name = "agregarCategoriaToolStripMenuItem";
            this.agregarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.agregarCategoriaToolStripMenuItem.Text = "Agregar Categoria";
            this.agregarCategoriaToolStripMenuItem.Click += new System.EventHandler(this.agregarCategoriaToolStripMenuItem_Click);
            // 
            // administrarCategoriasToolStripMenuItem
            // 
            this.administrarCategoriasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.administrarCategoriasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.administrarCategoriasToolStripMenuItem.Name = "administrarCategoriasToolStripMenuItem";
            this.administrarCategoriasToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.administrarCategoriasToolStripMenuItem.Text = "administrar Categorias";
            this.administrarCategoriasToolStripMenuItem.Click += new System.EventHandler(this.administrarCategoriasToolStripMenuItem_Click_1);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.aToolStripMenuItem.Text = "a";
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
        private System.Windows.Forms.ToolStripMenuItem generalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accesosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administarProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPedidosVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarCategoriasToolStripMenuItem;
    }
}