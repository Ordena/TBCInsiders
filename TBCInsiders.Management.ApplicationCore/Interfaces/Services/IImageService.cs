using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Interfaces.Services
{
    public interface IImageService
    {
        public string UploadImage(IFormFile image);
        public Image ReadImageAsBytes(IFormFile image);
    }
}
