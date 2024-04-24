using AnimeEntity.DTOs.Blogs;
using AnimeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Services.Abstract
{
    public interface IBlogService
    {
        Task<Blog?> GetBlog(Guid blogId);
        Task<IEnumerable<Blog>> GetAllNonDeletedBlogsWithCategories();
        Task CreateBlogAsync(AddBlogDto addBlogDto);
        Task<UpdateBlogDto?> UpdateBlogAsync(UpdateBlogDto updateBlogDto);
        Task<Blog?> SafeDeleteBlogAsync(Guid blogId);
    }
}
