using Oefenplatform.Lib.DTO.QuestionDto;
using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Admin.Models.LangFirstQuestions
{
    public class LangFirstQuestionsIndexVm
    {
        public IEnumerable<LangFirstGradeQuestionDto> Questions { get; set; }
    }
}
