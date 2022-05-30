using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Forms_SQLServer_MVP.Vista
{
    //volvemos publico
    public interface IMainView
    {
        event EventHandler ShowPetView;
        event EventHandler ShowOwnreView;
        event EventHandler ShowVetsView;
    }
}
