using AnimeEntity.DTOs.Blogs;
using AnimeEntity.DTOs.Categories;
using AnimeEntity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.AutoMapper.Blogs
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<AddBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<BlogCategory, Category>().ReverseMap();
        }
    }
}
