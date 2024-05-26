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
            Cronometro.Start();
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
                // Mostrar un mensaje de confirmación
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Crear una instancia del formulario de edición de empleados
                    EmpleadosEdicion oEmpleado = new EmpleadosEdicion();

                    // Llenar los campos del formulario con los valores de la fila seleccionada en el DataGridView
                    oEmpleado.tbIdEmpleado.Text = dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString();
                    oEmpleado.tbNombre.Text = dgvEmpleados.CurrentRow.Cells["Nombre"].Value.ToString();
                    oEmpleado.tbCargo.Text = dgvEmpleados.CurrentRow.Cells["Cargo"].Value.ToString();
                    oEmpleado.tbTelefono.Text = dgvEmpleados.CurrentRow.Cells["Telefono"].Value.ToString();
                    oEmpleado.tbEmail.Text = dgvEmpleados.CurrentRow.Cells["Email"].Value.ToString();

                    // Mostrar el formulario de edición de empleados como un diálogo modal
                    oEmpleado.ShowDialog();

                    // Recargar los datos después de cerrar el formulario de edición
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

        private void tbFiltro_TextChanged1(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void EmpleadosGestion_Load_1(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            Cronometro.Stop(); // Detener el timer mientras carga
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex.Message);
            }
            finally
            {
                Cronometro.Start(); // Reiniciar el timer después de cargar
            }
        }
    }
}