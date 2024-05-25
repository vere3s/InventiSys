using System;
using System.Collections.Generic;
using System.Data;
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
                string consultaPedido = $"INSERT INTO pedidocompras(IDProveedor, Estado, Comentarios) VALUES ({idProveedor}, 'Creado', '{nuevoComentario}');";




                int idPedido = operacion.EjecutarSentenciaYObtenerID(consultaPedido);
               

                // Verificar si se pudo obtener el ID del pedido
                if (idPedido > 0)
                {
                    foreach (Item item in detallesPedido)
                    {
                        // Construir la consulta para insertar el detalle del pedido
                
                        StringBuilder consultaDetalle = new StringBuilder();
                        consultaDetalle.Append("INSERT INTO detallepedidocompras(IDPedido, IDProducto, Cantidad, Precio) VALUES (");
                        consultaDetalle.Append(idPedido); // IDPedido es numérico, no necesita comillas
                        consultaDetalle.Append(", ");
                        consultaDetalle.Append(item.IDProducto); // IDProducto es numérico, no necesita comillas
                        consultaDetalle.Append(", ");
                        consultaDetalle.Append(item.Cantidad); // Cantidad es numérico, no necesita comillas
                        consultaDetalle.Append(", ");
                        consultaDetalle.Append(item.Precio); // Precio es numérico, no necesita comillas
                        consultaDetalle.Append(");");


                        // Ejecutar la consulta para insertar el detalle del pedido
                        operacion.EjecutarSentencia(consultaDetalle.ToString());
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
                consultaActualizacionProveedor.Append("UPDATE pedidocompras SET IDProveedor = ");
                consultaActualizacionProveedor.Append(nuevoProveedor);
                consultaActualizacionProveedor.Append(", ");
                consultaActualizacionProveedor.Append("Comentarios = '");
                consultaActualizacionProveedor.Append(nuevoComentario?.Replace("'", "''") ?? "");
                consultaActualizacionProveedor.Append("' WHERE IDPedido = ");
                consultaActualizacionProveedor.Append(idPedido);
                consultaActualizacionProveedor.Append(";");

                // Ejecutar la consulta de actualización del proveedor
                operacion.EjecutarSentencia(consultaActualizacionProveedor.ToString());

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

        public void EliminarProductosNoPresentesEnPedido(int idPedido, List<Item> nuevosDetallesPedido)
        {
            try
            {
                // Crear una instancia de DBOperacion para ejecutar las consultas
                DBOperacion operacion = new DBOperacion();

                // Construir la consulta para obtener todos los detalles del pedido actual
                StringBuilder consultaDetallesPedidoActual = new StringBuilder();
                consultaDetallesPedidoActual.Append("SELECT IDDetallePedido FROM detallepedidocompras WHERE IDPedido = ");
                consultaDetallesPedidoActual.Append(idPedido);
                consultaDetallesPedidoActual.Append(";");

                // Ejecutar la consulta para obtener los detalles del pedido actual
                DataTable detallesPedidoActual = operacion.Consultar(consultaDetallesPedidoActual.ToString());

                // Crear una lista para almacenar los IDs de los detalles presentes en el pedido actual
                List<int> idsDetallesPresentes = new List<int>();
                foreach (DataRow fila in detallesPedidoActual.Rows)
                {
                    int idDetallePedido = Convert.ToInt32(fila["IDDetallePedido"]);
                    idsDetallesPresentes.Add(idDetallePedido);
                }

                // Crear una lista para almacenar los IDs de los detalles presentes en los nuevos detalles del pedido
                List<int> idsNuevosDetalles = new List<int>();
                foreach (Item nuevoDetalle in nuevosDetallesPedido)
                {
                    idsNuevosDetalles.Add(nuevoDetalle.IDDetallePedido);
                }

                // Determinar los IDs de los detalles que ya no están presentes en los nuevos detalles del pedido
                List<int> idsDetallesAEliminar = idsDetallesPresentes.Except(idsNuevosDetalles).ToList();

                // Si hay detalles a eliminar, construir la consulta de eliminación y ejecutarla
                if (idsDetallesAEliminar.Count > 0)
                {
                    StringBuilder consultaEliminacionDetalles = new StringBuilder();
                    consultaEliminacionDetalles.Append("DELETE FROM detallepedidocompras WHERE IDDetallePedido IN (");

                    StringBuilder idsDetalles = new StringBuilder();
                    foreach (int idDetalle in idsDetallesAEliminar)
                    {
                        idsDetalles.Append(idDetalle);
                        idsDetalles.Append(",");
                    }

                    if (idsDetalles.Length > 0)
                    {
                        idsDetalles.Length--; // Eliminar el último carácter (coma)
                    }

                    consultaEliminacionDetalles.Append(idsDetalles);
                    consultaEliminacionDetalles.Append(");");

                    // Ejecutar la consulta de eliminación de detalles
                    operacion.EjecutarSentencia(consultaEliminacionDetalles.ToString());

                    Console.WriteLine("Detalles eliminados correctamente.");
                }
                else
                {
                    Console.WriteLine("No hay detalles para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar detalles del pedido: " + ex.Message);
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
                consultaVerificacion.Append("SELECT COUNT(*) FROM compras WHERE IDPedido = ");
                consultaVerificacion.Append(idPedido);
                consultaVerificacion.Append(";");

                // Ejecutar la consulta de verificación
                int count = Convert.ToInt32(operacion.Consultar(consultaVerificacion.ToString()).Rows[0][0]);


                // Si no existe un pago previo, proceder con la inserción
                if (count == 0)
                {
                    // Construir la consulta para insertar el pago en la tabla 'compras'
                    StringBuilder consultaCompra = new StringBuilder();
                    consultaCompra.Append("INSERT INTO compras(IDPedido, FechaCompra, IDEmpleado) VALUES (");
                    consultaCompra.Append(idPedido); // Insertamos el ID del pedido
                    consultaCompra.Append(", '");
                    consultaCompra.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Formateamos la fecha y hora
                    consultaCompra.Append("', ");
                    consultaCompra.Append(idEmpleado); // Insertamos el ID del empleado
                    consultaCompra.Append(");");

                    // Ejecutar la consulta para insertar la compra
                    return operacion.EjecutarSentencia(consultaCompra.ToString());

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
