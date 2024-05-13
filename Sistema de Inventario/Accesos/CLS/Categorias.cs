using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Accesos.CLS
{
    internal class Categorias
    {
        Int32 _IDCategoria;
        string _Nombre;
        Int32 _EsIngrendiente;

        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int EsIngrendiente { get => _EsIngrendiente; set => _EsIngrendiente = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO categorias(Nombre, EsIngrendiente) VALUES(");
            Sentencia.Append("'" + Nombre + "','" + EsIngrendiente + "');");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("UPDATE categorias SET ");
            Sentencia.Append("Nombre = '" + _Nombre + "'," +
                             "EsIngrendiente = '" + _EsIngrendiente + "'");
            Sentencia.Append("WHERE IDCategoria = " + _IDCategoria + "; ");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }

        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DBOperacion Operacion = new DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("DELETE FROM categorias ");
            Sentencia.Append("WHERE IDCategoria = " + _IDCategoria + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
    }
}
