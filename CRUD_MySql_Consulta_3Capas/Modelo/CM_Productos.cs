using CRUD_MySql_Consulta_3Capas.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MySql_Consulta_3Capas.Modelo
{
    public class CM_Productos
    {
        CD_Productos objetoCD = new CD_Productos();
        public DataTable MostrarProd()
        {
            DataTable tabla=new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;        
        }
    }
}
