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
            string fileName = "biesWeideLogo.png";
            string fileLocation = Path.Combine(_hostingEnvironment.WebRootPath, "images/", Path.GetFileName(fileName));
            if(picture != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.Combine(picture.FileName);
                fileLocation = Path.Combine(_hostingEnvironment.WebRootPath, locationUri, fileName);
                picture.CopyTo(new FileStream(fileLocation, FileMode.Create));
                return fileName;
            }
            else
            {
                return fileName;
            }
            
        }
    }
}
