using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//para agregar se va a la carpeta Modelo de proyecto clic derecho
//agregar / componente / interfaz = IPetRepositorio
namespace CRUD_Forms_SQLServer_MVP.Modelo
{
    // colocar al metodo publico
    public interface IPetRepositorio
    {
        void Add(PetModel petModel);
        void Edit(PetModel petModel);
        void Delete(int id);
        //expone una enumeracion iterativa para coleccion
        IEnumerable<PetModel> GetAll();
        IEnumerable<PetModel> GetByValue(string value);//valor de busquedas
    }
}
