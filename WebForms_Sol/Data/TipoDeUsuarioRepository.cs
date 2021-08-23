using Data.Common;
using Data.Connections;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoDeUsuarioRepository : BaseDapperRepository<TipoDeUsuario>
    {
        public TipoDeUsuarioRepository() : base(DbConnections.DbConnection) { }
    }
}
