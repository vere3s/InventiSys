using System;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class RolesEdicion : Form
    {
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbRol.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbRol, "El nombre del rol no puede estar vacío");
                    valido = false;
                }
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        public RolesEdicion()
        {
            InitializeComponent();
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // Create an object based on the entity class
                    CLS.Roles oRol = new CLS.Roles();

                    // Sync the object with the GUI
                    try
                    {
                        oRol.IDRol = Convert.ToInt32(tbIDRol.Text);
                    }
                    catch (Exception)
                    {
                        oRol.IDRol = 0;
                    }

                    oRol.Rol = tbRol.Text;

                    // Proceed
                    if (tbIDRol.Text.Trim().Length == 0)
                    {
                        // Insert new record
                        if (oRol.Insertar())
                        {
                            MessageBox.Show("Rol guardado correctamente");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El rol no pudo ser guardado");
                        }
                    }
                    else
                    {
                        // Update existing record
                        if (oRol.Actualizar())
                        {
                            MessageBox.Show("Rol actualizado correctamente");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El rol no pudo ser actualizado");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

   

    

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
