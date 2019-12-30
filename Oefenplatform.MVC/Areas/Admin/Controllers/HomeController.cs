using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
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
            string id = _user.GetUserId(User);
            var userCategory = _schoolUserCategoryRepository.GetById(1).Result;
            var user = _schoolUserRepository.GetByIdentityReference(id).Result;
            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            ICollection<ClassGroup> classGroup = _classGroupRepository.GetAll().ToList();
            ICollection<SchoolUser> schoolUsers = _schoolUserRepository.GetAll().ToList();

            UserViewModel userViewModel = new UserViewModel
            {
                ClassGroups = classGroup,
                Users = schoolUsers
            };

            return View(userViewModel);
        }
    }
}