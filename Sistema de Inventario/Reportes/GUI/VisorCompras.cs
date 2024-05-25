using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.GUI
{
    public partial class VisorCompras : Form
    {
        public VisorCompras()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                REP.Compras rOrdenes = new REP.Compras();
                rOrdenes.SetDataSource(DataLayer.Consultas.COMPRAS_SEGUN_PEDIDO(dpInicio.Text, dpFinal.Text));
                crvVisorCompras.ReportSource = rOrdenes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
