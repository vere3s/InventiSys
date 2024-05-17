using System;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class ClienteComentario : Form
    {
        public ClienteComentario()
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
            if (string.IsNullOrWhiteSpace(tbCliente.Text))
            {
                MessageBox.Show("El campo cliente no puede estar vacío.");
                return false;
            }
            return true;
        }
    }
}
