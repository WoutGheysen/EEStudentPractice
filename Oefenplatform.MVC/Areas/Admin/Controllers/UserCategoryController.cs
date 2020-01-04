using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
using Oefenplatform.MVC.Services;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserCategoryController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/SchoolUserCategory";

            var schoolUserCategories = WebApiService.GetApiResult<ICollection<SchoolUserCategory>>(fullLink);

            SchoolUserCategoryViewModel schoolUserCategoryViewModel = new SchoolUserCategoryViewModel
            {
                schoolUserCategories = schoolUserCategories
            };

            return View(schoolUserCategoryViewModel);
        }

        public IActionResult Details(int id)
        {
            string fullLink = $"{baseUri}/SchoolUserCategory/{id}";
            string userLink = $"{baseUri}/SchoolUser";
            var userCategory = WebApiService.GetApiResult<SchoolUserCategory>(fullLink);
            var users = WebApiService.GetApiResult<List<SchoolUser>>(userLink);

            SchoolUserCategoryDetailViewModel detailVm = new SchoolUserCategoryDetailViewModel
            {
                Id = userCategory.Id,
                Category = userCategory.Category,
                SchoolUsers = users

            };

            return View(detailVm);
        }

        public IActionResult Add()
        {
            SchoolUserCategoryDetailViewModel schoolUserCategoryDetailViewModel = new SchoolUserCategoryDetailViewModel
            {
                
            };

            return View(schoolUserCategoryDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SchoolUserCategoryDetailViewModel schoolUserCategoryDetailViewModel)
        {
            string fullLink = $"{baseUri}/SchoolUserCategory";

            SchoolUserCategory schoolUserCategory = new SchoolUserCategory
            {
                Category = schoolUserCategoryDetailViewModel.Category
            };

            await WebApiService.PostCallApi<SchoolUserCategory, SchoolUserCategory>(fullLink, schoolUserCategory);

            return RedirectToAction("Index", "UserCategory");
        }

        public IActionResult Edit(int id)
        {
            string fullLink = $"{baseUri}/SchoolUserCategory";

            string schoolUserCategoryById = fullLink + "/" + id;
            SchoolUserCategory schoolUserCategory = WebApiService.GetApiResult<SchoolUserCategory>(schoolUserCategoryById);

            SchoolUserCategoryDetailViewModel schoolUserCategoryDetailViewModel = new SchoolUserCategoryDetailViewModel
            {
                Category = schoolUserCategory.Category
            };

            return View(schoolUserCategoryDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolUserCategoryDetailViewModel schoolUserCategoryDetailViewModel)
        {
            string fullLink = $"{baseUri}/SchoolUserCategory";

            string schoolUserCategoryById = fullLink + "/" + schoolUserCategoryDetailViewModel.Id;
            SchoolUserCategory schoolUserCategory = WebApiService.GetApiResult<SchoolUserCategory>(schoolUserCategoryById);

            schoolUserCategory.Category = schoolUserCategoryDetailViewModel.Category;

            string updateLink = $"{baseUri}/SchoolUserCategory/{schoolUserCategory.Id}";
            await WebApiService.PutCallApi<SchoolUserCategory, SchoolUserCategory>(updateLink, schoolUserCategory);

            return RedirectToAction("Index", "UserCategory");
        }

        public async Task<IActionResult> Delete(int id)
        {
            string fullLink = $"{baseUri}/SchoolUserCategory";

            string schoolUserCategoryById = fullLink + "/" + id;
            await WebApiService.DeleteCallApi<SchoolUserCategory>(schoolUserCategoryById);

            return RedirectToAction("Index", "UserCategory");
        }
    }
}