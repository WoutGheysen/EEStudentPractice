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
            //POSSIBLE ADJUST FOR QUESTIONCATEGORY
            ViewBag.Mode = "Detail";
            var questionLink = $"{baseUri}/Question/{id}";
            var question = WebApiService.GetApiResult<Question>(questionLink);

            var viewModel = new LangQuestionsDetailVm()
            {
                QuestionCategory = question.QuestionCategory.CategoryQuestion,
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

        public IActionResult Update(int id)
        {
            //ADJUST FOR QUESTIONCATEGORY
            ViewBag.Mode = "Edit";
            var questionLink = $"{baseUri}/Question/{id}";
            var question = WebApiService.GetApiResult<Question>(questionLink);

            var viewModel = new LangQuestionsDetailVm()
            {
                Id = question.Id,
                QuestionTitle = question.QuestionTitle,
                Description = question.Description,
                AnswerId = question.Answer.Id,
                Answer = question.Answer.LangAnswer,
                QuestionCategory = question.QuestionCategory.CategoryQuestion,
                QuestionCategoryId = question.QuestionCategory.Id,
                FirstFeedbackId = question.Feedback.OfType<Feedback>().ElementAt(0).Id,
                FirstFeedback = question.Feedback.OfType<Feedback>().ElementAt(0).Description,
                SecondFeedbackId = question.Feedback.OfType<Feedback>().ElementAt(1).Id,
                SecondFeedback = question.Feedback.OfType<Feedback>().ElementAt(1).Description
            };
            return View("Detail", viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Mode = "Create";
            var categoryLink = $"{baseUri}/QuestionCategory";
            var categories = WebApiService.GetApiResult<List<QuestionCategory>>(categoryLink);
            var availableCategories = categories.Where(c => c.CategoryQuestion == QuestionCategories.LangQuestionSecondGrade || c.CategoryQuestion == QuestionCategories.LangQuestionThirdGrade);
            var viewModel = new LangQuestionsDetailVm()
            {
                AvailableCategories = availableCategories
            };
            return View("Detail", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(LangQuestionsDetailVm viewModel)
        {
            //ADJUST BOTH FOR QUESTIONCATEGORY (CAN QUESTIONCATEGORY BE CHANGED?)
            if (viewModel.Id != 0)
            {
                var categoryLink = $"{baseUri}/QuestionCategory/{viewModel.QuestionCategoryId}";
                var category = WebApiService.GetApiResult<QuestionCategory>(categoryLink);

                var answerLink = $"{baseUri}/Answer/{viewModel.AnswerId}";
                var answer = new Answer()
                {
                    Id = viewModel.AnswerId,
                    LangAnswer = viewModel.Answer
                };
                answer = await WebApiService.PutCallApi<Answer, Answer>(answerLink, answer);

                List<Feedback> feedbackList = new List<Feedback>();
                feedbackList.Add(new Feedback() { Id = viewModel.FirstFeedbackId, Description = viewModel.FirstFeedback, QuestionId = viewModel.Id });
                feedbackList.Add(new Feedback() { Id = viewModel.SecondFeedbackId, Description = viewModel.SecondFeedback, QuestionId = viewModel.Id });
                var questionLink = $"{baseUri}/Question/{viewModel.Id}";
                var question = new Question()
                {
                    Id = viewModel.Id,
                    QuestionTitle = viewModel.QuestionTitle,
                    Description = viewModel.Description,
                    AnswerId = answer.Id,
                    Answer = answer,
                    QuestionCategory = category,
                    QuestionCategoryId = category.Id,
                    Feedback = feedbackList
                };
                question = await WebApiService.PutCallApi<Question, Question>(questionLink, question);
                var feedbackLink = $"{baseUri}/Feedback";
                await WebApiService.PutCallApi<Feedback, Feedback>($"{feedbackLink}/{viewModel.FirstFeedbackId}", feedbackList.ElementAt(0));
                await WebApiService.PutCallApi<Feedback, Feedback>($"{feedbackLink}/{viewModel.SecondFeedbackId}", feedbackList.ElementAt(1));
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var categoryLink = $"{baseUri}/QuestionCategory/{viewModel.QuestionCategoryId}";
                var category = WebApiService.GetApiResult<QuestionCategory>(categoryLink);

                var answerLink = $"{baseUri}/Answer";
                var answer = new Answer()
                {
                    LangAnswer = viewModel.Answer
                };

                answer.Id = 0;

                List<Feedback> feedbackList = new List<Feedback>();
                feedbackList.Add(new Feedback() { Description = viewModel.FirstFeedback });
                feedbackList.Add(new Feedback() { Description = viewModel.SecondFeedback });
                var questionLink = $"{baseUri}/Question";
                var question = new Question()
                {
                    QuestionTitle = viewModel.QuestionTitle,
                    Description = viewModel.Description,
                    Answer = answer,
                    QuestionCategory = category,
                    Feedback = feedbackList
                };
                await WebApiService.PostCallApi<Question, Question>(questionLink, question);


                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var questionLink = $"{baseUri}/Question/{id}";
            var deletedQuestion = await WebApiService.DeleteCallApi<Question>(questionLink);

            var answerLink = $"{baseUri}/Answer/{deletedQuestion.AnswerId}";
            var deletedAnswer = await WebApiService.DeleteCallApi<Answer>(answerLink);

            return RedirectToAction(nameof(Index));
        }
    }
}