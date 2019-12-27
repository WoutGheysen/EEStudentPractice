using Oefenplatform.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oefenplatform.Lib.DTO.QuestionDto
{
    public class LangFirstGradeQuestionDto
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string FileName { get; set; }
        public string Answer { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public int QuestionCategory { get; set; } = 2;
    }
}
