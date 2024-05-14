using Accesos.CLS;
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

namespace Accesos.GUI
{
    public partial class RolesGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        public RolesGestion()
        {
            InitializeComponent();
        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        void Cargar()
        {
            _DATOS.DataSource = Consultas.Roles();
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DataSource = _DATOS;
            lbRegistros.Text = _DATOS.Count.ToString();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
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
                    if (dgvRoles.SelectedRows.Count > 0)
                    {

                        RolesEdicion f = new RolesEdicion(); // Pass the idRol to the RolesEdicion form
                        f.tbIDRol.Text = dgvRoles.SelectedRows[0].Cells["IDRol"].Value.ToString();
                        f.tbRol.Text = dgvRoles.SelectedRows[0].Cells["Rol"].Value.ToString();
                        f.ShowDialog();
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un rol para editar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete the selected role
                if (dgvRoles.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idRol = Convert.ToInt32(dgvRoles.SelectedRows[0].Cells["IDRol"].Value);
                        Roles oRol = new Roles();
                        oRol.IDRol = idRol;
                        if (oRol.Eliminar())
                        {
                            MessageBox.Show("Rol eliminado correctamente.");
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el rol.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un rol para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el rol: " + ex.Message);
            }
        }
    } }
