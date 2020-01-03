using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.AssessmentFirstLang
{
    public class AssessmentFirstLangCreateTestDetailVm
    {
        public Question QuestionToAdd { get; set; }
        public int QuestionId { get; set; }
        public bool IsToBeAdded { get; set; }
    }
}
