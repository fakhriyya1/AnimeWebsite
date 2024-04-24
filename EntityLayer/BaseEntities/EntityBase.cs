using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.BaseEntities
{
    public abstract class EntityBase:IEntityBase
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "admin";
        public string? ModifiedBy { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
