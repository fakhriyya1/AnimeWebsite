using AnimeBusiness.Services.Abstract;
using AnimeDAL.UnitOfWorks;
using AnimeEntity.DTOs.Categories;
using AnimeEntity.Entities;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesNonDeletedAsync()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(c => !c.IsDeleted);

            return categories.ToList();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByTIdAsync(id);

            return category;
        }

        public async Task<Category> CreateCategoryAsync(AddCategoryDto categoryAddDto)
        {
            Category category = new(categoryAddDto.Name);

            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await GetCategoryByIdAsync(updateCategoryDto.Id);

            if (category == null)
                return null;

            mapper.Map(updateCategoryDto, category);

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Exists(Category category)
        {
            var categories= await unitOfWork.GetRepository<Category>().GetAllAsync();

            foreach (var item in categories)
                if (item.Name.Equals(category.Name))
                    return !(item.Id == category.Id);

            return false;
        }

        public async Task<Category?> SafeDeleteCategoryAsync(int id)
        {
            var category=await GetCategoryByIdAsync(id);

            if(category == null) 
                return null;

            category.IsDeleted = true;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveChangesAsync();

            return category;
        }
    }
}
