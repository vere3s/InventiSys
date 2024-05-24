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
    public partial class VisorProductos : Form
    {
        public VisorProductos()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                REP.Productos rOrdenes = new REP.Productos();
                rOrdenes.SetDataSource(DataLayer.Consultas.SEGUN_PERIODO_INGREDIENTES(dpInicio.Text, dpFinal.Text));
                crvVisorProductos.ReportSource = rOrdenes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
