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
    public partial class CategoriaGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        public static DataTable CATEGORIAS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM categorias ORDER BY Nombre ASC;";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.CATEGORIAS();
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
                    _DATOS.Filter = "Categoria like '%" + tbFiltro.Text + "%'";
                }
                dgvCategorias.AutoGenerateColumns = false;
                dgvCategorias.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ContarCategorias()
        {
            try
            {
                DataTable Resultado = DataLayer.Consultas.CATEGORIAS();
                return Resultado.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar: " + ex.Message);
                return 0;
            }
        }
        public CategoriaGestion()
        {
            InitializeComponent();
            Cronometro.Start();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriasEdicion f = new CategoriasEdicion();
                f.ShowDialog();
                Cargar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoriaGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea editar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CategoriasEdicion oCategoria = new CategoriasEdicion();
                    oCategoria.tbIDCategoria.Text = dgvCategorias.CurrentRow.Cells["IDCategoria"].Value.ToString();
                    oCategoria.tbNombre.Text = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();
                    oCategoria.tbEsIngrediente.Text = dgvCategorias.CurrentRow.Cells["EsIngrendiente"].Value.ToString();

                    oCategoria.ShowDialog();
                    Cargar();
                }
            }
            catch (Exception)
            {
                // Handle exception appropriately
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Categorias oCategoria = new CLS.Categorias();
                    oCategoria.IDCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["IDCategoria"].Value.ToString());
                    if (oCategoria.Eliminar())
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

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
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
