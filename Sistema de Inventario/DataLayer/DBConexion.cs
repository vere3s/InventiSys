using System;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();
        private string _connectionString = "Server=192.168.131.21;Port=3306;Database=gestionrestaurantesdb;Uid=sistema-user;Pwd=Sistema-user;SSLMode=None";

        public DBConexion()
        {
            LoadConnectionStringFromXml();
        }

        protected Boolean Conectar()
        {
            Boolean Resultado = false;
            try
            {
                _CONEXION.ConnectionString = _connectionString;
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
            }
        }

        public string GetCurrentIpAddress()
        {
            var builder = new MySqlConnectionStringBuilder(_connectionString);
            return builder.Server;
        }

        public void UpdateIpAddress(string newIpAddress)
        {
            if (IsValidIp(newIpAddress))
            {
                var builder = new MySqlConnectionStringBuilder(_connectionString);
                builder.Server = newIpAddress;
                _connectionString = builder.ConnectionString;
                SaveConnectionStringToXml();
            }
            else
            {
                Console.WriteLine("Invalid IP address format.");
            }
        }

        private void LoadConnectionStringFromXml()
        {
            if (File.Exists("DBConfig.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("DBConfig.xml");
                XmlNode node = doc.SelectSingleNode("/Configuration/ConnectionString");
                if (node != null)
                {
                    _connectionString = node.InnerText;
                }
            }
        }

        private void SaveConnectionStringToXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("Configuration");
            XmlNode connectionStringNode = doc.CreateElement("ConnectionString");
            connectionStringNode.InnerText = _connectionString;
            root.AppendChild(connectionStringNode);
            doc.AppendChild(root);
            doc.Save("DBConfig.xml");
        }

        private bool IsValidIp(string ip)
        {
            // Simple IP address validation
            System.Net.IPAddress ipAddress;
            return System.Net.IPAddress.TryParse(ip, out ipAddress);
        }
    }
}
