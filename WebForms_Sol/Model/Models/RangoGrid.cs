using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class RangoGrid
    {
        public Guid UIDTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public int Orden { get; set; }
        public int Rango { get; set; }
    }
}
