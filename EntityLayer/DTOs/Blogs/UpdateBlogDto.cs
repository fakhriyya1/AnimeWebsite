using AnimeEntity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeEntity.DTOs.Blogs
{
    public class UpdateBlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile? Photo { get; set; }

        public string ImageUrl { get; set; }

        public List<int> SelectedCategories { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
