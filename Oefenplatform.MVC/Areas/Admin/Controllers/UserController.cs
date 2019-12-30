﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
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
            string loggedUserid = _user.GetUserId(User);
            var userCategory = _schoolUserCategoryRepository.GetById(1).Result;
            var user = _schoolUserRepository.GetByIdentityReference(loggedUserid).Result;
            if (user.SchoolUserCategory.Category != userCategory.Category)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            SchoolUser schoolUser = _schoolUserRepository.GetById(id).Result;

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