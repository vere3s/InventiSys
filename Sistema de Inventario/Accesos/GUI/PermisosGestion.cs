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
    public partial class PermisosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.Permisos();
                lbRegistros.Text = _DATOS.Count.ToString();
                FiltrarLocalmente();
            }
            catch (Exception)
            {
            }
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
                    _DATOS.Filter = "IDRol like '%" + tbFiltro.Text + "%'";
                }
                dgvPermisos.AutoGenerateColumns = false;
                dgvPermisos.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PermisosGestion()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Permisos oPermiso = new CLS.Permisos();
                    oPermiso.IDPermiso = Convert.ToInt32(dgvPermisos.CurrentRow.Cells["IDPermiso"].Value.ToString());
                    if (oPermiso.Eliminar())
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PermisosEdicion f = new PermisosEdicion();
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

            PermisosEdicion f = new PermisosEdicion();
            int a = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["IDOpcion"].Value);
            f.tbIDPermiso.Text = dgvPermisos.SelectedRows[0].Cells["IDPermiso"].Value.ToString();
            f.cbIDRol.SelectedValue = dgvPermisos.SelectedRows[0].Cells["IDRol"].Value.ToString();
            for (int i = 0; i < f.clbOpciones.Items.Count; i++)
            {
                var item = f.clbOpciones.Items[i] as ListItem;
                if (item != null && item.Value == a.ToString())
                {
                    f.clbOpciones.SetItemChecked(i, true);

                }

            }

            f.ShowDialog();

            Cargar();
        }

        private void PermisosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
