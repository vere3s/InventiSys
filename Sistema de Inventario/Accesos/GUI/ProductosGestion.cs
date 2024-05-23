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
    public partial class ProductosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        // Actualizar automaticamente 

        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        // Declarar el evento
        public event DataChangedEventHandler DataChanged;

    

        
        


        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.PRODUCTOS();
                lbRegistros.Text = _DATOS.Count.ToString();
                FiltrarLocalmente();
            }
            catch (Exception)
            {
            }
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (tbFiltro.Text.Trim().Length <= 0)
                {
                    _DATOS.RemoveFilter();
                }
                else
                {
                    _DATOS.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ProductosGestion()
        {
            InitializeComponent();
        }

        public static int ContarCategorias()
        {
            try
            {
                DataTable Resultado = DataLayer.Consultas.PRODUCTOS();
                return Resultado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar: " + ex.Message);
                return 0;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductosEdicion f = new ProductosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception)
            {

                throw;
            }

            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ProductosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductosEdicion oProducto = new ProductosEdicion();

                    oProducto.tbIDProducto.Text = dgvProductos.CurrentRow.Cells["IDProducto"].Value.ToString();
                    oProducto.tbNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                    oProducto.tbPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                    oProducto.tbCostoUnitario.Text = dgvProductos.CurrentRow.Cells["CostoUnitario"].Value.ToString();
                    oProducto.tbPlatillo.Text = dgvProductos.CurrentRow.Cells["EsPlatillo"].Value.ToString();
                    oProducto.cbIDCategoria.SelectedValue = dgvProductos.CurrentRow.Cells["IDCategoria"].Value;
                    oProducto.tbCantidad.Text = dgvProductos.CurrentRow.Cells["Cantidad"].Value.ToString();
                    oProducto.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            DataChanged?.Invoke(this, EventArgs.Empty);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Productos oProducto = new CLS.Productos();
                    oProducto.IDProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IDProducto"].Value.ToString());
                    if (oProducto.Eliminar())
                    {
                        MessageBox.Show("Resgistro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El resgistro no fue eliminado");
                    }
                    Cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
