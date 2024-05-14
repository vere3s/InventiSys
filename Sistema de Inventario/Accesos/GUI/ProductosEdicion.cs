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
    public partial class ProductosEdicion : Form
    {
        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (tbNombre.Text.Trim().Length == 0)
                {
                    Notificador.SetError(tbNombre, "Este campo no puede estar vacio");
                    valido = false;
                }
            }
            catch (Exception)
            {

                valido = false;
            }
            return valido;
        }
        public ProductosEdicion()
        {
            InitializeComponent();
            Cargar();
        }
        void Cargar()
        {
            cbIDCategoria.DataSource = Consultas.CATEGORIAS();
            cbIDCategoria.DisplayMember = "Nombre";
            cbIDCategoria.ValueMember = "IdCategoria";



        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    CLS.Productos oProducto = new CLS.Productos();
                    // SINCRONIZAMOS EL OBJETO CON LA GUI
                    try
                    {
                        oProducto.IDProducto = Convert.ToInt32(tbIDProducto.Text);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("No se puedo convertir ");
                        oProducto.IDProducto = 0;
                    }

                    oProducto.Nombre = tbNombre.Text;
                    oProducto.Precio = Convert.ToDouble(tbPrecio.Text);
                    oProducto.CostoUnitario = Convert.ToDouble(tbCostoUnitario.Text);
                    oProducto.IDCategoria = Convert.ToInt32(cbIDCategoria.SelectedValue);
                    oProducto.Cantidad = Convert.ToInt32(tbCantidad.Text);

                    //PROCEDER
                    if (tbIDProducto.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oProducto.Insertar())
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
                        if (oProducto.Actualizar())
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

                throw;
            }

        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductosEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
