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
        public static DataTable CATEGORIAS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM Categorias ORDER BY Nombre ASC;";
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
<<<<<<< Updated upstream
        public static DataTable PedidosVentas()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
                pv.IDPedido,
                pv.Cliente,
                pv.FechaPedido,
                pv.Estado,
                pv.Comentarios,
                SUM(dpv.Cantidad * dpv.Precio) AS 'Total'
            FROM
                pedidoventas pv
                LEFT JOIN detallepedidoventas dpv ON pv.IDPedido = dpv.IDPedido
            GROUP BY
                pv.IDPedido,
                pv.Cliente,
                pv.FechaPedido,
                pv.Estado,
                pv.Comentarios
            ORDER BY
                pv.FechaPedido DESC;
            ";
=======
        public static DataTable ROLES()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT IDRol, Rol FROM roles ORDER BY Rol ASC;";
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        public static DataTable PROVEEDORES()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM Proveedores ORDER BY Nombre ASC;";
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
        public static DataTable Empleados()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM Empleados ORDER BY Nombre ASC;";
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

        public static DataTable Roles()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM Roles ORDER BY Rol ASC;";
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

        public static DataTable USUARIOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT 
                u.IDUsuario, 
                u.Usuario, 
                u.Contraseña, 
                u.IDEmpleado, 
                u.IDRol, 
                r.Rol AS Rol,
                e.Nombre AS Empleado
            FROM 
                usuarios u
                INNER JOIN roles r ON u.IDRol = r.IDRol
                INNER JOIN empleados e ON u.IDEmpleado = e.IDEmpleado
            ORDER BY 
                u.Usuario ASC;";
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
        public static DataTable ProductosNoIngredientes()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
                p.IDProducto,
                p.Nombre,
                p.Precio,
                p.Cantidad
            FROM
                productos p
                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            WHERE
                c.EsIngrendiente = 0
                AND (p.Cantidad > 0 OR (p.Cantidad = 0 AND p.EsPlatillo = 1));
            ";
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
        public static DataTable DetallePedidoVentas(int id)
        {
            DataTable Resultado = new DataTable();
            String Consulta = $"SELECT * FROM detallepedidoventas where IDPedido= '{id}';";
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

=======
>>>>>>> Stashed changes
    }

}
