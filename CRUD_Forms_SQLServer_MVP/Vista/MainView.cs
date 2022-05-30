using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Forms_SQLServer_MVP.Vista
{
    //implementamos la interfaz principal con IMainView
    //luego clic ayuda implementar interfaz
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            //asociamos y generamos los eventos
            btnPets.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };

        }

        public event EventHandler ShowPetView;
        public event EventHandler ShowOwnreView;
        public event EventHandler ShowVetsView;
    }
}
