using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class AnimeDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Studio { get; set; }
        public string Status { get; set; }
        public DateTime DateAired { get; set; }

        //Relations
        public Anime Anime { get; set; }
        public Guid AnimeId { get; set; }
    }
}
