﻿using System;
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
    public partial class CategoriasEdicion : Form
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
        public CategoriasEdicion()
        {
            InitializeComponent();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    // CREAR UN OBJETO A PARTIR DE LA CLASE ENTIDAD
                    CLS.Categorias oCategoria= new CLS.Categorias();
                    // SINCRONIZAMOS EL OBJETO CON LA GUI
                    try
                    {
                        oCategoria.IDCategoria = Convert.ToInt32(tbIDCategoria.Text);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine("No se puedo convertir ");
                        oCategoria.IDCategoria = 0;
                    }

                    oCategoria.Nombre = tbNombre.Text;

                    oCategoria.EsIngrendiente = cbIngrediente.Checked ? 1 : 0;

                    //PROCEDER
                    if (tbIDCategoria.Text.Trim().Length == 0)
                    {
                        //GUARDAR NUEVO REGISTRO
                        if (oCategoria.Insertar())
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
                        if (oCategoria.Actualizar())
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
    }
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
