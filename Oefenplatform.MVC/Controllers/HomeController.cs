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
            if(loggedUserid == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserid}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);

            if (user.SchoolUserCategory.Category == "Admin")
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            else if (user.SchoolUserCategory.Category == "Teacher")
            {
                return RedirectToAction("Index", "Home", new { Area = "Teacher" });

            }
            return View();
        }

        public IActionResult IndexWithoutRedirect()
        {
            return View();
        }

        public ActionResult IndexVue()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
