using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesos.CLS
{
    internal class Productos
    {
        Int32 _IDProducto;
        string _Nombre;
        double _Precio;
        double _CostoUnitario;
        Int32 _EsPlatillo;
        Int32 _IDCategoria;
        Int32 _Cantidad;

        public int IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public double CostoUnitario { get => _CostoUnitario; set => _CostoUnitario = value; }
        public int EsPlatillo { get => _EsPlatillo; set => _EsPlatillo = value; }
        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }

        public Boolean Insertar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("INSERT INTO productos(nombre, precio, CostoUnitario, EsPlatillo, IDCategoria, Cantidad) VALUES(");
            Sentencia.Append("'" + Nombre + "','" + Precio + "','" + CostoUnitario + "','" + EsPlatillo + "','" + IDCategoria + "','" + Cantidad + "');");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Actualizar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion();
            StringBuilder Sentencia = new StringBuilder(); // objeto para construir cadenas complejas
            Sentencia.Append("UPDATE productos SET ");
            Sentencia.Append("Nombre = '" + Nombre + "','" +
                             "Precio = '" + _Precio + "'," +
                             "CostoUnitario = '" + _CostoUnitario + "'," +
                             "EsPlatillo = '" + _EsPlatillo + "'," +
                             "IDCategoria = '" + _IDCategoria + "'," +
                             "Cantidad = '" + _Cantidad + "'");
            Sentencia.Append("WHERE IDProducto = " + _IDProducto + "; ");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            DataLayer.DBOperacion Operacion = new DataLayer.DBOperacion(); // Agregar referencias= Referencias-Agregar referencia
            StringBuilder Sentencia = new StringBuilder(); // Objeto para construir cadenas complejas
            Sentencia.Append("DELETE FROM productos ");
            Sentencia.Append("WHERE IDProducto = " + _IDProducto + ";");
            try
            {
                if (Operacion.EjecutarSentencia(Sentencia.ToString()) >= 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch (Exception)
            {
                Resultado = false;
            }
            return Resultado;
        }
    }
}
