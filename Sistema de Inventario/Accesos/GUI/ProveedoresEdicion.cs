using System;
using System.Windows.Forms;
using Accesos.CLS;
using Accesos.CLS.Accesos.CLS;

namespace Accesos.GUI
{
    public partial class ProveedoresEdicion : Form
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
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        public ProveedoresEdicion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // Create an object from the entity class
                    Proveedores oProveedor = new Proveedores();
                    // Sync the object with the GUI
                    try
                    {
                        oProveedor.IDProveedor = Convert.ToInt32(tbIDProveedor.Text);
                    }
                    catch (Exception)
                    {
                        oProveedor.IDProveedor = 0;
                    }

                    oProveedor.Nombre = tbNombre.Text;
                    oProveedor.Telefono = tbTelefono.Text;
                    oProveedor.Email = tbEmail.Text;

                    // Proceed to save or update the record
                    if (tbIDProveedor.Text.Trim().Length == 0)
                    {
                        // Save a new record
                        if (oProveedor.Insertar())
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
                        // Update an existing record
                        if (oProveedor.Actualizar())
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
                // Handle exception appropriately
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProveedoresEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
