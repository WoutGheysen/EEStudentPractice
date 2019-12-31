using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.MVC.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _user;
        private readonly SchoolUserRepository _schoolUserRepository;
        private readonly SchoolUserCategoryRepository _schoolUserCategoryRepository;

        public HomeController(/*SignInManager<IdentityUser> signInManager, */
            UserManager<IdentityUser> user, SchoolUserRepository schoolUserRepository, 
            SchoolUserCategoryRepository schoolUserCategoryRepository)
        {
            //_signInManager = signInManager;
            _user = user;
            _schoolUserRepository = schoolUserRepository;
            _schoolUserCategoryRepository = schoolUserCategoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult IndexVue()
        {
            return View();
        }

        public IActionResult IsAdmin()
        {
            string id = _user.GetUserId(User);

            var userCategory = _schoolUserCategoryRepository.GetById(1).Result;
            var user = _schoolUserRepository.GetByIdentityReference(id).Result;
            if (user.SchoolUserCategory.Category == userCategory.Category)
            {
                return View();
            }
            return new RedirectToActionResult("Index", "Home", false);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
