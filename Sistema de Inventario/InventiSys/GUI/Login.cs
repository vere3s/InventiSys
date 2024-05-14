using Modelos;
using SesionManager;
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
            string query = @"
            SELECT 
                u.IDUsuario, u.Usuario, 
                e.IDEmpleado, e.Nombre, e.Cargo, e.Telefono, e.Email
            FROM 
                usuarios u
            INNER JOIN 
                empleados e ON u.IDEmpleado = e.IDEmpleado
            WHERE 
                u.Usuario = '" + tbUsuario.Text + @"' AND 
                u.Contraseña = '" + Accesos.CLS.Usuarios.ComputeSha256Hash(tbContraseña.Text) + @"';";
            dt = oOperacion.Consultar(query);
            if (dt.Rows.Count == 1)
            {
                SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
                oSesion.Usuario = tbUsuario.Text;
                DataRow row = dt.Rows[0];
                oSesion.empleado = new Empleado()
                {
                    IDEmpleado = Convert.ToInt32(row["IDEmpleado"]),
                    Nombre = row["Nombre"].ToString(),
                    Cargo = row["Cargo"].ToString(),
                    Telefono = row["Telefono"].ToString(),
                    Email = row["Email"].ToString()
                };
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
