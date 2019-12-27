using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.MVC.Areas.Admin.Models.LangFirstQuestions;
using Oefenplatform.MVC.Services;
using Oefenplatform.WebAPI.Constants;
using Oefenplatform.WebAPI.Controllers;
using Oefenplatform.WebAPI.Data;

namespace Oefenplatform.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LangFirstQuestionsController : Controller
    {
        
        string baseUri = "https://localhost:5001/api/question";

        public IActionResult Index()
        {
            string fullLink = $"{baseUri}/LangFirstGradeQuestions";

            var allFirstLangQuestions = WebApiService.GetApiResult<List<LangFirstGradeQuestionDto>>(fullLink);

            var viewModel = new LangFirstQuestionsIndexVm()
            {
                Questions = allFirstLangQuestions
            };

            return View(viewModel);
        }
    }
}