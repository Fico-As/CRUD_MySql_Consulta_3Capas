using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//acgremos las referencias a las carpetas Modelo, Vista;
using CRUD_Forms_SQLServer_MVP.Modelo;
using CRUD_Forms_SQLServer_MVP.Vista;
using System.Windows.Forms;

//el proyecto cuenta con tres carpetas PetPresentador, Modelo, Vista
// para agragar este fichero clic sobre carpeta Presentacion / agregar / clase = PetPresentador
namespace CRUD_Forms_SQLServer_MVP.Presentacion
{
    //volvemos a publico la clase
    public class PetPresentador
    {
        private IPetView view;
        private IPetRepositorio repositorio;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;
        //generamos el constructor para IPetView, IPetRepositorio haciendo clic derecho seleccionando ambos luego
        //acciones rapidas y ... / generar el construtor
        public PetPresentador(IPetView view, IPetRepositorio repositorio)
        {
            //iniciamos la fuente vinvulante de mascotas
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repositorio = repositorio;
            //suscribimos los eventos del controlador a los eventos de vista , implementamos lo que se va hace cuando un vento 
            //el presentador es el responsable de interpretar los eventos del usuario la comunicacion con los objetos del modelo
            //y la vista mueve las cosas de un componente a otro segun sea necesario.
            this.view.SearchEvent += SearchPet;//generamos el metodo usando el ayudante 
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //establecemos la fuente vinvulante de la fuente
            this.view.SetPetListBindingSource(petsBindingSource);
            //cargamos toda la lista de mascotas para esto se crea un metodo
            LoadAllPetList();
            //mostramos la vista
            this.view.Show();
        }
        //Metodos
        private void LoadAllPetList()
        {
            petList = repositorio.GetAll();
            petsBindingSource.DataSource = petList;//obtenemos los datos de la fuente
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SavePet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                petList = repositorio.GetByValue(this.view.SearchValue);
            }
            else
            {
                petList = repositorio.GetAll();
            }
            petsBindingSource.DataSource = petList;
        }
    }
}
