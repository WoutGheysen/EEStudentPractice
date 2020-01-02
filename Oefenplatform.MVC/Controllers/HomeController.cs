using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Models;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        string baseUri = "https://localhost:5001/api";

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
            string fullLink = $"{baseUri}/SchoolUser";

            string loggedUserid = _user.GetUserId(User);

            string categoryLink = $"{baseUri}/SchoolUserCategory";
            string getCategoryByIdLink = categoryLink + "/" + 1;
            var userCategory = WebApiService.GetApiResult<SchoolUserCategory>(getCategoryByIdLink);

            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserid}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);

            if (user.SchoolUserCategory.Category == userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
