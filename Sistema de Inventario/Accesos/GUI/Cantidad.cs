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
    public partial class Cantidad : Form
    {
        public int _cantidadMaxima = 0;
        public Cantidad()
        {
            InitializeComponent();
        }
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
                {
                    Notificador.SetError(tbCantidad, "Ingrese un número válido mayor que cero");
                    valido = false;
                }
                else if (cantidad > _cantidadMaxima)
                {
                    Notificador.SetError(tbCantidad, $"La cantidad no puede ser mayor que {_cantidadMaxima}");
                    valido = false;
                }

              
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
