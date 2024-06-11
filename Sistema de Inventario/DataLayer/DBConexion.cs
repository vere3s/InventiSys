using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Xml;

namespace DataLayer
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();
        private string _rutaArchivoConfiguracion = "config.xml"; // Cambia esto seg�n la ruta de tu archivo XML de configuraci�n

        protected Boolean Conectar()
        {
            Boolean Resultado = false;
            try
            {
                Configuracion config = new Configuracion();
                config.CargarDesdeXML(_rutaArchivoConfiguracion);

                _CONEXION.ConnectionString = $"Server={config.IP};Port=3306;Database=GestionRestauranteDB;Uid=sistema-user;Pwd=Sistema-user; SSLMode=None";
                _CONEXION.Open();
                Resultado = true;
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX.Message);
                Resultado = false;
            }
            return Resultado;
        }

        protected void Desconectar()
        {
            try
            {
                if (_CONEXION.State == System.Data.ConnectionState.Open)
                {
                    _CONEXION.Close();
                }
            }
            catch (Exception)
            {
                // Manejar la excepci�n de cierre de conexi�n
            }
        }

        public class Configuracion
        {
            public string IP { get; set; }

            // M�todo para cargar la configuraci�n desde un archivo XML
            public void CargarDesdeXML(string rutaArchivo)
            {
                try
                {
                    // Cargar el documento XML
                    XmlDocument doc = new XmlDocument();
                    doc.Load(rutaArchivo);

                    // Obtener el nodo de configuraci�n
                    XmlNode nodoConfiguracion = doc.SelectSingleNode("/Configuracion");

                    // Leer la direcci�n IP del nodo
                    IP = nodoConfiguracion.SelectSingleNode("IP").InnerText;
                }
                catch (Exception ex)
                {
                    // Manejar la excepci�n si ocurre alg�n problema al cargar el archivo XML
                    Console.WriteLine("Error al cargar la configuraci�n desde el archivo XML: " + ex.Message);
                }
            }
        }
        }
}
