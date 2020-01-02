using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        private readonly UserManager<IdentityUser> _user;
        private readonly SchoolUserRepository _schoolUserRepository;
        private readonly SchoolUserCategoryRepository _schoolUserCategoryRepository;
        private readonly ClassGroupRepository _classGroupRepository;

        public UserController(
            UserManager<IdentityUser> user, SchoolUserRepository schoolUserRepository,
            SchoolUserCategoryRepository schoolUserCategoryRepository, ClassGroupRepository classGroupRepository)
        {
            _user = user;
            _schoolUserRepository = schoolUserRepository;
            _schoolUserCategoryRepository = schoolUserCategoryRepository;
            _classGroupRepository = classGroupRepository;
        }

        public IActionResult Index(Guid id)
        {
            string fullLink = $"{baseUri}/SchoolUser";

            string loggedUserid = _user.GetUserId(User);

            string categoryLink = $"{baseUri}/SchoolUserCategory";
            string getCategoryByIdLink = categoryLink + "/" + 1;
            var userCategory = WebApiService.GetApiResult<SchoolUserCategory>(getCategoryByIdLink);

            string userByIdentityReference = $"{fullLink}/IdRef/{loggedUserid}";
            var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);

            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            string userById = fullLink + "/" + id;
            var schoolUser = WebApiService.GetApiResult<SchoolUser>(userById);

            UserDetailViewModel userDetailViewModel = new UserDetailViewModel
            {
                Id = schoolUser.Id,
                FirstName = schoolUser.FirstName,
                LastName = schoolUser.LastName,
                ClassGroup = schoolUser.ClassGroup,
                AvatarURL = schoolUser.AvatarURL,
                IdentityReference = schoolUser.IdentityReference,
                SchoolUserCategory = schoolUser.SchoolUserCategory
            };

            return View(userDetailViewModel);
        }

        
        public IActionResult Edit(Guid id)
        {
            string fullLink = $"{baseUri}/SchoolUser";
            string categoryLink = $"{baseUri}/SchoolUserCategory";
            string classgroupLink = $"{baseUri}/ClassGroup";

            string userById = fullLink + "/" + id;
            var schoolUser = WebApiService.GetApiResult<SchoolUser>(userById);

            var classGroups = new SelectList(WebApiService.GetApiResult<ICollection<ClassGroup>>(classgroupLink), nameof(ClassGroup.Id), nameof(ClassGroup.ClassGroupName), schoolUser.ClassGroup.Id.ToString());
            var schoolUserCategories = new SelectList(WebApiService.GetApiResult<ICollection<SchoolUserCategory>>(categoryLink), nameof(SchoolUserCategory.Id), nameof(SchoolUserCategory.Category), schoolUser.SchoolUserCategory.Id.ToString());

            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                Id = schoolUser.Id,
                FirstName = schoolUser.FirstName,
                LastName = schoolUser.LastName,
                ClassGroup = schoolUser.ClassGroup,
                AvatarURL = schoolUser.AvatarURL,
                IdentityReference = schoolUser.IdentityReference,
                SchoolUserCategory = schoolUser.SchoolUserCategory,
                ClassGroupOptions = classGroups,
                SchoolUserCategoryOptions = schoolUserCategories
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel editUserViewModel)
        {
            string fullLink = $"{baseUri}/SchoolUser";
            string categoryLink = $"{baseUri}/SchoolUserCategory";
            string classgroupLink = $"{baseUri}/ClassGroup";

            string userById = fullLink + "/" + editUserViewModel.Id;
            var schoolUser = WebApiService.GetApiResult<SchoolUser>(userById);

            schoolUser.FirstName = editUserViewModel.FirstName;
            schoolUser.LastName = editUserViewModel.LastName;

            string categoryById = categoryLink + "/" + editUserViewModel.SelectedSchoolUserCategoryId;
            string classgroupById = classgroupLink + "/" + editUserViewModel.SelectedClassGroupId;

            var schoolUserCategory = WebApiService.GetApiResult<SchoolUserCategory>(categoryById);
            var classGroup = WebApiService.GetApiResult<ClassGroup>(classgroupById);

            schoolUser.ClassGroup = classGroup;
            schoolUser.SchoolUserCategory = schoolUserCategory;

            await WebApiService.PutCallApi<SchoolUser, SchoolUser>(userById, schoolUser);

            return new RedirectToActionResult("Index", "User", new { id = editUserViewModel.Id });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            string fullLink = $"{baseUri}/SchoolUser";

            string userById = fullLink + "/" + id;
            var schoolUser = WebApiService.GetApiResult<SchoolUser>(userById);

            string identityId = schoolUser.IdentityReference;

            var identityUser = await _user.FindByIdAsync(identityId);
            
            await _user.DeleteAsync(identityUser);
            await WebApiService.DeleteCallApi<SchoolUser>(userById);

            return RedirectToAction("Index", "Home");
        }
    }
}