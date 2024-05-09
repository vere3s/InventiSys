using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Consultas
    {
        public static DataTable USUARIOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT IDUsuario, Usuario, Contraseña, IDEmpleado, IDRol FROM usuarios ORDER BY Usuario ASC;";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
            }
            catch (Exception)
            {

            }
            return Resultado;
        }
    }
}
