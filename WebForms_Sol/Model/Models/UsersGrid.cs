using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class UsersGrid
    {
        public Guid UIDUsuario { get; set; }
        public Guid UIDPersonaRef { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
