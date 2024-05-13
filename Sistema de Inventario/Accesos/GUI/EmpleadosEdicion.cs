using System;
using System.Windows.Forms;
using Accesos.CLS;

namespace Accesos.GUI
{
    public partial class EmpleadosEdicion : Form
    {
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbNombre.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbNombre, "Este campo no puede estar vacío");
                    valido = false;
                }
                // Agregar más validaciones si es necesario para otros campos
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        public EmpleadosEdicion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // Crear un objeto de la clase Empleados
                    Empleados oEmpleado = new Empleados();

                    try
                    {
                        oEmpleado.IDEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
                    }
                    catch (Exception)
                    {
                        oEmpleado.IDEmpleado = 0;
                    }

                    oEmpleado.Nombre = tbNombre.Text;
                    oEmpleado.Cargo = tbCargo.Text;
                    oEmpleado.Telefono = tbTelefono.Text;
                    oEmpleado.Email = tbEmail.Text;

                    if (tbIdEmpleado.Text.Trim().Length == 0)
                    {
                        // Guardar un nuevo registro
                        if (oEmpleado.Insertar())
                        {
                            MessageBox.Show("Registro guardado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser almacenado");
                        }
                    }
                    else
                    {
                        // Actualizar un registro existente
                        if (oEmpleado.Actualizar())
                        {
                            MessageBox.Show("Registro actualizado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El registro no pudo ser actualizado");
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Manejar la excepción apropiadamente
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmpleadosEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
