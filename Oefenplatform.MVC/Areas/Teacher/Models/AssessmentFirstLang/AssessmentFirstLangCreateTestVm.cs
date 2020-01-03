using Microsoft.AspNetCore.Mvc;
using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang
{
    public class AssessmentFirstLangCreateTestVm
    {
        public List<AssessmentFirstLangCreateTestDetailVm> QuestionsToBeAdded { get; set; }
    }
}
