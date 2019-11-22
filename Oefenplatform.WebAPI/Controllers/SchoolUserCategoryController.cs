using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolUserCategoryController : ControllerCrudBase<SchoolUserCategory, SchoolUserCategoryRepository>
    {
        public SchoolUserCategoryController(SchoolUserCategoryRepository SchoolUserCategoryRepository) :base(SchoolUserCategoryRepository)
        {

        }
    }
}