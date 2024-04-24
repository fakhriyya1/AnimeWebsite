using AnimeEntity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.FluentValidations
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required!");
            RuleFor(x => x.Title)
                .MinimumLength(2)
                .MaximumLength(150).WithMessage("Title must be between 2 and 150 characters!");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required!");
            RuleFor(x => x.Content)
                .MinimumLength(100)
                .MaximumLength(1500).WithMessage("Content must be between 100 and 1500 characters!");
                
        }
    }
}
