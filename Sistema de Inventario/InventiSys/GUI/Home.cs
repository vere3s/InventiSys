using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventiSys.GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbContadorUsuarios.Text = Consultas.USUARIOS().Rows.Count.ToString();
            lblContadorCategorias.Text=Consultas.CATEGORIAS().Rows.Count.ToString();
            lblContadorProductos.Text=Consultas.PRODUCTOS().Rows.Count.ToString();
            decimal ventasTotal = Consultas.VENTAS_TOTAL();
            lbVentasTotal.Text = ventasTotal.ToString("C");

            DataRow productoMayorPrecio = Consultas.PRODUCTOS_MAS_VENDIDO();
            string nombreProducto = productoMayorPrecio["Producto"].ToString();
            decimal precio = Convert.ToDecimal(productoMayorPrecio["Precio"]);
            lbProductoVenta.Text = $"{nombreProducto}";
            lbPrecioVenta.Text = $"{precio.ToString("C")}";

        }
    }
}
