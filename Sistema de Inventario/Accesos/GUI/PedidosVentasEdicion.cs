﻿using Accesos.CLS.Accesos.CLS;
using DataLayer;
using Modelos;
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
    public partial class PedidosVentasEdicion : Form
    {

        BindingSource _DATOS = new BindingSource();
        BindingSource _DATOSProductos = new BindingSource();
        public int _ID = -2;
        string txtCliente = "Juan";
        public PedidosVentasEdicion()
        {
            InitializeComponent();

        }
        private void AgregarProducto()
        {
            // Obtener el ID del producto seleccionado en el ListBox
            int idProductoSeleccionado = (int)listBox1.SelectedValue;

            if (idProductoSeleccionado != 0) // Ajusta según tu caso
            {
                // Verificar si el producto ya está en la lista
                DataRow[] filasExistentes = ((DataTable)_DATOS.DataSource).Select($"IDProducto = {idProductoSeleccionado}");

                if (filasExistentes.Length > 0)
                {
                    // Si el producto ya está en la lista, incrementar su cantidad en 1
                    filasExistentes[0]["Cantidad"] = Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                    filasExistentes[0]["Importe"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) * Convert.ToDecimal(filasExistentes[0]["Precio"]);
                }
                else
                {
                    // El producto no está en la lista, agregarlo
                    DataRowView productoSeleccionado = (DataRowView)listBox1.SelectedItem;
                    decimal precioProductoSeleccionado = Convert.ToDecimal(productoSeleccionado["Precio"]);
                    string nombreProductoSeleccionado = listBox1.GetItemText(listBox1.SelectedItem);

                    DataRow nuevaFila = ((DataTable)_DATOS.DataSource).NewRow();
                    nuevaFila["IDProducto"] = idProductoSeleccionado;
                    nuevaFila["Producto"] = nombreProductoSeleccionado;
                    nuevaFila["Cantidad"] = 1;
                    nuevaFila["Precio"] = precioProductoSeleccionado;
                    nuevaFila["Importe"] = precioProductoSeleccionado; // Por defecto, el importe es el mismo que el precio
                    ((DataTable)_DATOS.DataSource).Rows.Add(nuevaFila);
                }

                // Actualizar la vista del DataGridView (dgvPedido) para reflejar los cambios
                dgvPedido.Refresh(); // O cualquier método de actualización necesario
            }
        }


        private void PedidosVentasEdicion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            // Definir la estructura de la tabla de pedidos y agregarla al DataSet
            DataTable tablaPedidos = new DataTable();
            tablaPedidos.Columns.Add("IDProducto", typeof(int));
            tablaPedidos.Columns.Add("Producto", typeof(string));
            tablaPedidos.Columns.Add("Cantidad", typeof(int));
            tablaPedidos.Columns.Add("Precio", typeof(decimal));
            tablaPedidos.Columns.Add("Importe", typeof(decimal));
            DataSet _dataSet = new DataSet();
            _dataSet.Tables.Add(tablaPedidos);
            _DATOS.DataSource = tablaPedidos;
            if (_ID > 0)
            {
                btnModificar.Visible = true;
                btnEnPedido.Visible = false;
                _DATOS.DataSource = Consultas.DetallePedidoVentas(_ID);

            }
            // Establecer la tabla de pedidos como origen de datos para el BindingSource



            dgvPedido.AutoGenerateColumns = false;
            dgvPedido.DataSource = _DATOS.DataSource;
            _DATOSProductos.DataSource = Consultas.ProductosNoIngredientes();
            listBox1.DataSource = _DATOSProductos.DataSource;
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "IDProducto";
            lbRegistros.Text = _DATOSProductos.Count.ToString();
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (String.IsNullOrEmpty(tbFiltro.Text))
                {
                    listBox1.Visible = false;
                    _DATOS.RemoveFilter();
                }
                else
                {
                    listBox1.Visible = true;
                    _DATOS.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
                dgvPedido.AutoGenerateColumns = false;
                dgvPedido.DataSource = _DATOS;
            }
            catch (Exception)
            {

            }
        }
        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }
        private int ObtenerTotalProductos()
        {
            int totalProductos = 0;

            // Iterar sobre las filas del DataGridView
            foreach (DataRowView item in _DATOS)
            {
                // Obtener la cantidad del producto de la fila actual y sumarla al total
                totalProductos += Convert.ToInt32(item["Importe"]);
            }

            return totalProductos;
        }

        private int InsertarPedido()
        {
            try

            {
                if (String.IsNullOrEmpty(txtCliente)) { return -1; }

                // Crear una lista para almacenar los detalles del pedido como objetos Item
                List<Item> detallesPedido = new List<Item>();

                // Iterar sobre los datos en _DATOS para crear los objetos Item
                foreach (DataRowView item in _DATOS)
                {
                    // Obtener los datos del producto de la fila actual
                    int idProducto = Convert.ToInt32(item["IDProducto"]);
                    string nombreProducto = item["Producto"].ToString();
                    decimal precioProducto = Convert.ToDecimal(item["Precio"]);
                    int cantidad = Convert.ToInt32(item["Cantidad"]);

                    // Crear un objeto Item con los datos del producto y agregarlo a la lista
                    Item itemPedido = new Item(idProducto, nombreProducto, precioProducto, cantidad);
                    detallesPedido.Add(itemPedido);
                }
                PedidoVentas pedidoVentas = new PedidoVentas();
                // Llamar a la función de la capa de datos para insertar el pedido
                int idPedidoInsertado = pedidoVentas.Insertar(txtCliente, detallesPedido);

                // Verificar si se insertó correctamente
                if (idPedidoInsertado > 0)
                {
                    MessageBox.Show("Pedido insertado correctamente. ID del pedido: " + idPedidoInsertado);
                    // Aquí puedes realizar cualquier otra acción necesaria después de insertar el pedido

                    return idPedidoInsertado;
                }
                else
                {
                    MessageBox.Show("Error al insertar el pedido.");
                    return -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }
        private int ActualizarPedido()
        {
            try

            {
                if (String.IsNullOrEmpty(txtCliente)) { return -1; }

                // Crear una lista para almacenar los detalles del pedido como objetos Item
                List<Item> detallesPedido = new List<Item>();
                PedidoVentas pedidoVentas = new PedidoVentas();
                // Iterar sobre los datos en _DATOS para crear los objetos Item
                foreach (DataRowView item in _DATOS)
                {
                    // Obtener los datos del producto de la fila actual
                    int idProducto = Convert.ToInt32(item["IDProducto"]);
                    string nombreProducto = item["Producto"].ToString();
                    double precioProducto = Convert.ToDouble(item["Precio"]);
                    int cantidad = Convert.ToInt32(item["Cantidad"]);

                    pedidoVentas.ActualizarDetallePedidoVentas(1, cantidad, precioProducto);

                }

                // Llamar a la función de la capa de datos para insertar el pedido
                int idPedidoInsertado = pedidoVentas.Actualizar(_ID, txtCliente);

                // Verificar si se insertó correctamente
                if (idPedidoInsertado > 0)
                {
                    MessageBox.Show("Pedido insertado correctamente. ID del pedido: " + idPedidoInsertado);
                    // Aquí puedes realizar cualquier otra acción necesaria después de insertar el pedido

                    return idPedidoInsertado;
                }
                else
                {
                    MessageBox.Show("Error al insertar el pedido.");
                    return -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            int _idPedido = InsertarPedido(); if (_idPedido > 0)
            {
                PedidoVentas pedidoVentas = new PedidoVentas();
                SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();

                pedidoVentas.pagarPedido(_idPedido, ObtenerTotalProductos(), oSesion.empleado.IDEmpleado);
            }

        }

        private void btnEnPedido_Click(object sender, EventArgs e)
        {
            if (_ID <= 0)
            {
                InsertarPedido();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener la fila seleccionada en el DataGridView
            if (dgvPedido.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int indiceFila = dgvPedido.SelectedRows[0].Index;

                // Obtener la DataTable subyacente
                DataTable tablaPedidos = (DataTable)_DATOS.DataSource;

                // Eliminar la fila seleccionada
                tablaPedidos.Rows.RemoveAt(indiceFila);

                // Actualizar la vista del DataGridView
                dgvPedido.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}