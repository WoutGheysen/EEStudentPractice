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
            string fullLink = $"{baseUri}/User";

            string loggedUserid = _user.GetUserId(User);

            string getCategoryByIdLink = fullLink + "/" + 1;
            //var userCategory = WebApiService.GetApiResult<SchoolUserCategory>(getCategoryByIdLink);
            var userCategory = _schoolUserCategoryRepository.GetById(1).Result;

            string userByIdentityReference = fullLink + "/" + "GetByIdentityReference" + "/" + loggedUserid;
            //var user = WebApiService.GetApiResult<SchoolUser>(userByIdentityReference);
            var user = _schoolUserRepository.GetByIdentityReference(loggedUserid).Result;

            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            string userById = fullLink + "/" + id;
            SchoolUser schoolUser = _schoolUserRepository.GetById(id).Result;
            //var schoolUser = WebApiService.GetApiResult<SchoolUser>(userById);

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
            SchoolUser schoolUser = _schoolUserRepository.GetById(id).Result;
            var classGroups = new SelectList(_classGroupRepository.GetAll(), nameof(ClassGroup.Id), nameof(ClassGroup.ClassGroupName), schoolUser.ClassGroup.Id.ToString());
            var schoolUserCategories = new SelectList(_schoolUserCategoryRepository.GetAll(), nameof(SchoolUserCategory.Id), nameof(SchoolUserCategory.Category), schoolUser.SchoolUserCategory.Id.ToString());

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
            SchoolUser schoolUser = _schoolUserRepository.GetById(editUserViewModel.Id).Result;
            schoolUser.FirstName = editUserViewModel.FirstName;
            schoolUser.LastName = editUserViewModel.LastName;

            SchoolUserCategory schoolUserCategory = _schoolUserCategoryRepository.GetById(editUserViewModel.SelectedSchoolUserCategoryId).Result;
            ClassGroup classGroup = _classGroupRepository.GetById(editUserViewModel.SelectedClassGroupId).Result;
            schoolUser.ClassGroup = classGroup;
            schoolUser.SchoolUserCategory = schoolUserCategory;

            await _schoolUserRepository.Update(schoolUser);

            return new RedirectToActionResult("Index", "User", new { id = editUserViewModel.Id });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _schoolUserRepository.GetById(id);
            string identityId = user.IdentityReference;

            var identityUser = await _user.FindByIdAsync(identityId);
            
            await _user.DeleteAsync(identityUser);
            await _schoolUserRepository.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}