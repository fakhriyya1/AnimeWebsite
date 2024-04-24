using AnimeBusiness.FluentValidations;
using AnimeBusiness.Helpers.Images;
using AnimeBusiness.Services.Abstract;
using AnimeBusiness.Services.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Extensions
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection LoadBusinessLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddAutoMapper(assembly);

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CategoryValidator>();

            services.Configure<MvcOptions>(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        
            });

            return services;
        }
    }
}
