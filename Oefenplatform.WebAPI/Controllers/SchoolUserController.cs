using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.WebAPI.Repositories;
using Oefenplatform.Lib.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Oefenplatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolUserController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        protected readonly SchoolUserRepository _SchoolUserRepository;
        public SchoolUserController(SchoolUserRepository SchoolUserRepository, IHostingEnvironment hostingEnvironment)
        {
            _SchoolUserRepository = SchoolUserRepository;
            _hostingEnvironment = hostingEnvironment;
            
        }
        
        // GET: api/Authors/Basic
        [HttpGet]
       
        public async Task<IEnumerable<SchoolUser>> GetAll()
        {
            return await _SchoolUserRepository.ListAll();
        }

        [HttpPost]
        [Route("Image")]
        public async Task<IActionResult> Image(IFormFile formFile)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images/Avatars", formFile.FileName);

            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            return Ok(new { count = 1, formFile.Length });

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(SchoolUser user)
        {
            await _SchoolUserRepository.Add(user);
            return Ok();
            
        }

    }
}