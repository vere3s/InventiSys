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
    public partial class VisorVentas : Form
    {
        public VisorVentas()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                REP.Ventas rdVentas = new REP.Ventas();
                rdVentas.SetDataSource(DataLayer.Consultas.VENTAS_SEGUN_PERIODO_PRODUCTOS(dpInicio.Text, dpFinal.Text));
                 crvVisorVentas.ReportSource = rdVentas ;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
