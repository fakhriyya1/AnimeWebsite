using AnimeEntity.DTOs.Categories;
using AnimeEntity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.AutoMapper.Categories
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
