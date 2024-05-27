using Accesos.CLS;
using DataLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class UsuariosEdicion : Form
    {
        SesionManager.Sesion oSesion = SesionManager.Sesion.ObtenerInstancia();
        private Boolean _RegistroExitoso = false;
        public bool RegistroExitoso { get => _RegistroExitoso; private set => _RegistroExitoso = value;} // Propiedad pública 
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbUsuario.Text.Trim().Length == 0 )
                {
                    Notificador.SetError(tbUsuario, "Este campo no puede estar vacio");
                    valido = false;
                }
                if (tbContraseña.Text.Trim().Length == 0)
                { 
                    Notificador.SetError(tbContraseña, "Este campo no puede estar vacio");
                    valido = false;
                }
                if (CLS.Usuarios.UsuarioExiste(tbUsuario.Text))
                {
                    MessageBox.Show("El usuario ya existe. Por favor, elija otro nombre de usuario.");
                    valido = false;
                }
            }
            catch (Exception)
            {

                valido = false;
            }
            return valido;
        }
        public UsuariosEdicion()
        {

            InitializeComponent();
            Cargar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    CLS.Usuarios oUsuario = new CLS.Usuarios();
                    // SINCRONIZAMOS EL OBJETO CON LA GUI
                    try
                    {
                        oUsuario.IDUsuario = Convert.ToInt32(tbIDUsuario.Text);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("No se puedo convertir ");
                        oUsuario.IDUsuario = 0;
                    }

                    oUsuario.Usuario = tbUsuario.Text;
                    oUsuario.Contraseña = tbContraseña.Text;
                    oUsuario.IDEmpleado = Convert.ToInt32(cbIDEmpleado.SelectedValue);
                    oUsuario.IDRol = Convert.ToInt32(cbIDRol.SelectedValue);
                    //PROCEDER
                    if (tbIDUsuario.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oUsuario.Insertar())
                        {
                            MessageBox.Show("Resgistro realizado con éxito");
                            _RegistroExitoso = true;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el Usuario");
                            _RegistroExitoso = false;
                        }
                    }
                    else
                    {
                        // ACTUALIZAR NUEVO REGISTRO
                        if (oUsuario.Actualizar())
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Cargar()
        {

            cbIDEmpleado.DataSource = Consultas.Empleados();
            cbIDEmpleado.DisplayMember = "Nombre";
            cbIDEmpleado.ValueMember = "idEmpleado";
            cbIDRol.DataSource = Consultas.ROLES();
            cbIDRol.DisplayMember = "Rol";
            cbIDRol.ValueMember = "IDRol";
        }
    }
}
