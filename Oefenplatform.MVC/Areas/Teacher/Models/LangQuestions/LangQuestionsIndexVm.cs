using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.LangQuestions
{
    public class LangQuestionsIndexVm
    {
        public IEnumerable<Question> Questions { get; set; }
    }
}
