﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION = new MySqlConnection();

        protected Boolean Conectar()
        {
            Boolean Resultado = false;
            try
            {
                _CONEXION.ConnectionString = "Server=localhost;Port=3306;Database=gestionrestaurantesdb;Uid=sistema-user;Pwd=Sistema-user; SSLMode = None"; //contiene informacion para conectarmnos al servidor de datos
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
    }
}
