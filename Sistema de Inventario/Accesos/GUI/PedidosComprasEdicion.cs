using Accesos.CLS;
using DataLayer;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class PedidosComprasEdicion : Form
    {

        BindingSource _DATOS = new BindingSource();
        BindingSource _DATOSProductos = new BindingSource();
        public int _ID = -2;
        public int _IDproveedor = -2;
        public string txtComentario = "";
        int nCantidad;
        decimal nCosto;
        public PedidosComprasEdicion()
        {
            InitializeComponent();

        }
        private void AgregarProducto()
        {
            // Obtener el ID del producto seleccionado en el ListBox
            int selectedIndex = listBox1.SelectedIndex;
            int idProductoSeleccionado = (int)listBox1.SelectedValue;
            int existencias = Convert.ToInt32(((DataRowView)listBox1.Items[selectedIndex])["Cantidad"]);

            if (idProductoSeleccionado != 0) // Ajusta según tu caso
            {
                // Verificar si el producto ya está en la lista
                DataRow[] filasExistentes = ((DataTable)_DATOS.DataSource).Select($"IDProducto = {idProductoSeleccionado}");

                // Verificar si la cantidad seleccionada es menor o igual a las existencias disponibles
                if (filasExistentes.Length > 0 || nCantidad <= existencias)
                {
                    listBox1.Text = "";

                    if (filasExistentes.Length > 0)
                    {
                        // Si el producto ya está en la lista, incrementar su cantidad en 1
                        filasExistentes[0]["Cantidad"] = nCantidad > 0 ? nCantidad : Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                        filasExistentes[0]["Importe"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) * Convert.ToDecimal(filasExistentes[0]["CostoUnitario"]);
                    }
                    else
                    {
                        CantidadCosto c = new CantidadCosto();

                        c.cantidadMaxima = existencias;
                        DataRowView productoSeleccionado = (DataRowView)listBox1.SelectedItem;
                        decimal precioProductoSeleccionado = Convert.ToDecimal(productoSeleccionado["CostoUnitario"]);
                        string nombreProductoSeleccionado = listBox1.GetItemText(listBox1.SelectedItem);
                        c.tbCantidad.Text = "1";
                        c.tbCosto.Text = precioProductoSeleccionado.ToString();
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            nCantidad = Convert.ToInt32(c.tbCantidad.Text);
                            nCosto = Convert.ToDecimal(c.tbCosto.Text);
                        
                        DataRow nuevaFila = ((DataTable)_DATOS.DataSource).NewRow();
                        nuevaFila["IDProducto"] = idProductoSeleccionado;
                        nuevaFila["Producto"] = nombreProductoSeleccionado;
                        nuevaFila["Cantidad"] = nCantidad > 0 ? nCantidad : 1;
                        nuevaFila["CostoUnitario"] = nCosto > 0 ? nCosto : precioProductoSeleccionado;
                        nuevaFila["Importe"] = Convert.ToDecimal(nuevaFila["Cantidad"]) * Convert.ToDecimal(nuevaFila["CostoUnitario"]);
                        ((DataTable)_DATOS.DataSource).Rows.Add(nuevaFila);
                        }
                    }
                }
                else
                {
                    // Maneja la situación donde la cantidad seleccionada es mayor que las existencias disponibles
                }
            }
            listBox1.Text = "";
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
            tablaPedidos.Columns.Add("CostoUnitario", typeof(decimal));
            tablaPedidos.Columns.Add("Importe", typeof(decimal));
            tablaPedidos.Columns.Add("IDDetallePedido", typeof(int));
            DataSet _dataSet = new DataSet();
            _dataSet.Tables.Add(tablaPedidos);
            _DATOS.DataSource = tablaPedidos;
            if (_ID > 0)
            {
                btnModificar.Visible = true;
                btnEnPedido.Visible = false;
                _DATOS.DataSource = Consultas.DetallePedidoCompras(_ID);


            }
            // Establecer la tabla de pedidos como origen de datos para el BindingSource



            dgvPedido.AutoGenerateColumns = false;
            dgvPedido.DataSource = _DATOS.DataSource;
            _DATOSProductos.DataSource = Consultas.ProductosNoContables();
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
                    _DATOSProductos.RemoveFilter();
                }
                else
                {
                    listBox1.Visible = true;
                    _DATOSProductos.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
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
        #region Insertar Pedido
        private void btnEnPedido_Click(object sender, EventArgs e)
        {

            InsertarPedido();


        }
        private int InsertarPedido()
        {
            try

            {
                if (_IDproveedor <= 0) { return -1; }
                if (_ID > 0) { return _ID; }
                if (_DATOS.Count == 0) { return -1; }

                // Crear una lista para almacenar los detalles del pedido como objetos Item
                List<Item> detallesPedido = new List<Item>();

                // Iterar sobre los datos en _DATOS para crear los objetos Item
                foreach (DataRowView item in _DATOS)
                {
                    // Obtener los datos del producto de la fila actual
                    int idProducto = Convert.ToInt32(item["IDProducto"]);
                    string nombreProducto = item["Producto"].ToString();
                    decimal precioProducto = Convert.ToDecimal(item["CostoUnitario"]);
                    int cantidad = Convert.ToInt32(item["Cantidad"]);
                    // int idDetallpedido = Convert.ToInt32(item["IDDetallePedido"]);
                    // Crear un objeto Item con los datos del producto y agregarlo a la lista
                    Item itemPedido = new Item(idProducto, precioProducto, cantidad);
                    detallesPedido.Add(itemPedido);
                }
                PedidoCompras pedidoCompras = new PedidoCompras();
                // Llamar a la función de la capa de datos para insertar el pedido
                int idPedidoInsertado = pedidoCompras.Insertar(_IDproveedor, detallesPedido, txtComentario);

                // Verificar si se insertó correctamente
                if (idPedidoInsertado > 0)
                {
                    MessageBox.Show("Pedido insertado correctamente. ID del pedido: " + idPedidoInsertado);
                    // Aquí puedes realizar cualquier otra acción necesaria después de inserta2r el pedido
                    _ID = idPedidoInsertado;
                    btnModificar.Visible = true;
                    btnEnPedido.Visible = false;
                    return idPedidoInsertado;
                }
                else
                {
                    MessageBox.Show("Error al insertar el pedido.");
                    return -2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return -10;
            }
        }
        #endregion

        #region Actualizar Pedido
        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActualizarPedido();
        }
        private int ActualizarPedido()
        {
            try
            {
                if (_IDproveedor <= 0) { return -1; }
                if (_DATOS.Count == 0) { return -1; }
                if (_DATOS == null)
                {
                    return -1;
                }
                // Create a list to store the details of the order as Item objects
                List<Item> detallesPedido = new List<Item>();
                PedidoCompras pedidoCompras = new PedidoCompras();


                // Iterate over the data in _DATOS to create the Item objects
                foreach (DataRowView item in _DATOS)
                {
                    // Obtain the data of the product from the current row
                    int idProducto = Convert.ToInt32(item["IDProducto"]);

                    decimal precioProducto = Convert.ToDecimal(item["CostoUnitario"]);
                    int cantidad = Convert.ToInt32(item["Cantidad"]);
                    int idDetallePedido = -1;
                    try
                    {
                        idDetallePedido = Convert.ToInt32(item["IDDetallePedido"]);
                    }
                    catch (Exception)
                    {

                        idDetallePedido = -1;
                    }


                    // Add the product to the list of details
                    detallesPedido.Add(new Item(idProducto, precioProducto, cantidad, idDetallePedido));


                }

                // Remove products from the order that are not present in the DataGridView

                // pedidoVentas.EliminarProductosNoPresentesEnPedido(_ID, detallesPedido);

                // Update the order with the new details
                int idPedidoActualizado = pedidoCompras.Actualizar(_ID, _IDproveedor, detallesPedido, txtComentario);

                // Check if the update was successful
                if (idPedidoActualizado > 0)
                {
                    MessageBox.Show("Pedido actualizado correctamente. ID del pedido: " + idPedidoActualizado);
                    return idPedidoActualizado;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el pedido.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en edicion: " + ex.ToString());
                return -1;
            }
        }
        #endregion

        #region Pagar Pedido
        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Verifica si hay elementos en la lista de datos
            if (_DATOS.Count == 0)
            {
                return; // Sale del método si no hay datos
            }

            // Verifica si el ID es válido
            if (_ID <= 0)
            {
                InsertarPedido(); // Inserta un nuevo pedido si el ID es menor o igual a cero
            }
            if (_ID > 0)
            {
                // Muestra un cuadro de diálogo de confirmación antes de realizar el pago
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas realizar el pago?", "Confirmar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verifica si el usuario confirmó el pago
                if (result == DialogResult.Yes)
                {
                    // El ID es mayor que cero, por lo que se asume que ya existe un pedido
                    PedidoCompras pedidoCompras = new PedidoCompras();
                    SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();

                    // Realiza el pago del pedido
                    int idPago = pedidoCompras.PagarPedido(_ID, ObtenerTotalProductos(), oSesion.empleado.IDEmpleado);

                    // Manejo de resultados del pago
                    if (idPago > 0)
                    {
                        MessageBox.Show("Pago realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (idPago == 0)
                    {
                        MessageBox.Show("Ya existe un pago para este pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al procesar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion



        #region Eliminar
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
        #endregion



        #region Cliente
        private void btnCliente_Click(object sender, EventArgs e)
        {
            ProveedorComentario f = new ProveedorComentario();

            f.cbProveedor.SelectedValue = _IDproveedor;
            // Método para obtener el IdProveedor de la fila actual
            f.rtbComentario.Text = txtComentario;

            if (f.ShowDialog() == DialogResult.OK)
            {
                txtComentario = f.rtbComentario.Text;
                _IDproveedor = Convert.ToInt32(f.cbProveedor.SelectedValue);

            }
        }
        #endregion



        private void btnCantidad_Click(object sender, EventArgs e)
        {
            CantidadCosto c = new CantidadCosto();
            c.tbCantidad.Text = nCantidad.ToString();
            c.tbCosto.Text = nCosto.ToString();
            if (c.ShowDialog() == DialogResult.OK)
            {
                nCantidad = Convert.ToInt32(c.tbCantidad.Text);
                nCosto = Convert.ToDecimal(c.tbCosto.Text);
            }
        }
    }
}