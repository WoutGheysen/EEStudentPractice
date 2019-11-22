using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using Oefenplatform.MVC.Services;

namespace Oefenplatform.MVC.Controllers
{
    public class QuestionController : Controller
    {

        string baseUri = "https://localhost:5001/api/question";

        public IActionResult Index()
        {
            string questionUri = $"{baseUri}";

            return View(WebApiService.GetApiResult<List<Question>>(questionUri));
        }
    }
}