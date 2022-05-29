using Prueba02.Models;
using System;
using System.Windows.Forms;

namespace Prueba02
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private bool Editar = false;
        private string idProducto = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void MostrarProductos()
        {
            CN_Productos objetoCN1 = new CN_Productos();
            dataGridView1.DataSource = objetoCN1.MostrarProd();
        }
        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescipcion.Text = "";
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(txtNombre.Text, txtDescipcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MostrarProductos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo insertar los datos" + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtDescipcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MostrarProductos();
                    Editar = false;
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo insertar los datos" + ex);
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescipcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.eliminarProd(idProducto);
                MessageBox.Show("Eliminado Correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
