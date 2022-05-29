using MySql.Data.MySqlClient;
using System.Data;

namespace Prueba02.Dao
{
    public class CD_Conexion
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
