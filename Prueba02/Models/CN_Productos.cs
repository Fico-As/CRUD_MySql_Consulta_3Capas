using Prueba02.Dao;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace Prueba02.Models
{
    class CN_Productos
    {
        CD_Productos objetoCD = new CD_Productos();
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPA();
            return tabla;
        }
        public void InsertarProd(string nombre, string desc, string marca, string precio, string stock)
        {
            double precio2 = ConvertirADouble(precio);
            objetoCD.InsertarPA(nombre, desc, marca, precio2, Convert.ToInt32(stock));
        }

        public void EditarProd(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            double precio2 = ConvertirADouble(precio);
            objetoCD.EditarPA(nombre, desc, marca, precio2, Convert.ToInt32(stock), Convert.ToInt32(id));
        }
        public void eliminarProd(string id)
        {
            objetoCD.EliminarPA(Convert.ToInt32(id));
        }
        private double ConvertirADouble(string cadena)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (cadena != null)
                    if (!cadena.Contains(","))
                        result = double.Parse(cadena, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(cadena.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception)
            {
                try
                {
                    result = Convert.ToDouble(cadena);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(cadena.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }
    }
}
