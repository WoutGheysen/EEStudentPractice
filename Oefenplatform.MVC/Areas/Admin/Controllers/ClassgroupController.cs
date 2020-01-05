using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class ClassgroupController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/ClassGroup";

            var classGroups = WebApiService.GetApiResult<ICollection<ClassGroup>>(fullLink);

            ClassGroupViewModel classGroupViewModel = new ClassGroupViewModel
            {
                classGroups = classGroups
            };

            return View(classGroupViewModel);
        }

        public IActionResult Details(int id)
        {
            string classgroupLink = $"{baseUri}/ClassGroup";
            string fullLink = $"{baseUri}/ClassGroup/{id}";
            string userLink = $"{baseUri}/SchoolUser";
            var classGroup = WebApiService.GetApiResult<ClassGroup>(fullLink);
            var users = WebApiService.GetApiResult<List<SchoolUser>>(userLink);

            ClassGroupDetailViewModel detailVm = new ClassGroupDetailViewModel
            {
                Id = classGroup.Id,
                ClassGroupName = classGroup.ClassGroupName,
                YearGrade = classGroup.YearGrade,
                SelectedYearGradeId = classGroup.YearGradeId,
                SchoolUsers = users

            };

            return View(detailVm);
        }

        public IActionResult Add()
        {
            string fullLink = $"{baseUri}/YearGrade";

            var yearGrades = new SelectList(WebApiService.GetApiResult<ICollection<YearGrade>>(fullLink), nameof(YearGrade.Id), nameof(YearGrade.Grade));

            ClassGroupDetailViewModel classGroupDetailViewModel = new ClassGroupDetailViewModel
            {
                YearGradeOptions = yearGrades
            };

            return View(classGroupDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClassGroupDetailViewModel classGroupDetailViewModel)
        {
            string fullLink = $"{baseUri}/ClassGroup";
            string yeargradeLink = $"{baseUri}/YearGrade/{classGroupDetailViewModel.SelectedYearGradeId}";

            YearGrade yearGrade = WebApiService.GetApiResult<YearGrade>(yeargradeLink);

            ClassGroup classGroup = new ClassGroup
            {
                ClassGroupName = classGroupDetailViewModel.ClassGroupName,
                YearGrade = null,
                YearGradeId = yearGrade.Id
            };

            await WebApiService.PostCallApi<ClassGroup, ClassGroup>(fullLink, classGroup);

            return RedirectToAction("Index", "Classgroup");
        }

        public IActionResult Edit(int id)
        {
            string fullLink = $"{baseUri}/ClassGroup";

            string classgroupById = fullLink + "/" + id;
            ClassGroup classGroup = WebApiService.GetApiResult<ClassGroup>(classgroupById);

            string yeargradeLink = $"{baseUri}/YearGrade";
            var yearGrades = new SelectList(WebApiService.GetApiResult<ICollection<YearGrade>>(yeargradeLink), nameof(YearGrade.Id), nameof(YearGrade.Grade), classGroup.YearGrade.Id.ToString());

            ClassGroupDetailViewModel editClassGroupViewModel = new ClassGroupDetailViewModel
            {
                ClassGroupName = classGroup.ClassGroupName,
                SchoolUsers = classGroup.SchoolUsers,
                YearGrade = classGroup.YearGrade,
                YearGradeOptions = yearGrades
            };

            return View(editClassGroupViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClassGroupDetailViewModel editClassGroupViewModel)
        {
            string fullLink = $"{baseUri}/ClassGroup";

            string classgroupById = fullLink + "/" + editClassGroupViewModel.Id;
            ClassGroup classGroup = WebApiService.GetApiResult<ClassGroup>(classgroupById);

            classGroup.ClassGroupName = editClassGroupViewModel.ClassGroupName;

            classGroup.SchoolUsers = editClassGroupViewModel.SchoolUsers;

            string yeargradeLink = $"{baseUri}/YearGrade/{editClassGroupViewModel.SelectedYearGradeId}";
            YearGrade yearGrade = WebApiService.GetApiResult<YearGrade>(yeargradeLink);

            classGroup.YearGrade = yearGrade;
            classGroup.YearGradeId = yearGrade.Id;

            string updateLink = $"{baseUri}/ClassGroup/{classGroup.Id}";
            await WebApiService.PutCallApi<ClassGroup, ClassGroup>(updateLink, classGroup);

            return RedirectToAction("Index", "Classgroup");
        }

        public async Task<IActionResult> Delete(int id)
        {
            string fullLink = $"{baseUri}/ClassGroup";

            string classgroupById = fullLink + "/" + id;
            await WebApiService.DeleteCallApi<ClassGroup>(classgroupById);

            return RedirectToAction("Index", "Classgroup");
        }
    }
}