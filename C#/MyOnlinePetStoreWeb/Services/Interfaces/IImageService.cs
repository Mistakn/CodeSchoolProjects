using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Interfaces {
    public interface IImageService {

        Task<string> SaveImageAsync(IFormFile image);

    }
}
