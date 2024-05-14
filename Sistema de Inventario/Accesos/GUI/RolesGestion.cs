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
    public partial class RolesGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.ROLES();
                FiltrarLocalmente();
            }
            catch (Exception)
            {
            }
        }
        public RolesGestion()
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
                    _DATOS.Filter = "Rol like '%" + tbFiltro.Text + "%'";
                }
                dgvRoles.AutoGenerateColumns = false;
                dgvRoles.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void RolesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
            lbRegistros.Text = dgvRoles.Rows.Count.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                RolesEdicion f = new RolesEdicion();
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
                    RolesEdicion oUsuario = new RolesEdicion();
                    oUsuario.tbIDRol.Text = dgvRoles.CurrentRow.Cells["IDRol"].Value.ToString();
                    oUsuario.tbRol.Text = dgvRoles.CurrentRow.Cells["Rol"].Value.ToString();
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
                    CLS.Roles oRol = new CLS.Roles();
                    oRol.IDRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells["IDRol"].Value.ToString());
                    if (oRol.Eliminar())
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
