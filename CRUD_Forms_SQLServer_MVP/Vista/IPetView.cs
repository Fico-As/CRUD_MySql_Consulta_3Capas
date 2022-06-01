using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//agreamos este fichero clic sobre carpeta Vista / agregar / componente / interfaz= IPetView
namespace CRUD_Forms_SQLServer_MVP.Vista
{
    //lo volvemos publico
    public interface IPetView
    {
        //propiedades de la vista de mascotas
        string PetId { get; set; }
        string PetName { get; set; }
        string PetType { get; set; }
        string PetColour { get; set; }

        //otras propiedades para busqueda edicion resultado satisfactorio 
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSucessful { get; set; }
        string Message { get; set; }

        // eventos para las acciones de los usuarios como un clic
        // eventHandler= representa la metodo que controla un evento, 
        // Representa el método que controlará un evento que no tiene datos de eventos.
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // los metodos
        // BindingSource= encapsula el origen de los datos
        //SetPetListBindingSource = (metodo) Establecer fuente de enlace de lista de mascotas
        void SetPetListBindingSource(BindingSource petList);
        //metodo para mostrar 
        void Show();

    }
}
