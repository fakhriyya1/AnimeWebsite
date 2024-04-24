using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class Anime : EntityBase
    {
        public string Title { get; set; }
        public int ViewCount { get; set; } = 0;

        //Relations
        public AnimeDetail AnimeDetail { get; set; }
        public Slider? Slider { get; set; }
        public Image Image { get; set; }
        public Guid ImageId { get; set; }
        public ICollection<AnimeCategory> Categories { get; set; }
    }
}
