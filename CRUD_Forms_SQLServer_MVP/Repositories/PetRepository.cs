using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agregamso referencias
using System.Data.SqlClient;
using System.Data;
using CRUD_Forms_SQLServer_MVP.Modelo;

//para crear este fichero clase clic derecho sobre Repository /  agregar / clase = PetRepository
namespace CRUD_Forms_SQLServer_MVP.Repositories
{
    //volvemos en publico la clase y definimos su herencia con :BaseRepository
    // nos situamos sobre IPetRepositorio e implementamos las interfaces simples no todas
    public class PetRepository : BaseRepository, IPetRepositorio
    {
        //constructor
        public PetRepository(string connectionString)
        {
            //esto se lo hace por el metodo de inyeccion de dependencia y  pruebas unitarias
            this.connectionString = connectionString;
        }
        public void Add(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
   
            //usamos using para conectarnos a la cadena de conexion
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Pet order by Pet_Id desc";
                //usign se desecha de lo ejecutado por tanto no es necesario cerrar la conexion
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Nombre = reader[1].ToString();
                        petModel.Tipo = reader[2].ToString();
                        petModel.Color = reader[3].ToString();
                        petList.Add(petModel);
                    }
                }
            }
            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();
            //creamos esta variable para la busqueda
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;
            //usamos using para conectarnos a la cadena de conexion
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                //command.CommandText = "Select * from Pet order by Id desc";
                command.CommandText = @"Select * from Pet where Pet_Id=@id or Pet_Nombre like @name+'%' order by Pet_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;
                //usign se desecha de lo ejecutado por tanto no es necesario cerrar la conexion
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Nombre = reader[1].ToString();
                        petModel.Tipo = reader[2].ToString();
                        petModel.Color = reader[3].ToString();
                        petList.Add(petModel);
                    }
                }
            }
            return petList;
        }
    }
}
