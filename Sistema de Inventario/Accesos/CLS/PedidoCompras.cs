using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using DataLayer; // Ajusta el namespace según la estructura de tu proyecto
using Modelos;

namespace Accesos.CLS
{
    public class PedidoCompras
    {
        // Constructor
        public PedidoCompras()
        {

        }

        // Método para insertar el pedido de compras en la base de datos
        public int Insertar(int idProveedor, List<Item> detallesPedido,string nuevoComentario)
        {
            try
            {
                // Crear una instancia de DBOperacion para ejecutar las consultas
                DBOperacion operacion = new DBOperacion();

                // Construir la consulta para insertar el pedido en la tabla 'pedidocompras'
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string consultaPedido = "INSERT INTO pedidocompras(IDProveedor, FechaPedido, Estado, Comentarios) VALUES (@IDProveedor, @FechaPedido, @Estado, @Comentarios);";

                // Crear un diccionario de parámetros y añadir los valores correspondientes
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@IDProveedor", idProveedor);
                parametros.Add("@FechaPedido", fechaActual);
                parametros.Add("@Estado", "Creado");
                parametros.Add("@Comentarios", nuevoComentario);

                // Ejecutar la consulta para insertar el pedido y obtener su ID
                int idPedido = operacion.EjecutarSentenciaYObtenerID(consultaPedido, parametros);



                // Verificar si se pudo obtener el ID del pedido
                if (idPedido > 0)
                {
                    foreach (Item item in detallesPedido)
                    {
                        // Construir la consulta para insertar el detalle del pedido
                        StringBuilder consultaDetalle = new StringBuilder();
                        consultaDetalle.Append("INSERT INTO detallepedidocompras(IDPedido, IDProducto, Cantidad, Precio, Fecha) VALUES (@IDPedido, @IDProducto, @Cantidad, @Precio, @Fecha)");

                        // Crear un diccionario de parámetros y añadir los valores correspondientes
                        Dictionary<string, object> parametrosDetalles = new Dictionary<string, object>();
                        parametrosDetalles.Add("@IDPedido", idPedido);
                        parametrosDetalles.Add("@IDProducto", item.IDProducto);
                        parametrosDetalles.Add("@Cantidad", item.Cantidad);
                        parametrosDetalles.Add("@Precio", item.Precio.ToString("0.00", CultureInfo.InvariantCulture));
                        parametrosDetalles.Add("@Fecha", DateTime.Now);

                        // Ejecutar la consulta para insertar el detalle del pedido
                        operacion.EjecutarSentencia(consultaDetalle.ToString(), parametrosDetalles);

                    }
                    return idPedido;
                }

                // Si no se pudo insertar el pedido o obtener su ID, devolver -1
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int Actualizar(int idPedido, int nuevoProveedor, List<Item> nuevosDetallesPedido,string nuevoComentario)
        {
            try
            {
                // Crear una instancia de DBOperacion para ejecutar las consultas
                DBOperacion operacion = new DBOperacion();

                // Construir la consulta para actualizar el proveedor del pedido
                StringBuilder consultaActualizacionProveedor = new StringBuilder();
                consultaActualizacionProveedor.Append("UPDATE pedidocompras SET IDProveedor = @NuevoProveedor, Comentarios = @NuevoComentario WHERE IDPedido = @IDPedido");

                // Crear un diccionario de parámetros y añadir los valores correspondientes
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@NuevoProveedor", nuevoProveedor);
                parametros.Add("@NuevoComentario", nuevoComentario?.Replace("'", "''") ?? ""); // Escapar comillas simples
                parametros.Add("@IDPedido", idPedido);

                // Ejecutar la consulta de actualización del proveedor
                operacion.EjecutarSentencia(consultaActualizacionProveedor.ToString(), parametros);

                // Eliminar los detalles del pedido que ya no están en la lista de nuevos detalles
                StringBuilder consultaEliminacionDetalles = new StringBuilder();
                consultaEliminacionDetalles.Append("DELETE FROM detallepedidocompras WHERE IDPedido = ");
                consultaEliminacionDetalles.Append(idPedido);
                consultaEliminacionDetalles.Append(" AND IDDetallePedido NOT IN (");

                StringBuilder idsDetallesAEliminar = new StringBuilder();
                foreach (Item nuevoDetalle in nuevosDetallesPedido)
                {
                    idsDetallesAEliminar.Append(nuevoDetalle.IDDetallePedido);
                    idsDetallesAEliminar.Append(",");
                }

                if (idsDetallesAEliminar.Length > 0)
                {
                    idsDetallesAEliminar.Length--; // Eliminar el último carácter (coma)
                }

                consultaEliminacionDetalles.Append(idsDetallesAEliminar);
                consultaEliminacionDetalles.Append(");");

                // Ejecutar la consulta de eliminación de detalles
                operacion.EjecutarSentencia(consultaEliminacionDetalles.ToString());

                // Insertar o actualizar los nuevos detalles del pedido
                foreach (Item nuevoDetalle in nuevosDetallesPedido)
                {
                    if (nuevoDetalle.IDDetallePedido == -1)
                    {
                        StringBuilder consultaInsercionDetalle = new StringBuilder();
                        consultaInsercionDetalle.Append("INSERT INTO detallepedidocompras(IDPedido, IDProducto, Cantidad, Precio) VALUES(");
                        consultaInsercionDetalle.Append(idPedido);
                        consultaInsercionDetalle.Append(",");
                        consultaInsercionDetalle.Append(nuevoDetalle.IDProducto);
                        consultaInsercionDetalle.Append(",");
                        consultaInsercionDetalle.Append(nuevoDetalle.Cantidad);
                        consultaInsercionDetalle.Append(",");
                        consultaInsercionDetalle.Append(nuevoDetalle.Precio.ToString("0.00"));
                        consultaInsercionDetalle.Append(");");

                        // Ejecutar la consulta de inserción
                        operacion.EjecutarSentencia(consultaInsercionDetalle.ToString());
                    }
                    else
                    {
                        StringBuilder consultaActualizacionDetalle = new StringBuilder();
                        consultaActualizacionDetalle.Append("UPDATE detallepedidocompras SET IDProducto = ");
                        consultaActualizacionDetalle.Append(nuevoDetalle.IDProducto);
                        consultaActualizacionDetalle.Append(", Cantidad = ");
                        consultaActualizacionDetalle.Append(nuevoDetalle.Cantidad);
                        consultaActualizacionDetalle.Append(", Precio = ");
                        consultaActualizacionDetalle.Append(nuevoDetalle.Precio.ToString("0.00"));
                        consultaActualizacionDetalle.Append(" WHERE IDDetallePedido = ");
                        consultaActualizacionDetalle.Append(nuevoDetalle.IDDetallePedido);
                        consultaActualizacionDetalle.Append(" AND IDPedido = ");
                        consultaActualizacionDetalle.Append(idPedido);
                        consultaActualizacionDetalle.Append(";");

                        // Ejecutar la consulta de actualización
                        operacion.EjecutarSentencia(consultaActualizacionDetalle.ToString());
                    }
                }

                return idPedido;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el pedido: " + ex.Message);
                return -1;
            }
        }

        public bool Eliminar(int idPedido)
        {
            try
            {
                // Crear una instancia de DBOperacion para ejecutar las consultas
                DBOperacion operacion = new DBOperacion();

                // Construir la consulta para eliminar los detalles del pedido
                StringBuilder consultaEliminacionDetalles = new StringBuilder();
                consultaEliminacionDetalles.Append("DELETE FROM detallepedidocompras WHERE IDPedido = ");
                consultaEliminacionDetalles.Append(idPedido);
                consultaEliminacionDetalles.Append(";");

                // Construir la consulta para eliminar el pedido
                StringBuilder consultaEliminacionPedido = new StringBuilder();
                consultaEliminacionPedido.Append("DELETE FROM pedidocompras WHERE IDPedido = ");
                consultaEliminacionPedido.Append(idPedido);
                consultaEliminacionPedido.Append(";");

                // Ejecutar las consultas de eliminación
                operacion.EjecutarSentencia(consultaEliminacionPedido.ToString());
                operacion.EjecutarSentencia(consultaEliminacionDetalles.ToString());

                Console.WriteLine("Pedido y detalles eliminados correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el pedido y sus detalles: " + ex.Message);
                return false;
            }
        }
        public int PagarPedido(int idPedido, double precio, int idEmpleado)
        {
            try
            {
                // Crear una instancia de DBOperacion para ejecutar las consultas
                DBOperacion operacion = new DBOperacion();

                // Construir la consulta para verificar si ya existe un pago para el idPedido
                StringBuilder consultaVerificacion = new StringBuilder();
            
                consultaVerificacion.Append("SELECT COUNT(*) FROM compras WHERE IDPedido = @IDPedido");

                // Crear un diccionario de parámetros y añadir el valor de IDPedido
                Dictionary<string, object> parametro = new Dictionary<string, object>
                {
                    { "@IDPedido", idPedido }
                };

                // Ejecutar la consulta de verificación
                int count = Convert.ToInt32(operacion.Consultar(consultaVerificacion.ToString(), parametro).Rows[0][0]);



                // Si no existe un pago previo, proceder con la inserción
                if (count == 0)
                {
                    // Construir la consulta para insertar el pago en la tabla 'compras'
                    StringBuilder consultaCompra = new StringBuilder();
                    consultaCompra.Append("INSERT INTO compras(IDPedido, FechaCompra, IDEmpleado) VALUES (@IDPedido, @FechaCompra, @IDEmpleado)");

                    // Crear un diccionario de parámetros y añadir los valores correspondientes
                    Dictionary<string, object> parametros = new Dictionary<string, object>
                    {
                        { "@IDPedido", idPedido },
                        { "@FechaCompra", DateTime.Now },
                        { "@IDEmpleado", idEmpleado }
                    };

                    // Ejecutar la consulta para insertar la compra
                    return operacion.EjecutarSentencia(consultaCompra.ToString(), parametros);


                    // Si la inserción es exitosa, mostrar un mensaje

                }
                else
                {
                    // Mostrar un mensaje indicando que ya existe un pago para ese pedido
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

    }
}
