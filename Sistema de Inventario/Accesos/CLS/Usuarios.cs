using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
<<<<<<< Updated upstream
            Sentencia.Append("'" + Usuario + "',md5('" + Usuarios.ConvertirContraseña(Contraseña) + "'),'" + IDEmpleado + "','" + IDRol + "');");
=======
            Sentencia.Append("'" + Usuario + "', ");
            Sentencia.Append("'" + ComputeSha256Hash(Contraseña) + "', ");
            Sentencia.Append("'" + IDEmpleado + "', ");
            Sentencia.Append("'" + IDRol + "');");
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            Sentencia.Append("Usuario = '" + _Usuario + "'," +
                             "Contraseña = '" + Usuarios.ConvertirContraseña(_Contraseña) + "'," +
                             "IDEmpleado = '" + _IDEmpleado + "'," +
                             "IDRol = '" + _IDRol + "'");
=======
            Sentencia.Append("Usuario = '" + _Usuario + "', ");
            Sentencia.Append("Contraseña = '" + _Contraseña + "', ");
            Sentencia.Append("IDEmpleado = '" + _IDEmpleado + "', ");
            Sentencia.Append("IDRol = '" + _IDRol + "' ");
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
=======
        public static string ComputeSha256Hash(string cContraseña)
        {
            // Crear un objeto SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash de la cadena de entrada y obtener el arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cContraseña));

                // Convertir el arreglo de bytes a un string StringBuilder (más eficiente)
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                // Devolver el string hexadecimal
                return builder.ToString();
>>>>>>> Stashed changes
            }
        }
    }
}
