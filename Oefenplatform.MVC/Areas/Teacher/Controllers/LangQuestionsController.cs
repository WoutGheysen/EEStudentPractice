using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Teacher.Models.LangQuestions;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Constants;

namespace Oefenplatform.MVC.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LangQuestionsController : Controller
    {
        string baseUri = "https://localhost:5001/api";

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/Question/";

            var allLangQuestions = WebApiService.GetApiResult<List<Question>>(fullLink);
            var specificList = allLangQuestions.Where(c => c.QuestionCategory.CategoryQuestion == QuestionCategories.LangQuestionSecondGrade || c.QuestionCategory.CategoryQuestion == QuestionCategories.LangQuestionThirdGrade);

            var viewModel = new LangQuestionsIndexVm()
            {
                Questions = specificList
            };

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Mode = "Detail";
            var questionLink = $"{baseUri}/Question/{id}";
            var question = WebApiService.GetApiResult<Question>(questionLink);

            var viewModel = new LangQuestionsDetailVm()
            {
                Id = question.Id,
                QuestionTitle = question.QuestionTitle,
                Description = question.Description,
                AnswerId = question.Answer.Id,
                Answer = question.Answer.LangAnswer,
                FirstFeedbackId = question.Feedback.OfType<Feedback>().ElementAt(0).Id,
                FirstFeedback = question.Feedback.OfType<Feedback>().ElementAt(0).Description,
                SecondFeedbackId = question.Feedback.OfType<Feedback>().ElementAt(1).Id,
                SecondFeedback = question.Feedback.OfType<Feedback>().ElementAt(1).Description
            };
            return View("Detail", viewModel);
        }
    }
}