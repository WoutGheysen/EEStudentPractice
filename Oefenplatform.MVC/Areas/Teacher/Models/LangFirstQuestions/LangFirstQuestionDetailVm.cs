using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.LangFirstQuestions
{
    public class LangFirstQuestionDetailVm
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; } = "Wat staat er op de Foto?";
        public string FileName { get; set; }
        public string Answer { get; set; }
        public string FirstFeedback { get; set; }
        public string SecondFeedback { get; set; }
    }
}
