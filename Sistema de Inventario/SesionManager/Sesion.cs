﻿using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SesionManager
{
    public class Sesion
    {
        private static Sesion _instance;
        private static readonly object _lock = new object();
        public Empleado empleado;
        String _Usuario;

        public string Usuario
        {
            get => _Usuario;
            set => _Usuario = value;
        }

        public static Sesion ObtenerInstancia()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Sesion();
                    }
                }
            }
            return _instance;
        }
        private Sesion() { }
        public Boolean ValidarPermiso(Int32 pIDOpcion)
        {
            Boolean Resultado = false;
            DataTable Result = new DataTable();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append(@"select a.IDOpcion, c.Opcion from permisos a ");
            Sentencia.Append("INNER JOIN usuarios b on b.IDRol = a.IDRol ");
            Sentencia.Append("inner join opciones c on c.IDOpcion = a.IDOpcion ");
            Sentencia.Append("where b.Usuario = '" + _Usuario + "'");
            Sentencia.Append("AND a.IDOpcion=" + pIDOpcion.ToString() + ";");
            DataLayer.DBOperacion oOperacion = new DataLayer.DBOperacion();
            Result = oOperacion.Consultar(Sentencia.ToString());
            if (Result.Rows.Count > 0)
            {
                Resultado = true;
            }
            if (!Resultado)
            {
                MessageBox.Show("Acceso denegado");
            }

            return Resultado;
        }
    }
}
