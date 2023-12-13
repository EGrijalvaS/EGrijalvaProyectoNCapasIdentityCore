using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UserIdentity
    {
        public string IdUsuario { get; set; }
        public string UserName { get; set; }    

        // Propiedad de navegación para Rol
        public ML.Rol Rol { get; set; }
        public List<object> IdentityUsers { get; set; } // Lista de Identity Usuarios
    }
}
