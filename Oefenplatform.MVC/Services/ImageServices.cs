using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Services
{
    public class ImageServices
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ImageServices(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string UploadImage(IFormFile picture, string locationUri)
        {
            string fileLocation = Path.Combine(_hostingEnvironment.WebRootPath, "images/", Path.GetFileName("biesWeideLogo.png"));
            if(picture != null)
            {
                fileLocation = Path.Combine(_hostingEnvironment.WebRootPath, locationUri, Path.GetFileName(picture.FileName)) + Guid.NewGuid().ToString();
                picture.CopyTo(new FileStream(fileLocation, FileMode.Create));
                return fileLocation;
            }
            else
            {
                return fileLocation;
            }
            
        }
    }
}
