using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Admin.Models;
using Oefenplatform.WebAPI.Repositories;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    public class ClassgroupController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        private readonly ClassGroupRepository _classGroupRepository;
        private readonly YearGradeRepository _yearGradeRepository;

        public ClassgroupController(ClassGroupRepository classGroupRepository, YearGradeRepository yearGradeRepository)
        {
            _classGroupRepository = classGroupRepository;
            _yearGradeRepository = yearGradeRepository;
        }

        public IActionResult Index()
        {
            var classGroups = _classGroupRepository.GetAll().ToList();

            ClassGroupViewModel classGroupViewModel = new ClassGroupViewModel
            {
                classGroups = classGroups
            };

            return View(classGroupViewModel);
        }

        public IActionResult Add()
        {
            var yearGrades = new SelectList(_yearGradeRepository.GetAll(), nameof(YearGrade.Id), nameof(YearGrade.Grade));

            ClassGroupDetailViewModel classGroupDetailViewModel = new ClassGroupDetailViewModel
            {
                YearGradeOptions = yearGrades
            };

            return View(classGroupDetailViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClassGroupDetailViewModel classGroupDetailViewModel)
        {
            YearGrade yearGrade = _yearGradeRepository.GetById(classGroupDetailViewModel.SelectedYearGradeId).Result;

            ClassGroup classGroup = new ClassGroup
            {
                ClassGroupName = classGroupDetailViewModel.ClassGroupName,
                YearGrade = yearGrade,
            };

            await _classGroupRepository.Add(classGroup);

            return RedirectToAction("Index", "Classgroup");
        }

        public IActionResult Edit(int id)
        {
            ClassGroup classGroup = _classGroupRepository.GetById(id).Result;

            var yearGrades = new SelectList(_yearGradeRepository.GetAll(), nameof(YearGrade.Id), nameof(YearGrade.Grade), classGroup.YearGrade.Id.ToString());

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
            ClassGroup classGroup = _classGroupRepository.GetById(editClassGroupViewModel.Id).Result;
            classGroup.ClassGroupName = editClassGroupViewModel.ClassGroupName;

            classGroup.SchoolUsers = editClassGroupViewModel.SchoolUsers;

            YearGrade yearGrade = _yearGradeRepository.GetById(editClassGroupViewModel.SelectedYearGradeId).Result;
            classGroup.YearGrade = yearGrade;

            await _classGroupRepository.Update(classGroup);

            return RedirectToAction("Index", "Classgroup");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _classGroupRepository.Delete(id);

            return RedirectToAction("Index", "Classgroup");
        }
    }
}