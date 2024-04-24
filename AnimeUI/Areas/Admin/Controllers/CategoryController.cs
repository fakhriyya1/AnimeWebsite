using AnimeBusiness.Extensions;
using AnimeBusiness.Services.Abstract;
using AnimeEntity.DTOs.Categories;
using AnimeEntity.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AnimeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto addCategoryDto)
        {
            var category = mapper.Map<Category>(addCategoryDto);
            var result = await validator.ValidateAsync(category);
            var exists = await categoryService.Exists(category);

            if (exists)
                result.Errors.Add(new ValidationFailure("Name", "This category name already exists"));

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(addCategoryDto);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);

            return View(addCategoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var category = await categoryService.GetCategoryByIdAsync(categoryId);

            if (category == null)
                return NotFound();

            var updateCategoryDto = mapper.Map<UpdateCategoryDto>(category);

            return View(updateCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = mapper.Map<Category>(updateCategoryDto);
            var result = await validator.ValidateAsync(category);
            var exists = await categoryService.Exists(category);

            if (exists)
                result.Errors.Add(new ValidationFailure("Name", "This category name already exists"));

            if (result.IsValid)
            {
                await categoryService.UpdateCategoryAsync(updateCategoryDto);

                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(ModelState);

            return View(updateCategoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound();

            await categoryService.SafeDeleteCategoryAsync(id);

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

    }
}
