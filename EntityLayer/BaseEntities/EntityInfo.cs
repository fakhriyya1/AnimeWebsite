using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.BaseEntities
{
    public abstract class EntityInfo : IEntityBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
