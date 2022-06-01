using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//hacemos referencia a todos las carpetas
using CRUD_Forms_SQLServer_MVP.Modelo;
using CRUD_Forms_SQLServer_MVP.Presentacion;
using CRUD_Forms_SQLServer_MVP.Vista;
using CRUD_Forms_SQLServer_MVP.Repositories;

//agreamos una referencia para ello sobre proyecto / agregar referencia / ensamblados buscar = conf -> System.Configuration
using System.Configuration;


namespace CRUD_Forms_SQLServer_MVP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //definimos las de conexion desde las Propieties del proyecto haciendo doble clic sobre este
            //sale una ventana donde insertamos los campos - hacemos clic en la parte derecha donde hay un 
            //menu y seleccionamos configuracion o settings sale una tabla con name/nombre, type/tipo, scope/ambito,value/valor
            //name = SqlConnection (escribimos), tipo= seleccionamos (Connection string / cadena de conexion), Scope= aplicacion
            //hacemos doble clic sobre value => server name= ip , 
            //recortamos esto es App.Config en la cabecera de conexion CRUD_Forms_SQLServer_MVP.Properties.Settings.
            //dejandolo de la siguiente manera <add name="SqlConnection"
            //otra forma es usando App.config con etiquetas de marcado.
            //definimos e instanciamos la vista

            //definimos la cadena de conexion convirtiendolo en string
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            //IPetView view = new PetView();
            //IPetRepositorio repository = new PetRepository(sqlConnectionString);
            //instanciamos el presentador e inyectamos las clases
            //new PetPresentador(view, repository);
            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}
