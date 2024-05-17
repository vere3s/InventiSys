using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Item
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int IDDetallePedido { get; set; }
        public int Cantidad { get; set; }

        // Constructor
        public Item(int idProducto, decimal precio, int cantidad)
        {
            IDProducto = idProducto;
           
            Precio = precio;
            Cantidad = cantidad;
       
        }
        public Item(int idProducto,  decimal precio, int cantidad, int iDDetallePedido)
        {
            IDProducto = idProducto;
           
            Precio = precio;
            Cantidad = cantidad;
            IDDetallePedido = iDDetallePedido;
        }
    }

}
