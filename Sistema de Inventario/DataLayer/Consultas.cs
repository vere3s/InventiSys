﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
            FROM productos
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
            FROM productos
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
            String Consulta = @"SELECT * FROM categorias ORDER BY Nombre ASC;";
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
        public static DataTable PedidosVentas(string inicio, string final)
        {
            DataTable Resultado = new DataTable();
                        String Consulta = $@"SELECT
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
            WHERE
                CAST(pv.FechaPedido AS DATE) BETWEEN '{inicio}' AND '{final}'
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
            String Consulta = @"SELECT * FROM proveedores ORDER BY Nombre ASC;";
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
            String Consulta = @"SELECT * FROM empleados ORDER BY Nombre ASC;";
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
            String Consulta = @"SELECT * FROM roles ORDER BY Rol ASC;";
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
    c.Nombre AS NombreC,
    CASE
        WHEN p.EsPlatillo = 1 THEN 'Sí'
        ELSE 'No'
    END AS SinStock
FROM
    productos p
    INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
ORDER BY
    p.Nombre ASC;
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
        public static DataTable USUARIOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT 
                u.IDUsuario, 
                u.Usuario, 
                u.Contraseña as Contrasena, 
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
                p.EsPlatillo,
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

        public static DataTable PedidosCompras(string inicio,string final)
        {
            
  
            DataTable Resultado = new DataTable();
            string Consulta = $@"
        SELECT
            pc.IDPedido,
            pc.IDProveedor,
            ps.Nombre AS Proveedor,
            pc.FechaPedido,
            pc.Estado,
            pc.Comentarios,
            SUM(dpv.Cantidad * dpv.Precio) AS Total,
            CASE 
                WHEN c.IDCompras IS NOT NULL THEN 'Pagado'
                ELSE 'No Pagado'
            END AS EstadoPago
        FROM
            pedidocompras pc
            LEFT JOIN detallepedidocompras dpv ON pc.IDPedido = dpv.IDPedido
            LEFT JOIN compras c ON pc.IDPedido = c.IDPedido
            LEFT JOIN proveedores ps ON pc.IDProveedor = ps.IDProveedor
        WHERE
           CAST(pc.FechaPedido AS DATE) BETWEEN '{inicio}' AND '{final}'
        GROUP BY
            pc.IDPedido,
            pc.IDProveedor,
            ps.Nombre,
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
            string Consulta = @"SELECT 
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
            String Consulta = @"SELECT * FROM opciones ORDER BY Opcion ASC;";
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
            String Consulta = @"SELECT DISTINCT
                p.IDProducto, 
                p.Nombre,
                p.Precio, 
                p.CostoUnitario,
                p.IDCategoria, 
                COALESCE(MAX(cs.FechaCompra), 'N/A') AS FechaCompra,
                c.Nombre AS NombreC,
	            (p.Cantidad* p.Precio) as TotalPrecio,
                p.Cantidad as Existencia
            FROM
                productos p
                left join detallepedidocompras dpc on dpc.IDProducto = p.IDProducto
                left join compras cs on cs.IDPedido = dpc.IDPedido

                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            Where
                c.EsIngrendiente = 0
            GROUP BY
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                c.Nombre
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
            String Consulta = @"SELECT DISTINCT
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                COALESCE(MAX(cs.FechaCompra), 'N/A') AS FechaCompra,
                c.Nombre AS NombreC,
                (p.Cantidad * p.CostoUnitario) AS 'Total costo',
                p.Cantidad AS Existencia
            FROM
                productos p
                LEFT JOIN detallepedidocompras dpc ON dpc.IDProducto = p.IDProducto
                LEFT JOIN compras cs ON cs.IDPedido = dpc.IDPedido
                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            WHERE 
                c.EsIngrendiente = 1
            GROUP BY
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                c.Nombre
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
                detallepedidocompras dpv
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
        public static DataTable SEGUN_PERIODO_INGREDIENTES(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT DISTINCT
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                COALESCE(MAX(cs.FechaCompra), 'N/A') AS FechaCompra,
                c.Nombre AS NombreC,
                (p.Cantidad * p.CostoUnitario) AS 'Total costo',
                p.Cantidad AS Existencia
            FROM
                productos p
                LEFT JOIN detallepedidocompras dpc ON dpc.IDProducto = p.IDProducto
                LEFT JOIN compras cs ON cs.IDPedido = dpc.IDPedido
                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            WHERE 
                c.EsIngrendiente = 1
            AND 
	            CAST(cs.FechaCompra AS DATE) between '" + pFechaInicio + "' AND '" + pFechaFinal +@"'
            GROUP BY
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                c.Nombre
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

        public static DataTable SEGUN_PERIODO_PRODUCTOS(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT
                p.IDProducto, 
                p.Nombre,
                p.Precio, 
                p.CostoUnitario, 
                cs.FechaCompra,
			
	            (p.Cantidad* p.Precio) as TotalPrecio,
                p.Cantidad as Existencia
            FROM
                productos p
                left join detallepedidocompras dpc on dpc.IDProducto = p.IDProducto
                left join compras cs on cs.IDPedido = dpc.IDPedido

                INNER JOIN categorias c ON p.IDCategoria = c.IDCategoria
            Where
                c.EsIngrendiente = 0
            AND 
	            CAST(cs.FechaCompra AS DATE) between '" + pFechaInicio + "' AND '" + pFechaFinal + @"'
            GROUP BY
                p.IDProducto, 
                p.Nombre,
                p.CostoUnitario, 
                p.IDCategoria, 
                c.Nombre,
                cs.FechaCompra
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

        public static DataTable VENTAS_SEGUN_PERIODO_PRODUCTOS(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = $@"SELECT
                v.IDVentas AS 'ID Venta',
                pv.Cliente AS 'Cliente',
                v.FechaVenta AS 'Fecha de Venta',
                v.Precio AS 'Precio Total',
                e.Nombre AS 'Empleado'
            FROM
                ventas v
            INNER JOIN
                empleados e ON v.IDEmpleado = e.IDEmpleado
            INNER JOIN
                pedidoventas pv ON v.IDPedido = pv.IDPedido
            WHERE
                CAST(v.FechaVenta AS DATE) BETWEEN '{pFechaInicio}' AND '{pFechaFinal}'
            ORDER BY
                v.FechaVenta DESC;";
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

        public static DataTable COMPRAS_SEGUN_PEDIDO(string pFechaInicio, string pFechaFinal)
        {
            DataTable Resultado = new DataTable();
            String Consulta = @"SELECT DISTINCT
               c.IDCompras,
               c.FechaCompra,
               c.IDPedido,
               p.Nombre As Producto,
               e.Nombre AS Empleado,
               dc.Precio as Costo
               
               FROM 
               GestionRestauranteDB.compras c
               left join GestionRestauranteDB.detallepedidocompras dc on c.IDPedido = dc.IDPedido
               left join GestionRestauranteDB.productos p on dc.IDProducto = p.IDProducto
               INNER JOIN GestionRestauranteDB.empleados e ON c.IDEmpleado = e.IDEmpleado
               
               WHERE
 CAST(c.FechaCompra AS DATE) BETWEEN '" + pFechaInicio + "' AND '" + pFechaFinal + @"'
             GROUP BY
                c.IDCompras,
               c.FechaCompra,

               c.IDPedido,
               p.Nombre,
               e.Nombre,
               dc.Precio
             ORDER BY
               c.FechaCompra ASC; ";
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

