using System;
using System.Data;
using System.Windows.Forms;
using Accesos.CLS;
using Accesos.CLS.Accesos.CLS;

namespace Accesos.GUI
{
    public partial class ProveedoresGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        public ProveedoresGestion()
        {
            InitializeComponent();
        }

        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.PROVEEDORES();
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
                if (String.IsNullOrEmpty(tbFiltro.Text))
                {
                    _DATOS.RemoveFilter();
                }
                else
                {
                    _DATOS.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
                dgvProveedores.AutoGenerateColumns = false;
                dgvProveedores.DataSource = _DATOS;
            }
            catch (Exception)
            {
                
            }
        }



        private void ProveedoresGestion_Load(object sender, EventArgs e)
        {
            Cargar();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedoresEdicion f = new ProveedoresEdicion();
                f.ShowDialog();
                Cargar();
                
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


        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProveedoresEdicion oProveedor = new ProveedoresEdicion();
                    oProveedor.tbIDProveedor.Text = dgvProveedores.CurrentRow.Cells["IDProveedor"].Value.ToString();
                    oProveedor.tbNombre.Text = dgvProveedores.CurrentRow.Cells["Nombre"].Value.ToString();
                    oProveedor.tbTelefono.Text = dgvProveedores.CurrentRow.Cells["Telefono"].Value.ToString();
                    oProveedor.tbEmail.Text = dgvProveedores.CurrentRow.Cells["Email"].Value.ToString();
                    oProveedor.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {
                // Handle exception appropriately
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Proveedores oProveedor = new Proveedores();
                    oProveedor.IDProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["IDProveedor"].Value.ToString());
                    if (oProveedor.Eliminar())
                    {
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El registro no fue eliminado");
                    }
                    Cargar();
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
