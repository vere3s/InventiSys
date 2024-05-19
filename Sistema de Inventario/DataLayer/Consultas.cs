using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class Consultas
    {
         public static DataTable PedidosCompras(int id)
        {
            DataTable Resultado = new DataTable();
            String Consulta = $@"SELECT *
            FROM 
                pedidocompras dpv
     
            WHERE 
                dpv.IDPedido = '{id}';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Resultado;
        }
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
        public static DataTable PedidosVentas()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
    DISTINCT pv.IDPedido,
    pv.Cliente,
    pv.FechaPedido,
    pv.Estado,
    pv.Comentarios,
    SUM(dpv.Cantidad * dpv.Precio) AS 'Total',
    CASE 
        WHEN v.IDVentas IS NOT NULL THEN 'Pagado'
        ELSE 'No Pagado'
    END AS 'EstadoPago'
FROM
    pedidoventas pv
    LEFT JOIN detallepedidoventas dpv ON pv.IDPedido = dpv.IDPedido
    LEFT JOIN ventas v ON pv.IDPedido = v.IDPedido
GROUP BY
    pv.IDPedido,
    pv.Cliente,
    pv.FechaPedido,
    pv.Estado,
    pv.Comentarios,
    v.IDVentas
ORDER BY
    pv.FechaPedido DESC;
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

        public static DataTable ROLES()
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
        public static DataTable PRODUCTOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
    p.IDProducto, 
    p.Nombre,
    p.Precio, 
    p.CostoUnitario,
    p.EsPlatillo, 
    p.IDCategoria, 
   
    p.Cantidad,
     c.nombre AS Categoria
FROM
    productos p
    INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
ORDER BY
    p.Nombre ASC; ";
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
            String Consulta = $@"SELECT 
             
       
                p.IDProducto,
                p.Nombre AS Producto,
                dpv.Cantidad,
                dpv.Precio,
                (dpv.Cantidad * dpv.Precio) AS Importe
            FROM 
                detallepedidoventas dpv
            INNER JOIN 
                productos p ON dpv.IDProducto = p.IDProducto
            WHERE 
                dpv.IDPedido = '{id}';";
            DBOperacion operacion = new DBOperacion();
            try
            {
                Resultado = operacion.Consultar(Consulta);
                Console.WriteLine("el id es" + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Resultado;
        }

        public static object PedidosCompras()
        {
  
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
    DISTINCT pc.IDPedido,
    pc.IDProveedor,
    pc.FechaPedido,
    pc.Estado,
    pc.Comentarios,
ps.Nombre,
    SUM(dpv.Cantidad * dpv.Precio) AS 'Total',
    CASE 
        WHEN v.IDVentas IS NOT NULL THEN 'Pagado'
        ELSE 'No Pagado'
    END AS 'EstadoPago'
FROM
    pedidocompras pc
    LEFT JOIN detallepedidoCompras dpv ON pc.IDPedido = dpv.IDPedido
    LEFT JOIN ventas v ON pc.IDPedido = v.IDPedido
    LEFT JOIN Proveedores ps on pc.IDProveedor = ps.IDProveedor
GROUP BY
    pv.IDPedido,
    pv.IDProveedor,
    pv.FechaPedido,
    pv.Estado,
    pv.Comentarios,
    v.IDVentas
ORDER BY
    pv.FechaPedido DESC;
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
    }

}
