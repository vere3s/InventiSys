using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Accesos.GUI
{
    public partial class Inventario : Form
    {
        BindingSource _DATOS = new BindingSource();

        // actualizar 
        public ProductosGestion _productosGestion;

        private Boolean Validar()
        {
            Boolean valido = true;
          
            return valido;
        }
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.INVENTARIOPRODUCTOS();
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
                    _DATOS.Filter = "Nombre like '%" + tbFiltro.Text + "%'";
                }
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inventario()
        {
            InitializeComponent();
          
        }
        public void productosGestion(ProductosGestion productosGestion)
        {
            _productosGestion = productosGestion;

            // Suscribirse al evento DataChanged del formulario principal
            _productosGestion.DataChanged += OnDataChanged;
        }
        private void OnDataChanged(object sender, EventArgs e)
        {
            // Recargar los datos en el formulario dependiente
            Cargar();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Desuscribirse del evento para evitar referencias no válidas
            if (_productosGestion != null)
            {
                _productosGestion.DataChanged -= OnDataChanged;
            }
        }


        private void Inventario_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void ExportDataGridViewToPDF(DataGridView dgv, string filePath)
        {
            try
            {
                // Crear un nuevo documento PDF
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Crear una tabla con el número de columnas igual al número de columnas del DataGridView
                PdfPTable pdfTable = new PdfPTable(dgv.ColumnCount);
                pdfTable.WidthPercentage = 100;

                // Agregar encabezados de columna
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    pdfTable.AddCell(cell);
                }

                // Agregar las filas de datos del DataGridView a la tabla PDF
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow) // Ignorar la fila nueva
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                        }
                    }
                }

                // Agregar la tabla al documento
                document.Add(pdfTable);

                // Cerrar el documento
                document.Close();

                MessageBox.Show("PDF exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvertirPDF_Click(object sender, EventArgs e)
        {
            // Selecciona una ruta para guardar el archivo PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF file|*.pdf";
            saveFileDialog.Title = "Guardar como PDF";
            saveFileDialog.FileName = "Inventario.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToPDF(dgvInventario, saveFileDialog.FileName);
            }
        }
    }
}
