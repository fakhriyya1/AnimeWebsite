using AnimeEntity.Entities;
using Microsoft.AspNetCore.Http;

namespace AnimeEntity.DTOs.Blogs
{
    public class AddBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public IFormFile Photo { get; set; }

        public List<int> SelectedCategories { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
