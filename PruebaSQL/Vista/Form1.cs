using PruebaSQL.Controlador;
using PruebaSQL.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ActualizarLista();
        }

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

        private void limpiarListado()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txttarjetaCredito.Text = "";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MOD_Clientes listaClientes = new MOD_Clientes();
            listaClientes.Nombre = txtNombre.Text;
            listaClientes.Apellido = txtApellido.Text;
            listaClientes.Telefono = txtTelefono.Text;
            listaClientes.Tarjeta = txttarjetaCredito.Text;
            if (idCliente != 0)
            {
                listaClientes.Id = Convert.ToInt32(idCliente);
            }
            CTRL_Clientes datosBD = new CTRL_Clientes();
            datosBD.GuardarLista(listaClientes);
            ActualizarLista();
            limpiarListado();
            idCliente = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
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
            MOD_Clientes listaClientes = new MOD_Clientes();
            listaClientes = (MOD_Clientes)listDatos.SelectedItem;
            CTRL_Clientes datosBD = new CTRL_Clientes();
            datosBD.eliminarDatos(listaClientes);
            ActualizarLista();
        }
    }
}
