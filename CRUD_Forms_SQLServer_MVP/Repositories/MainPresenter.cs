using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregamos los repositorios carpetas del proyecto
using CRUD_Forms_SQLServer_MVP.Vista;
using CRUD_Forms_SQLServer_MVP.Modelo;
using CRUD_Forms_SQLServer_MVP.Repositories;
using CRUD_Forms_SQLServer_MVP.Presentacion;


//para crear este archivo clic sobre carpeta presentacion / agregar / clase = MainPresenter
namespace CRUD_Forms_SQLServer_MVP.Repositories
{
    //lo volvemos publico
    public class MainPresenter
    {
        //creamos los campos usando los metodos abstractos
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            //mostrar el eventos de mascotas
            this.mainView.ShowPetView += ShowPetView;
        }
        //generamos el metodo para ShowPetView
        private void ShowPetView(object sender, EventArgs e)
        {
            //implementamos el metodo para mostrar
            IPetView view = new PetView();
            IPetRepositorio repository = new PetRepository(sqlConnectionString);
            new PetPresentador(view, repository);
}

        //creamos los constructores de ambas variables

    }
}
