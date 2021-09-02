using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Implementations {
    public class ImageService : IImageService {


        private readonly IWebHostEnvironment _webHostEnviroment;


        public ImageService(IWebHostEnvironment webHostEnvironment) {
            _webHostEnviroment = webHostEnvironment;
        }


        public async Task<string> SaveImageAsync(IFormFile image) {
            var fileName = Path.GetFileName(image.FileName);
            var filePath = Path.Combine(_webHostEnviroment.WebRootPath, "images", "uploads", fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            return Path.Combine("images", "uploads", fileName);
        }

    }
}
