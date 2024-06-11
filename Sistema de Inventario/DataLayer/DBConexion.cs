using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Xml;

namespace DataLayer
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();
        private string _rutaArchivoConfiguracion = "config.xml"; // Cambia esto según la ruta de tu archivo XML de configuración

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
                // Manejar la excepción de cierre de conexión
            }
        }

        public class Configuracion
        {
            public string IP { get; set; }

            // Método para cargar la configuración desde un archivo XML
            public void CargarDesdeXML(string rutaArchivo)
            {
                try
                {
                    // Cargar el documento XML
                    XmlDocument doc = new XmlDocument();
                    doc.Load(rutaArchivo);

                    // Obtener el nodo de configuración
                    XmlNode nodoConfiguracion = doc.SelectSingleNode("/Configuracion");

                    // Leer la dirección IP del nodo
                    IP = nodoConfiguracion.SelectSingleNode("IP").InnerText;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción si ocurre algún problema al cargar el archivo XML
                    Console.WriteLine("Error al cargar la configuración desde el archivo XML: " + ex.Message);
                }
            }
        }
        }
}
