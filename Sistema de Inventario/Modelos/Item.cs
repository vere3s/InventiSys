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
        public int Cantidad { get; set; }

        // Constructor
        public Item(int idProducto, string nombreProducto, decimal precio, int cantidad)
        {
            IDProducto = idProducto;
            NombreProducto = nombreProducto;
            Precio = precio;
            Cantidad = cantidad;
        }
    }

}
