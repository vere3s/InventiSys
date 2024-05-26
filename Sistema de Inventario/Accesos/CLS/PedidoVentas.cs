using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesos.CLS
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Text;
    using DataLayer; // Ajusta el namespace según la estructura de tu proyecto
    using Modelos;

    namespace Accesos.CLS
    {
        public class PedidoVentas
        {
            public string Cliente { get; set; }


            // Constructor
            public PedidoVentas()
            {

            }

            // Método para insertar el pedido en la base de datos
            // Método para insertar el pedido en la base de datos
            public int PagarPedido(int idPedido, double precio, int idEmpleado)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Construir la consulta para verificar si ya existe un pago para el idPedido
                    StringBuilder consultaVerificacion = new StringBuilder();
                    consultaVerificacion.Append("SELECT COUNT(*) FROM ventas WHERE IDPedido = ");
                    consultaVerificacion.Append(idPedido);
                    consultaVerificacion.Append(";");

                    // Ejecutar la consulta de verificación
                    int count = Convert.ToInt32(operacion.Consultar(consultaVerificacion.ToString()).Rows[0][0]);

                    // Si no existe un pago previo, proceder con la inserción
                    if (count == 0)
                    {
                        // Construir la consulta para insertar la venta en la tabla 'ventas'
                        StringBuilder consultaVenta = new StringBuilder();
                        consultaVenta.Append("INSERT INTO ventas(IDPedido, Precio, FechaVenta, IDEmpleado) VALUES(");
                        consultaVenta.Append(idPedido);
                        consultaVenta.Append(",");
                        consultaVenta.Append(precio.ToString("F2", CultureInfo.InvariantCulture)); // Formateamos el precio a dos decimales con punto decimal
                        consultaVenta.Append(",'");
                        consultaVenta.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Formateamos la fecha y hora
                        consultaVenta.Append("',");
                        consultaVenta.Append(idEmpleado);
                        consultaVenta.Append(");");

                        // Ejecutar la consulta para insertar la venta
                        operacion.EjecutarSentencia(consultaVenta.ToString());

                        // Si la inserción es exitosa, mostrar un mensaje y retornar 1
             
                        return 1;
                    }
                    else
                    {
                        // Mostrar un mensaje indicando que ya existe un pago para ese pedido y retornar 0
                        
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error y retornar -1
               
                    return -1;
                }
            }

            public int Insertar(string cliente, List<Item> detallesPedido, string Comentario)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    

                    // Obtener la fecha actual de la máquina local
                    DateTime fechaActual = DateTime.Now;

                    // Construir la consulta de inserción con la fecha actual
                    StringBuilder consultaPedido = new StringBuilder();
                    consultaPedido.Append("INSERT INTO pedidoventas(Cliente, FechaPedido, Estado, Comentarios) VALUES('");
                    consultaPedido.Append(cliente.Replace("'", "''")); // Escapar apóstrofes en el cliente
                    consultaPedido.Append("', '");
                    consultaPedido.Append(fechaActual.ToString("yyyy-MM-dd HH:mm:ss")); // Formatear la fecha como string
                    consultaPedido.Append("', 'Pendiente', '");
                    consultaPedido.Append(Comentario.Replace("'", "''")); // Escapar apóstrofes en el comentario
                    consultaPedido.Append("');");




                    int idPedido = operacion.EjecutarSentenciaYObtenerID(consultaPedido.ToString());
                    // Ejecutar la consulta para insertar el pedido

                    // Obtener el ID del pedido recién insertado
                    StringBuilder consultaIDPedido = new StringBuilder();


                    // Verificar si se pudo obtener el ID del pedido
                    if (idPedido > 0)
                    {
                        Console.WriteLine("El id es" + idPedido);
                        // Iterar sobre los detalles del pedido para insertar cada uno en la tabla 'detallepedidoventas'
                        foreach (Item item in detallesPedido)
                        {
                            // Construir la consulta para insertar el detalle del pedido
                            StringBuilder consultaDetalle = new StringBuilder();
                            consultaDetalle.Append("INSERT INTO detallepedidoventas(IDPedido, IDProducto, Cantidad, Precio) VALUES(");
                            consultaDetalle.Append(idPedido);

                            consultaDetalle.Append(",");
                            consultaDetalle.Append(item.IDProducto);
                            Console.WriteLine("El id es idProducto" + item.IDProducto);
                            consultaDetalle.Append(",");
                            consultaDetalle.Append(item.Cantidad);
                            Console.WriteLine("El id es idProducto" + item.Cantidad);
                            consultaDetalle.Append(",");
                            consultaDetalle.Append(item.Precio);
                            Console.WriteLine("El id es idProducto" + item.Precio);
                            consultaDetalle.Append(");");

                            // Ejecutar la consulta para insertar el detalle del pedido
                            Console.WriteLine("El id es idSentencia" + operacion.EjecutarSentencia(consultaDetalle.ToString()));
                        }

                        // Si se llega a este punto, se insertaron correctamente todos los detalles del pedido
                        return idPedido;
                    }


                    // Si no se pudo insertar el pedido o obtener su ID, devolver false
                    return -1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Si ocurre alguna excepción, devolver false
                    return -1;
                }
            }
            public int Actualizar(int idPedido, string nuevoCliente, List<Item> nuevosDetallesPedido,string nuevoEstado,string nuevoComentario)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();



                    // Construir la consulta para actualizar el cliente del pedido
                    StringBuilder consultaActualizacion = new StringBuilder();
                    consultaActualizacion.Append("UPDATE pedidoventas SET ");
                    consultaActualizacion.Append("Cliente = '");
                    consultaActualizacion.Append(nuevoCliente?.Replace("'", "''") ?? ""); // Check for null before replacing
                    consultaActualizacion.Append("', ");
                    consultaActualizacion.Append("Estado = '");
                    consultaActualizacion.Append(nuevoEstado?.Replace("'", "''") ?? ""); // Check for null before replacing
                    consultaActualizacion.Append("', ");
                    consultaActualizacion.Append("Comentarios = '");
                    consultaActualizacion.Append(nuevoComentario?.Replace("'", "''") ?? ""); // Check for null before replacing
                    consultaActualizacion.Append("' WHERE IDPedido = ");
                    consultaActualizacion.Append(idPedido.ToString()); // Convert idPedido to string
                    consultaActualizacion.Append(";");


                    // Ejecutar la consulta de actualización del cliente
                    operacion.EjecutarSentencia(consultaActualizacion.ToString());

                    // Eliminar los detalles del pedido que ya no están en la lista de nuevos detalles
                    StringBuilder consultaEliminacionDetalles = new StringBuilder();
                    consultaEliminacionDetalles.Append("DELETE FROM detallepedidoventas WHERE IDPedido = ");
                    consultaEliminacionDetalles.Append(idPedido);
                    consultaEliminacionDetalles.Append(" AND IDDetallePedido NOT IN (");

                    // Construir una cadena de IDs de detalles a eliminar
                    StringBuilder idsDetallesAEliminar = new StringBuilder();
                    foreach (Item nuevoDetalle in nuevosDetallesPedido)
                    {
                        idsDetallesAEliminar.Append(nuevoDetalle.IDDetallePedido);
                        idsDetallesAEliminar.Append(",");
                    }

                    // Eliminar la coma adicional al final
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
                        // Si el ID del detalle es igual a -1, significa que es un nuevo detalle y se debe insertar
                        if (nuevoDetalle.IDDetallePedido == -1)
                        {
                            StringBuilder consultaInsercionDetalle = new StringBuilder();
                            consultaInsercionDetalle.Append("INSERT INTO detallepedidoventas(IDPedido, IDProducto, Cantidad, Precio) VALUES(");
                            consultaInsercionDetalle.Append(idPedido);
                            consultaInsercionDetalle.Append(",");
                            consultaInsercionDetalle.Append(nuevoDetalle.IDProducto);
                            consultaInsercionDetalle.Append(",");
                            consultaInsercionDetalle.Append(nuevoDetalle.Cantidad);
                            consultaInsercionDetalle.Append(",");
                            consultaInsercionDetalle.Append(nuevoDetalle.Precio.ToString("0.00")); // Formatear el precio a dos decimales
                            consultaInsercionDetalle.Append(");");

                            // Ejecutar la consulta de inserción
                            operacion.EjecutarSentencia(consultaInsercionDetalle.ToString());
                        }
                        else
                        {
                            StringBuilder consultaActualizacionDetalle = new StringBuilder();
                            consultaActualizacionDetalle.Append("UPDATE detallepedidoventas SET IDProducto = ");
                            consultaActualizacionDetalle.Append(nuevoDetalle.IDProducto);
                            consultaActualizacionDetalle.Append(", Cantidad = ");
                            consultaActualizacionDetalle.Append(nuevoDetalle.Cantidad);
                            consultaActualizacionDetalle.Append(", Precio = ");
                            consultaActualizacionDetalle.Append(nuevoDetalle.Precio.ToString("0.00")); // Formatear el precio a dos decimales
                            consultaActualizacionDetalle.Append(" WHERE IDDetallePedido = ");
                            consultaActualizacionDetalle.Append(nuevoDetalle.IDDetallePedido);
                            consultaActualizacionDetalle.Append(" And IDPedido = ");
                            consultaActualizacionDetalle.Append(idPedido);
                            consultaActualizacionDetalle.Append(";");

                            // Ejecutar la consulta de actualización
                            operacion.EjecutarSentencia(consultaActualizacionDetalle.ToString());
                        }
                    }

                    // Confirmar la transacción
              

                    // Si todo se realizó correctamente, devolver el ID del pedido actualizado
                    return idPedido;
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, cancelar la transacción y devolver -1
                    Console.WriteLine("Error al actualizar el pedido: " + ex.Message);

                    return -1;
                }
            }

            public void ActualizarDetallePedidoVentas(int idDetallePedido, int nuevaCantidad, double nuevoPrecio)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Construir la consulta para actualizar el detalle del pedido
                    StringBuilder consultaActualizacion = new StringBuilder();
                    consultaActualizacion.Append("UPDATE detallepedidoventas SET Cantidad = ");
                    consultaActualizacion.Append(nuevaCantidad);
                    consultaActualizacion.Append(", Precio = ");
                    consultaActualizacion.Append(nuevoPrecio.ToString("0.00")); // Formateamos el precio a dos decimales
                    consultaActualizacion.Append(" WHERE IDDetallePedido = ");
                    consultaActualizacion.Append(idDetallePedido);
                    consultaActualizacion.Append(";");

                    // Ejecutar la consulta de actualización
                    operacion.EjecutarSentencia(consultaActualizacion.ToString());

                    Console.WriteLine("Detalle del pedido actualizado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el detalle del pedido: " + ex.Message);
                }
            }


            public Boolean Eliminar(int idPedido)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Consultar si hay algún pago asociado con el pedido
                    string consultaPago = "SELECT COUNT(*) FROM pagos WHERE IDPedido = " + idPedido;
                    int count = Convert.ToInt32(operacion.EjecutarSentencia(consultaPago));

                    // Si hay algún pago asociado, no se permite eliminar
                    if (count > 0)
                    {
                        Console.WriteLine("No se puede eliminar el pedido porque ya tiene un pago asociado.");
                        return false;
                    }

                    // Si no hay pagos asociados, procedemos con la eliminación

                    // Construir la consulta para eliminar los detalles del pedido
                    StringBuilder consultaEliminacionDetalles = new StringBuilder();
                    consultaEliminacionDetalles.Append("DELETE FROM detallepedidoventas WHERE IDPedido = ");
                    consultaEliminacionDetalles.Append(idPedido);
                    consultaEliminacionDetalles.Append(";");

                    // Construir la consulta para eliminar el pedido
                    StringBuilder consultaEliminacionPedido = new StringBuilder();
                    consultaEliminacionPedido.Append("DELETE FROM pedidoventas WHERE IDPedido = ");
                    consultaEliminacionPedido.Append(idPedido);
                    consultaEliminacionPedido.Append(";");

                    // Ejecutar la consulta de eliminación del pedido
                    operacion.EjecutarSentencia(consultaEliminacionPedido.ToString());

                    // Ejecutar la consulta de eliminación de los detalles del pedido
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
                    consultaDetallesPedidoActual.Append("SELECT IDDetallePedido FROM detallepedidoventas WHERE IDPedido = ");
                    consultaDetallesPedidoActual.Append(idPedido);
                    consultaDetallesPedidoActual.Append(";");

                    // Ejecutar la consulta para obtener los detalles del pedido actual
                    DataTable detallesPedidoActual = operacion.Consultar(consultaDetallesPedidoActual.ToString());

                    // Crear una lista para almacenar los IDs de los detalles presentes en el pedido actual
                    List<int> idsDetallesPresentes = new List<int>();

                    // Iterar sobre los resultados de la consulta y almacenar los IDs de los detalles
                    foreach (DataRow fila in detallesPedidoActual.Rows)
                    {
                        int idDetallePedido = Convert.ToInt32(fila["IDDetallePedido"]);
                        idsDetallesPresentes.Add(idDetallePedido);
                    }

                    // Crear una lista para almacenar los IDs de los detalles presentes en los nuevos detalles del pedido
                    List<int> idsNuevosDetalles = new List<int>();

                    // Iterar sobre los nuevos detalles del pedido y almacenar sus IDs
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
                        consultaEliminacionDetalles.Append("DELETE FROM detallepedidoventas WHERE IDDetallePedido IN (");

                        // Construir una cadena de IDs de detalles a eliminar
                        StringBuilder idsDetalles = new StringBuilder();
                        foreach (int idDetalle in idsDetallesAEliminar)
                        {
                            idsDetalles.Append(idDetalle);
                            idsDetalles.Append(",");
                        }

                        // Eliminar la coma adicional al final
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

        }
    }

}
