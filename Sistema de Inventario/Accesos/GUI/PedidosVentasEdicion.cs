using Accesos.CLS.Accesos.CLS;
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
        public string txtCliente = "";
        public string txtComentario  = "";
        int nCantidad =0;
        public PedidosVentasEdicion()
        {
            InitializeComponent();

        }
        private void AgregarProducto()
        {
            // Obtener el producto seleccionado en el ListBox
            DataRowView productoSeleccionado = (DataRowView)listBox1.SelectedItem;

            // Obtener el ID del producto seleccionado en el ListBox
            int idProductoSeleccionado = (int)productoSeleccionado["IDProducto"];

            // Verificar si el producto ya está en la lista
            DataRow[] filasExistentes = ((DataTable)_DATOS.DataSource).Select($"IDProducto = {idProductoSeleccionado}");

            // Obtener si el producto es un platillo y sus existencias
            bool esPlatillo = Convert.ToBoolean(productoSeleccionado["EsPlatillo"]);
            int existencias = Convert.ToInt32(productoSeleccionado["Cantidad"]);

            // Si es un platillo, no es necesario verificar las existencias
            if (!esPlatillo || (filasExistentes.Length > 0 && esPlatillo))
            {
                // Verificar si la cantidad seleccionada es menor o igual a las existencias disponibles
                if (filasExistentes.Length > 0 || nCantidad <= existencias)
                {
                    listBox1.Text = "";

                    if (filasExistentes.Length > 0)
                    {
                        // Si el producto ya está en la lista, incrementar su cantidad en 1
                        filasExistentes[0]["Cantidad"] = nCantidad > 0 ? nCantidad : Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                        filasExistentes[0]["Importe"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) * Convert.ToDecimal(filasExistentes[0]["Precio"]);
                    }
                    else
                    {
                        // El producto no está en la lista, agregarlo
                        Cantidad c = new Cantidad();
                        c._cantidadMaxima = existencias;

                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            nCantidad = Convert.ToInt32(c.tbCantidad.Text);
                            decimal precioProductoSeleccionado = Convert.ToDecimal(productoSeleccionado["Precio"]);
                            string nombreProductoSeleccionado = listBox1.GetItemText(listBox1.SelectedItem);

                            DataRow nuevaFila = ((DataTable)_DATOS.DataSource).NewRow();
                            nuevaFila["IDProducto"] = idProductoSeleccionado;
                            nuevaFila["Producto"] = nombreProductoSeleccionado;
                            nuevaFila["Cantidad"] = nCantidad > 0 ? nCantidad : 1;
                            nuevaFila["Precio"] = precioProductoSeleccionado;
                            nuevaFila["Importe"] = precioProductoSeleccionado * nCantidad; // Calcular el importe correctamente
                            ((DataTable)_DATOS.DataSource).Rows.Add(nuevaFila);
                        }
                    }
                }
                else
                {
                    // Manejar la situación donde la cantidad seleccionada es mayor que las existencias disponibles
                    MessageBox.Show("La cantidad seleccionada supera las existencias disponibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Si es un platillo, agregarlo sin verificar las existencias
            {
                listBox1.Text = "";

                if (filasExistentes.Length > 0)
                {
                    // Si el producto ya está en la lista, incrementar su cantidad en 1
                    filasExistentes[0]["Cantidad"] = nCantidad > 0 ? nCantidad : Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                    filasExistentes[0]["Importe"] = Convert.ToDecimal(filasExistentes[0]["Cantidad"]) * Convert.ToDecimal(filasExistentes[0]["Precio"]);
                }
                else
                {
                    // El producto no está en la lista, agregarlo sin verificar existencias
                    decimal precioProductoSeleccionado = Convert.ToDecimal(productoSeleccionado["Precio"]);
                    string nombreProductoSeleccionado = listBox1.GetItemText(listBox1.SelectedItem);
                    Cantidad c = new Cantidad();
                    c._cantidadMaxima = 9999;

                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        nCantidad = Convert.ToInt32(c.tbCantidad.Text);
                        DataRow nuevaFila = ((DataTable)_DATOS.DataSource).NewRow();
                        nuevaFila["IDProducto"] = idProductoSeleccionado;
                        nuevaFila["Producto"] = nombreProductoSeleccionado;
                        nuevaFila["Cantidad"] = nCantidad > 0 ? nCantidad : 1;
                        nuevaFila["Precio"] = precioProductoSeleccionado;
                        nuevaFila["Importe"] = precioProductoSeleccionado * nCantidad; // Calcular el importe correctamente
                        ((DataTable)_DATOS.DataSource).Rows.Add(nuevaFila);
                    }
                }
            }

            nCantidad = 0;
            listBox1.Text = "";
            // Actualizar la vista del DataGridView (dgvPedido) para reflejar los cambios
            dgvPedido.Refresh(); // O cualquier método de actualización necesario
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
            tablaPedidos.Columns.Add("IDDetallePedido", typeof(int));
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
                    _DATOSProductos.RemoveFilter();
                }
                else
                {
                    listBox1.Visible = true;
                    _DATOSProductos.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
             
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
                if (_DATOS.Count == 0) { return -1; }
               if(_ID >= 0)
                {
                    return _ID;
                }
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
                   // int idDetallpedido = Convert.ToInt32(item["IDDetallePedido"]);
                    // Crear un objeto Item con los datos del producto y agregarlo a la lista
                    Item itemPedido = new Item(idProducto, precioProducto, cantidad);
                    detallesPedido.Add(itemPedido);
                }
                PedidoVentas pedidoVentas = new PedidoVentas();
                // Llamar a la función de la capa de datos para insertar el pedido
                int idPedidoInsertado = pedidoVentas.Insertar(txtCliente, detallesPedido,txtComentario);

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
                
             
                if (_DATOS.Count == 0) { return -1; }
                if (_ID <= 0)
                {
                    return -1;
                }
                if (String.IsNullOrEmpty(txtCliente)) { return -1; }
                if (_DATOS == null)
                {
                    return -1;
                }
                // Create a list to store the details of the order as Item objects
                List<Item> detallesPedido = new List<Item>();
                PedidoVentas pedidoVentas = new PedidoVentas();
                

                // Iterate over the data in _DATOS to create the Item objects
                foreach (DataRowView item in _DATOS)
                {
                    // Obtain the data of the product from the current row
                    int idProducto = Convert.ToInt32(item["IDProducto"]);
                   
                    decimal precioProducto = Convert.ToDecimal(item["Precio"]);
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
                int idPedidoActualizado = pedidoVentas.Actualizar(_ID, txtCliente, detallesPedido,"Actualizado",txtComentario);

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
            if (_ID <= 0) { _ID = InsertarPedido(); }
    


               
                if (_ID > 0)
                {
                    PedidoVentas pedidoVentas = new PedidoVentas();
                    SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();

                   int pedidopagado = pedidoVentas.PagarPedido(_ID, ObtenerTotalProductos(), oSesion.empleado.IDEmpleado);

                }
            

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

            if (_DATOS.Count == 0) { return; }
            ActualizarPedido();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ClienteComentario f = new ClienteComentario();
            f.rtbComentario.Text = txtComentario;
            f.tbCliente.Text = txtCliente;
            if (f.ShowDialog() == DialogResult.OK) {
                txtComentario = f.rtbComentario.Text.ToString();
            txtCliente = f.tbCliente.Text;
            }
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            Cantidad c = new Cantidad();
            c.tbCantidad.Text = nCantidad.ToString();
            if(c.ShowDialog() == DialogResult.OK) {
                nCantidad = Convert.ToInt32(c.tbCantidad.Text);
            }
        }
    }
}