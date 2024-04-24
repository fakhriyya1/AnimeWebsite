using AnimeBusiness.Helpers.Images;
using AnimeBusiness.Services.Abstract;
using AnimeDAL.UnitOfWorks;
using AnimeEntity.DTOs.Blogs;
using AnimeEntity.Entities;
using AnimeEntity.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Services.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IMapper mapper;

        public BlogService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.imageHelper = imageHelper;
            this.mapper = mapper;
        }

        public async Task CreateBlogAsync(AddBlogDto addBlogDto)
        {
            var imageUpload = await imageHelper.Upload(addBlogDto.Title, addBlogDto.Photo, ImageType.Blog);
            Image image = new Image(imageUpload.FullName, addBlogDto.Photo.ContentType);

            await unitOfWork.GetRepository<Image>().AddAsync(image);

            Blog blog = new Blog(addBlogDto.Title, addBlogDto.Content, image.Id, addBlogDto.SelectedCategories.Select(catId=>new BlogCategory { CategoryId=catId}).ToList());
            await unitOfWork.GetRepository<Blog>().AddAsync(blog);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllNonDeletedBlogsWithCategories()
        {
            var blogs = await unitOfWork.GetRepository<Blog>().GetAllAsyncIQueryable(b=>!b.IsDeleted).Include(bc => bc.Categories.Where(c=>!c.Category.IsDeleted)).ThenInclude(c => c.Category).ToListAsync();

            return blogs;
        }

        public async Task<Blog?> GetBlog(Guid blogId)
        {
            var blog=await unitOfWork.GetRepository<Blog>().GetEntityAsync(b=>b.Id==blogId&&!b.IsDeleted, b=>b.Image, blog=>blog.Categories);

            if (blog == null)
                return null;

            return blog;
        }

        
        public async Task<UpdateBlogDto?> UpdateBlogAsync(UpdateBlogDto updateBlogDto)
        {
            var blog = await GetBlog(updateBlogDto.Id);

            if (blog == null)
                return null;

            if (updateBlogDto.Photo != null)
            {
                imageHelper.Delete(blog.Image.FileName);

                var imageUpload = await imageHelper.Upload(updateBlogDto.Title, updateBlogDto.Photo, ImageType.Blog);
                Image image = new Image(imageUpload.FullName, updateBlogDto.Photo.ContentType);

                await unitOfWork.GetRepository<Image>().AddAsync(image);
                unitOfWork.GetRepository<Image>().DeleteAsync(blog.Image);

                blog.ImageId = image.Id;
            }

            mapper.Map(updateBlogDto, blog);
            
            blog.Categories = updateBlogDto.SelectedCategories.Select(catId => new BlogCategory { CategoryId = catId }).ToList();

            await unitOfWork.SaveChangesAsync();

            return updateBlogDto;
        }

        public async Task<Blog?> SafeDeleteBlogAsync(Guid blogId)
        {
            var blog=await unitOfWork.GetRepository<Blog>().GetByTIdAsync(blogId);

            if(blog == null) return null;

            blog.IsDeleted= true;
            await unitOfWork.GetRepository<Blog>().UpdateAsync(blog);
            await unitOfWork.SaveChangesAsync();

            return blog;
        }

    }
}
