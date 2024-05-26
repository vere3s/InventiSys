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
    public partial class CantidadCosto : Form
    {
       public int cantidadMaxima;
        public CantidadCosto()
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
             

                if (!decimal.TryParse(tbCosto.Text.Trim(), out decimal costoUnitario) || costoUnitario <= 0)
                {
                    Notificador.SetError(tbCosto, "Ingrese un número válido mayor que cero");
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

        private void CantidadCosto_Load(object sender, EventArgs e)
        {

        }
    }
}
