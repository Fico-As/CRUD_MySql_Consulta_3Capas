using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// para crear este formulario clic derecho sobre carpeta Vista / agregar / formulario (windows forms) = PetView

namespace CRUD_Forms_SQLServer_MVP.Vista
{
    public partial class PetView : Form, IPetView
    {
        //campos creados para este fichero
        private string message;
        private bool isSucessful;
        private bool isEdit;

        //constructores
        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            //vamos a ocultar la segunda pestana por que solo sale cuando hay datos a modificar o borrar
            tabControl1.TabPages.Remove(tabPageDetalle);
        }

        //metodo = Asociar y aumentar ver eventos
        private void AssociateAndRaiseViewEvents()
        {
            //asociamos al evento clic del mouse
            //metodo de controlador de eventos o usando las expresiones lamdas usando un delegado
            /* usamos las expresiónes lambda = que es una función anónima que puede usar para crear delegados o 
             * tipos de árbol de expresiones. Al utilizar expresiones lambda, puede escribir 
             * funciones locales que pueden pasarse como argumentos o devolverse como el valor 
             * de las llamadas a funciones.*/
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            /* delegate c#= Un delegado es una forma de puntero de función de tipo seguro utilizado por Common Language Infrastructure 
             * (CLI). Los delegados especifican un método para llamar y, opcionalmente, un objeto para llamar al método.
             * KeyCode= es una propiedad de KeyEventArgs y proporciona datos para los eventos y. Tiene el tipo , 
             * que es un KeyDownKeyUpKeysenum
             */
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    //Invoke(Delegate)= Ejecuta el delegado especificado en el subproceso que posee el
                    //controlador de ventana subyacente del panel de acciones
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string PetId { get { return txtId.Text; } set { txtId.Text = value; } }
        public string PetName { get { return txtNombre.Text; } set { txtNombre.Text = value; } }
        public string PetType { get { return txtTipo.Text; } set { txtTipo.Text = value; } }
        public string PetColour { get { return txtColor.Text; } set { txtColor.Text = value; } }
        public string SearchValue { 
            get { return txtSearch.Text; } 
            set { txtSearch.Text = value; } 
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        //generamos los campos isSucessFul distinto a IsSucessful de la interfaz este se crea como campo al principo del archivo
        public bool IsSucessful { 
            get { return isSucessful; } 
            set { isSucessful = value; } 
        }
        public string Message { 
            get { return message; } 
            set { message = value; } 
        }//generamos el campo messagen en  IPetView

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPetListBindingSource(BindingSource petList)
        {
            //enlazamos el datagrid a la lista de mascotas
            dataGridView1.DataSource = petList;
        }

        public void show()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
