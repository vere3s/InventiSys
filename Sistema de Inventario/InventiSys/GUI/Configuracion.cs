using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventiSys.GUI
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            db.UpdateIpAddress(this.textBox1.Text);
            this.Close();
        }
        DBOperacion db = new DBOperacion();
        private void Configuracion_Load(object sender, EventArgs e)
        {
            textBox1.Text = db.GetCurrentIpAddress();
            
        }
    }
}
