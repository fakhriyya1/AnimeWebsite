using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class AnimeCategory
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
