using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBOperacion : DBConexion
    {
        public DataTable Consultar(string pConsulta)
        {
            DataTable Resultado = new DataTable();
            MySqlDataAdapter Adaptador = new MySqlDataAdapter();
            MySqlCommand Comando = new MySqlCommand();
            try
            {
                if (base.Conectar()) //Base para acceder a los miembros de la clase base 
                {
                    Comando.Connection = base._CONEXION;
                    Comando.CommandType = System.Data.CommandType.Text;
                    Comando.CommandText = pConsulta;
                    Adaptador.SelectCommand = Comando;
                    Adaptador.Fill(Resultado);
                    base.Desconectar();
                }
            }
            catch (Exception)
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public Int32 EjecutarSentenciaYObtenerID(String pSentencia)
        {
            Int32 idGenerado = -1;
            MySqlCommand Comando = new MySqlCommand();
            try
            {
                if (base.Conectar())
                {
                    Comando.Connection = base._CONEXION;
                    Comando.CommandType = System.Data.CommandType.Text;
                    Comando.CommandText = pSentencia;

                    // Ejecutar la sentencia
                    Comando.ExecuteNonQuery();

                    // Obtener el ID generado por la última inserción
                    Comando.CommandText = "SELECT LAST_INSERT_ID();";
                    idGenerado = Convert.ToInt32(Comando.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar sentencia: " + ex.Message);
                throw;
            }
            finally
            {
                if (base._CONEXION.State == ConnectionState.Open)
                    base._CONEXION.Close();
            }
            return idGenerado;
        }
        public Int32 EjecutarSentencia(String pSentencia)
        {
            Int32 FilasAfectadas = 0;
            MySqlCommand Comando = new MySqlCommand();
            try
            {
                if (base.Conectar())
                {
                    Comando.Connection = base._CONEXION;
                    Comando.CommandType = System.Data.CommandType.Text;
                    Comando.CommandText = pSentencia;
                    FilasAfectadas = Comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar sentencia: " + ex.Message);
                FilasAfectadas = -1;
            }
            return FilasAfectadas;
        }
    }
}
