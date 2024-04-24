using AnimeDAL.Context;
using AnimeDAL.UnitOfWorks;
using AnimeEntity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.FluentValidations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MinimumLength(2).WithMessage("Category name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Category name must be less than 50 characters.");
                
        }
    }
}
