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
    public partial class Login : Form
    {
        private Boolean _Autorizado = false;
        public bool Autorizado { get => _Autorizado; set => _Autorizado = value; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            string query = @"SELECT 
            IDUsuario, Usuario, 
            IDEmpleado, IDRol
            FROM usuarios
            where Usuario = '" + tbUsuario.Text + @"'
            and Contraseña = MD5('" + tbContraseña.Text + @"');";
            dt = oOperacion.Consultar(query);
            if (dt.Rows.Count == 1)
            {
                SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
                oSesion.Usuario = tbUsuario.Text;
                _Autorizado = true;
                Close();
            }
            else
            {
                lbMensaje.Text = "USUARIO O CLAVE ERRONEOS.";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
