using Dapper;
using Model.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public Guid UIDPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroTelefono { get; set; }
        public bool Sexo { get; set; }
        public Guid UIDTipoPersonaRef { get; set; }
    }
}
