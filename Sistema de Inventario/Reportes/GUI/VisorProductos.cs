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
    public partial class crvProductos : Form
    {
        public crvProductos()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void VisorProductos_Load(object sender, EventArgs e)
        {

        }

        private void Mostrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                REP.Productos rdProductos = new REP.Productos();
                rdProductos.SetDataSource(DataLayer.Consultas.ORDENES_SEGUN_PERIODO_PRODUCTOS(dpInicio.Text, dpFinal.Text));
                crvProducto.ReportSource = rdProductos;

            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
