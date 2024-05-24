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

        public static DataTable ProductosPocoStock()
        {
            DataTable Resultado = new DataTable();
            String Consulta = $@"SELECT Nombre, Cantidad
FROM gestionrestaurantesdb.productos
WHERE Cantidad < 15 and esPlatillo = 0;
";
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
        public static DataTable ProductosNoContables()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT IDProducto, Nombre, Precio, CostoUnitario, EsPlatillo, IDCategoria, Cantidad
FROM gestionrestaurantesdb.productos
WHERE EsPlatillo = 0;

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
                pv.FechaPedido DESC; ";
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
                 c.Nombre AS NombreC
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
                ps.Nombre,
                pc.FechaPedido,
                pc.Estado,
                pc.Comentarios,
            ps.Nombre,
                SUM(dpv.Cantidad * dpv.Precio) AS 'Total',
                CASE 
                    WHEN c.IDCompras IS NOT NULL THEN 'Pagado'
                    ELSE 'No Pagado'
                END AS 'EstadoPago'
            FROM
                pedidocompras pc
                LEFT JOIN detallepedidoCompras dpv ON pc.IDPedido = dpv.IDPedido
                LEFT JOIN Compras c ON pc.IDPedido = c.PedidoCompras_IDPedido
                LEFT JOIN Proveedores ps on pc.IDProveedor = ps.IDProveedor
            GROUP BY
                pc.IDPedido,
                pc.IDProveedor,
                pc.FechaPedido,
                pc.Estado,
                pc.Comentarios,
			    c.IDCompras
            ORDER BY
                pc.FechaPedido DESC;";
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

        public static DataTable Permisos()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT 
                p.IDPermiso, 
                p.IDRol, 
                p.IDOpcion,  
                r.Rol AS Rol,
                o.Opcion AS Opcion
            FROM 
                permisos p
                INNER JOIN roles r ON p.IDRol = r.IDRol
                INNER JOIN opciones o ON p.IDOpcion = o.IDOpcion
            ORDER BY 
                p.IDPermiso ASC;";
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

        public static DataTable OPCIONES()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT * FROM Opciones ORDER BY Opcion ASC;";
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

        public static DataTable INVENTARIOPRODUCTOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
                p.IDProducto, 
                p.Nombre,
                p.Precio, 
                p.CostoUnitario,
                p.IDCategoria, 
                cs.FechaCompra,
                c.Nombre AS NombreC,
	            (p.Cantidad* p.Precio) as TotalPrecio,
                p.Cantidad as Existencia
            FROM
                productos p
                left join detallepedidocompras dpc on dpc.IDProducto = p.IDProducto
                left join compras cs on cs.PedidoCompras_IDPedido = dpc.IDPedido

                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            Where
                c.EsIngrendiente = 0
            ORDER BY
                p.Nombre ASC;";
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
        public static DataTable INVENTARIOINGREDIENTES()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                cs.FechaCompra,
                c.Nombre AS NombreC,
	            (p.Cantidad* p.CostoUnitario) as 'Total costo',
                p.Cantidad as Existencia
            FROM
                productos p
                left join detallepedidocompras dpc on dpc.IDProducto = p.IDProducto
                left join compras cs on cs.PedidoCompras_IDPedido = dpc.IDPedido
                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            Where 
             c.EsIngrendiente = 1
            ORDER BY
                p.Nombre ASC;";
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

        public static DataTable DetallePedidoCompras(int id)
        {
            DataTable Resultado = new DataTable();
            String Consulta = $@"SELECT 
             
       
                p.IDProducto,
                p.Nombre AS Producto,
                dpv.Cantidad,
                dpv.Precio as CostoUnitario,
                (dpv.Cantidad * dpv.Precio) AS Importe
            FROM 
                detallepedidoCompras dpv
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
    }

}
