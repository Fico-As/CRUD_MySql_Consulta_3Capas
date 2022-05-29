using CRUD_MySql_Consulta_3Capas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_MySql_Consulta_3Capas
{
    public partial class Form1 : Form
    {
        CM_Productos objetoCM = new CM_Productos();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CM_Productos objetoCM_1 = new CM_Productos();
            dataGridView1.DataSource = objetoCM_1.MostrarProd();

        }
    }
}
