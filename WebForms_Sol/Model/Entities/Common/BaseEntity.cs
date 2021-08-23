using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Uid { get; set; }
    }

    public interface IBaseEntity : IBaseEntity<Guid>
    {

    }

    public interface IBaseEntity<TKey>
    {
        TKey Uid { get; set; }
    }
}
