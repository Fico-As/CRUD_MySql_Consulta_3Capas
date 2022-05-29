using MySqlConnector;
using PruebaSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSQL.Controlador
{
    public class CTRL_Clientes
    { 
        public MySqlConnection ConectarBD()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string BD = "clientes";
            string cadena = "Server=" + servidor + "; DataBase=" + BD + "; User Id=" + usuario + "; Password=" + password + "";
            MySqlConnection conexionBD = new MySqlConnection(cadena);
            return conexionBD;
        }
        public MySqlConnection AbrirConexion()
        {
            MySqlConnection conexionbd = ConectarBD();
            if (conexionbd.State == ConnectionState.Closed)
                conexionbd.Open();
            return conexionbd;
        }

        public MySqlConnection CerrarConexion()
        {
            MySqlConnection conexionbd = ConectarBD();
            if (conexionbd.State == ConnectionState.Open)
                conexionbd.Close();
            return conexionbd;
        }
        public List<MOD_Clientes> MostrarDatos()
        {
            string consulta = "select * from clientes";
            CTRL_Clientes conexion = new CTRL_Clientes();
            MySqlCommand comando = new MySqlCommand(consulta);
            List<MOD_Clientes> lista = new List<MOD_Clientes>();
            comando.Connection= conexion.AbrirConexion();            
            MySqlDataReader lectura;
            lectura = comando.ExecuteReader();
            while (lectura.Read())
            {
                MOD_Clientes listaClientes = new MOD_Clientes();
                listaClientes.Id = lectura.GetInt32("id");
                listaClientes.Nombre = lectura.GetString("nombre");
                listaClientes.Apellido = lectura.GetString("apellido");
                listaClientes.Telefono = lectura.GetString("telefono");
                listaClientes.Tarjeta = lectura.GetString("tarjeta_de_credito");
                lista.Add(listaClientes);
            }
            conexion.CerrarConexion();
            return lista;
        }
        public void GuardarLista(MOD_Clientes listaClientes)
        {
            if (listaClientes.Id == 0)
            {
                insertarDatos(listaClientes);
            }
            else
            {
                actualizarDatos(listaClientes);
            }
        }

        private void actualizarDatos(MOD_Clientes listaClientes)
        {
            string consulta = "UPDATE `clientes` SET `nombre` = '" + listaClientes.Nombre + "', `apellido` = '" +
                listaClientes.Apellido + "', `telefono` = '" + listaClientes.Telefono + "', `tarjeta_de_credito` = '" +
                listaClientes.Tarjeta + "' WHERE `clientes`.`id` = " + listaClientes.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = AbrirConexion();
            comando.ExecuteReader();
            comando.Connection.Close();
        }

        private void insertarDatos(MOD_Clientes listaClientes)
        {
            string consulta = "INSERT INTO `clientes` (`id`, `nombre`, `apellido`, `telefono`, `tarjeta_de_credito`) VALUES (NULL, '" +
                listaClientes.Nombre + "', '" + listaClientes.Apellido + "', '" + listaClientes.Telefono + "', '" + listaClientes.Tarjeta + "');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = AbrirConexion();
            comando.ExecuteReader();
            comando.Connection=CerrarConexion();
        }
        public void eliminarDatos(MOD_Clientes listaClientes)
        {
            string consulta = "DELETE FROM `clientes` WHERE `clientes`.`id` = " + listaClientes.Id + "";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = AbrirConexion();
            comando.ExecuteNonQuery();
            comando.Connection = CerrarConexion();
             
        }
    }
}
