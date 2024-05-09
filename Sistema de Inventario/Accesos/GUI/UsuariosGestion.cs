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
    public partial class UsuariosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.USUARIOS();
                FiltrarLocalmente();
            }
            catch (Exception)
            {
            }
        }
        public UsuariosGestion()
        {
            InitializeComponent();
        }
        private void FiltrarLocalmente()
        {
            try
            {
                if (tbFiltro.Text.Trim().Length <= 0)
                {
                    _DATOS.RemoveFilter();
                }
                else
                {
                    _DATOS.Filter = "Usuario like '%" + tbFiltro.Text + "%'";
                }
                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ContarUsuarios()
        {
            try
            {
                DataTable Resultado = DataLayer.Consultas.USUARIOS();
                return Resultado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar: " + ex.Message);
                return 0;
            }
        }
        private void UsuariosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
            lbRegistros.Text = ContarUsuarios().ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuariosEdicion f = new UsuariosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuariosEdicion oUsuario = new UsuariosEdicion();
                    oUsuario.tbIDUsuario.Text = dgvUsuarios.CurrentRow.Cells["IDUsuario"].Value.ToString();
                    oUsuario.tbUsuario.Text = dgvUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
                    oUsuario.tbContraseña.Text = dgvUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                    oUsuario.tbIDEmpleado.Text = dgvUsuarios.CurrentRow.Cells["IDEmpleado"].Value.ToString();
                    oUsuario.tbIDRol.Text = dgvUsuarios.CurrentRow.Cells["IDRol"].Value.ToString();
                    oUsuario.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Usuarios oUsuario = new CLS.Usuarios();
                    oUsuario.IDUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IDUsuario"].Value.ToString());
                    if (oUsuario.Eliminar())
                    {
                        MessageBox.Show("Resgistro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El resgistro no fue eliminado");
                    }
                    Cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
