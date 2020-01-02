using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        private readonly UserManager<IdentityUser> _user;
        private readonly SchoolUserRepository _schoolUserRepository;
        private readonly SchoolUserCategoryRepository _schoolUserCategoryRepository;
        private readonly ClassGroupRepository _classGroupRepository;

        public HomeController(
            UserManager<IdentityUser> user, SchoolUserRepository schoolUserRepository,
            SchoolUserCategoryRepository schoolUserCategoryRepository, ClassGroupRepository classGroupRepository)
        {

            _user = user;
            _schoolUserRepository = schoolUserRepository;
            _schoolUserCategoryRepository = schoolUserCategoryRepository;
            _classGroupRepository = classGroupRepository;
        }

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/SchoolUser";

            string loggedUserid = _user.GetUserId(User);

            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserid}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);

            string categoryLink = $"{baseUri}/SchoolUserCategory";
            string getCategoryByIdLink = categoryLink + "/" + 1;
            var userCategory = WebApiService.GetApiResult<SchoolUserCategory>(getCategoryByIdLink);

            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            string classgroupLink = $"{baseUri}/ClassGroup";

            ICollection<ClassGroup> classGroup = WebApiService.GetApiResult<ICollection<ClassGroup>>(classgroupLink);
            ICollection<SchoolUser> schoolUsers = WebApiService.GetApiResult<ICollection<SchoolUser>>(fullLink);

            UserViewModel userViewModel = new UserViewModel
            {
                ClassGroups = classGroup,
                Users = schoolUsers
            };

            return View(userViewModel);
        }
    }
}