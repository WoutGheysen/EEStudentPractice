using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Controllers;
using Oefenplatform.MVC.Models.Shared;
using Oefenplatform.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        string baseUri = "https://localhost:5001/api";

        private readonly UserManager<IdentityUser> _user;
        public NavbarViewComponent(UserManager<IdentityUser> user)
        {
            _user = user;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string fullLink = $"{baseUri}/SchoolUser";
            var userIdentity = User as ClaimsPrincipal;

            string loggedUserId = _user.GetUserId(userIdentity);

            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserId}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);
            ViewBag.Mode = user.SchoolUserCategory.Category;
            if(user.SchoolUserCategory.Category == "Admin")
            {
                var viewModel = new NavbarVm()
                {
                    Action = "Index",
                    Controller = "Home",
                    Area = "Admin"
                };
                return await Task.FromResult<IViewComponentResult>(View(viewModel));
            }
            if(user.SchoolUserCategory.Category == "Teacher")
            {
                var viewModel = new NavbarVm()
                {
                    Action = "Index",
                    Controller = "Home",
                    Area = "Teacher"
                };
                return await Task.FromResult<IViewComponentResult>(View(viewModel));
            }
            if(user.SchoolUserCategory.Category == "Student")
            {
                var viewModel = new NavbarVm()
                {
                    Action = "Index",
                    Controller = "Home"
                };
                return await Task.FromResult<IViewComponentResult>(View(viewModel));
            }
            else
            {
                var viewModel = new NavbarVm()
                {
                    Action = "Index",
                    Controller = "Home"
                };
                return await Task.FromResult<IViewComponentResult>(View(viewModel));
            }
        }
    }
}
