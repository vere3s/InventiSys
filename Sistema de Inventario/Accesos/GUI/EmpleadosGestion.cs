using System;
using System.Windows.Forms;
using Accesos.CLS;
using DataLayer;

namespace Accesos.GUI
{
    public partial class EmpleadosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();

        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = Consultas.Empleados();
                lbRegistros.Text = _DATOS.Count.ToString();
                FiltrarLocalmente();
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        public EmpleadosGestion()
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
                    _DATOS.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
                dgvEmpleados.AutoGenerateColumns = false;
                dgvEmpleados.DataSource = _DATOS;
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadosEdicion f = new EmpleadosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EmpleadosEdicion oEmpleado = new EmpleadosEdicion();
                    oEmpleado.tbIdEmpleado.Text = dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString();
                    oEmpleado.tbNombre.Text = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
                    oEmpleado.tbCargo.Text = dgvEmpleados.CurrentRow.Cells["Cargo"].Value.ToString();
                    oEmpleado.tbTelefono.Text = dgvEmpleados.CurrentRow.Cells["Telefono"].Value.ToString();
                    oEmpleado.tbEmail.Text = dgvEmpleados.CurrentRow.Cells["Email"].Value.ToString();

                    oEmpleado.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Empleados oEmpleado = new Empleados();
                    oEmpleado.IDEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString());
                    if (oEmpleado.Eliminar())
                    {
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    {
                        MessageBox.Show("El registro no fue eliminado");
                    }
                    Cargar();
                }
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void EmpleadosGestion_Load_1(object sender, EventArgs e)
        {

        }
    }
}
