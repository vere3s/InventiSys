using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesos.CLS
{
    using System;
    using System.Collections.Generic;
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
            public void pagarPedido(int idPedido, double precio, int idEmpleado)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Construir la consulta para insertar la venta en la tabla 'ventas'
                    StringBuilder consultaVenta = new StringBuilder();
                    consultaVenta.Append("INSERT INTO ventas(IDPedido, Precio, FechaVenta, IDEmpleado) VALUES(");
                    consultaVenta.Append(idPedido);
                    consultaVenta.Append(",");
                    consultaVenta.Append(precio.ToString("0.00")); // Formateamos el precio a dos decimales
                    consultaVenta.Append(",'");
                    consultaVenta.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Formateamos la fecha y hora
                    consultaVenta.Append("',");
                    consultaVenta.Append(idEmpleado);
                    consultaVenta.Append(");");

                    // Ejecutar la consulta para insertar la venta
                    operacion.EjecutarSentencia(consultaVenta.ToString());

                    // Si la inserción es exitosa, mostrar un mensaje
                    Console.WriteLine("Venta realizada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al realizar la venta: " + ex.Message);
                }
            }
            public int Insertar(string cliente, List<Item> detallesPedido)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Construir la consulta para insertar el pedido en la tabla 'pedidoventas'
                    StringBuilder consultaPedido = new StringBuilder();
                    consultaPedido.Append("INSERT INTO pedidoventas(Cliente,Estado) VALUES('");
                    consultaPedido.Append(cliente);
                    consultaPedido.Append("','Pendiente');");

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
            public int Actualizar(int idPedido, string nuevoCliente)
            {
                try
                {
                    // Crear una instancia de DBOperacion para ejecutar las consultas
                    DBOperacion operacion = new DBOperacion();

                    // Construir la consulta para actualizar el cliente del pedido
                    StringBuilder consultaActualizacion = new StringBuilder();
                    consultaActualizacion.Append("UPDATE pedidoventas SET Cliente = '");
                    consultaActualizacion.Append(nuevoCliente);
                    consultaActualizacion.Append("' WHERE IDPedido = ");
                    consultaActualizacion.Append(idPedido);
                    consultaActualizacion.Append(";");

                    // Ejecutar la consulta de actualización
                   return operacion.EjecutarSentencia(consultaActualizacion.ToString());

                   
                }
                catch (Exception ex)
                {
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
        }
    }

}
