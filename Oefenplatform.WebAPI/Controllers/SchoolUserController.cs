using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.WebAPI.Repositories;
using Oefenplatform.Lib.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

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
        [HttpGet]
       
        public async Task<IEnumerable<SchoolUser>> GetAll()
        {
            return await _SchoolUserRepository.ListAll();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _SchoolUserRepository.GetById(id));
        }

        [HttpGet]
        [Route("IdRef/{id}")]
        public async Task<IActionResult> GetByIdentityReference(string id)
        {
            return Ok(await _SchoolUserRepository.GetByIdentityReference(id));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SchoolUser deletedEntity = await _SchoolUserRepository.Delete(id);
            if (deletedEntity == null)
            {
                return NotFound();
            }
            return Ok(deletedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SchoolUser entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != entity.Id)
            {
                return BadRequest();
            }

            SchoolUser updatedEntity = await _SchoolUserRepository.Update(entity);
            if (updatedEntity == null)
            {
                return NotFound();
            }
            return Ok(updatedEntity);
        }

    }
}