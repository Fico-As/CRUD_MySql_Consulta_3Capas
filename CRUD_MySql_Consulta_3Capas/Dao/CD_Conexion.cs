using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MySql_Consulta_3Capas.Dao
{
    class CD_Conexion
    {
        private MySqlConnection Conectar()
        {
            MySqlConnection conexion = new MySqlConnection();
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string BD = "practica";
            string cadena = "Server=" + servidor + "; DataBase=" + BD + "; User Id=" + usuario + "; Password=" + password + "";
            conexion = new MySqlConnection(cadena);
            return conexion;
        }
        public MySqlConnection AbrirConexion()
        {
            MySqlConnection conexionbd = Conectar();
            if (conexionbd.State == ConnectionState.Closed)
                conexionbd.Open();
            return conexionbd;
        }

        public MySqlConnection CerrarConexion()
        {
            MySqlConnection conexionbd = Conectar();
            if (conexionbd.State == ConnectionState.Open)
                conexionbd.Close();
            return conexionbd;
        }
    }
}
