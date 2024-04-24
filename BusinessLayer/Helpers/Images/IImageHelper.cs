using AnimeEntity.DTOs.Images;
using AnimeEntity.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness.Helpers.Images
{
    public interface IImageHelper
    {
        Task<UploadedImageDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
        void Delete(string imageName);
    }
}
