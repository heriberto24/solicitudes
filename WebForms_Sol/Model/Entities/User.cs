using Dapper;
using Model.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("Usuarios")]
    public class User 
    {
        [Key]
        public Guid UIDUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid UIDPersonaRef { get; set; }
        public Guid UIDTipoUsuarioRef { get; set; }
        public bool Status { get; set; }
    }
}
