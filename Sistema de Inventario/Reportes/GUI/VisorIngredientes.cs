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
    public partial class VisorIngredientes : Form
    {
        public VisorIngredientes()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                REP.Ingredientes rOrdenes = new REP.Ingredientes();
                rOrdenes.SetDataSource(DataLayer.Consultas.SEGUN_PERIODO_INGREDIENTES(dpInicio.Text, dpFinal.Text));
                crvVisorIngredientes.ReportSource = rOrdenes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
