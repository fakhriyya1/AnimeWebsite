using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class Category: EntityInfo
    {
        public string Name { get; set; }

        public Category()
        {
            
        }

        public Category(string name, string createdBy="admin")
        {
            Name = name;
            CreatedBy = createdBy;
        }

        //Relations
        public ICollection<AnimeCategory> Animes { get; set; }
        public ICollection<BlogCategory> Blogs { get; set; }

    }
}
