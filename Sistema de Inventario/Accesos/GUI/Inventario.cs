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
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
