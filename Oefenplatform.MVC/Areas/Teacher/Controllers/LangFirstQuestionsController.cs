using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Areas.Teacher.Models.LangFirstQuestions;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Constants;
using Oefenplatform.WebAPI.Controllers;
using Oefenplatform.WebAPI.Data;

namespace Oefenplatform.MVC.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class LangFirstQuestionsController : Controller
    {
        
        string baseUri = "https://localhost:5001/api";

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/Question/LangFirstGradeQuestions";

            var allFirstLangQuestions = WebApiService.GetApiResult<List<LangFirstGradeQuestionDto>>(fullLink);

            var viewModel = new LangFirstQuestionsIndexVm()
            {
                Questions = allFirstLangQuestions
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Mode = "Edit";
            return View("Detail");
        }

        [HttpPost]
        public async Task<IActionResult> Save(LangFirstQuestionDetailVm viewModel)
        {
            if (viewModel.Id != 0)
            {

            }
            else
            {
                var categoryLink = $"{baseUri}/QuestionCategory/{2}";
                var category = WebApiService.GetApiResult<QuestionCategory>(categoryLink);

                var answerLink = $"{baseUri}/Answer";
                var answer = new Answer()
                {
                    LangAnswer = viewModel.Answer
                };
                var seededAnswer = await WebApiService.PostCallApi<Answer, Answer>(answerLink, answer);

                var questionLink = $"{baseUri}/Question";
                var question = new Question()
                {
                    QuestionTitle = viewModel.QuestionTitle,
                    FileName = viewModel.FileName,
                    Answer = seededAnswer,
                    QuestionCategory = category
                };
                var seededQuestion = await WebApiService.PostCallApi<Question, Question>(questionLink, question);

                var feedbackLink = $"{baseUri}/Feedback";
                var firstFeedback = new Feedback()
                {
                    Description = viewModel.FirstFeedback,
                    Question = question
                };
                await WebApiService.PostCallApi<Feedback, Feedback>(feedbackLink, firstFeedback);

                var secondFeedback = new Feedback()
                {
                    Description = viewModel.SecondFeedback,
                    Question = question
                };
                await WebApiService.PostCallApi<Feedback, Feedback>(feedbackLink, secondFeedback);

                return RedirectToAction(nameof(Index));

                //List<Feedback> testList = new List<Feedback>();
                //testList.Add(new Feedback() { Description = viewModel.FirstFeedback });
                //testList.Add(new Feedback() { Description = viewModel.SecondFeedback });
                //var dto = new LangFirstGradeQuestionDto() 
                //{
                //    QuestionTitle = viewModel.QuestionTitle,
                //    FileName = viewModel.FileName,
                //    Answer = viewModel.Answer,
                //    Feedback = testList,

                //};
                ////return null;
                ////throw new NotImplementedException();
                //await WebApiService.PostCallApi<Question, Question>(fullLink, dto);
            }
            return null;
        }
    }
}