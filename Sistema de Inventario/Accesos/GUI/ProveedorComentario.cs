using DataLayer;
using System;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class ProveedorComentario : Form
    {
        public ProveedorComentario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                Close();

            }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(cbProveedor.Text))
            {
                MessageBox.Show("El campo proveedor no puede estar vacío.");
                return false;
            }
            return true;
        }

        private void ProveedorComentario_Load(object sender, EventArgs e)
        {
            cbProveedor.DataSource = Consultas.PROVEEDORES();

            cbProveedor.DisplayMember = "Nombre";
            cbProveedor.ValueMember = "IDProveedor";
        }
    }
}
