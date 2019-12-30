using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _user;
        private readonly SchoolUserRepository _schoolUserRepository;
        private readonly SchoolUserCategoryRepository _schoolUserCategoryRepository;

        public HomeController(
            UserManager<IdentityUser> user, SchoolUserRepository schoolUserRepository,
            SchoolUserCategoryRepository schoolUserCategoryRepository)
        {

            _user = user;
            _schoolUserRepository = schoolUserRepository;
            _schoolUserCategoryRepository = schoolUserCategoryRepository;
        }

        public IActionResult Index()
        {
            string id = _user.GetUserId(User);
            var userCategory = _schoolUserCategoryRepository.GetById(1).Result;
            var user = _schoolUserRepository.GetByIdentityReference(id).Result;
            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
            return View();
        }
    }
}