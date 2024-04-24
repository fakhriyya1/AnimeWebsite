using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class Blog : EntityBase
    {
        public Blog()
        {

        }

        public Blog(string title, string content, Guid imageId, ICollection<BlogCategory> categories)
        {
            Title = title;
            Content = content;
            ImageId = imageId;
            Categories=categories;
        }

        public string Title { get; set; }
        public string Content { get; set; }

        //Relations
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<BlogCategory> Categories { get; set; }
    }
}
