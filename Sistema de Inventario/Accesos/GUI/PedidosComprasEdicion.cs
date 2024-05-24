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
            int idProductoSeleccionado = (int)listBox1.SelectedValue;


            if (idProductoSeleccionado != 0) // Ajusta según tu caso
            {
                // Verificar si el producto ya está en la lista
                DataRow[] filasExistentes = ((DataTable)_DATOS.DataSource).Select($"IDProducto = {idProductoSeleccionado}");
                listBox1.Text = "";
                if (filasExistentes.Length > 0)
                {
                    // Si el producto ya está en la lista, incrementar su cantidad en 1
                    filasExistentes[0]["Cantidad"] = nCantidad > 0? nCantidad: Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                    filasExistentes[0]["Importe"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) * Convert.ToDecimal(filasExistentes[0]["CostoUnitario"]);
                }
                else
                {
                    CantidadCosto c = new CantidadCosto();

                    // El producto no está en la lista, agregarlo
                    DataRowView productoSeleccionado = (DataRowView)listBox1.SelectedItem;
                    decimal precioProductoSeleccionado = Convert.ToDecimal(productoSeleccionado["CostoUnitario"]);
                    string nombreProductoSeleccionado = listBox1.GetItemText(listBox1.SelectedItem);
                    c.tbCantidad.Text = "1";
                    c.tbCosto.Text = precioProductoSeleccionado.ToString();
                    if(c.ShowDialog() == DialogResult.OK)
                    {
                        nCantidad =Convert.ToInt32( c.tbCantidad.Text);
                        nCosto = Convert.ToDecimal(c.tbCosto.Text);
                    }
                    DataRow nuevaFila = ((DataTable)_DATOS.DataSource).NewRow();
                    nuevaFila["IDProducto"] = idProductoSeleccionado;
                    nuevaFila["Producto"] = nombreProductoSeleccionado;
                    nuevaFila["Cantidad"] = nCantidad > 0 ? nCantidad : 1;
                    nuevaFila["CostoUnitario"] = nCosto > 0 ? nCosto : precioProductoSeleccionado;
                    nuevaFila["Importe"] = precioProductoSeleccionado; // Por defecto, el importe es el mismo que el precio
                    ((DataTable)_DATOS.DataSource).Rows.Add(nuevaFila);
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

        private int InsertarPedido()
        {
            try

            {
                if (_IDproveedor <= 1) { return -1; }
                if (_ID >= 1) { return _ID; }
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
                int idPedidoInsertado = pedidoCompras.Insertar(_IDproveedor, detallesPedido);

                // Verificar si se insertó correctamente
                if (idPedidoInsertado > 0)
                {
                    MessageBox.Show("Pedido insertado correctamente. ID del pedido: " + idPedidoInsertado);
                    // Aquí puedes realizar cualquier otra acción necesaria después de inserta2r el pedido

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
        private int ActualizarPedido()
        {
            try
            {
                if (_IDproveedor <= 0) { return -1; }
                if(_DATOS.Count == 0) { return -1; }
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
                    detallesPedido.Add(new Item(idProducto, precioProducto,cantidad,idDetallePedido));

                  
                }

                // Remove products from the order that are not present in the DataGridView
               
               // pedidoVentas.EliminarProductosNoPresentesEnPedido(_ID, detallesPedido);

                // Update the order with the new details
                int idPedidoActualizado = pedidoCompras.Actualizar(_ID,_IDproveedor, detallesPedido,txtComentario);

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


        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (_DATOS.Count == 0) { return; }
            if (_ID <= 0)
            {
                _ID = InsertarPedido();
            }
          
                PedidoCompras pedidoCompras = new PedidoCompras();
                SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
                Console.WriteLine($"ID del Pedido: {_ID}, Total de Productos: {ObtenerTotalProductos()}, ID del Empleado: {oSesion.empleado.IDEmpleado}");

                pedidoCompras.PagarPedido(_ID, ObtenerTotalProductos(), oSesion.empleado.IDEmpleado);
            

        }

        private void btnEnPedido_Click(object sender, EventArgs e)
        {
            if (_ID <= 0)
            {
               _ID = InsertarPedido();
               
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
            ActualizarPedido();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ProveedorComentario f = new ProveedorComentario();

            f.cbProveedor.SelectedValue = _IDproveedor;
            // Método para obtener el IdProveedor de la fila actual
            f.rtbComentario.Text = txtComentario;
            
            if (f.ShowDialog() == DialogResult.OK) {
                txtComentario = f.rtbComentario.Text;
                _IDproveedor = Convert.ToInt32(f.cbProveedor.SelectedValue);
               
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            CantidadCosto c = new CantidadCosto();
            c.tbCantidad.Text = nCantidad.ToString();
            c.tbCosto.Text = nCosto.ToString();
            if(c.ShowDialog() == DialogResult.OK)
            {
                nCantidad =  Convert.ToInt32(c.tbCantidad.Text);
                nCosto = Convert.ToDecimal(c.tbCosto.Text); 
            }
        }
    }
}