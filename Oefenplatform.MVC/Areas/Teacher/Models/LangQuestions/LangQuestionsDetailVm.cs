﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oefenplatform.MVC.Areas.Teacher.Models.LangQuestions
{
    public class LangQuestionsDetailVm
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string Description { get; set; }
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public int FirstFeedbackId { get; set; }
        public string FirstFeedback { get; set; }
        public int SecondFeedbackId { get; set; }
        public string SecondFeedback { get; set; }
    }
}
