using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class BlogCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
