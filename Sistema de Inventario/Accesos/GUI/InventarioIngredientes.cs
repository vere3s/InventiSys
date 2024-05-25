using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Accesos.GUI
{
    public partial class InventarioIngredientes : Form
    {
        BindingSource _DATOS = new BindingSource();
        public void Cargar()
        {
            try
            {
                _DATOS.DataSource = DataLayer.Consultas.INVENTARIOINGREDIENTES();
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
                dgvIngredientes.AutoGenerateColumns = false;
                dgvIngredientes.DataSource = _DATOS;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public InventarioIngredientes()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        }

        private void InventarioIngredientes_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
        private void ExportarDataGridViewPDF(DataGridView dgv, string filePath)
        {
            try
            {
                // Crear un nuevo documento PDF
                Document documento = new Document(PageSize.A4, 0, 0, 0, 0);
                PdfWriter escribir = PdfWriter.GetInstance(documento, new FileStream(filePath, FileMode.Create));
                documento.Open();

                // Crear una tabla con el número de columnas igual al número de columnas del DataGridView
                PdfPTable pdfTable = new PdfPTable(dgv.ColumnCount);
                pdfTable.WidthPercentage = 100;

                // Agregar encabezados de columna
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(column.HeaderText));
                    celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                    pdfTable.AddCell(celda);
                }

                // Agregar las filas de datos del DataGridView a la tabla PDF
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow) // Ignorar la fila nueva
                    {
                        foreach (DataGridViewCell celda in row.Cells)
                        {
                            pdfTable.AddCell(celda.Value?.ToString() ?? string.Empty);
                        }
                    }
                }

                // Agregar la tabla al documento
                documento.Add(pdfTable);

                // Cerrar el documento
                documento.Close();

                MessageBox.Show("¡PDF exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para exportar DataGridView a Excel
        private void ExportarDataGridViewExcel(DataGridView dgv, string filePath)
        {
            try
            {
                // Crear un nuevo paquete de Excel
                using (var paquete = new ExcelPackage())
                {
                    // Agregar una nueva hoja de trabajo
                    ExcelWorksheet hoja = paquete.Workbook.Worksheets.Add("InventarioIngredientes");

                    // Agregar encabezados de columna
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        hoja.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                    }

                    // Agregar filas de datos
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            hoja.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                        }
                    }

                    // Guardar el archivo
                    FileInfo fi = new FileInfo(filePath);
                    paquete.SaveAs(fi);

                    MessageBox.Show("Excel exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConvertirPDF_Click(object sender, EventArgs e)
        {
            // Selecciona una ruta para guardar el archivo PDF
            SaveFileDialog guardarArchivo = new SaveFileDialog();
            guardarArchivo.Filter = "PDF file|*.pdf";
            guardarArchivo.Title = "Guardar como PDF";
            guardarArchivo.FileName = "InventarioIngredientes.pdf";

            if (guardarArchivo.ShowDialog() == DialogResult.OK)
            {
                ExportarDataGridViewPDF(dgvIngredientes, guardarArchivo.FileName);
            }
        }

        private void btnConvertirExcel_Click(object sender, EventArgs e)
        {
            // Selecciona una ruta para guardar el archivo Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file|*.xlsx";
            saveFileDialog.Title = "Guardar como Excel";
            saveFileDialog.FileName = "InventarioIngredientes.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportarDataGridViewExcel(dgvIngredientes, saveFileDialog.FileName);
            }
        }
    }
}
