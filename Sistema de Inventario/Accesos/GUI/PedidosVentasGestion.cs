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
    public partial class PedidosVentasGestion : Form
    {
        int _id = -1;
        BindingSource _DATOS = new BindingSource();
 
        public PedidosVentasGestion()
        {
            InitializeComponent();
         
            dgvPedidosVentas.AutoGenerateColumns = false;
        }
        private void Cargar()
        {
            _DATOS.DataSource = Consultas.PedidosVentas(dpInicio.Text,dpFinal.Text);
            dgvPedidosVentas.DataSource = _DATOS.DataSource;
            FiltrarLocalmente();

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
                    _DATOS.Filter = "Cliente like '%" + tbFiltro.Text + "%'";
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
            PedidosVentasEdicion pedidosVentasEdicion = new PedidosVentasEdicion();
            pedidosVentasEdicion.ShowDialog();
            Cargar();
        }

    

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPedidosVentas.SelectedRows.Count > 0)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Deseas editar el pedido seleccionado?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    // Crear una instancia del formulario de edición
                    PedidosVentasEdicion pedidosVentasEdicion = new PedidosVentasEdicion();

                    // Asignar valores al formulario de edición
                    pedidosVentasEdicion._ID = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IDPedido"].Value);
                    pedidosVentasEdicion.txtCliente = dgvPedidosVentas.SelectedRows[0].Cells["Cliente"].Value.ToString();
                    pedidosVentasEdicion.txtComentario = dgvPedidosVentas.SelectedRows[0].Cells["Comentarios"].Value.ToString();

                    // Mostrar el formulario de edición
                    pedidosVentasEdicion.ShowDialog();

                    // Actualizar la vista después de editar
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila
            if (dgvPedidosVentas.SelectedRows.Count > 0)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el pedido seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del pedido seleccionado
                    int idSeleccionado = Convert.ToInt32(dgvPedidosVentas.SelectedRows[0].Cells["IdPedido"].Value);

                    PedidoVentas pedidoVentas = new PedidoVentas();

                    // Intentar eliminar el pedido
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
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
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
    }
}