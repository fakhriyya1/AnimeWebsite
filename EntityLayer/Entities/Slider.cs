using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class Slider : EntityInfo
    {
        //Relations
        public Anime Anime { get; set; }
        public Guid AnimeId { get; set; }
    }
}
