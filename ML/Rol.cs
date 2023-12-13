using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {
        public string? Name { get; set; }
        public Guid RoleId { get; set; } // GUID: Tipo de variable única
        public List<object> Roles { get; set; }
    }
}
