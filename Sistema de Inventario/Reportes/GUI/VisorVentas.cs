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
                REP.Ventas rdProductos = new REP.Ventas();
               // rdProductos.SetDataSource(DataLayer.Consultas.(dpInicio.Text, dpFinal.Text));
                //crvVisorVentas.ReportSource = rdProductos;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
