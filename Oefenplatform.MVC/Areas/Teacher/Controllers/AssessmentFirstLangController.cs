using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Constants;

namespace Oefenplatform.MVC.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class AssessmentFirstLangController : Controller
    {
        string baseUri = "https://localhost:5001/api";
        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/Assessment/";
            var allLangAssessments = WebApiService.GetApiResult<List<Assessment>>(fullLink);

            var viewModel = new AssessmentFirstLangIndexVm() 
            { 
                SelectedAssessments = allLangAssessments
            };


            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            string fullLink = $"{baseUri}/Assessment/{id}";
            var langAssessment = WebApiService.GetApiResult<Assessment>(fullLink);

            var viewModel = new AssessmentFirstLangDetailVm() 
            { 
                Id = langAssessment.Id,
                AssessmentTitle = langAssessment.AssessmentTitle,
                RelatedAssessments = langAssessment.AssessmentDetails
            };

            return View(viewModel);
        }

        public IActionResult CreateTest()
        {
            string fullLink = $"{baseUri}/Question/";

            var allLangQuestions = WebApiService.GetApiResult<List<Question>>(fullLink);
            var specificList = allLangQuestions
                .Where(c => c.QuestionCategory.CategoryQuestion == QuestionCategories.LangQuestionFirstGrade)
                .ToList();
            var detailList = new List<AssessmentFirstLangCreateTestDetailVm>();
            foreach (var item in specificList)
            {
                var detailModel = new AssessmentFirstLangCreateTestDetailVm()
                {
                    QuestionToAdd = item,
                    QuestionId = item.Id
                };

                detailList.Add(detailModel);
            }
            

            return View(detailList);
        }

        public IActionResult Create()
        {
            ViewBag.Mode = "Create";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(List<AssessmentFirstLangCreateTestDetailVm> vm)
        {
            var questionsToAdd = new List<Question>();
            string fullLink = $"{baseUri}/Assessment/{2}";
            var langAssessment = WebApiService.GetApiResult<Assessment>(fullLink);
            try
            {
                foreach (var question in vm)
                {
                    if (question.IsToBeAdded)
                    {
                        var questionToAdd =  WebApiService.GetApiResult<Question>($"{baseUri}/Question/{question.QuestionId}");
                        questionsToAdd.Add(questionToAdd);
                    }
                }

                var assessment = new AssessmentDetail()
                {
                    AssessmentTitle = $"{langAssessment.AssessmentTitle}, {DateTime.Now.Date}",
                    Questions = questionsToAdd,
                    AssessmentId = 2,
                    Assessment = langAssessment
                };
                await WebApiService.PostCallApi<AssessmentDetail, AssessmentDetail>($"{baseUri}/assessmentdetail", assessment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(Index));


        }
    }
}