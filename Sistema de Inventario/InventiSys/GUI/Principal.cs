﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accesos.GUI;
using DataLayer;

namespace InventiSys.GUI
{
    public partial class Principal : Form
    {
        SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
        ProductosGestion productosGestion = new ProductosGestion();


        public Principal()
        {
            InitializeComponent();
            DataTable dt = Consultas.ProductosPocoStock();
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Error;
            notifyIcon1.BalloonTipTitle = "Bajo Inventario";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;

            string lowStockMessage = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                string nombreProducto = row["Nombre"].ToString();
                lowStockMessage += $"El producto {nombreProducto} tiene bajo stock.\n";
            }

            if (!string.IsNullOrEmpty(lowStockMessage))
            {
                notifyIcon1.BalloonTipText = lowStockMessage;
                notifyIcon1.ShowBalloonTip(30000); // Mostrar por 30 segundos
            }

        }


        private Form ObtenerFormularioExistente(Type TipoFormulario)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == TipoFormulario)
                {
                    return form; // Devuelve la instancia existente del formulario
                }
            }
            return null; // No encontró ninguna instancia existente
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            btnUsuario.Text = oSesion.Usuario;
            //Cambia el color de fondo del control MdiClient
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    c.BackColor = Color.Teal; // color
                }
            }
            Home f = new Home();
            f.MdiParent = this;
            f.Show();
        }

        private void editarUsuario_Click(object sender, EventArgs e)
        {
            Accesos.GUI.UsuariosEdicion f = new Accesos.GUI.UsuariosEdicion();
            f.MdiParent = this;
            f.Show();

            f.tbUsuario.Text = oSesion.Usuario;
            f.tbContraseña.Text = oSesion.Contraseña;
        }

        private void cerrarSesión_Click(object sender, EventArgs e)
        {
            Close();
            Login f = new Login();
            f.ShowDialog();
            if (f.Autorizado)
            {
                Principal pf = new Principal();
                pf.Show();
            }
        }
        private void inicioMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica si ya existe una instancia del formulario
            Form FormularioExistente = ObtenerFormularioExistente(typeof(Home));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                Home f = new Home();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void dashboardMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region MouseEnter
        private void inicioMenuItem_MouseEnter(object sender, EventArgs e)
        {
            inicioMenuItem.ForeColor = Color.Black;
        }

        private void inicioMenuItem_MouseLeave(object sender, EventArgs e)
        {
            inicioMenuItem.ForeColor = Color.DarkGray;
        }

        private void dashboardMenuItem_MouseEnter(object sender, EventArgs e)
        {
            dashboardMenuItem.ForeColor = Color.Black;
        }

        private void dashboardMenuItem_MouseLeave(object sender, EventArgs e)
        {
            dashboardMenuItem.ForeColor = Color.DarkGray;
        }

        private void generalMenuItem_MouseEnter(object sender, EventArgs e)
        {
            ventasMenuItem.ForeColor = Color.Black;
        }

        private void generalMenuItem_MouseLeave(object sender, EventArgs e)
        {
            ventasMenuItem.ForeColor = Color.DarkGray;
        }

        private void accesosMenuItem_MouseEnter(object sender, EventArgs e)
        {
            accesosMenuItem.ForeColor = Color.Black;
        }

        private void accesosMenuItem_MouseLeave(object sender, EventArgs e)
        {
            accesosMenuItem.ForeColor = Color.DarkGray;
        }

        private void inventarioMenuItem_MouseEnter(object sender, EventArgs e)
        {
            inventarioMenuItem.ForeColor = Color.Black;
        }

        private void inventarioMenuItem_MouseLeave(object sender, EventArgs e)
        {
            inventarioMenuItem.ForeColor = Color.DarkGray;
        }

        private void productosMenuItem_MouseEnter(object sender, EventArgs e)
        {
            productosMenuItem.ForeColor = Color.Black;
        }

        private void productosMenuItem_MouseLeave(object sender, EventArgs e)
        {
            productosMenuItem.ForeColor = Color.DarkGray;
        }

        private void categoriasMenuItem_MouseEnter(object sender, EventArgs e)
        {
            categoriasMenuItem.ForeColor = Color.Black;
        }

        private void categoriasMenuItem_MouseLeave(object sender, EventArgs e)
        {
            categoriasMenuItem.ForeColor = Color.DarkGray;
        }

        private void accesosMenuItem_Click(object sender, EventArgs e)
        {
            accesosMenuItem.ForeColor = Color.Black;
        }

        private void productosMenuItem_Click(object sender, EventArgs e)
        {
            productosMenuItem.ForeColor = Color.Black;
        }
        #endregion
        
        #region FORMULARIOS DE TABLAS
        private void administrarUsuarios_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(Accesos.GUI.UsuariosGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                try
                {
                    if (oSesion.ValidarPermiso(1))
                    {
                        Accesos.GUI.UsuariosGestion f = new Accesos.GUI.UsuariosGestion();
                        f.MdiParent = this;
                        f.Show();
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void agregarUsuario_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(Accesos.GUI.UsuariosEdicion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                try
                {
                    if (oSesion.ValidarPermiso(1))
                    {
                        Accesos.GUI.UsuariosEdicion f = new Accesos.GUI.UsuariosEdicion();
                        f.MdiParent = this;
                        f.Show();
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void administrarCategorias_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(CategoriaGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                CategoriaGestion f = new CategoriaGestion();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void agregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriasEdicion f = new CategoriasEdicion();
                f.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void administrarProductos_Click(object sender, EventArgs e)
        {


            Form FormularioExistente = ObtenerFormularioExistente(typeof(ProductosGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
                if (FormularioExistente is ProductosGestion)
                {
                    ((ProductosGestion)FormularioExistente).Cargar();
                }
            }
            else
            {
                ProductosGestion productosGestion = new ProductosGestion();
                productosGestion.MdiParent = this;
                productosGestion.Show();
            }

        }

        private void agregarProductos_Click(object sender, EventArgs e)
        {

            try
            {
                ProductosEdicion f = new ProductosEdicion();
                f.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void pedidos_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(PedidosVentasGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                PedidosVentasGestion f = new PedidosVentasGestion();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(PedidosComprasGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                PedidosComprasGestion f = new PedidosComprasGestion();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(PedidosComprasGestion));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                PermisosGestion f = new PermisosGestion();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                PermisosEdicion f = new PermisosEdicion();
                f.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void inventarioDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(Inventario));
            Inventario f;
            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); 
                if (FormularioExistente is Inventario)
                {
                    ((Inventario)FormularioExistente).Cargar(); 
                }
            }
            else
            {

                f = new Inventario();
                f.MdiParent = this;
                f.Show();
                
            }
        }

        private void inventarioDeIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormularioExistente = ObtenerFormularioExistente(typeof(InventarioIngredientes));

            if (FormularioExistente != null)
            {
                FormularioExistente.Activate(); // Activar la instancia existente
            }
            else
            {
                InventarioIngredientes f = new InventarioIngredientes();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void inventarioDeIngredientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
