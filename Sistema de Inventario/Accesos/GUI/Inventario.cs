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
    public partial class Inventario : Form
    {
        BindingSource _DATOS = new BindingSource();

        // actualizar 
        public ProductosGestion _productosGestion;

        private Boolean Validar()
        {
            Boolean valido = true;
          
            return valido;
        }
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.INVENTARIOPRODUCTOS();
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
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inventario()
        {
            InitializeComponent();
          
        }
        public void productosGestion(ProductosGestion productosGestion)
        {
            _productosGestion = productosGestion;

            // Suscribirse al evento DataChanged del formulario principal
            _productosGestion.DataChanged += OnDataChanged;
        }
        private void OnDataChanged(object sender, EventArgs e)
        {
            // Recargar los datos en el formulario dependiente
            Cargar();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Desuscribirse del evento para evitar referencias no válidas
            if (_productosGestion != null)
            {
                _productosGestion.DataChanged -= OnDataChanged;
            }
        }


        private void Inventario_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void dgvInventario_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {



        }

        private void dgvInventario_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dgvInventario_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
