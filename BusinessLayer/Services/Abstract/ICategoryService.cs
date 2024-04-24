using AnimeEntity.DTOs.Categories;
using AnimeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesNonDeletedAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(AddCategoryDto categoryAddDto);
        Task<Category?> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<Category?> SafeDeleteCategoryAsync(int id);
        Task<bool> Exists(Category category);
    }
}
