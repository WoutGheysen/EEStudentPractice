using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Services;

namespace Oefenplatform.MVC.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        private readonly UserManager<IdentityUser> _user;

        public HomeController(/*SignInManager<IdentityUser> signInManager, */
            UserManager<IdentityUser> user)
        {
            //_signInManager = signInManager;
            _user = user;
        }

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/SchoolUser";

            string loggedUserid = _user.GetUserId(User);

            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserid}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);

            if (user.SchoolUserCategory.Category == "Teacher" || user.SchoolUserCategory.Category == "Admin")
            {
                return View();
            }

            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}