using System;
using System.Text;

namespace Accesos.CLS
{
    internal class Roles
    {
        Int32 _IDRol;
        string _Rol;

        public int IDRol { get => _IDRol; set => _IDRol = value; }
        public string Rol { get => _Rol; set => _Rol = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("INSERT INTO roles(Rol) VALUES('");
            Sentencia.Append(Rol + "');");
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
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("UPDATE roles SET ");
            Sentencia.Append("Rol = '" + _Rol + "'");
            Sentencia.Append(" WHERE IDRol = " + _IDRol + "; ");
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
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder();
            Sentencia.Append("DELETE FROM roles ");
            Sentencia.Append("WHERE IDRol = " + _IDRol + ";");
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
