using Accesos.CLS;
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
            dgvPedidosVentas.AutoGenerateColumns = false;
           
        }
        private void Cargar()
        {
            _DATOS.DataSource = Consultas.PedidosCompras(dpInicio.Text,dpFinal.Text);
            lbRegistros.Text = _DATOS.Count.ToString();
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
            // Obtener el ID del pedido y el ID del proveedor de la fila seleccionada
            int idPedido = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IDPedido"].Value);
            int idProveedor = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IdProveedor"].Value);

            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Deseas editar el pedido seleccionado?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                // Crear una instancia del formulario de edición
                PedidosComprasEdicion pedidosComprasEdicion = new PedidosComprasEdicion();

                // Pasar los datos necesarios al formulario de edición
                pedidosComprasEdicion._ID = idPedido;
                pedidosComprasEdicion._IDproveedor = idProveedor;

                // Mostrar el formulario de edición
                pedidosComprasEdicion.ShowDialog();

                // Actualizar la vista después de editar
                Cargar();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // Verificar si se ha seleccionado una fila
            if (dgvPedidosVentas.SelectedRows.Count > 0)
            {
                // Obtener el ID del pedido seleccionado
                int idSeleccionado = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IdPedido"].Value);

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el pedido seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    PedidoCompras pedidoCompras = new PedidoCompras();

                    // Intentar eliminar el pedido
                    int resultadoEliminacion = pedidoCompras.Eliminar(idSeleccionado);
                    if (resultadoEliminacion == 1)
                    {
                        MessageBox.Show("Pedido eliminado correctamente.");
                        // Recargar los datos en el DataGridView después de eliminar
                        Cargar();
                    }
                    else if (resultadoEliminacion == -1)
                    {
                        MessageBox.Show("No se puede eliminar el pedido porque existen compras asociadas.");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el pedido.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProveedoresGestion f = new ProveedoresGestion();
            f.ShowDialog();
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            Cronometro.Stop(); // Detener el timer mientras carga
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex.Message);
            }
            finally
            {
                Cronometro.Start(); // Reiniciar el timer después de cargar
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dgvPedidosVentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPedidosVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidosVentas.SelectedRows.Count > 0)
            {
                // Obtiene el valor de la celda en la columna del ID del pedido
                int idPedido = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IDPedido"].Value);

                dgvProductos.DataSource = Consultas.DetallePedidoCompras(idPedido);
            }
        }

    }
}