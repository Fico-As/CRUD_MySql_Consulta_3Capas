using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSQL.Modelo
{
    public class MOD_Clientes
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string tarjeta;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre;  }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }
        public string NombreCompleto
        {
            get { return nombre + " " + apellido + " " + telefono; }
        }
        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
