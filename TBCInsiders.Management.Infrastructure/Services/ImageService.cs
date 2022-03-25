using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Services;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        public ImageService()
        {
            
        }

        public Image ReadImageAsBytes(IFormFile file)
        {
            Image image = null;

            if (file.Length > 0)
            {
                using(var stream = new MemoryStream())
                {
                    image = new Image();
                    file.CopyTo(stream);
                    image.Type = Path.GetExtension(file.FileName);
                    image.Data = stream.ToArray();
                }
            }

            return image;
        }

        public string UploadImage(IFormFile image)
        {
            
            if (image.Length > 0)
            {
                var path = Directory.GetCurrentDirectory() + "\\Images";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyToAsync(stream);
                }
                if(string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }
            return string.Empty;
        }
    }
}
