using PruebaSQL.Controlador;
using PruebaSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PruebaSQL
{
    public partial class Form1 : Form
    {
        private int idCliente = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //carga los datos al iniciar el formulario
            ActualizarLista();
        }
        //realiza una conexion trae un listado de datos desde la BD
        //luego lo muestra en el Lista de datos -> listBox
        private void ActualizarLista()
        {
            CTRL_Clientes datosBD = new CTRL_Clientes();
            List<MOD_Clientes> listaBD = new List<MOD_Clientes>();
            listaBD = datosBD.MostrarDatos();
            listDatos.Items.Clear();
            MOD_Clientes listaDeCliente = new MOD_Clientes();
            for (int i = 0; i < listaBD.Count; i++)
            {
                listaDeCliente = listaBD[i];
                listDatos.Items.Add(listaDeCliente);
            }
        }
        //limpia los datos del formulario
        private void limpiarListado()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txttarjetaCredito.Text = "";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();//cierra el programa
        }
        //realiza el guardado de los datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MOD_Clientes listaClientes = new MOD_Clientes();//crea una clase
            listaClientes.Nombre = txtNombre.Text;//extrae los datos de los textBox
            listaClientes.Apellido = txtApellido.Text;
            listaClientes.Telefono = txtTelefono.Text;
            listaClientes.Tarjeta = txttarjetaCredito.Text;
            if (idCliente != 0)//verifica si es para guardar o para actualizar
            {
                //si se actualiza entonces tiene Id anterior caso contrario es 0
                listaClientes.Id = Convert.ToInt32(idCliente);
            }
            CTRL_Clientes datosBD = new CTRL_Clientes();
            datosBD.GuardarLista(listaClientes);//envia las clase lista
            ActualizarLista();//actualiza la vista de datos
            limpiarListado();//limpia el formulario
            idCliente = 0;//coloca nuevamente idcliente a 0 para insertar nuevo registro.
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //extrae los datos del dataList y los lleva a los campos del los textBox y otros
            //para si ser modificados para luego ser guardados con el boton guardar
            MOD_Clientes listaClientes = new MOD_Clientes();
            listaClientes = (MOD_Clientes)listDatos.SelectedItem;
            idCliente = listaClientes.Id;
            txtNombre.Text = listaClientes.Nombre;
            txtApellido.Text = listaClientes.Apellido;
            txtTelefono.Text = listaClientes.Telefono;
            txttarjetaCredito.Text = listaClientes.Tarjeta;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //extrae el Id del registro actual seleccionado del dataList para luego
            //enviarlo para eliminar el registro
            MOD_Clientes listaClientes = new MOD_Clientes();
            listaClientes = (MOD_Clientes)listDatos.SelectedItem;
            CTRL_Clientes datosBD = new CTRL_Clientes();
            datosBD.eliminarDatos(listaClientes);
            ActualizarLista();
        }
    }
}
