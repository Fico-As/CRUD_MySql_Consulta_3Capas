using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Prueba02.Dao
{
    class CD_Productos
    {
        CD_Conexion conexion = new CD_Conexion();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Select * from Productos";
            comando.CommandType = CommandType.Text;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string nombre, String desc, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into Productos values(null,'" + nombre + "','" +
                desc + "','" + marca + "'," + precio + "," + stock + ")";
            comando.CommandType = CommandType.Text;
            comando.ExecuteReader();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Editar(string nombre, String desc, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE `productos` SET `nombre` = '" + nombre + "', `descripcion` = '" + desc + "', `marca` = '" +
                marca + "', `precio` = " + precio + ", `stock` = " + stock + " WHERE `productos`.`id` = " + id + ";";
            comando.CommandType = CommandType.Text;
            comando.ExecuteReader();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM `productos` WHERE `productos`.`id` = " + id + ";";
            comando.CommandType = CommandType.Text;
            comando.ExecuteReader();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable MostrarPA()//mustra datos con procedimientos almacenado
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_MostrarDatos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void InsertarPA(string nombre, String desc, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_nombre", nombre);
            comando.Parameters.AddWithValue("_desc", desc);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precio", precio);
            comando.Parameters.AddWithValue("_stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EditarPA(string nombre, String desc, string marca, double precio, int stock,int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EditarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_nombre", nombre);
            comando.Parameters.AddWithValue("_desc", desc);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precio", precio);
            comando.Parameters.AddWithValue("_stock", stock);
            comando.Parameters.AddWithValue("_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
        public void EliminarPA(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;         
            comando.Parameters.AddWithValue("_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}
