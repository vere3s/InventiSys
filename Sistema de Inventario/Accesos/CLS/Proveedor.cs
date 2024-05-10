using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesos.CLS
{
    using System;
    using System.Text;
    using DataLayer; // You may need to adjust the namespace according to your project structure.

    namespace Accesos.CLS
    {
        internal class Proveedores
        {
            Int32 _IDProveedor;
            string _Nombre;
            string _Telefono;
            string _Email;

            public int IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
            public string Nombre { get => _Nombre; set => _Nombre = value; }
            public string Telefono { get => _Telefono; set => _Telefono = value; }
            public string Email { get => _Email; set => _Email = value; }

            public Boolean Insertar()
            {
                Boolean Resultado = false;
                DBOperacion Operacion = new DBOperacion();
                StringBuilder Sentencia = new StringBuilder();
                Sentencia.Append("INSERT INTO proveedores(Nombre, Telefono, Email) VALUES(");
                Sentencia.Append("'" + Nombre + "','" + Telefono + "','" + Email + "');");
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
                Sentencia.Append("UPDATE proveedores SET ");
                Sentencia.Append("Nombre = '" + _Nombre + "'," +
                                 "Telefono = '" + _Telefono + "'," +
                                 "Email = '" + _Email + "'");
                Sentencia.Append("WHERE IDProveedor = " + _IDProveedor + "; ");
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
                Sentencia.Append("DELETE FROM proveedores ");
                Sentencia.Append("WHERE IDProveedor = " + _IDProveedor + ";");
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

}
