using Accesos.CLS.Accesos.CLS;
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

namespace Accesos.GUI
{
    public partial class PedidosComprasGestion : Form
    {
        int _id = -1;
        BindingSource _DATOS = new BindingSource();
        public PedidosComprasGestion()
        {
            InitializeComponent();
        }
        private void Cargar()
        {
            _DATOS.DataSource = Consultas.PedidosCompras();
            dgvPedidosVentas.AutoGenerateColumns = false;
            dgvPedidosVentas.DataSource = _DATOS.DataSource;
           

        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (String.IsNullOrEmpty(tbFiltro.Text))
                {
                    _DATOS.RemoveFilter();
                }
                else
                {
                    _DATOS.Filter = "Proveedor like '%" + tbFiltro.Text + "%'";
                }
                dgvPedidosVentas.AutoGenerateColumns = false;
                dgvPedidosVentas.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }
        private void PedidosVentasGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void PedidosVentasGestion_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PedidosComprasEdicion pedidosComprasEdicion = new PedidosComprasEdicion();
            pedidosComprasEdicion.ShowDialog();
            Cargar();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            PedidosComprasEdicion pedidosComprasEdicion = new PedidosComprasEdicion();
            pedidosComprasEdicion._ID = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IDPedido"].Value);
            pedidosComprasEdicion._IDproveedor = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IdProveedor"].Value);
            pedidosComprasEdicion.ShowDialog();
            Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // Verificar si se ha seleccionado una fila
            if (dgvPedidosVentas.SelectedRows.Count > 0)
            {

                int idSeleccionado = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IdPedido"].Value);


                PedidoVentas pedidoVentas = new PedidoVentas();

                if (pedidoVentas.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Pedido eliminado correctamente.");
                    // Recargar los datos en el DataGridView después de eliminar
                    Cargar();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pedido.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }


        }
    }
}