using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// podemos crear esta carpeta o bien crear un nuevo proyecto para el Rpositorio

namespace CRUD_Forms_SQLServer_MVP.Repositories
{
    // volvemos publico y abstracto esta clase para que solo se pueda usar atravez de la herencia.
    public abstract class BaseRepository
    {
        protected string connectionString;

    }
}
