using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Accesos.CLS
{
    public class Usuarios
    {
        Int32 _IDUsuario;
        string _Usuario;
        string _Contraseña;
        Int32 _IDEmpleado;
        Int32 _IDRol;

        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public int IDRol { get => _IDRol; set => _IDRol = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("INSERT INTO usuarios(Usuario, Contraseña, IDEmpleado, IDRol) VALUES(");
            Sentencia.Append("'" + Usuario + "',md5('" + Usuarios.ConvertirContraseña(Contraseña) + "'),'" + IDEmpleado + "','" + IDRol + "');");
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
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("UPDATE usuarios SET ");
            Sentencia.Append("Usuario = '" + _Usuario + "'," +
                             "Contraseña = '" + Usuarios.ConvertirContraseña(_Contraseña) + "'," +
                             "IDEmpleado = '" + _IDEmpleado + "'," +
                             "IDRol = '" + _IDRol + "'");
            Sentencia.Append("WHERE IDUsuario = " + _IDUsuario + "; ");
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
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion(); // Agregar referencias= Referencias-Agregar referencia
            StringBuilder Sentencia = new StringBuilder(); // Objeto para construir cadenas complejas
            Sentencia.Append("DELETE FROM usuarios ");
            Sentencia.Append("WHERE IDUsuario = " + _IDUsuario + ";");
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
        public static string ConvertirContraseña(string cContraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] ConvertirBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cContraseña));

                StringBuilder convertirCadena = new StringBuilder();
                for (int i = 0; i < ConvertirBytes.Length; i++)
                {
                    convertirCadena.Append(ConvertirBytes[i].ToString("x2"));
                }
                return convertirCadena.ToString();
            }
        }
    }
}
