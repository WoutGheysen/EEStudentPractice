using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Oefenplatform.Lib.Models;
using Oefenplatform.WebAPI.Controllers;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ClassGroupRepository _classGroupRepository;
        private readonly SchoolUserCategoryRepository _schoolUserCategoryRepository;
        private readonly SchoolUserController _schoolUserController;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            SchoolUserController schoolUserController,
            ClassGroupRepository classGroupRepository,
            SchoolUserCategoryRepository schoolUserCategoryRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _schoolUserController = schoolUserController;
            _classGroupRepository = classGroupRepository;
            _schoolUserCategoryRepository = schoolUserCategoryRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            //[Required]
            //[EmailAddress]
            //[Display(Name = "Email")]
            //public string Email { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Classgroup")]
            public ClassGroup ClassGroupName { get; set; }

            [Display(Name = "UserCategory")]
            public SchoolUserCategory SchoolUserCategory { get; set; }
        }

        [BindProperty]
        public int SelectedClassGroupId { get; set; }
        [BindProperty]
        public int SelectedSchoolUserCategoryId { get; set; }
        public SelectList ClassGroupOptions { get; set; }
        public SelectList SchoolUserCategoryOptions { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ClassGroupOptions = new SelectList(_classGroupRepository.GetAll(), nameof(ClassGroup.Id), nameof(ClassGroup.ClassGroupName));
            SchoolUserCategoryOptions = new SelectList(_schoolUserCategoryRepository.GetAll(), nameof(SchoolUserCategory.Id), nameof(SchoolUserCategory.Category));

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            Input.ClassGroupName = await _classGroupRepository.GetById(SelectedClassGroupId);
            Input.SchoolUserCategory = await _schoolUserCategoryRepository.GetById(SelectedSchoolUserCategoryId);

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Name/*, Email = Input.Email */};

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    var schoolUser = new SchoolUser
                    {
                        IdentityReference = user.Id,
                        FirstName = user.UserName,
                        Id = Guid.NewGuid(),
                        LastName = "admin",
                        ClassGroup = Input.ClassGroupName,
                        SchoolUserCategory = Input.SchoolUserCategory
                    };
                    await _schoolUserController.Create(schoolUser);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
