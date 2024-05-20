using Accesos.CLS;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accesos.GUI
{
    public partial class PermisosEdicion : Form
    {
        BindingSource _DATOS = new BindingSource();
        DataTable _DatosOpciones = new DataTable();

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
                    _DATOS.Filter = "opcion like '%" + tbFiltro.Text + "%'";
                }

                clbOpciones.DataSource = _DATOS;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Boolean Validar()
        {
            Boolean valido = true;
            try
            {
                if (cbIDRol.Text.Trim().Length == 0)
                {
                    Notificador.SetError(cbIDRol, "Este campo no puede estar vacio");
                    valido = false;
                }
            }
            catch (Exception)
            {
                valido = false;
            }
            return valido;
        }

        public PermisosEdicion()
        {
            InitializeComponent();
            Cargar();
        }

        void Cargar()
        {
            cbIDRol.DataSource = Consultas.ROLES();
            cbIDRol.DisplayMember = "Rol";
            cbIDRol.ValueMember = "IdRol";

            CargarOpciones();
        }

        private void CargarOpciones()
        {
            var opciones = Consultas.OPCIONES().AsEnumerable()
                .Select(row => new ListItem(row["Opcion"].ToString(), row["IDOpcion"].ToString()))
                .ToList();

            _DATOS.DataSource = opciones;

            clbOpciones.DataSource = _DATOS;
            clbOpciones.DisplayMember = "DisplayName";
            clbOpciones.ValueMember = "Value";
        }

        private void tbFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {



            if (Validar())
            {
                Permisos oPermiso = new Permisos();

                try
                {
                    oPermiso.IDPermiso = Convert.ToInt32(tbIDPermiso.Text);
                }
                catch (Exception)
                {
                    oPermiso.IDPermiso = 0;
                }

                oPermiso.IDRol = Convert.ToInt32(cbIDRol.SelectedValue);
                foreach (ListItem item in clbOpciones.CheckedItems)
                {
                    oPermiso.IDOpcion = Convert.ToInt32(item.Value);
                }


                if (tbIDPermiso.Text.Trim().Length == 0)
                {
                    if (oPermiso.Insertar())
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
                    if (oPermiso.Actualizar())
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

        private void PermisosEdicion_Load(object sender, EventArgs e)
        {

        }

        private void clbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clbOpciones_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < clbOpciones.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        clbOpciones.SetItemChecked(i, false);
                    }
                }
            }
        }
    }

    public class ListItem
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }

        public ListItem(string displayName, string value)
        {
            DisplayName = displayName;
            Value = value;
        }
    }
}
