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
    public partial class RolesEdicion : Form
    {
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbRol.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbRol, "Este campo no puede estar vacio");
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
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    CLS.Roles oRol = new CLS.Roles();
                    // SINCRONIZAMOS EL OBJETO CON LA GUI
                    try
                    {
                        oRol.IDRol = Convert.ToInt32(tbIDRol.Text);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("No se puedo convertir ");
                        oRol.IDRol = 0;
                    }

                    oRol.Rol = tbRol.Text;
                    //PROCEDER
                    if (tbIDRol.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oRol.Insertar())
                        {
                            MessageBox.Show("Resgistro guardado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El resgistro no pudo ser almacenado");
                        }
                    }
                    else
                    {
                        // ACTUALIZAR NUEVO REGISTRO
                        if (oRol.Actualizar())
                        {
                            MessageBox.Show("Resgistro actualizado");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("El resgistro no pudo ser actualizado");
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
