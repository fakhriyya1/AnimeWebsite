using AnimeEntity.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.Entities
{
    public class Image:EntityBase
    {
        public Image()
        {

        }

        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }

        //Relations
        public Anime? Anime { get; set; }
        public Blog? Blog { get; set; }
    }
}
