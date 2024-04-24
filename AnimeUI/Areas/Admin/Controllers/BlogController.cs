using AnimeBusiness.Extensions;
using AnimeBusiness.Services.Abstract;
using AnimeEntity.DTOs.Blogs;
using AnimeEntity.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AnimeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Blog> validator;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IMapper mapper, IValidator<Blog> validator)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await blogService.GetAllNonDeletedBlogsWithCategories();

            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();

            return View(new AddBlogDto
            {
                Categories = categories.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogDto addBlogDto)
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            var blog = mapper.Map<Blog>(addBlogDto);
            var result = await validator.ValidateAsync(blog);

            if (addBlogDto.SelectedCategories == null || !addBlogDto.SelectedCategories.Any())
            {
                result.Errors.Add(new ValidationFailure("Categories", "Category cannot be left empty"));
            }
            else
            {
                var selectedCategoryIds = addBlogDto.SelectedCategories;
                var validCategoryIds = categories.Select(c => c.Id).ToList();

                if (selectedCategoryIds.Except(validCategoryIds).Any())
                    result.Errors.Add(new ValidationFailure("Categories", "Invalid category selected!"));
            }

            if (addBlogDto.Photo == null)
                result.Errors.Add(new ValidationFailure("Photo", "Image must be selected!"));

            if (result.IsValid)
            {
                await blogService.CreateBlogAsync(addBlogDto);
                return RedirectToAction("Index", "Blog", new { Area = "Admin" });
            }

            result.AddToModelState(ModelState);

            return View(new AddBlogDto
            {
                Categories = categories.ToList()
            });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid blogId)
        {
            var blog = await blogService.GetBlog(blogId);

            if (blog == null)
                return BadRequest();

            var updateBlogDto = mapper.Map<UpdateBlogDto>(blog);
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();

            List<int> categoryIds = [];

            foreach (var category in blog.Categories)
            {
                categoryIds.Add(category.CategoryId);
            }

            updateBlogDto.SelectedCategories = categoryIds;
            updateBlogDto.Categories = categories.ToList();
            updateBlogDto.ImageUrl = blog.Image.FileName;

            return View(updateBlogDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            var blog = await blogService.GetBlog(updateBlogDto.Id);

            if (blog == null)
                return BadRequest();

            var result = validator.Validate(blog);

            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();

            if (updateBlogDto.SelectedCategories == null || !updateBlogDto.SelectedCategories.Any())
            {
                result.Errors.Add(new ValidationFailure("Categories", "Category cannot be left empty"));
            }
            else
            {
                var selectedCategoryIds = updateBlogDto.SelectedCategories;
                var validCategoryIds = categories.Select(c => c.Id).ToList();

                if (selectedCategoryIds.Except(validCategoryIds).Any())
                    result.Errors.Add(new ValidationFailure("Categories", "Invalid category selected!"));
            }

            if (result.IsValid)
            {
                await blogService.UpdateBlogAsync(updateBlogDto);
                return RedirectToAction("Index", "Blog", new { Area = "Admin" });
            }

            result.AddToModelState(ModelState);

            var map = mapper.Map<UpdateBlogDto>(blog);

            map.Categories = categories.ToList();
            map.SelectedCategories = blog.Categories.Select(catId => catId.CategoryId).ToList();
            map.ImageUrl = updateBlogDto.ImageUrl;

            return View(map);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid blogId)
        {
            var blog = await blogService.SafeDeleteBlogAsync(blogId);

            if (blog == null)
                return BadRequest();

            return RedirectToAction("Index", "Blog", new { Area = "Admin" });
        }
    }
}
